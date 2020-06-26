using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using Hotsapp.Data.Model;
using Hotsapp.Data.Util;
using Hotsapp.WebApi.Services;
using Hotsapp.WebApi.Services.Youtube;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Serilog;
using static Hotsapp.WebApi.Services.ChannelService;

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
            }
            catch (Exception e)
            {
                _log.Information(e, "Invalid playlist url [{0}]", data.playlistUrl);
                return BadRequest("Invalid playlist");
            }

            var videos = await youtubeService.ImportPlaylist(playlistId);

            var videoIds = videos.Select(v => v.Id).ToList();

            await channelService.AddVideosToPlaylist(data.channelId, videoIds);
            return Ok();
        }

        [HttpGet("live-status/{channelId}")]
        public async Task<IActionResult> GetLiveStatus(Guid channelId, [FromServices] YouTubeCacheService youTubeCacheService)
        {
            Channel channel;
            ChannelLiveStatus status = new ChannelLiveStatus();
            PlayHistory currentMedia;
            ChannelPlaylist playlist;
            using (var ctx = DataFactory.GetDataContext())
            {
                channel = await ctx.Channel.FirstOrDefaultAsync(c => c.OwnerId == User.GetUserId() && !c.IsDisabled && c.Id == channelId);
                if (channel == null)
                    return NotFound();

                currentMedia = await ctx.PlayHistory.Where(p => p.ChannelId == channel.Id).OrderByDescending(p => p.StartDateUTC).FirstOrDefaultAsync();
                playlist = await ctx.ChannelPlaylist.FirstOrDefaultAsync(p => p.ChannelId == channel.Id);
            }

            status.channelStatus = channel.Status;

            string nextMediaId = null;
            if (!string.IsNullOrEmpty(playlist?.Playlist))
            {
                var list = JsonConvert.DeserializeObject<List<VideoInfo>>(playlist.Playlist);
                var firstItem = list.FirstOrDefault();
                nextMediaId = firstItem?.Id;

                if (list != null)
                    status.mediaCountInPlaylist = list.Count;
            }

            status.currentMediaId = currentMedia?.MediaId;
            status.startDateUTC = currentMedia?.StartDateUTC;
            status.currentMediaDuration = currentMedia?.Duration;
            status.nextMediaId = nextMediaId;

            if (status.currentMediaId != null)
            {
                var info = await youTubeCacheService.GetVideoInfo(status.currentMediaId);
                status.currentMediaTitle = info?.Snippet?.Title;
            }

            if (status.nextMediaId != null)
            {
                var info = await youTubeCacheService.GetVideoInfo(status.nextMediaId);
                status.nextMediaTitle = info?.Snippet?.Title;
            }

            return Ok(status);
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

        public class ChannelLiveStatus
        {
            public string channelStatus { get; set; }
            //public int usersCount { get; set; }
            public string currentMediaId { get; set; }
            public string currentMediaTitle { get; set; }
            public string nextMediaId { get; set; }
            public string nextMediaTitle { get; set; }
            public DateTime? startDateUTC { get; set; }
            public int? currentMediaDuration { get; set; }
            public int mediaCountInPlaylist { get; set; }
        }
    }
}