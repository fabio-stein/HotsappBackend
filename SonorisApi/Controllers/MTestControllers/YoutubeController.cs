using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbManager.Contexts;
using DbManager.Model;
using Microsoft.AspNetCore.Mvc;
using YoutubeDataApi;
using YoutubeDataApi.model;

namespace SonorisApi.Controllers
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
