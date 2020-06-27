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

        public async Task<List<VideoInfo>> AddVideosToLibrary(Guid channelId, List<string> videoIds)
        {
            _log.Information("Trying to add {0} video(s) to library", videoIds.Count);
            var videos = await _cacheService.GetVideos(videoIds);
            _log.Information("Found {0} of {1} available videos", videos.Count, videoIds.Count);

            var list = videos.Select(v =>
            {
                var duration = XmlConvert.ToTimeSpan(v.ContentDetails.Duration);
                return new VideoInfo()
                {
                    Id = v.Id,
                    Duration = (int)duration.TotalSeconds
                };
            }).ToList();

            _log.Information("[{0}] Adding videos to playlist", channelId);

            using (var ctx = DataFactory.GetDataContext())
            {
                var channelLibrary = await ctx.ChannelLibrary.FirstOrDefaultAsync(p => p.ChannelId == channelId);

                var library = new List<VideoInfo>();
                if (channelLibrary.Library != null)
                    library = JsonConvert.DeserializeObject<List<VideoInfo>>(channelLibrary.Library);

                var filteredList = list.Where(l => !library.Any(c => c.Id == l.Id)).ToList();
                library.AddRange(filteredList);

                if(filteredList.Count != list.Count)
                    _log.Information("[{0}] Ignoring {1} already existing video(s)", channelId, (list.Count - filteredList.Count));

                channelLibrary.Library = JsonConvert.SerializeObject(library);

                ctx.Update(channelLibrary);

                await ctx.SaveChangesAsync();
            }

            _log.Information("[{0}] Channel library updated successfully", channelId);
            return list;
        }

        public async Task AddVideosToPlaylist(Guid channelId, List<VideoInfo> videos)
        {
            _log.Information("[{0}] Adding videos to playlist", channelId);

            using (var ctx = DataFactory.GetDataContext())
            {
                var channelPlaylist = await ctx.ChannelPlaylist.FirstOrDefaultAsync(p => p.ChannelId == channelId);

                var playlist = new List<VideoInfo>();
                if (channelPlaylist.Playlist != null)
                    playlist = JsonConvert.DeserializeObject<List<VideoInfo>>(channelPlaylist.Playlist);

                playlist.AddRange(videos);

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
