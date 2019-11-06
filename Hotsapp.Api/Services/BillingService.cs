using Dapper;
using Hotsapp.Data.Util;
using Hotsapp.Payment;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Hotsapp.Api.Services
{
    public class BillingService : IHostedService, IDisposable
    {
        private Timer _timer;
        private BalanceService _balanceService;

        public BillingService(BalanceService balanceService)
        {
            _balanceService = balanceService;
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {
            Console.WriteLine("Starting DbTasksService");

            _timer = new Timer(Run, null, TimeSpan.Zero,
                TimeSpan.FromDays(1));

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken stoppingToken)
        {
            Console.WriteLine("Stopping DbTasksService");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }


        private void Run(object state)
        {
            var list = GetPendingPayments().Result;
            list.ForEach(o =>
            {
                Console.WriteLine("Executing BillingService for reservation id {0}", o.ReservationId);
                TryExecuteBilling(o).Wait();
            });
        }

        private async Task TryExecuteBilling(PendingPayment o)
        {
            try
            {
                using (var ctx = DataFactory.GetContext())
                {
                    var res = ctx.VirtualNumberReservation.SingleOrDefault(r => r.Id == o.ReservationId);
                    var dayPrice = 1;
                    var amountToTake = o.TotalDays * dayPrice;
                    await _balanceService.TryTakeCredits(res.UserId, amountToTake, new BalanceService.TransactionOptions { virtualNumberReservationId = res.Id, forceBilling = true });
                }
            }catch(Exception e)
            {
                Console.WriteLine("Billing failed");
                Console.WriteLine(e.ToString());
            }
        }

        public  async Task<List<PendingPayment>> GetPendingPayments()
        {
            using(var conn = DataFactory.OpenConnection())
            {
                var data = await conn.QueryAsync<PendingPayment>(@"WITH last_payment AS(
SELECT tr.VirtualNumberReservationId, MAX(tr.DateTimeUTC) AS LastPaymentUTC FROM transaction tr
  WHERE tr.VirtualNumberReservationId IS NOT NULL
  GROUP BY tr.VirtualNumberReservationId
  ),
  bill_info AS(

SELECT res.Id, DATE(COALESCE(lp.LastPaymentUTC, res.StartDateUTC)) AS BillStart, DATE(COALESCE(res.EndDateUTC, UTC_DATE)) AS BillEnd FROM virtual_number_reservation res
  LEFT JOIN last_payment lp ON lp.VirtualNumberReservationId = res.Id
  )

SELECT Id AS ReservationId, (bi.BillEnd-bi.BillStart) AS TotalDays FROM bill_info bi
  WHERE (bi.BillEnd-bi.BillStart) > 0");
                return data.ToList();
            }
        }

        public class PendingPayment
        {
            public int ReservationId { get; set; }
            public int TotalDays { get; set; }
        }

    }
}
