using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotsapp.Api.Controllers.model;
using Hotsapp.Api.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotsapp.Api.Controllers
{
    [Route("api/paypal-webhook/98jdkqw0d9/webhook")]
    [ApiController]
    public class PayPalWebhookController : ControllerBase
    {
        private SubscriptionService _subscriptionService;
        public PayPalWebhookController(SubscriptionService subscriptionService)
        {
            _subscriptionService = subscriptionService;
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Webhook(PayPalWebhookData data)
        {
            switch (data.event_type)
            {
                case "BILLING.SUBSCRIPTION.CREATED":

                    break;
                case "PAYMENT.SALE.COMPLETED":

                    break;
                case "BILLING.SUBSCRIPTION.CANCELLED":

                    break;
                default:
                    
                    break;
            }
            return Ok(data);
        }
    }
}