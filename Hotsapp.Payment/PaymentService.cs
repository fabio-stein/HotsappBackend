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
using Hotsapp.Data.Util;

namespace Hotsapp.Payment
{
    public class PaymentService
    {
        private PayPalClient _paypalClient;
        private IConfiguration _configuration;
        private BalanceService _balanceService;
        public PaymentService(IConfiguration configuration, BalanceService balanceService)
        {
            _configuration = configuration;

            var clientId = configuration.GetSection("Payment")["PaypalClientId"];
            var clientSecret = configuration.GetSection("Payment")["PaypalClientSecret"];
            var isLive = configuration.GetSection("Payment")["Mode"] == "Live";
            _paypalClient = new PayPalClient(clientId, clientSecret, !isLive);
            _balanceService = balanceService;
        }

        public async Task<PayPal.v1.Subscriptions.Subscription> CreateSubscription()
        {
            var planId = _configuration.GetSection("Payment")["PlanId"];
            var s = await _paypalClient.CreateSubscription(planId);
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
            using(var dataContext = DataFactory.GetContext())
            {
                var order = await _paypalClient.CaptureOrder(orderId);

                if (order.Status != "COMPLETED")
                    throw new Exception("Order not completed");

                var units = order.PurchaseUnits[0];
                var quantity = units.Items[0].Quantity;
                var value = decimal.Parse(quantity, CultureInfo.InvariantCulture);
                if (units.Amount.Currency != "BRL")
                    throw new Exception("Currency is not BRL");

                var payment = new Data.Model.Payment()
                {
                    Amount = value,
                    DateTimeUtc = DateTime.UtcNow,
                    PaypalOrderId = order.Id,
                    UserId = userId
                };
                await dataContext.Payment.AddAsync(payment);
                await dataContext.SaveChangesAsync();
                await _balanceService.CreditsTransaction(userId, value, new BalanceService.TransactionOptions { paymentId = payment.Id });
            }
        }

        public async Task<PayPal.v1.Orders.Order> CreateOrder(int credits, string price)
        {
            return await _paypalClient.CreateOrder(credits, price);
        }
    }
}
