using Hotsapp.ServiceManager.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Hotsapp.Data.Model;

namespace Hotsapp.ServiceManager.Services
{
    public class ServiceUpdater
    {
        PhoneService phone = new PhoneService();
        public ServiceUpdater()
        {
            
        }

        public async Task Start()
        {
            SendUpdate("STARTING");
            _ = UpdateTask();
            phone.OnMessageReceived += OnMessageReceived;
            await phone.Start();
            await phone.Login();

            await Task.Delay(6000000);
        }

        public async Task UpdateTask()
        {
            await Task.Delay(1000);
            bool? isOnline = null;
            try
            {
                isOnline = await phone.IsOnline();
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
                    await phone.SendMessage(message.PhoneNumber, message.Text);
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
    }
}
