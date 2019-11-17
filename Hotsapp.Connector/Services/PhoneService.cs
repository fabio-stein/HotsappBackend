using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Hotsapp.Connector.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Hotsapp.Connector.Services
{
    public class PhoneService
    {
        ProcessManager _processManager;
        public event EventHandler<MessageReceived> OnMessageReceived;
        private NumberManager _numberManager;
        private IHostingEnvironment _hostingEnvironment;
        private IConfiguration _configuration;
        public bool isDead { get; private set; } = false;
        private bool initialized = false;
        public PhoneService(ProcessManager processManager, NumberManager numberManager, IConfiguration config, IHostingEnvironment hostingEnvironment)
        {
            _processManager = processManager;
            _numberManager = numberManager;
            _configuration = config;
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task<bool> SendCode()
        {
            isDead = false;
            if (!initialized)
            {
                _processManager.OnOutputReceived += Pm_OnOutputReceived;
                initialized = true;
            }
            _processManager.Start();

            var configPath = _configuration["YowsupConfigPath"] + _numberManager.currentFlow.PhoneNumber;
            Directory.CreateDirectory(configPath);//Create if not exists

            await _processManager.SendCommand($"script -q -c \"yowsup-cli registration --requestcode sms --config-phone {_numberManager.currentFlow.PhoneNumber} --config-cc {_numberManager.currentFlow.CountryCode} \" /dev/null");

            await _processManager.SendCommand("");

            var waitSucess = _processManager.WaitOutput("status: sent", 10000);
            var waitError = _processManager.WaitOutput("status: fail", 10000);
            var result = await Task.WhenAny(waitSucess, waitError);

            //Quando o yowsup gera a configuração, não é possível especificar o path, então copia a configuração do path default após ser gerada
            //para o path configurado
            if (result == waitSucess && _hostingEnvironment.IsDevelopment())
            {
                await Task.Delay(2000);
                await _processManager.SendCommand($"mv ~/.config/yowsup/{_numberManager.currentFlow.PhoneNumber} {configPath}");
            }

            return result == waitSucess;
        }

        public async Task<bool> ConfirmCode()
        {

            var configPath = _configuration["YowsupConfigPath"] + _numberManager.currentFlow.PhoneNumber;
            await _processManager.SendCommand($"script -q -c \"yowsup-cli registration --register {_numberManager.currentFlow.ConfirmCode} -c \"{configPath}\" \" /dev/null");
            var waitSucess = _processManager.WaitOutput("status: ok", 10000);
            var waitError = _processManager.WaitOutput("status: fail", 10000);
            var result = await Task.WhenAny(waitSucess, waitError);
            return result == waitSucess;
        }

        public void Stop()
        {
            _processManager.Stop();
        }

        private void Pm_OnOutputReceived(object sender, string e)
        {
            if (e == null)
                return;
            Console.WriteLine(e);

            if (e.Contains("Exception in thread Thread"))
                isDead = true;

            var match = Regex.Match(e, "(?<=\t).*");
            if (match.Success)
            {
                var message = match.Value;
                message = message.Substring(1, message.Length - 1);
                var number = Regex.Match(e, "55.+@s.whatsapp").Value.Replace("@s.whatsapp", "");
                Console.WriteLine($"Message: [{number}] {match.Value}");
                var mr = new MessageReceived()
                {
                    Number = number,
                    Message = message
                };
                OnMessageReceived.Invoke(this, mr);
            }
        }
    }
}
