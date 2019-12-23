using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Hotsapp.Data;
using Hotsapp.Data.Model;
using PayPal.v1.Subscriptions;

namespace Hotsapp.Payment
{
    public class PaymentService
    {
        private PayPalClient _paypalClient;
        private BalanceService _balanceService;
        public PaymentService(IConfiguration configuration, BalanceService balanceService)
        {
            _balanceService = balanceService;

            var clientId = configuration.GetSection("Payment")["PaypalClientId"];
            var clientSecret = configuration.GetSection("Payment")["PaypalClientSecret"];
            var isLive = configuration.GetSection("Payment")["Mode"] == "Live";
            _paypalClient = new PayPalClient(clientId, clientSecret, !isLive);
        }

        public async Task<PayPal.v1.Subscriptions.Subscription> CreateSubscription()
        {
            var s = await _paypalClient.CreateSubscription("P-4DB99075G2808273ULXRS7RI");
            return s;
        }

        public async Task<PayPal.v1.Subscriptions.Subscription> GetSubscription(string subscriptionId)
        {
            var s = await _paypalClient.GetSubscription(subscriptionId);
            return s;
        }

        public async Task CancelSubscription(string subscriptionId, string reason)
        {
            await _paypalClient.CancelSubscription(subscriptionId, reason);
        }

        public async Task CaptureOrder(string orderId, int userId)
        {
            /*DISABLED
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var order = await _paypalClient.CaptureOrder(orderId);

                if (order.Status != "COMPLETED")
                    throw new Exception("Order not completed");

                var amount = order.PurchaseUnits[0].AmountWithBreakdown;
                var value = decimal.Parse(amount.Value, CultureInfo.InvariantCulture);
                if (amount.CurrencyCode != "BRL" || value < 5)
                    throw new Exception("Invalid Operation");

                var payment = new Data.Model.Payment()
                {
                    Amount = value,
                    DateTimeUtc = DateTime.UtcNow,
                    PaypalOrderId = order.Id,
                    UserId = userId
                };
                await _dataContext.Payment.AddAsync(payment);
                await _dataContext.SaveChangesAsync();
                await _balanceService.AddCredits(userId, value, new BalanceService.TransactionOptions { paymentId = payment.Id });
                scope.Complete();
            }*/
        }
    }
}
