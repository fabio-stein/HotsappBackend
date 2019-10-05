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
    public class SingleMessageProcessService : IHostedService, IDisposable
    {
        private Timer _timer;
        private BalanceService _balanceService;
        private bool isRunning = false;

        public SingleMessageProcessService(BalanceService balanceService)
        {
            _balanceService = balanceService;
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {
            Console.WriteLine("Starting SingleMessageProcessService");

            _timer = new Timer(ProcessQueue, null, TimeSpan.Zero,
                TimeSpan.FromMilliseconds(300));

            return Task.CompletedTask;
        }

        private void ProcessQueue(object state)
        {
            if (isRunning)
                return;
            isRunning = true;
            using(var context = DataFactory.GetContext())
            {
                var queue = context.SingleMessage.Where(m => !m.Processed).OrderBy(m => m.CreateDateUtc).ToList();
                queue.ForEach(item =>
                {
                    try
                    {
                        ProcessItem(item).Wait();
                        SetAsProcessed(item).Wait();
                    }catch(Exception e)
                    {
                        Console.WriteLine(e.Message);
                    }
                });
            }
            isRunning = false;
        }

        private async Task ProcessItem(SingleMessage sm)
        {
            using(var context = DataFactory.GetContext())
            {
                try
                {
                    var item = await context.SingleMessage.Where(n => n.Id == sm.Id).SingleAsync();
                    var number = await GetAvailableInternalNumber();
                    if (number == null)
                        throw new Exception("No numbers available");
                    await _balanceService.TryTakeCredits(item.UserId, 1);
                    var message = new Message()
                    {
                        InternalNumber = number,
                        IsInternal = true,
                        Processed = false,
                        DateTimeUtc = DateTime.UtcNow,
                        Content = item.Content,
                        ExternalNumber = item.ToNumber,
                    };
                    await context.Message.AddAsync(message);
                    await context.SaveChangesAsync();
                }
                catch(Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }
        }

        private async Task SetAsProcessed(SingleMessage sm)
        {
            using (var context = DataFactory.GetContext())
            {
                var item = await context.SingleMessage.Where(n => n.Id == sm.Id).SingleAsync();
                item.Processed = true;
                await context.SaveChangesAsync();
            }
        }

        private async Task<string> GetAvailableInternalNumber()
        {
            try
            {
                using (var context = DataFactory.GetContext())
                {
                    var minTime = DateTime.UtcNow.AddMinutes(-1);
                    var maxTime = DateTime.UtcNow.AddMinutes(1);//Filter test numbers
                    var number = await context.VirtualNumber.Where(n => n.LastCheckUtc >= minTime && n.LastCheckUtc <= maxTime).SingleOrDefaultAsync();
                    if (number != null)
                        return number.Number;
                }
            }catch(Exception e)
            {
                Console.WriteLine(e.Message);
            }
            return null;
        }

        public Task StopAsync(CancellationToken stoppingToken)
        {
            Console.WriteLine("Stopping SingleMessageProcessService");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }
    }
}
