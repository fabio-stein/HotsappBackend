using System;
using System.Collections.Generic;
using System.Text;

namespace YoutubeDataApi.model
{
    public class BaseResult
    {
        public string etag { get; set; }
        //public BaseResultId id { get; set; }
        public BaseResultSnippet snippet { get; set; }
    }
    public class BaseResultSnippet
    {
        public DateTime publishedAt { get; set; }
        public string channelId { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public ThumbItems thumbnails { get; set; }
        public string channelTitle { get; set; }
    }

    public class ThumbItems
    {
        public ThumbItem @default { get; set; }
        public ThumbItem high { get; set; }
        public ThumbItem medium { get; set; }
    }

    public class ThumbItem
    {
        public string url { get; set; }
        public int width { get; set; }
        public int height { get; set; }
    }
}
