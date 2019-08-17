using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Transactions;
using System.Web;
using System.Xml;
using DbManager.Contexts;
using DbManager.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sonoris.Api.Controllers.MMediaController;
using Sonoris.Api.Controllers.MMediaController.Action;
using Sonoris.Api.Services;
using Sonoris.Api.Services.SChannelPlaylist;
using YoutubeDataApi;

namespace Sonoris.Api.Modules.MMediaController
{
    [Route("api/Media/[action]")]
    public class MediaController : Controller
    {
        private readonly IAuthorizationService _authorizationService;

        public MediaController(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        [HttpPost]
        public IActionResult GetMediaInfo([FromServices] MediaService service, [FromBody] ActionGetMediaInfo data)
        {
            var media = service.CheckValidMedia(data.source);
            if (media?.error == true)
                return BadRequest(media.message);

            return Ok(media);
        }

        [HttpPost]
        public async Task<IActionResult> AddMedia([FromServices] MediaService mediaService, [FromServices] ChannelPlaylistService playlistService, [FromBody] ActionAddMedia data)
        {
            var authorizationResult = await _authorizationService.AuthorizeAsync(User, data.channel, "ChannelManage");
            if (!authorizationResult.Succeeded)
                return Forbid();

            var media = mediaService.CheckValidMedia(data.source);
            if (media?.error == true)
                return BadRequest(media.message);

            try
            {
                using (var scope = new TransactionScope())
                {
                    var newMedia = mediaService.AddMedia(data.channel, data.source, data.title);
                    if(data.addToPlaylist)
                        playlistService.AddMediaToPlaylist(newMedia.MedId);

                    scope.Complete();
                }
            }catch(Exception e)
            {
                return BadRequest(e.Message);
            }
            return Ok();
        }

        [HttpGet("{channel}")]
        public async Task<IActionResult> GetList(int channel)
        {
            var authorizationResult = await _authorizationService.AuthorizeAsync(User, channel, "ChannelManage");
            if (!authorizationResult.Succeeded)
                return Forbid();

            using (var context = new DataContext())
            {
                var data = context.Media.Where(m => m.MedChannel == channel).ToList();
                var items = data.Select(m => ChannelMediaUtil.ToMediaView(m));
                return Ok(items);
            }
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Remove(long id)
        {
            using (var context = new DataContext())
            {
                var item = context.Media.Where(m => m.MedId == id).SingleOrDefault();

                var authorizationResult = await _authorizationService.AuthorizeAsync(User, item.MedChannel, "ChannelManage");
                if (!authorizationResult.Succeeded)
                    return Forbid();

                context.Media.Remove(item);
                context.SaveChanges();
                return Ok();
            }
        }
    }
}
