using Hotsapp.Data.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotsapp.Data.Model;
using Microsoft.Extensions.Hosting;
using System.Threading;
using System.IO;

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

        public ServiceUpdater(PhoneService phoneService, NumberManager numberManager, IHostingEnvironment hostingEnvironment)
        {
            _phoneService = phoneService;
            _numberManager = numberManager;
            _hostingEnvironment = hostingEnvironment;
        }

        public async Task CheckMessagesToSend()
        {
            using (var context = DataFactory.GetContext())
            {
                var message = context.Message.Where(m => m.IsInternal && !m.Processed)
                    .OrderBy(m => m.Id)
                    .FirstOrDefault();
                if(message != null)
                {
                    Console.WriteLine("New message to send!");
                    await _phoneService.SendMessage(message.ExternalNumber, message.Content);
                    message.Processed = true;
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
                    UserId = number.CurrentOwnerId
                };
                context.Message.Add(message);
                context.SaveChanges();
            }
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Starting");
            _numberManager.TryAllocateNumber().Wait();
            if (_numberManager.currentNumber == null)
                throw new Exception("Cannot allocate any number");

            _numberManager.LoadData();

            SendUpdate("STARTING");
            UpdateTask(null);
            _phoneService.OnMessageReceived += OnMessageReceived;

            _phoneService.Start().Wait();
            _phoneService.Login().Wait();
            lastLoginAttempt = DateTime.UtcNow;
            if(_hostingEnvironment.IsProduction())
                _phoneService.SetProfilePicture().Wait();
            _phoneService.SetStatus().Wait();

            _timer = new Timer(UpdateTask, null, TimeSpan.Zero,
                TimeSpan.FromMilliseconds(500));
            return Task.CompletedTask;
        }

        private void UpdateTask(object state)
        {
            if (updateRunning)
                return;
            updateRunning = true;
            Console.WriteLine("UPDATE TASK RUN");
            try
            {
                _numberManager.PutCheck().Wait();
                try
                {
                    isOnline = _phoneService.IsOnline().Result;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                    isOnline = false;
                }
                string status = status = ((bool)isOnline) ? "ONLINE" : "OFFLINE";
                SendUpdate(status);
                CheckMessagesToSend().Wait();
            }
            catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
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
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }

            updateRunning = false;
        }

        private async Task CheckDisconnection()
        {
            var minTimeToCheckAgain = DateTime.UtcNow.AddSeconds(-15);
            if (lastLoginAttempt == null || lastLoginAttempt > minTimeToCheckAgain)
                return;

            if (_phoneService.isDead)
            {
                Console.WriteLine("[Connection Checker] PhoneService IsDead! Reconnecting.");
                _phoneService.Stop();
                await _phoneService.Start();
                await _phoneService.Login();
                lastLoginAttempt = DateTime.UtcNow;
                return;
            }

            if (offlineCount >= 5)
            {
                Console.WriteLine("[Connection Checker] PhoneService is offline! Reconnecting.");
                await _phoneService.Login();
                lastLoginAttempt = DateTime.UtcNow;
                return;
            }
            
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Timed Background Service is stopping.");
            _phoneService.Stop();

            _timer?.Change(Timeout.Infinite, 0);

            _numberManager.ReleaseNumber().Wait();

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
