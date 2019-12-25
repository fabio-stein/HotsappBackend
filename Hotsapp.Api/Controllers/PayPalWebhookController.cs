using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using Hotsapp.Api.Controllers.model;
using Hotsapp.Api.Services;
using Hotsapp.Data.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

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
            try
            {
                switch (data.event_type)
                {
                    case "BILLING.SUBSCRIPTION.ACTIVATED":
                        await ProcessSubscriptionActivated(data);
                        break;
                    case "PAYMENT.SALE.COMPLETED":
                        await ProcessPaymentReceived(data);
                        break;
                    case "BILLING.SUBSCRIPTION.CANCELLED":
                        await ProcessSubscriptionCancelled(data);
                        break;
                    default:
                        Console.WriteLine("Error On PayPal Webhook - Unknown Function");
                        Console.WriteLine(JsonConvert.SerializeObject(data));
                        break;
                }
            }catch(Exception e)
            {
                Console.WriteLine("Error On PayPal Webhook - "+e.Message);
                Console.WriteLine(e.ToString());
                Console.WriteLine(JsonConvert.SerializeObject(data));
            }
            return Ok(data);
        }

        private async Task ProcessSubscriptionActivated(PayPalWebhookData data)
        {
            using(var ctx = DataFactory.GetContext())
            {
                var subId = data.resource.id;
                Console.WriteLine($"PayPal Webhook - Activating Subscription [{subId}]");
                var subscription = ctx.Subscription.Where(s => s.PaypalRefId == subId).FirstOrDefault();
                subscription.Status = "Active";
                subscription.StartDateUtc = data.resource.status_update_time;
                await ctx.SaveChangesAsync();
            }
        }

        private async Task ProcessPaymentReceived(PayPalWebhookData data)
        {
            using (var ctx = DataFactory.GetContext())
            {
                var paymentId = data.resource.id;
                Console.WriteLine($"PayPal Webhook - Payment Received [Payment: {paymentId}]");
                var subId = data.resource.billing_agreement_id;
                var subscription = ctx.Subscription.Where(s => s.PaypalRefId == subId).FirstOrDefault();

                subscription.StartDateUtc = subscription.StartDateUtc ?? DateTime.UtcNow;

                var endDate = (DateTime) (subscription.EndDateUtc ?? subscription.StartDateUtc);
                endDate = endDate.AddMonths(1);
                subscription.EndDateUtc = endDate;

                var payment = new Hotsapp.Data.Model.Payment()
                {
                    Id = Guid.NewGuid(),
                    PaypalOrderId = paymentId,
                    SubscriptionId = subscription.Id,
                    UserId = subscription.UserId,
                    DateTimeUtc = DateTime.UtcNow,
                    Amount = decimal.Parse(data.resource.amount.total, CultureInfo.InvariantCulture)
                };
                await ctx.Payment.AddAsync(payment);
                
                await ctx.SaveChangesAsync();
            }
        }

        private async Task ProcessSubscriptionCancelled(PayPalWebhookData data)
        {
            using (var ctx = DataFactory.GetContext())
            {
                var subId = data.resource.id;
                Console.WriteLine($"PayPal Webhook - Cancelling Subscription [{subId}]");
                var subscription = ctx.Subscription.Where(s => s.PaypalRefId == subId).FirstOrDefault();
                subscription.Status = "Cancelled";
                await ctx.SaveChangesAsync();
            }
        }
    }
}