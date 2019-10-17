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
        private BalanceService _balanceService;
        public NumberController(BalanceService balanceService)
        {
            _balanceService = balanceService;
        }

        [HttpGet]
        public async Task<IActionResult> GetMyNumbers()
        {
            using(var ctx = DataFactory.GetContext())
            {
                var numbers = ctx.VirtualNumber.Where(n => n.CurrentOwnerId == UserId).ToList();
                var list = numbers.Select(n => new { NumberId = n.Number });
                return Ok(list);
            }
        }

        [HttpPut("{numberId}")]
        public async Task<IActionResult> DeleteReservation([FromRoute] string numberId)
        {
            using (var ctx = DataFactory.GetContext())
            {
                var number = ctx.VirtualNumber.Where(n => n.CurrentOwnerId == UserId && n.Number == numberId).SingleOrDefault();
                if (number == null)
                    return NotFound();
                number.CurrentOwnerId = null;
                var reservations = ctx.NumberPeriod.Where(n => n.UserId == UserId && n.VirtualNumberId == numberId && (n.EndDateUtc == null || n.EndDateUtc >= DateTime.UtcNow)).ToList();
                foreach (var reserve in reservations)
                {
                    if (reserve.StartDateUtc >= DateTime.UtcNow)
                    {
                        ctx.NumberPeriod.Remove(reserve);
                        continue;
                    }

                    reserve.EndDateUtc = DateTime.UtcNow;
                    ctx.NumberPeriod.Update(reserve);
                }
                await ctx.SaveChangesAsync();
                return Ok();
            }
        }

        [HttpPost]
        public async Task<IActionResult> ReserveNew()
        {
            using (var ctx = DataFactory.GetContext())
            {
                var newNumber = ctx.VirtualNumber.Where(n => n.CurrentOwnerId == null).FirstOrDefault();
                if (newNumber == null)
                    return BadRequest("No available numbers");

                var reserve = new NumberPeriod()
                {
                    StartDateUtc = DateTime.UtcNow,
                    EndDateUtc = DateTime.UtcNow.AddDays(30),
                    UserId = (int)UserId,
                    VirtualNumberId = newNumber.Number
                };
                newNumber.CurrentOwnerId = UserId;
                await ctx.NumberPeriod.AddAsync(reserve);
                await _balanceService.TryTakeCredits((int)UserId, 20);
                await ctx.SaveChangesAsync();
                return Ok();
            }
        }
    }
}