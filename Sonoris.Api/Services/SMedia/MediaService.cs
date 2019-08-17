using DbManager.Contexts;
using DbManager.Model;
using Google.Apis.YouTube.v3;
using Google.Apis.YouTube.v3.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Xml;
using Sonoris.Api.Services.SMedia.model;

namespace Sonoris.Api.Services
{
    public class MediaService
    {
        private YouTubeService _ytService { get; set; }

        public MediaService(YoutubeManager _manager)
        {
            _ytService = _manager.client;
        }

        public Video GetVideoFromUrl(String url)
        {
            Uri uri = new Uri(url);
            string videoId = HttpUtility.ParseQueryString(uri.Query).Get("v");

            if (videoId == null || videoId == "")
                throw new Exception("Invalid Source");

            var req = _ytService.Videos.List("id,snippet,contentDetails,status");
            req.Id = videoId;
            var data = req.ExecuteAsync().Result;

            if (data.Items.Count == 0)
                throw new Exception("Media Not Found");

            return data.Items[0];
        }

        public CheckMediaResult CheckValidMedia(String source)
        {
            var res = new CheckMediaResult();
            try
            {
                var data = GetVideoFromUrl(source);

                var embeddable = data.Status.Embeddable;
                if (embeddable != true)
                    throw new Exception("Media not embeddable");

                res.video = data;
            }catch(Exception e)
            {
                res.error = true;
                res.message = e.Message;
            }
            return res;
        }

        public Media AddMedia(int channel, String source, String title)
        {
            var video = GetVideoFromUrl(source);
            var ptsDuration = video.ContentDetails.Duration;
            TimeSpan ts = XmlConvert.ToTimeSpan(ptsDuration);
            var duration = ts.TotalSeconds;

            var media = new Media();
            media.MedDurationSeconds = (long)duration;
            media.MedName = video.Snippet.Title;
            media.MedChannel = channel;
            if (title != null)
                media.MedName = title;
            media.MedSource = source;
            media.MedType = 1;

            using (var context = new DataContext())
            {
                context.Media.Add(media);
                context.SaveChanges();
            }
            return media;
        }
    }
}
