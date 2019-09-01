using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WhatsTroll.Api.Controllers;
using WhatsTroll.Api.Controllers.MChannel.action;
using WhatsTroll.Api.Controllers.MChannel.model;
using WhatsTroll.Api.Services;
using WhatsTroll.Api.Services.Storage;
using WhatsTroll.Data.Model;

namespace WhatsTroll.Api.Modules.MChannel
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
        public async Task Create([FromBody] ChannelEditForm Channel)
        {
            /*
            String imageHash;
            using (var temp = FileUtil.ReceiveTempUploadedFile(Channel.files))
            {
                imageHash = FileUtil.SimpleMd5(temp);
                await storage.provider.UploadAsync(temp, $"{imageHash}.png");
            }*/

            using (var context = new DataContext())
            {
                context.Channel.Add(new Channel()
                {
                    Name = Channel.Name,
                    //ChImage = imageHash,
                    //ChCoverImage = "Test2",
                    UserId = (int)UserId
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
            var worker = manager.workers.Find(w => w.channel.Id == channel);
            using (var context = new DataContext())
            {
                var data = context.Channel.Where(c => c.Id == channel).SingleOrDefault();
                if (data != null)
                    res.Name = data.Name;
            }
            res.Channel = channel;
            if (worker == null)
                res.Running = false;
            else
            {
                res.Name = worker.channel.Name;
                res.Running = true;
                if (worker.playlistItem != null)
                {
                    res.RunningItem = worker.playlistItem.Media.Title;
                    res.StartDate = (DateTime)worker.playlistItem.StartDateUtc;
                    long duration = worker.playlistItem.Media.DurationSeconds;
                    res.EndDate = ((DateTime)worker.playlistItem.StartDateUtc).AddSeconds(duration);
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
                var item = context.Channel.Where(c => c.Id == channel).SingleOrDefault();
                context.Channel.Remove(item);

                //await storage.provider.DeleteAsync(item.ChImage+".png");
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
                    channels = channels.Where(c => c.UserId == UserId);
                if (!String.IsNullOrEmpty(options.Name))
                    channels = channels.Where(c => EF.Functions.Like(c.Name, $"%{options.Name}%"));

                int pageSize = 10;
                channels = channels.Skip(pageSize * (options.page-1));
                channels = channels.Take(pageSize);
                return channels.ToList();
            }
        }
    }
}
