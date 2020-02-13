using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Hotsapp.ServiceManager.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Hotsapp.ServiceManager.Services
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
        private ILogger<PhoneService> _log;
        public PhoneService(ProcessManager processManager, NumberManager numberManager, IConfiguration config, IHostingEnvironment hostingEnvironment, ILogger<PhoneService> log)
        {
            _processManager = processManager;
            _numberManager = numberManager;
            _configuration = config;
            _hostingEnvironment = hostingEnvironment;
            _log = log;
        }

        public async Task Start()
        {
            isDead = false;
            if (!initialized)
            {
                _processManager.OnOutputReceived += Pm_OnOutputReceived;
                initialized = true;
            }
            _processManager.Start();

            var configPath = _configuration["YowsupConfigPath"] + _numberManager.currentNumber;
            Directory.CreateDirectory(configPath);//Create if not exists

            await _processManager.SendCommand($"script -q -c \"yowsup-cli demos --yowsup -c \"{configPath}\" --config-pushname Hotsapp \" /dev/null");
            
            await _processManager.SendCommand("");
            await _processManager.WaitOutput("offline", 10000);
            _log.LogInformation("Service Ready");
        }

        public void Stop()
        {
            _processManager.Stop();
        }

        public async Task Login()
        {
            await _processManager.SendCommand("/L");
            await _processManager.WaitOutput("Auth: Logged in!");
            _log.LogInformation("Login Success");
        }

        public async Task SetProfilePicture()
        {
            _log.LogInformation("Updating profile picture");
            await _processManager.SendCommand("/profile setPicture /app/Assets/profile.jpg");
        }

        public async Task SetStatus()
        {
            _log.LogInformation("Updating custom status message");
            await _processManager.SendCommand($"/profile setStatus \"{_configuration["ProfileStatus"]}\"");
        }

        private void Pm_OnOutputReceived(object sender, string e)
        {
            if (e == null)
                return;
            _log.LogInformation("[Output]: "+e);

            if (e.Contains("Exception in thread Thread"))
                isDead = true;
            //if (e.Contains("InvalidMessage for"))//Its thrown after a long time online
            //    isDead = true;

            var match = Regex.Match(e, "(?<=\t).*");
            if (match.Success)
            {
                var message = match.Value;
                message = message.Substring(1, message.Length - 1);
                var number = Regex.Match(e, "55.+@s.whatsapp").Value.Replace("@s.whatsapp", "");
                _log.LogInformation($"Message Received: [{number}] {match.Value}");
                var mr = new MessageReceived()
                {
                    Number = number,
                    Message = message
                };
                OnMessageReceived.Invoke(this, mr);
            }
        }

        public async Task<bool> SendMessage(string number, string message)
        {
            await _processManager.SendCommand($"/message send {number} \"{message}\"");
            var waitSucess = _processManager.WaitOutput("Sent:", 10000);
            var waitInvalidNumber = _processManager.WaitOutput("is that a valid user", 10000);
            var result = await Task.WhenAny(waitSucess, waitInvalidNumber);
            return result == waitSucess;
        }

        public async Task<bool> IsOnline()
        {
            var offline = _processManager.WaitOutput("offline");
            var online = _processManager.WaitOutput("connected");
            _processManager.SendCommand("");
            _processManager.SendCommand("");
            _processManager.SendCommand("");
            var timeout = Task.Delay(1000);
            var res = await Task.WhenAny(offline, online, timeout);
            //TryDisposeTasks(new Task[] { offline, online, timeout });
            if (res == online)
                return true;
            else
                return false;
        }

        private static void TryDisposeTasks(Task[] tasks)
        {
            var list = new List<Task>(tasks);
            list.ForEach(task =>
            {
                try
                {
                    task.Dispose();
                }catch(Exception e) { }
            });
        }
    }
}
