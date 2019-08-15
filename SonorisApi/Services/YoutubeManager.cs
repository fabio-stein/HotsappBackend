using Google.Apis.Http;
using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SonorisApi.Services
{
    public class YoutubeManager
    {
        private string YOUTUBE_DATA_API_KEY;
        public YouTubeService client { get; private set; }
        public YoutubeManager()
        {
            var config = new ConfigurationBuilder()
             .AddJsonFile("config.json")
             .Build();
            YOUTUBE_DATA_API_KEY = config["YOUTUBE_DATA_API_KEY"];

            client = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = YOUTUBE_DATA_API_KEY,
                ApplicationName = "affectiva.github.io",//this.GetType().ToString
            });
            client.HttpClient.DefaultRequestHeaders.Referrer = new Uri("https://affectiva.github.io");
        }
    }
}
