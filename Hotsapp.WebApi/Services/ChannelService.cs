using Hotsapp.Data.Util;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Xml;

namespace Hotsapp.WebApi.Services
{
    public class ChannelService
    {
        private ILogger _log = Log.ForContext<YouTubeCacheService>();
        private readonly YouTubeCacheService _cacheService;

        public ChannelService(YouTubeCacheService cacheService)
        {
            _cacheService = cacheService;
        }

        public async Task AddVideosToPlaylist(Guid channelId, List<string> videoIds)
        {
            _log.Information("Trying to add {0} video(s) to playlist", videoIds.Count);
            var videos = await _cacheService.GetVideos(videoIds);
            _log.Information("Found {0} of {1} available videos", videos.Count, videoIds.Count);

            var orderedList = new List<VideoInfo>();
            videoIds.ForEach(v =>
            {
                var item = videos.FirstOrDefault(s => s.Id == v);
                if (item != null)
                {
                    var duration = XmlConvert.ToTimeSpan(item.ContentDetails.Duration);
                    var video = new VideoInfo()
                    {
                        Id = item.Id,
                        Duration = (int)duration.TotalSeconds
                    };
                    orderedList.Add(video);
                }
            });

            _log.Information("[{0}] Adding videos to playlist", channelId);

            using (var ctx = DataFactory.GetDataContext())
            {
                var channelPlaylist = await ctx.ChannelPlaylist.FirstOrDefaultAsync(p => p.ChannelId == channelId);

                var playlist = new List<VideoInfo>();
                if (channelPlaylist.Playlist != null)
                    playlist = JsonConvert.DeserializeObject<List<VideoInfo>>(channelPlaylist.Playlist);

                playlist.AddRange(orderedList);

                channelPlaylist.Playlist = JsonConvert.SerializeObject(playlist);

                ctx.Update(channelPlaylist);

                await ctx.SaveChangesAsync();
            }

            _log.Information("[{0}] Channel playlist updated successfully", channelId);
        }

        public class VideoInfo
        {
            public string Id { get; set; }
            public int Duration { get; set; }
        }
    }
}
