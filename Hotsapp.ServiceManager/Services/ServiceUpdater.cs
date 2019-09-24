using Hotsapp.ServiceManager.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotsapp.Data.Model;
using Microsoft.Extensions.Hosting;
using System.Threading;

namespace Hotsapp.ServiceManager.Services
{
    public class ServiceUpdater : IHostedService, IDisposable
    {
        PhoneService _phoneService;
        private Timer _timer;
        private bool updateRunning = false;

        public ServiceUpdater(PhoneService phoneService)
        {
            _phoneService = phoneService;
        }

        public async Task CheckMessagesToSend()
        {
            var context = DataFactory.GetContext();
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
            var context = DataFactory.GetContext();
            {
                var s = context.Phoneservice.First();
                s.LastUpdateUtc = DateTime.UtcNow;
                s.Status = status;
                context.SaveChanges();
            }
        }

        public void OnMessageReceived(object sender, Data.MessageReceived mr)
        {
            var context = DataFactory.GetContext();
            {
                var message = new Message()
                {
                    Content = mr.Message,
                    ExternalNumber = mr.Number,
                    InternalNumber = "84826193915",
                    DateTimeUtc = DateTime.UtcNow,
                    IsInternal = false
                };
                context.Message.Add(message);
                context.SaveChanges();
            }
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Starting");
            SendUpdate("STARTING");
            UpdateTask(null);
            _phoneService.OnMessageReceived += OnMessageReceived;

            _phoneService.Start().Wait();
            _phoneService.Login().Wait();

            _timer = new Timer(UpdateTask, null, TimeSpan.Zero,
                TimeSpan.FromMilliseconds(500));

            return Task.CompletedTask;
        }

        private void UpdateTask(object state)
        {
            if (updateRunning)
                return;
            updateRunning = true;
            try
            {
                bool? isOnline = null;
                try
                {
                    isOnline = _phoneService.IsOnline().Result;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
                string status = "ERROR";
                if (isOnline != null)
                {
                    status = ((bool)isOnline) ? "ONLINE" : "OFFLINE";
                }
                SendUpdate(status);
                CheckMessagesToSend().Wait();
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
                Console.WriteLine(e.StackTrace);
            }
            updateRunning = false;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Timed Background Service is stopping.");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
