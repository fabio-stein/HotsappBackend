using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DbManager.Contexts;
using DbManager.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SonorisApi.Controllers.MChannelPlaylist;
using SonorisApi.Services.SChannelPlaylist;

namespace SonorisApi.Modules.MChannelPlaylist
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

            using (var context = new ChannelPlaylistContext())
            {
                var CPLs = context.GetCurrentPlaylist(channel);
                var items = CPLs.Select(cpl => ChannelPlaylistUtil.ToPlaylistView(cpl));
                return Ok(items);
            }
        }

        [HttpPost]
        public async Task<IActionResult> AddMediaToPlaylist([FromBody] ActionAddMediaToPlaylist data, [FromServices] ChannelPlaylistService playlistService)
        {
            var authorizationResult = await _authorizationService.AuthorizeAsync(User, data.channel, "ChannelManage");
            if (!authorizationResult.Succeeded)
                return Forbid();

            playlistService.AddMediaToPlaylist(data.mediaId);
            return Ok();
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> Remove(long id, [FromServices] ChannelPlaylistService playlistService)
        {
            using (var context = new ChannelPlaylistContext())
            {
                var item = context.ChannelPlaylist.Where(p => p.CplId == id).SingleOrDefault();
                var authorizationResult = await _authorizationService.AuthorizeAsync(User, item.CplChannel, "ChannelManage");
                if (!authorizationResult.Succeeded)
                    return Forbid();
            }
            playlistService.Remove(id);
            return Ok();
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> MoveDown(long id, [FromServices] ChannelPlaylistService playlistService)
        {
            using (var context = new ChannelPlaylistContext())
            {
                var item = context.ChannelPlaylist.Where(p => p.CplId == id).SingleOrDefault();
                var authorizationResult = await _authorizationService.AuthorizeAsync(User, item.CplChannel, "ChannelManage");
                if (!authorizationResult.Succeeded)
                    return Forbid();
            }
            playlistService.MoveDown(id);
            return Ok();
        }

        [HttpPost("{id}")]
        public async Task<IActionResult> MoveUp(long id, [FromServices] ChannelPlaylistService playlistService)
        {
            using (var context = new ChannelPlaylistContext())
            {
                var item = context.ChannelPlaylist.Where(p => p.CplId == id).SingleOrDefault();
                var authorizationResult = await _authorizationService.AuthorizeAsync(User, item.CplChannel, "ChannelManage");
                if (!authorizationResult.Succeeded)
                    return Forbid();
            }
            playlistService.MoveUp(id);
            return Ok();
        }

    }
}
