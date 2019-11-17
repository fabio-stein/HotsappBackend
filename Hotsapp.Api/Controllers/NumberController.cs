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
                var numbers = ctx.VirtualNumber.Where(n => n.OwnerId == UserId).ToList();
                var list = numbers.Select(n => new { NumberId = n.Number });
                return Ok(list);
            }
        }

        [HttpPut("{numberId}")]
        public async Task<IActionResult> DeleteReservation([FromRoute] string numberId)
        {
            using (var ctx = DataFactory.GetContext())
            {
                var number = ctx.VirtualNumber.Where(n => n.OwnerId == UserId && n.Number == numberId).SingleOrDefault();
                if (number == null)
                    return NotFound();
                number.OwnerId = null;
                var periods = ctx.NumberPeriod.Where(n => n.UserId == UserId && n.VirtualNumberId == numberId && (n.EndDateUtc == null || n.EndDateUtc >= DateTime.UtcNow)).ToList();
                foreach (var period in periods)
                {
                    if (period.StartDateUtc >= DateTime.UtcNow)
                    {
                        ctx.NumberPeriod.Remove(period);
                        continue;
                    }

                    period.EndDateUtc = DateTime.UtcNow;
                    ctx.NumberPeriod.Update(period);
                }

                var reservation = ctx.VirtualNumberReservation.SingleOrDefault(r => r.NumberId == numberId);
                if (reservation != null)
                    reservation.EndDateUtc = DateTime.UtcNow;
                await ctx.SaveChangesAsync();
                return Ok();
            }
        }

        [HttpPost]
        public async Task<IActionResult> ReserveNew()
        {
            using (var ctx = DataFactory.GetContext())
            {
                var newNumber = ctx.VirtualNumber.Where(n => n.OwnerId == null).FirstOrDefault();
                if (newNumber == null)
                    return BadRequest("No available numbers");

                var reserve = new NumberPeriod()
                {
                    StartDateUtc = DateTime.UtcNow,
                    EndDateUtc = DateTime.UtcNow.AddDays(30),
                    UserId = (int)UserId,
                    VirtualNumberId = newNumber.Number
                };
                newNumber.OwnerId = UserId;
                await ctx.NumberPeriod.AddAsync(reserve);
                await _balanceService.TryTakeCredits((int)UserId, 20, null);
                await ctx.VirtualNumberReservation.AddAsync(new VirtualNumberReservation()
                {
                    StartDateUtc = DateTime.UtcNow,
                    UserId = (int)UserId,
                    NumberId = newNumber.Number
                });
                await ctx.SaveChangesAsync();
                return Ok();
            }
        }
    }
}