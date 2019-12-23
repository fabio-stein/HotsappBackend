using Hotsapp.Payment;
using PayPal.v1.Subscriptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotsapp.Api.Services
{
    public class SubscriptionService
    {
        private PaymentService _paymentService;

        public SubscriptionService(PaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        public async Task<Subscription> CreateSubscription()
        {
            var subscription = await _paymentService.CreateSubscription();
            return subscription;
        }

        public async Task AddPeriodToSubscription()
        {

        }

        public async Task TerminateSubscription()
        {

        }
    }
}
