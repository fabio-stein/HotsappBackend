using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using WhatsTroll.Data;

namespace WhatsTroll.Payment
{
    public class PaymentService
    {
        private PaypalClient _paypalClient;
        private BalanceService _balanceService;
        public PaymentService(IConfiguration configuration, BalanceService balanceService)
        {
            _balanceService = balanceService;

            var clientId = configuration.GetSection("Payment")["PaypalClientId"];
            var clientSecret = configuration.GetSection("Payment")["PaypalClientSecret"];
            var isLive = configuration.GetSection("Payment")["Mode"] == "Live";
            _paypalClient = new PaypalClient(clientId, clientSecret, !isLive);
        }

        public async Task CaptureOrder(string orderId, int userId)
        {
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var order = await _paypalClient.CaptureOrder(orderId);

                if (order.Status != "COMPLETED")
                    throw new Exception("Order not completed");

                var amount = order.PurchaseUnits[0].AmountWithBreakdown;
                var value = decimal.Parse(amount.Value, CultureInfo.InvariantCulture);
                if (amount.CurrencyCode != "BRL" || value < 5)
                    throw new Exception("Invalid Operation");

                using (var context = DataFactory.CreateNew())
                {
                    var payment = new Data.Model.Payment()
                    {
                        Amount = value,
                        DateTimeUtc = DateTime.UtcNow,
                        PaypalOrderId = order.Id,
                        UserId = userId
                    };
                    await context.Payment.AddAsync(payment);
                    await context.SaveChangesAsync();
                    await _balanceService.AddCredits(userId, value, payment.Id);
                }
                scope.Complete();
            }
        }
    }
}
