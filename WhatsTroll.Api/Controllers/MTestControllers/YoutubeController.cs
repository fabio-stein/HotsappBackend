using Microsoft.AspNetCore.Mvc;
using WhatsTroll.Data.Model;
using YoutubeDataApi;
using YoutubeDataApi.model;

namespace WhatsTroll.Api.Controllers
{
    [Route("api/YoutubeController/[action]")]
    public class YoutubeController : Controller
    {
        [HttpGet]
        public BaseResponse Add([FromServices] YoutubeDataService DataController)
        {
            
            using (var context = new DataContext())
            {
                /*
                var snippet = DataController.GetVideo().items[0].snippet;
                    context.Media.Add(new Media()
                    {
                        VidTitle = snippet.title
                    });
                context.SaveChanges();*/
            }
            return null;
        }
    }
}
