using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotsapp.Data.Model;
using Hotsapp.Data.Util;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Hotsapp.WebApi.Controllers.AdmChannel
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChannelController : ControllerBase
    {
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            using (var ctx = DataFactory.GetDataContext())
            {
                var data = ctx.Channel.Where(c => c.OwnerId == User.GetUserId() && !c.IsDisabled).OrderByDescending(c => c.CreateDateUTC).ToList();
                return Ok(data);
            }
        }

        [HttpGet("{channelId}")]
        public async Task<IActionResult> GetOne(Guid channelId)
        {
            using (var ctx = DataFactory.GetDataContext())
            {
                var data = await ctx.Channel.FirstOrDefaultAsync(c => c.OwnerId == User.GetUserId() && c.Id == channelId && !c.IsDisabled);

                if (data == null)
                    return NotFound();
                else
                    return Ok(data);
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] ChannelForm data)
        {
            using (var ctx = DataFactory.GetDataContext())
            {
                var channel = new Channel()
                {
                    OwnerId = User.GetUserId(),
                    CreateDateUTC = DateTime.UtcNow,
                    Title = data.channelTitle,
                    Description = data.channelDescription
                };

                await ctx.Channel.AddAsync(channel);
                await ctx.SaveChangesAsync();
                return Ok(channel.Id);
            }
        }

        [HttpDelete("{channelId}")]
        public async Task<IActionResult> Delete(Guid channelId)
        {
            using (var ctx = DataFactory.GetDataContext())
            {
                var channel = await ctx.Channel.FirstOrDefaultAsync(c => c.OwnerId == User.GetUserId() && c.Id == channelId && !c.IsDisabled);
                if (channel == null)
                    return NotFound();
                else
                {
                    channel.IsDisabled = true;
                    //TODO SEND STOP SIGNAL
                    ctx.Channel.Update(channel);
                    await ctx.SaveChangesAsync();
                    return Ok();
                }
            }
        }

        public class ChannelForm
        {
            public string channelTitle { get; set; }
            public string channelDescription { get; set; }
        }
    }
}