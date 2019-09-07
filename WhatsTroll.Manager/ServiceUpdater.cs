using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WhatsTroll.Data;
using WhatsTroll.Data.Model;

namespace WhatsTroll.Manager
{
    public class ServiceUpdater
    {
        PhoneService phone = new PhoneService();
        public ServiceUpdater()
        {
            SendUpdate("STARTING");
            _ = UpdateTask();
            phone.OnMessageReceived += OnMessageReceived;
            phone.Start().Wait();
            phone.Login().Wait();
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
            using(var context = DataFactory.CreateNew())
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
            using (var context = DataFactory.CreateNew())
            {
                var s = context.Phoneservice.First();
                s.LastUpdate = DateTime.UtcNow;
                s.Status = status;
                context.SaveChanges();
            }
        }

        public void OnMessageReceived(object sender, Data.MessageReceived mr)
        {
            using(var context = DataFactory.CreateNew())
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
