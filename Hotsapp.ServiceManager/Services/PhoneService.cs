using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Hotsapp.ServiceManager.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace Hotsapp.ServiceManager.Services
{
    public class PhoneService
    {
        ProcessManager _processManager;
        public event EventHandler<MessageReceived> OnMessageReceived;
        private NumberManager _numberManager;
        private IHostingEnvironment _hostingEnvironment;
        private IConfiguration _configuration;
        public PhoneService(ProcessManager processManager, NumberManager numberManager, IConfiguration config, IHostingEnvironment hostingEnvironment)
        {
            _processManager = processManager;
            _numberManager = numberManager;
            _configuration = config;
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task Start()
        {
            _processManager.OnOutputReceived += Pm_OnOutputReceived;
            _processManager.Start();

            var configPath = _configuration["YowsupConfigPath"] + _numberManager.currentNumber;
            Directory.CreateDirectory(configPath);//Create if not exists

            await _processManager.SendCommand($"script -q -c \"yowsup-cli demos --yowsup -c \"{configPath}\" --config-pushname Hotsapp \" /dev/null");
            
            await _processManager.SendCommand("");
            await _processManager.WaitOutput("offline", 10000);
            Console.WriteLine("READY");
        }

        public void Stop()
        {
            _processManager.Stop();
        }

        public async Task Login()
        {
            await _processManager.SendCommand("/L");
            await _processManager.WaitOutput("Auth: Logged in!");
            Console.WriteLine("LOGIN SUCCESS");
        }

        private void Pm_OnOutputReceived(object sender, string e)
        {
            Console.WriteLine(e);
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

        public async Task SendMessage(string number, string message)
        {
            await _processManager.SendCommand($"/message send {number} \"{message}\"");
            await _processManager.WaitOutput("Sent:");
        }

        public async Task<bool> IsOnline()
        {
            _processManager.SendCommand("");
            _processManager.SendCommand("");
            _processManager.SendCommand("");
            var offline = _processManager.WaitOutput("offline");
            var online = _processManager.WaitOutput("connected");
            var timeout = Task.Delay(1000);
            var res = await Task.WhenAny(offline, online, timeout);
            if (res == online)
                return true;
            else
                return false;
        }
    }
}
