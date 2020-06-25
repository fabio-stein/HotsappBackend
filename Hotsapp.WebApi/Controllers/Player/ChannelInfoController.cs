using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotsapp.Data.Util;
using Hotsapp.WebApi.Services;
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
        public async Task<IActionResult> GetChannelInfo([FromQuery] Guid channelId, [FromServices] YouTubeCacheService youTubeCacheService)
        {
            using (var ctx = DataFactory.GetDataContext())
            {
                var channel = await ctx.Channel.FirstOrDefaultAsync(c => c.Id == channelId);

                if (channel == null)
                    return NotFound();

                string lastMediaTitle = null;

                var lastMedia = await ctx.PlayHistory
                    .Where(c => c.ChannelId == channelId)
                    .OrderByDescending(c => c.StartDateUTC)
                    .FirstOrDefaultAsync();

                if (lastMedia != null)
                {
                    var mediaInfo = await youTubeCacheService.GetVideoInfo(lastMedia.MediaId);
                    lastMediaTitle = mediaInfo?.Snippet?.Title;
                }

                return Ok(new
                {
                    title = channel.Title,
                    lastMediaTitle
                });
            }
        }
    }
}