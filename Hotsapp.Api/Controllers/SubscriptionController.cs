using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotsapp.Api.Services;
using Hotsapp.Data.Util;
using Hotsapp.Payment;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotsapp.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SubscriptionController : BaseController
    {
        private PaymentService _paymentService;

        public SubscriptionController(PaymentService paymentService)
        {
            _paymentService = paymentService;
        }

        public async Task<IActionResult> GetStatus()
        {
            using (var conn = DataFactory.GetContext())
            {
                var lastSubscription = conn.Subscription.OrderByDescending(sub => sub.CreateDateUtc).FirstOrDefault();
                if (lastSubscription != null)
                    return Ok(new
                    {
                        Status = lastSubscription.Status
                    });
                else
                    return Ok(new
                    {
                        Status = (string)null
                    });
            }
        }

        public async Task<IActionResult> GetPaymentUrl()
        {
            using (var conn = DataFactory.GetContext())
            {
                var pendingSubscription = conn.Subscription.Where(sub => sub.UserId == (int)UserId && (sub.Status == "Pending")).FirstOrDefault();
                if (pendingSubscription == null)
                    return NotFound();

                var paypalSubscription = await _paymentService.GetSubscription(pendingSubscription.PaypalRefId);

                if (paypalSubscription.status != "APPROVAL_PENDING")
                    return BadRequest("Houve um problema na assinatura");

                var paymentUrl = paypalSubscription.links.Where(l => l.rel == "approve").FirstOrDefault();
                return Ok(new
                {
                    Url = paymentUrl.href
                });
            }
        }

        public async Task<IActionResult> Create()
        {
            using(var conn = DataFactory.GetContext())
            {
                var activeSubscription = conn.Subscription.Where(sub => sub.UserId == (int)UserId && (sub.Status == "Pending" || sub.Status == "Active")).Count();
                if (activeSubscription > 0)
                    return BadRequest("Você já possui uma assinatura");

                var newSubscription = await _paymentService.CreateSubscription();

                conn.Subscription.Add(new Data.Model.Subscription()
                {
                    CreateDateUtc = DateTime.UtcNow,
                    Status = "Pending",
                    UserId = (int)UserId,
                    PaypalRefId = newSubscription.id
                });
                await conn.SaveChangesAsync();
                return Ok(newSubscription);
            }
        }

        public async Task<IActionResult> Cancel()
        {
            using (var conn = DataFactory.GetContext())
            {
                var activeSubscription = conn.Subscription.Where(sub => sub.UserId == (int)UserId && (sub.Status == "Pending" || sub.Status == "Active")).FirstOrDefault();

                if (activeSubscription == null)
                    return BadRequest("A assinatura já foi cancelada");

                try
                {
                    await _paymentService.CancelSubscription(activeSubscription.PaypalRefId, "Geral");
                }catch(Exception e)
                {
                    Console.WriteLine("Failed to cancel user subscription");
                    Console.WriteLine(e.Message);
                }

                activeSubscription.Status = "Cancelled";
                await conn.SaveChangesAsync();
                return Ok();
            }
        }
    }
}