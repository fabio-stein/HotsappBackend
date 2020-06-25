using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Hotsapp.Data.Model;
using Hotsapp.Data.Util;
using Hotsapp.WebApi.Services;
using Hotsapp.WebApi.Services.Youtube;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;

namespace Hotsapp.WebApi.Controllers.AdmChannel
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChannelController : ControllerBase
    {
        private ILogger _log = Log.ForContext<ChannelController>();

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

                var channelPlaylist = new ChannelPlaylist() { ChannelId = channel.Id };

                await ctx.ChannelPlaylist.AddAsync(channelPlaylist);

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

        [HttpPost("import-playlist")]
        public async Task<IActionResult> ImportPlaylist([FromServices] YoutubeClientService youtubeService, [FromServices] ChannelService channelService,
            [FromBody] ImportPlaylistForm data)
        {
            using (var ctx = DataFactory.GetDataContext())
            {
                var channel = await ctx.Channel.FirstOrDefaultAsync(c => c.OwnerId == User.GetUserId() && c.Id == data.channelId && !c.IsDisabled);
                if (channel == null)
                    return NotFound();
            }

            string playlistId = null;
            try
            {
                Uri playlistUri = new Uri(data.playlistUrl);
                playlistId = HttpUtility.ParseQueryString(playlistUri.Query).Get("list");
            }catch(Exception e)
            {
                _log.Information(e, "Invalid playlist url [{0}]", data.playlistUrl);
                return BadRequest("Invalid playlist");
            }

            var videos = await youtubeService.ImportPlaylist(playlistId);

            var videoIds = videos.Select(v => v.Id).ToList();

            await channelService.AddVideosToPlaylist(data.channelId, videoIds);
            return Ok();
        }

        public class ChannelForm
        {
            public string channelTitle { get; set; }
            public string channelDescription { get; set; }
        }

        public class ImportPlaylistForm
        {
            public Guid channelId { get; set; }
            public string playlistUrl { get; set; }
        }
    }
}