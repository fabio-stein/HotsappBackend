using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotsapp.Data.Util;
using Hotsapp.WebApi.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using static Hotsapp.WebApi.Services.ChannelService;

namespace Hotsapp.WebApi.Controllers.AdmChannel
{
    [Route("api/[controller]")]
    [ApiController]
    public class PlaylistController : ControllerBase
    {
        [HttpGet("{channelId}")]
        public async Task<IActionResult> Get(Guid channelId, [FromServices] YouTubeCacheService youTubeCacheService)
        {
            List<VideoInfo> playlist;
            string playlistHash;
            using (var ctx = DataFactory.GetDataContext())
            {
                var channel = await ctx.Channel.FirstOrDefaultAsync(c => c.OwnerId == User.GetUserId() && c.Id == channelId && !c.IsDisabled);
                if (channel == null)
                    return NotFound();

                var channelPlaylist = await ctx.ChannelPlaylist.FirstOrDefaultAsync(l => l.ChannelId == channelId);
                playlist = channelPlaylist.Playlist.FromJson<List<VideoInfo>>();
                playlistHash = channelPlaylist.Playlist.GetMD5Hash();
            }

            var videosInfo = await youTubeCacheService.GetVideos(playlist.Select(l => l.Id).ToList());
            var result = playlist.Select(v =>
            {
                var item = videosInfo.FirstOrDefault(i => i.Id == v.Id);
                return new
                {
                    v.Id,
                    Title = (item?.Snippet?.Title != null) ? item?.Snippet?.Title : "Unknown Media"
                };
            }).ToList();

            var response = new PlaylistHashedData()
            {
                hash = playlistHash,
                data = result
            };
            return Ok(response);
        }

        [HttpDelete("{channelId}")]
        public async Task<IActionResult> Delete(Guid channelId, [FromQuery] int indexToRemove, [FromQuery] string hash)
        {
            using (var ctx = DataFactory.GetDataContext())
            {
                var channel = await ctx.Channel.FirstOrDefaultAsync(c => c.OwnerId == User.GetUserId() && c.Id == channelId && !c.IsDisabled);
                if (channel == null)
                    return NotFound();

                var channelPlaylist = await ctx.ChannelPlaylist.FirstOrDefaultAsync(l => l.ChannelId == channelId);
                var playlist = channelPlaylist.Playlist.FromJson<List<VideoInfo>>();

                var currentHash = channelPlaylist.Playlist.GetMD5Hash();
                if (currentHash != hash)
                    return BadRequest("Playlist changed, please update and try again");

                playlist.RemoveAt(indexToRemove);
                channelPlaylist.Playlist = playlist.ToJson();
                ctx.ChannelPlaylist.Update(channelPlaylist);

                await ctx.SaveChangesAsync();
                return Ok();
            }
        }
    }

    public class PlaylistHashedData
    {
        public string hash { get; set; }
        public object data { get; set; }
    }
}