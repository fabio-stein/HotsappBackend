using Hotsapp.Data.Model;
using Hotsapp.Data.Util;
using Hotsapp.Payment;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Hotsapp.Api.Services
{
    public class CampaignProcessor : IHostedService, IDisposable
    {
        private Timer _timer;
        private Timer _cleanerTimer;
        private IHostingEnvironment _env;
        private BalanceService _balanceService;

        public CampaignProcessor(IHostingEnvironment env, BalanceService balanceService)
        {
            _env = env;
            _balanceService = balanceService;
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {
            Console.WriteLine("Starting CampaignProcessor");

            _timer = new Timer(Execute, null, TimeSpan.Zero,
                TimeSpan.FromSeconds(1));

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken stoppingToken)
        {
            Console.WriteLine("Stopping CampaignProcessor");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
            _cleanerTimer?.Dispose();
        }

        bool running = false;
        private void Execute(object state)
        {
            if (running)
                return;
            else
                running = true;

            try
            {
                using (var ctx = DataFactory.GetContext())
                {
                    var activeCampaigns = ctx.Campaign.Where(c => !c.IsCanceled && !c.IsPaused && !c.IsComplete).ToList();
                    activeCampaigns.ForEach(c =>
                    {
                        try
                        {
                            ProcessCampaign(c).Wait();
                        }
                        catch (Exception e) { Console.WriteLine(e.Message); }
                    });
                }
            }
            catch (Exception e) { Console.WriteLine(e.Message); }
            running = false;
        }

        private async Task ProcessCampaign(Campaign srcCampaign)
        {
            using (var ctx = DataFactory.GetContext())
            {
                var campaign = ctx.Campaign.Where(c => c.Id == srcCampaign.Id).SingleOrDefault();

                var pendingContact = ctx.CampaignContact.FirstOrDefault(c => c.CampaignId == campaign.Id && !c.Processed && c.MessageId != null);
                if(pendingContact != null)
                {
                    Console.WriteLine("Checking pending contact message status");
                    var message = await ctx.Message.Where(m => m.Id == pendingContact.MessageId).SingleOrDefaultAsync();
                    if (message.Processed)
                    {
                        pendingContact.Processed = true;
                        pendingContact.IsSuccess = !(bool)message.Error;
                    }
                    else
                    {
                        if(message.DateTimeUtc < DateTime.UtcNow.AddMinutes(-1))
                        {
                            Console.WriteLine("Internal number take too long to send the message, removing");
                            message.Processed = true;
                            message.Error = true;
                            message.ErrorCode = "internal_too_late";
                            pendingContact.MessageId = null;
                        }
                    }
                }
                else
                {
                    var contactToSend = ctx.CampaignContact.FirstOrDefault(c => c.CampaignId == campaign.Id && !c.Processed && c.MessageId == null);
                    if(contactToSend != null)
                    {
                        Console.WriteLine("Preparing new message");
                        var lastSystemMessage = await ctx.Message.OrderByDescending(m => m.DateTimeUtc).Where(m => m.Processed && m.Error == false).FirstOrDefaultAsync();
                        var text = campaign.MessageToSend.Replace("\n", @"\n");
                        var newMessage = new Message()
                        {
                            Content = campaign.MessageToSend,
                            DateTimeUtc = DateTime.UtcNow,
                            IsInternal = true,
                            InternalNumber = lastSystemMessage.InternalNumber,
                            ExternalNumber = contactToSend.PhoneNumber,
                            UserId = 20 // Fabio
                        };
                        ctx.Add(newMessage);
                        contactToSend.MessageId = newMessage.Id;
                    }
                    else
                    {
                        Console.WriteLine("No more contacts to send");
                    }
                }

                var total = await ctx.CampaignContact.CountAsync(c => c.CampaignId == campaign.Id);
                var processed = await ctx.CampaignContact.CountAsync(c => c.CampaignId == campaign.Id && c.Processed);

                if(total == processed)
                {
                    var errors = await ctx.CampaignContact.CountAsync(c => c.CampaignId == campaign.Id && c.Processed && !c.IsSuccess);
                    campaign.IsComplete = true;
                    var pricePerUnit = 0.15;
                    var totalBack = errors * pricePerUnit;
                    await _balanceService.CreditsTransaction(campaign.OwnerId, (decimal)totalBack);
                }

                await ctx.SaveChangesAsync();
            }
        }
    }
}
