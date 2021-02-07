using Google.Apis.Http;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using Microsoft.Extensions.Configuration;
using Serilog;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotsapp.WebApi.Services.Youtube
{
    public class TestClient : IConfigurableHttpClientInitializer
    {
        public void Initialize(ConfigurableHttpClient httpClient)
        {
            httpClient.DefaultRequestHeaders.Add("x-origin", "https://explorer.apis.google.com");
        }
    }
    public class YoutubeClientService
    {
        private ILogger _log = Log.ForContext<YoutubeClientService>();
        private YouTubeCacheService _youtubeCacheService;
        private YouTubeService _youTubeService;
        public YoutubeClientService(YouTubeCacheService youtubeCacheService, IConfiguration config)
        {
            _youtubeCacheService = youtubeCacheService;
            var key = config["YouTubeApiKey"];

            _youTubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = key,
                ApplicationName = this.GetType().ToString(),
                HttpClientInitializer = new TestClient()
            });
        }

        public async Task<List<Video>> ImportPlaylist(string playlistId)
        {
            _log.Information("Importing playlist [{0}]", playlistId);
            var playlistSearch = _youTubeService.PlaylistItems.List("snippet");
            playlistSearch.MaxResults = 50;
            playlistSearch.PlaylistId = playlistId;

            var videoSearch = _youTubeService.Videos.List("snippet,contentDetails,status");
            videoSearch.MaxResults = 50;

            var items = new List<Video>();

            int page = 1;
            while (page <= 10)
            {
                _log.Information("Loading playlist page {0}", page);
                var playlistResult = await playlistSearch.ExecuteAsync();

                var listIds = playlistResult.Items.ToList().Select(i => i.Snippet.ResourceId.VideoId);
                var ids = string.Join(',', listIds);

                videoSearch.Id = ids;

                var videosResult = await videoSearch.ExecuteAsync();

                items.AddRange(videosResult.Items);

                if (playlistResult.NextPageToken == null)
                    break;

                playlistSearch.PageToken = playlistResult.NextPageToken;

                page++;
            }

            await _youtubeCacheService.SaveVideosCache(items);
            _log.Information("Successfully imported playlist [{0}]", playlistId);

            return items;
        }
    }
}
