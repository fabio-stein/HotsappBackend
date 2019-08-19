using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sonoris.Api.Controllers.MChannelPlaylist;
using Sonoris.Api.Services.SPlaylistMedia;
using Sonoris.Data.Context;

namespace Sonoris.Api.Modules.MChannelPlaylist
{
    [Consumes("application/json")]
    [Produces("application/json")]
    [Route("api/ChannelPlaylist/[action]")]
    public class ChannelPlaylistController : Controller
    {
        private readonly IAuthorizationService _authorizationService;

        public ChannelPlaylistController(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        [HttpGet("{channel}")]
        public async Task<IActionResult> GetList(int channel)
        {
            var authorizationResult = await _authorizationService.AuthorizeAsync(User, channel, "ChannelManage");
            if (!authorizationResult.Succeeded)
                return Forbid();

            using (var context = new PlaylistMediaContext())
            {
                var CPLs = context.GetCurrentPlaylist(channel);
                var items = CPLs.Select(cpl => ChannelPlaylistUtil.ToPlaylistView(cpl));
                return Ok(items);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddMediaToPlaylist([FromBody] ActionAddMediaToPlaylist data, [FromServices] PlaylistMediaService playlistService)
        {
            var authorizationResult = await _authorizationService.AuthorizeAsync(User, data.channel, "ChannelManage");
            if (!authorizationResult.Succeeded)
                return Forbid();

            playlistService.AddMediaToPlaylist(data.mediaId);
            return Ok();
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Remove(long id, [FromServices] PlaylistMediaService playlistService)
        {
            using (var context = new PlaylistMediaContext())
            {
                var item = context.PlaylistMedia.Where(p => p.Id == id).SingleOrDefault();
                var authorizationResult = await _authorizationService.AuthorizeAsync(User, item.ChannelId, "ChannelManage");
                if (!authorizationResult.Succeeded)
                    return Forbid();
            }
            playlistService.Remove(id);
            return Ok();
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> MoveDown(long id, [FromServices] PlaylistMediaService playlistService)
        {
            using (var context = new PlaylistMediaContext())
            {
                var item = context.PlaylistMedia.Where(p => p.Id == id).SingleOrDefault();
                var authorizationResult = await _authorizationService.AuthorizeAsync(User, item.ChannelId, "ChannelManage");
                if (!authorizationResult.Succeeded)
                    return Forbid();
            }
            playlistService.MoveDown(id);
            return Ok();
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> MoveUp(long id, [FromServices] PlaylistMediaService playlistService)
        {
            using (var context = new PlaylistMediaContext())
            {
                var item = context.PlaylistMedia.Where(p => p.Id == id).SingleOrDefault();
                var authorizationResult = await _authorizationService.AuthorizeAsync(User, item.ChannelId, "ChannelManage");
                if (!authorizationResult.Succeeded)
                    return Forbid();
            }
            playlistService.MoveUp(id);
            return Ok();
        }

    }
}
