using Hotsapp.Data.Util;
using Hotsapp.WebApi.Services;
using Hotsapp.WebApi.Services.Youtube;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using static Hotsapp.WebApi.Services.ChannelService;

namespace Hotsapp.WebApi.Controllers.AdmChannel
{
    [Route("api/[controller]")]
    [ApiController]
    public class LibraryController : ControllerBase
    {
        private readonly ILogger _log = Log.ForContext<LibraryController>();

        [HttpPost("import-playlist")]
        public async Task<IActionResult> ImportPlaylist([FromServices] YoutubeClientService youtubeService, [FromServices] ChannelService channelService,
            [FromBody] ImportLibraryForm data)
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

            var libraryItems = await channelService.AddVideosToLibrary(data.channelId, videoIds);

            if (data.addToPlaylist)
                await channelService.AddVideosToPlaylist(data.channelId, libraryItems);

            return Ok(new { imported = libraryItems.Count });
        }

        [HttpGet("{channelId}")]
        public async Task<IActionResult> Get(Guid channelId, [FromServices] YouTubeCacheService youTubeCacheService)
        {
            List<VideoInfo> library;
            using (var ctx = DataFactory.GetDataContext())
            {
                var channel = await ctx.Channel.FirstOrDefaultAsync(c => c.OwnerId == User.GetUserId() && c.Id == channelId && !c.IsDisabled);
                if (channel == null)
                    return NotFound();

                var channelLibrary = await ctx.ChannelLibrary.FirstOrDefaultAsync(l => l.ChannelId == channelId);
                library = JsonConvert.DeserializeObject<List<VideoInfo>>(channelLibrary.Library);
            }

            var videosInfo = await youTubeCacheService.GetVideos(library.Select(l => l.Id).ToList());
            var result = library.Select(v =>
            {
                var item = videosInfo.FirstOrDefault(i => i.Id == v.Id);
                return new
                {
                    v.Id,
                    Title = (item?.Snippet?.Title != null) ? item?.Snippet?.Title : "Unknown Media"
                };
            }).ToList();

            return Ok(result);
        }

        [HttpDelete("{channelId}")]
        public async Task<IActionResult> Delete(Guid channelId, [FromQuery] string mediaId)
        {
            using (var ctx = DataFactory.GetDataContext())
            {
                var channel = await ctx.Channel.FirstOrDefaultAsync(c => c.OwnerId == User.GetUserId() && c.Id == channelId && !c.IsDisabled);
                if (channel == null)
                    return NotFound();

                var channelLibrary = await ctx.ChannelLibrary.FirstOrDefaultAsync(l => l.ChannelId == channelId);
                var library = JsonConvert.DeserializeObject<List<VideoInfo>>(channelLibrary.Library);

                var channelPlaylist = await ctx.ChannelPlaylist.FirstOrDefaultAsync(l => l.ChannelId == channelId);
                var playlist = JsonConvert.DeserializeObject<List<VideoInfo>>(channelPlaylist.Playlist);

                var libraryItem = library.FirstOrDefault(l => l.Id == mediaId);

                if (libraryItem == null)
                    return NotFound("Media not found");

                var playlistItem = playlist.FirstOrDefault(p => p.Id == mediaId);
                if (playlistItem != null)
                    return BadRequest("Cannot delete an item from the library in your playlist");

                library.Remove(libraryItem);
                channelLibrary.Library = JsonConvert.SerializeObject(library);
                ctx.ChannelLibrary.Update(channelLibrary);

                await ctx.SaveChangesAsync();
                return Ok();
            }
        }

        [HttpPost("{channelId}/send-to-playlist")]
        public async Task<IActionResult> SendToPlaylist(Guid channelId, [FromQuery] string mediaId)
        {
            using (var ctx = DataFactory.GetDataContext())
            {
                var channel = await ctx.Channel.FirstOrDefaultAsync(c => c.OwnerId == User.GetUserId() && c.Id == channelId && !c.IsDisabled);
                if (channel == null)
                    return NotFound();

                var channelLibrary = await ctx.ChannelLibrary.FirstOrDefaultAsync(l => l.ChannelId == channelId);
                var library = JsonConvert.DeserializeObject<List<VideoInfo>>(channelLibrary.Library);

                var channelPlaylist = await ctx.ChannelPlaylist.FirstOrDefaultAsync(l => l.ChannelId == channelId);
                var playlist = JsonConvert.DeserializeObject<List<VideoInfo>>(channelPlaylist.Playlist);

                var libraryItem = library.FirstOrDefault(l => l.Id == mediaId);

                if (libraryItem == null)
                    return NotFound("Media not found");

                playlist.Add(libraryItem);
                channelPlaylist.Playlist = JsonConvert.SerializeObject(playlist);
                ctx.ChannelPlaylist.Update(channelPlaylist);

                await ctx.SaveChangesAsync();
                return Ok();
            }
        }
    }

    public class ImportLibraryForm
    {
        public Guid channelId { get; set; }
        public string playlistUrl { get; set; }
        public bool addToPlaylist { get; set; }
    }
}