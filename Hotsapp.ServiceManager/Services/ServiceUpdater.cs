using Hotsapp.Data.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotsapp.Data.Model;
using Microsoft.Extensions.Hosting;
using System.Threading;
using System.IO;
using Serilog.Context;
using Microsoft.Extensions.Logging;

namespace Hotsapp.ServiceManager.Services
{
    public class ServiceUpdater : IHostedService, IDisposable
    {
        PhoneService _phoneService;
        NumberManager _numberManager;
        private Timer _timer;
        private bool updateRunning = false;
        private DateTime? lastLoginAttempt = null;
        private bool isOnline = false;
        private int offlineCount = 0;
        private IHostingEnvironment _hostingEnvironment;
        private ILogger<ServiceUpdater> _log;

        public ServiceUpdater(PhoneService phoneService, NumberManager numberManager, IHostingEnvironment hostingEnvironment, ILogger<ServiceUpdater> log)
        {
            _phoneService = phoneService;
            _numberManager = numberManager;
            _hostingEnvironment = hostingEnvironment;
            _log = log;
        }

        public async Task CheckMessagesToSend()
        {
            using (var context = DataFactory.GetContext())
            {
                var message = context.Message.Where(m => m.IsInternal && !m.Processed && m.InternalNumber == _numberManager.currentNumber)
                    .OrderBy(m => m.Id)
                    .FirstOrDefault();
                if(message != null)
                {
                    _log.LogInformation("New message to send!");
                    var success = await _phoneService.SendMessage(message.ExternalNumber, message.Content);
                    message.Processed = true;
                    message.Error = !success;
                    await context.SaveChangesAsync();
                }
            }
        }

        public void SendUpdate(string status)
        {
            using (var context = DataFactory.GetContext())
            {
                var s = context.Phoneservice.First();
                s.LastUpdateUtc = DateTime.UtcNow;
                s.Status = status;
                context.SaveChanges();
            }
        }

        public void OnMessageReceived(object sender, Data.MessageReceived mr)
        {
            using (var context = DataFactory.GetContext())
            {
                var number = context.VirtualNumber.SingleOrDefault(n => n.Number == _numberManager.currentNumber);
                var message = new Message()
                {
                    Content = mr.Message,
                    ExternalNumber = mr.Number,
                    InternalNumber = _numberManager.currentNumber,
                    DateTimeUtc = DateTime.UtcNow,
                    IsInternal = false,
                    UserId = number.OwnerId
                };
                context.Message.Add(message);
                context.SaveChanges();
            }
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Task.Run(Init);
            return Task.CompletedTask;
        }

        public async Task Init()
        {
            _log.LogInformation("Starting ServiceUpdater");
            updateRunning = false;
            while (true)
            {
                _numberManager.TryAllocateNumber().Wait();
                if (_numberManager.currentNumber != null)
                    break;
                _log.LogInformation("Cannot allocate any number, waiting...");
                Task.Delay(3000).Wait();
            }

            LogContext.PushProperty("PhoneNumber", _numberManager.currentNumber);

            _numberManager.LoadData();

            SendUpdate("STARTING");
            UpdateTask(null);
            _phoneService.OnMessageReceived += OnMessageReceived;

            _phoneService.Start().Wait();
            _phoneService.Login().Wait();
            lastLoginAttempt = DateTime.UtcNow;
            if (_hostingEnvironment.IsProduction())
                _phoneService.SetProfilePicture().Wait();
            _phoneService.SetStatus().Wait();

            _timer = new Timer(UpdateTask, null, TimeSpan.Zero,
                TimeSpan.FromMilliseconds(500));
        }

        private void UpdateTask(object state)
        {
            if (updateRunning)
                return;
            updateRunning = true;
            _log.LogInformation("Run Update Check");
            try
            {
                _numberManager.PutCheck().Wait();
                if (_numberManager.ShouldStop().Result)
                {
                    _log.LogInformation("Automatically stopping ServiceUpdater");
                    
                    StopAsync(new CancellationToken()).Wait();
                    Environment.Exit(-1);
                    /*
                    Task.Run(() =>
                    {
                        Task.Delay(3000).Wait();
                        _log.LogInformation("Automatically starting ServiceUpdater");
                        StartAsync(new CancellationToken());
                    });*/

                    return;
                }
                try
                {
                    isOnline = _phoneService.IsOnline().Result;
                    _log.LogInformation("Number is online: {0}", isOnline);
                }
                catch (Exception e)
                {
                    _log.LogError(e, "ServiceUpdater IsOnline Check Error");
                    isOnline = false;
                }
                string status = status = ((bool)isOnline) ? "ONLINE" : "OFFLINE";
                SendUpdate(status);
                if(isOnline)
                    CheckMessagesToSend().Wait();
            }
            catch(Exception e)
            {
                _log.LogError(e, "ServiceUpdater Error");
                isOnline = false;
            }

            if (isOnline)
                offlineCount = 0;
            else
                offlineCount++;

            try
            {
                CheckDisconnection().Wait();
            }
            catch (Exception e)
            {
                _log.LogError(e, "ServiceUpdater CheckDisconnection Error");
            }

            updateRunning = false;
        }

        private async Task CheckDisconnection()
        {
            var minTimeToCheckAgain = DateTime.UtcNow.AddSeconds(-15);
            if (lastLoginAttempt == null || lastLoginAttempt > minTimeToCheckAgain)
                return;

            if (offlineCount > 20)
            {
                _log.LogInformation("OfflineCount exceeded limit, stopping service");
                try
                {
                    _phoneService.Stop();
                }catch(Exception e)
                {
                    _log.LogError(e, "Error stopping service");
                }
                Environment.Exit(-1);
            }

            /*
            if (_phoneService.isDead || (offlineCount >= 5 && offlineCount <= 10))
            {
                _log.LogInformation("[Connection Checker] PhoneService IsDead! Reconnecting.");
                _phoneService.Stop();
                await _phoneService.Start();
                await _phoneService.Login();
                lastLoginAttempt = DateTime.UtcNow;
                offlineCount = 0;
                return;
            }*/

            /*
            if (offlineCount >= 5 && offlineCount <= 10)
            {
                _log.LogInformation("[Connection Checker] PhoneService is offline! Reconnecting.");
                await _phoneService.Login();
                lastLoginAttempt = DateTime.UtcNow;
                return;
            }*/
            
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            _log.LogInformation("Timed Background Service is stopping.");
            _phoneService.Stop();

            _timer?.Change(Timeout.Infinite, 0);

            try
            {
                _numberManager.ReleaseNumber().Wait();
            }catch(Exception e)
            {
                _log.LogError(e, "Error Stopping ServiceUpdater");
            }

            LogContext.PushProperty("PhoneNumber", null);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
