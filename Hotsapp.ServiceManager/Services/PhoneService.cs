using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Hotsapp.ServiceManager.Data;
using Hotsapp.ServiceManager.Util;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Caching.Memory;
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
        private IMemoryCache _cache;
        public PhoneService(ProcessManager processManager, NumberManager numberManager, IConfiguration config, IHostingEnvironment hostingEnvironment,
            ILogger<PhoneService> log, IMemoryCache cache)
        {
            _processManager = processManager;
            _numberManager = numberManager;
            _configuration = config;
            _hostingEnvironment = hostingEnvironment;
            _log = log;
            _cache = cache;
        }

        public async Task Start()
        {
            _log.LogInformation("Starting PhoneService");
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

            var count = 0;
            var limit = 10;
            while (true)
            {
                if (count >= limit)
                    throw new Exception("Failed to start");
                try
                {
                    _log.LogInformation("Waiting to process start");
                    _ = _processManager.SendCommand("");
                    var result = await _processManager.WaitOutput("offline", 5000);
                    break;
                }catch(Exception e)
                {
                    _log.LogInformation(e, "Process not ready yet");
                }
                count++;
            }
            _log.LogInformation("Service Ready");
        }

        public void Stop()
        {
            _processManager.Stop();
        }

        public async Task<string> Login()
        {
            await _processManager.SendCommand("/L");
            var success = _processManager.WaitOutput("Auth: Logged in!", 25000);
            var error = _processManager.WaitOutput("Authentication Failure", 25000);
            var timeout = Task.Delay(24000);
            var result = await Task.WhenAny(success, error, timeout);
            if (result == success)
            {
                _log.LogInformation("Login Success");
                return "success";
            }
            else
            {
                if (result == error){
                    _log.LogInformation("Login error");
                    return "login_error";
                }
                if (result == timeout){
                    _log.LogInformation("Login timeout");
                    return "timeout";
                }
            }
            return "unknown";
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

        public async Task<bool> SendMessage(string rawNumber, string message)
        {
            var isAlternativeNumber = false;
            var number = NumberInfo.ParseNumber(rawNumber);
            if(number == null)
            {
                _log.LogInformation("Invalid number " + rawNumber);
                return false;
            }

            var alternativeNumberCache = CheckAlternativeNumber(rawNumber);
            if(alternativeNumberCache != null)
            {
                number = NumberInfo.ParseNumber(alternativeNumberCache);
                _log.LogInformation("Using alternative number in cache");
            }

            while (true)
            {
                var result = await SendMessageInternal(number.GetFullNumber(), message);
                if (result == "success")
                {
                    if (isAlternativeNumber)
                    {
                        _log.LogInformation("Message sent after trying with alternative number");
                        _cache.Set(rawNumber, number.GetFullNumber());
                    }
                    return true;
                }
                else if (result == "error")
                    return false;

                if(result == "invalid_number")
                {
                    if (!isAlternativeNumber)
                    {
                        isAlternativeNumber = true;
                        _log.LogInformation("Trying alternative number");
                        number = number.GetAlternativeNumber();
                        continue;
                    }
                    else
                    {
                        _log.LogInformation("Failed to send message using alternative number");
                    }
                }
                break;
            }
            return false;
        }

        private async Task<string> SendMessageInternal(string number, string message)
        {
            await _processManager.SendCommand($"/message send {number} \"{message}\"");
            var waitSucess = _processManager.WaitOutput("Sent:", 6000);
            var waitInvalidNumber = _processManager.WaitOutput("is that a valid user", 6000);
            var waitTimeout = Task.Delay(5000);
            var result = await Task.WhenAny(waitSucess, waitInvalidNumber, waitTimeout);
            if (result == waitSucess)
                return "success";
            else if (result == waitInvalidNumber)
                return "invalid_number";
            else
                return "error";
        }

        public async Task<bool> IsOnline()
        {
            var offline = _processManager.WaitOutput("offline");
            var online = _processManager.WaitOutput("connected");
            _ = Task.Run(async () =>
            {
                await Task.Delay(10);//Wait some time to proccess the response handlers
                _ = _processManager.SendCommand("");
                _ = _processManager.SendCommand("");
                _ = _processManager.SendCommand("");
            });
            var timeout = Task.Delay(1000);
            var res = await Task.WhenAny(offline, online, timeout);
            if (res == online)
                return true;
            else
                return false;
        }

        private string CheckAlternativeNumber(string origin)
        {
            string dest = null;
            _cache.TryGetValue(origin, out dest);
            return dest;
        }
    }
}
