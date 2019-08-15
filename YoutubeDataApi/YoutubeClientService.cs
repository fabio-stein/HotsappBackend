using Google.Apis.Services;
using Google.Apis.YouTube.v3;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Text;

namespace YoutubeDataApi
{
    public class YoutubeClientService
    {
        private string YOUTUBE_DATA_API_KEY;
        public YoutubeClientService()
        {
            var config = new ConfigurationBuilder()
             .AddJsonFile("config.json")
             .Build();
            YOUTUBE_DATA_API_KEY = config["YOUTUBE_DATA_API_KEY"];

            var youtubeService = new YouTubeService(new BaseClientService.Initializer()
            {
                ApiKey = YOUTUBE_DATA_API_KEY,
                ApplicationName = "affectiva.github.io"//this.GetType().ToString(),
            });
        }
    }
}
