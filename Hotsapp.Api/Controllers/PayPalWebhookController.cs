using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotsapp.Api.Controllers.model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotsapp.Api.Controllers
{
    [Route("api/paypal-webhook/98jdkqw0d9/webhook")]
    [ApiController]
    public class PayPalWebhookController : ControllerBase
    {
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Webhook(PayPalWebhookData data)
        {
            return Ok(data);
        }
    }
}