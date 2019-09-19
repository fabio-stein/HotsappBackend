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

        public ServiceUpdater(PhoneService phoneService)
        {
            _phoneService = phoneService;
        }

        public async Task Start()
        {
            Console.WriteLine("Starting");
            SendUpdate("STARTING");
            _ = UpdateTask();
            _phoneService.OnMessageReceived += OnMessageReceived;
            await _phoneService.Start();
            await _phoneService.Login();
        }

        public async Task UpdateTask()
        {
            await Task.Delay(1000);
            bool? isOnline = null;
            try
            {
                isOnline = await _phoneService.IsOnline();
            }
            catch (Exception e){
                Console.WriteLine(e.ToString());
            }
            string status = "ERROR";
            if (isOnline != null)
            {
                status = ((bool)isOnline) ? "ONLINE" : "OFFLINE";
            }
            SendUpdate(status);
            await CheckMessagesToSend();

            _ = UpdateTask();
        }

        public async Task CheckMessagesToSend()
        {
            var context = DataFactory.GetContext();
            {
                var message = context.Message.Where(m => m.SentDateUtc == null)
                    .OrderBy(m => m.Id)
                    .FirstOrDefault();
                if(message != null)
                {
                    Console.WriteLine("New message to send!");
                    await _phoneService.SendMessage(message.PhoneNumber, message.Text);
                    message.SentDateUtc = DateTime.UtcNow;
                    await context.SaveChangesAsync();
                }
            }
        }

        public void SendUpdate(string status)
        {
            var context = DataFactory.GetContext();
            {
                var s = context.Phoneservice.First();
                s.LastUpdate = DateTime.UtcNow;
                s.Status = status;
                context.SaveChanges();
            }
        }

        public void OnMessageReceived(object sender, Data.MessageReceived mr)
        {
            var context = DataFactory.GetContext();
            {
                var message = new MessageReceived()
                {
                    Message = mr.Message,
                    FromNumber = mr.Number,
                    ToNumber = "639552450578",
                    ReceiveDateUtc = DateTime.UtcNow
                };
                context.MessageReceived.Add(message);
                context.SaveChanges();
            }
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            Console.WriteLine("Timed Background Service is starting.");
            Start();

            _timer = new Timer(DoWork, null, TimeSpan.Zero,
                TimeSpan.FromSeconds(5));

            return Task.CompletedTask;
        }

        private void DoWork(object state)
        {
            Console.WriteLine("Timed Background Service is working.");
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
