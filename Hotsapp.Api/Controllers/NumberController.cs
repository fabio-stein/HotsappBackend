using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotsapp.Data.Model;
using Hotsapp.Data.Util;
using Hotsapp.Payment;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Hotsapp.Api.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class NumberController : BaseController
    {
        public NumberController()
        {
        }

        [HttpGet]
        public async Task<IActionResult> GetMyNumbers()
        {
            using(var ctx = DataFactory.GetContext())
            {
                var numbers = ctx.VirtualNumber.Where(n => n.OwnerId == UserId).ToList();
                var list = numbers.Select(n => new { NumberId = n.Number });
                return Ok(list);
            }
        }

    }
}