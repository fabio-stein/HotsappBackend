using Flurl.Http;
using Microsoft.Extensions.Configuration;
using System;
using YoutubeDataApi.model;

namespace YoutubeDataApi
{
    public class YoutubeDataService
    {
        private string YOUTUBE_DATA_API_KEY;
        public YoutubeDataService()
        {
            var config = new ConfigurationBuilder()
             .AddJsonFile("config.json")
             .Build();
            YOUTUBE_DATA_API_KEY = config["YOUTUBE_DATA_API_KEY"];
        }

        IFlurlRequest CreateRequest(String ApiMethod)
        {
            return $"https://www.googleapis.com/youtube/v3/{ApiMethod}?key={YOUTUBE_DATA_API_KEY}"
                .WithHeader("Referer", "affectiva.github.io");
        }

        private T YoutubePostRequest<T, K>(string ApiMethod, object Data)
        {
            return CreateRequest(ApiMethod)
                .SetQueryParams(Data)
                .GetJsonAsync<T>().Result;
        }
        public BaseResponse GetVideo(String id)
        {
            var res = YoutubePostRequest<BaseResponse, object>("videos", new {
                part = "id,snippet",
                id
            });
            return res;
        }
        public static async void Get(int i)
        {
            var url = "https://www.googleapis.com/youtube/v3/search?part=snippet&q=" + i + "&maxResults=50&type=video&key=123";
            var t = url
                .WithHeader("Referer", "affectiva.github.io")
                .GetStringAsync().Result;
            Console.WriteLine(t + " - " + i);
        }
    }
}
