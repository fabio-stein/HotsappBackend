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
        private IConfiguration _configuration;
        public PaymentService(IConfiguration configuration)
        {
            _configuration = configuration;

            var clientId = configuration.GetSection("Payment")["PaypalClientId"];
            var clientSecret = configuration.GetSection("Payment")["PaypalClientSecret"];
            var isLive = configuration.GetSection("Payment")["Mode"] == "Live";
            _paypalClient = new PayPalClient(clientId, clientSecret, !isLive);
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
    }
}
