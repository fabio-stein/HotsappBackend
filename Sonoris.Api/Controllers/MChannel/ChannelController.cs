using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;
using DbManager.Contexts;
using DbManager.Model;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Sonoris.Api.Controllers;
using Sonoris.Api.Controllers.MChannel.action;
using Sonoris.Api.Controllers.MChannel.model;
using Sonoris.Api.Services;
using Sonoris.Api.Services.Storage;
using Sonoris.Api.Util;

namespace Sonoris.Api.Modules.MChannel
{
    [Route("api/Channel/[action]")]
    [Authorize]
    public class ChannelController : BaseController
    {
        private readonly IAuthorizationService _authorizationService;
        public ChannelController(IAuthorizationService authorizationService)
        {
            _authorizationService = authorizationService;
        }

        [HttpPost]
        public async Task Add([FromForm] ChannelEditForm Channel, [FromServices] StorageService storage)
        {
            String imageHash;
            using (var temp = FileUtil.ReceiveTempUploadedFile(Channel.files))
            {
                imageHash = FileUtil.SimpleMd5(temp);
                await storage.provider.UploadAsync(temp, $"{imageHash}.png");
            }

            using (var context = new DataContext())
            {
                context.Channel.Add(new Channel()
                {
                    ChName = Channel.chName,
                    ChImage = imageHash,
                    ChCoverImage = "Test2",
                    ChOwner = (int)UserId
                });
                context.SaveChanges();
                Ok();
            }
        }
        [HttpPost]
        public List<Channel> Get()
        {
            using (var context = new DataContext())
            {
                var data = context.Channel
                    .ToList();
                return data;
            }
        }

        [HttpGet("{channel}")]
        public async Task<IActionResult> ChannelStatus(int channel, [FromServices] ChannelWorkerService manager)
        {
            var authorizationResult = await _authorizationService.AuthorizeAsync(User, channel, "ChannelManage");
            if (!authorizationResult.Succeeded)
                return Forbid();

            var res = new ChannelStatusView();
            var worker = manager.workers.Find(w => w.channel.ChId == channel);
            using (var context = new DataContext())
            {
                var data = context.Channel.Where(c => c.ChId == channel).SingleOrDefault();
                if (data != null)
                    res.Name = data.ChName;
            }
            res.Channel = channel;
            if (worker == null)
                res.Running = false;
            else
            {
                res.Name = worker.channel.ChName;
                res.Running = true;
                if (worker.playlistItem != null)
                {
                    res.RunningItem = worker.playlistItem.CplMediaNavigation.MedName;
                    res.StartDate = (DateTime)worker.playlistItem.CplStartDate;
                    long duration = worker.playlistItem.CplMediaNavigation.MedDurationSeconds;
                    res.EndDate = ((DateTime)worker.playlistItem.CplStartDate).AddSeconds(duration);
                    res.Duration = duration;
                }
            }
            return Ok(res);
        }

        [HttpPost("{channel}")]
        public async Task<IActionResult> StartChannel(int channel, [FromServices] ChannelWorkerService manager)
        {
            var authorizationResult = await _authorizationService.AuthorizeAsync(User, channel, "ChannelManage");
            if (!authorizationResult.Succeeded)
                return Forbid();

            manager.StartChannelWorker(channel);
            return Ok();
        }

        [HttpPost("{channel}")]
        public async Task<IActionResult> StopChannel(int channel, [FromServices] ChannelWorkerService manager)
        {
            var authorizationResult = await _authorizationService.AuthorizeAsync(User, channel, "ChannelManage");
            if (!authorizationResult.Succeeded)
                return Forbid();

            _ = manager.RequestWorkerStop(channel);
            return Ok();
        }

        [HttpPost("{channel}")]
        public async Task<IActionResult> Delete(int channel, [FromServices] StorageService storage)
        {
            var authorizationResult = await _authorizationService.AuthorizeAsync(User, channel, "ChannelManage");
            if (!authorizationResult.Succeeded)
                return Forbid();

            using (var context = new DataContext())
            {
                var item = context.Channel.Where(c => c.ChId == channel).SingleOrDefault();
                context.Channel.Remove(item);

                await storage.provider.DeleteAsync(item.ChImage+".png");
                context.SaveChanges();
                return Ok();
            }
        }

        [HttpPost]
        public List<Channel> Search([FromBody] ActionChannelSearch options)
        {
            using (var context = new DataContext())
            {
                var channels = context.Channel.AsQueryable();
                if (options.Mine == true)
                    channels = channels.Where(c => c.ChOwner == UserId);
                if (!String.IsNullOrEmpty(options.Name))
                    channels = channels.Where(c => EF.Functions.ILike(c.ChName, $"%{options.Name}%"));

                int pageSize = 10;
                channels = channels.Skip(pageSize * (options.page-1));
                channels = channels.Take(pageSize);
                return channels.ToList();
            }
        }
    }
}
