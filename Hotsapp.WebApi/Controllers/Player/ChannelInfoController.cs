using Hotsapp.Data.Util;
using Hotsapp.WebApi.Services;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Hotsapp.WebApi.Controllers
{
    [Route("api/channel-info")]
    [ApiController]
    [AllowAnonymous]
    public class ChannelInfoController : ControllerBase
    {
        private ILogger _log = Log.ForContext<ChannelInfoController>();

        [HttpGet("status")]
        public async Task<IActionResult> GetChannelInfo([FromQuery] Guid channelId, [FromServices] YouTubeCacheService youTubeCacheService)
        {
            using (var ctx = DataFactory.GetDataContext())
            {
                var channel = await ctx.Channel.FirstOrDefaultAsync(c => c.Id == channelId);

                if (channel == null)
                    return NotFound();

                string lastMediaTitle = null;

                try
                {
                    var lastMedia = await ctx.PlayHistory
                        .Where(c => c.ChannelId == channelId)
                        .OrderByDescending(c => c.StartDateUTC)
                        .FirstOrDefaultAsync();

                    if (lastMedia != null)
                    {
                        var mediaInfo = await youTubeCacheService.GetVideoInfo(lastMedia.MediaId);
                        lastMediaTitle = mediaInfo?.Snippet?.Title;
                    }
                }
                catch (Exception e)
                {
                    _log.Information(e, "[{0}] Failed to load channel last media", channelId);
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