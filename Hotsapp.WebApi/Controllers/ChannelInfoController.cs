using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotsapp.Data.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hotsapp.WebApi.Controllers
{
    [Route("api/channel-info")]
    [ApiController]
    [AllowAnonymous]
    public class ChannelInfoController : ControllerBase
    {
        [HttpGet("status")]
        public async Task<IActionResult> GetChannelInfo([FromQuery] Guid channelId)
        {
            using (var ctx = DataFactory.GetDataContext())
            {
                var channel = await ctx.Channel.FirstOrDefaultAsync(c => c.Id == channelId);

                if (channel == null)
                    return NotFound();

                return Ok(new
                {
                    title = channel.Title,
                });
            }
        }
    }
}