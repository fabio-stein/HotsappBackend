using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotsapp.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class SubscriptionController : BaseController
    {
        public async Task<IActionResult> GetStatus()
        {
            return Ok();
        }

        public async Task<IActionResult> CreateSubscription()
        {
            return Ok();
        }

        public async Task<IActionResult> CancelSubscription()
        {
            return Ok();
        }
    }
}