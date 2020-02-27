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
        private DateTime? lastUpdate = null;

        public ServiceUpdater(PhoneService phoneService, NumberManager numberManager, IHostingEnvironment hostingEnvironment, ILogger<ServiceUpdater> log)
        {
            _phoneService = phoneService;
            _numberManager = numberManager;
            _hostingEnvironment = hostingEnvironment;
            _log = log;
        }

        bool runningMessageSender = false;
        public async Task CheckMessagesToSend()
        {
            if (runningMessageSender)
                return;
            runningMessageSender = true;

            try
            {
                using (var context = DataFactory.GetContext())
                {
                    var message = context.Message.Where(m => m.IsInternal && !m.Processed && m.InternalNumber == _numberManager.currentNumber)
                        .OrderBy(m => m.Id)
                        .FirstOrDefault();
                    if (message != null)
                    {
                        int maxAttempts = 5;
                        var success = false;
                        for (int i = 1; i <= maxAttempts; i++)
                        {
                            try
                            {
                                _log.LogInformation("Sending new message! Attempt: {0} of {1}", i, maxAttempts);
                                success = await _phoneService.SendMessage(message.ExternalNumber, message.Content);
                                if (!success)
                                    throw new Exception("Cannot send message");
                                break;
                            }
                            catch (Exception e)
                            {
                                _log.LogError(e, "Failed to send message");
                                await Task.Delay(3000);
                            }
                        }
                        message.Processed = true;
                        message.Error = !success;
                        await context.SaveChangesAsync();
                    }
                }
            }catch(Exception e)
            {
                _log.LogError(e, "Error running MessageSender");
            }

            runningMessageSender = false;
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
                await Task.Delay(3000);
                try
                {
                    _log.LogInformation("Trying to allocate number");
                    _numberManager.TryAllocateNumber().Wait();
                    if (_numberManager.currentNumber != null)
                        break;
                }catch(Exception e)
                {
                    _log.LogError(e, "Error allocating number");
                }
                _log.LogInformation("Cannot allocate any number, waiting...");
            }

            LogContext.PushProperty("PhoneNumber", _numberManager.currentNumber);

            _numberManager.LoadData();

            _phoneService.OnMessageReceived += OnMessageReceived;

            try
            {
                _phoneService.Start().Wait();
            }catch(Exception e)
            {
                _log.LogError(e, "Cannot start PhoneService");
                await _numberManager.SetNumberError("startup_error");
                await StopAsync(new CancellationToken());
            }
            var loginResult = await _phoneService.Login();
            if (loginResult != "success")
            {
                if(loginResult != "timeout")
                    await _numberManager.SetNumberError(loginResult);
                await StopAsync(new CancellationToken());
            }

            await _numberManager.ClearNumberError();

            lastLoginAttempt = DateTime.UtcNow;
            if (_hostingEnvironment.IsProduction())
                _phoneService.SetProfilePicture().Wait();
            _phoneService.SetStatus().Wait();

            _timer = new Timer(UpdateTask, null, TimeSpan.Zero,
                TimeSpan.FromMilliseconds(800));

            new Timer(CheckDeadService, null, TimeSpan.Zero,
                TimeSpan.FromMilliseconds(1000));
        }

        private void CheckDeadService(object state)
        {
            if (lastUpdate != null && lastUpdate < DateTime.UtcNow.AddMinutes(-1))
            {
                _log.LogInformation("DeadServiceCherker - Current Service is Dead, Stopping...");
                StopAsync(new CancellationToken()).Wait();
                return;
            }
        }

        private void UpdateTask(object state)
        {
            if (updateRunning)
                return;
            updateRunning = true;
            _log.LogInformation("Run Update Check");
            lastUpdate = DateTime.UtcNow;

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

            try
            {
                _numberManager.PutCheck().Wait();
                if (_numberManager.ShouldStop().Result)
                {
                    _log.LogInformation("Automatically stopping ServiceUpdater");
                    
                    StopAsync(new CancellationToken()).Wait();

                    return;
                }
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
        }

        bool stopping = false;
        public async Task StopAsync(CancellationToken cancellationToken)
        {
            if (stopping)
                await Task.Delay(10000000); //Just to handle all calls and avoid post processing when the app is shutting down
            stopping = true;

            _log.LogInformation("Timed Background Service is stopping.");
            var stopTask = Task.Run(() =>
            {
                try
                {
                    _phoneService.Stop();
                    _timer?.Change(Timeout.Infinite, 0);
                    _numberManager.ReleaseNumber().Wait();
                }
                catch (Exception e)
                {
                    _log.LogError(e, "Error Stopping ServiceUpdater");
                }
            });
            var timeout = Task.Delay(10000);
            var result = await Task.WhenAny(stopTask, timeout);

            if (result == stopTask)
                _log.LogInformation("Success stopping service");
            else
                _log.LogInformation("Failed to stop service");

            LogContext.PushProperty("PhoneNumber", null);

            Environment.Exit(-1);
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
