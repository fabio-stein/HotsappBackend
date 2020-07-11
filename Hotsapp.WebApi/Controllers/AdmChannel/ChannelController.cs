using Hotsapp.Data.Model;
using Hotsapp.Data.Util;
using Hotsapp.Messaging;
using Hotsapp.WebApi.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using RabbitMQ.Client;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Hotsapp.WebApi.Services.ChannelService;

namespace Hotsapp.WebApi.Controllers.AdmChannel
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChannelController : ControllerBase
    {
        private ILogger _log = Log.ForContext<ChannelController>();

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            using (var ctx = DataFactory.GetDataContext())
            {
                var data = ctx.Channel.Where(c => c.OwnerId == User.GetUserId() && !c.IsDisabled).OrderByDescending(c => c.CreateDateUTC).ToList();
                return Ok(data);
            }
        }

        [HttpGet("{channelId}")]
        public async Task<IActionResult> GetOne(Guid channelId)
        {
            using (var ctx = DataFactory.GetDataContext())
            {
                var data = await ctx.Channel.FirstOrDefaultAsync(c => c.OwnerId == User.GetUserId() && c.Id == channelId && !c.IsDisabled);

                if (data == null)
                    return NotFound();
                else
                    return Ok(data);
            }
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromBody] ChannelForm data)
        {
            using (var ctx = DataFactory.GetDataContext())
            {
                var channel = new Channel()
                {
                    OwnerId = User.GetUserId(),
                    CreateDateUTC = DateTime.UtcNow,
                    Title = data.channelTitle,
                    Description = data.channelDescription,
                    Status = "STOPPED",
                };

                await ctx.Channel.AddAsync(channel);

                var channelPlaylist = new ChannelPlaylist() { ChannelId = channel.Id, Playlist = "[]" };
                var channelLibrary = new ChannelLibrary() { ChannelId = channel.Id, Library = "[]" };

                await ctx.ChannelPlaylist.AddAsync(channelPlaylist);
                await ctx.ChannelLibrary.AddAsync(channelLibrary);

                await ctx.SaveChangesAsync();
                return Ok(channel.Id);
            }
        }

        [HttpDelete("{channelId}")]
        public async Task<IActionResult> Delete(Guid channelId)
        {
            using (var ctx = DataFactory.GetDataContext())
            {
                var channel = await ctx.Channel.FirstOrDefaultAsync(c => c.OwnerId == User.GetUserId() && c.Id == channelId && !c.IsDisabled);
                if (channel == null)
                    return NotFound();
                else
                {
                    channel.IsDisabled = true;
                    //TODO SEND STOP SIGNAL
                    ctx.Channel.Update(channel);
                    await ctx.SaveChangesAsync();
                    return Ok();
                }
            }
        }

        [HttpGet("live-status/{channelId}")]
        public async Task<IActionResult> GetLiveStatus(Guid channelId, [FromServices] YouTubeCacheService youTubeCacheService)
        {
            Channel channel;
            ChannelLiveStatus status = new ChannelLiveStatus();
            PlayHistory currentMedia;
            ChannelPlaylist playlist;
            using (var ctx = DataFactory.GetDataContext())
            {
                channel = await ctx.Channel.FirstOrDefaultAsync(c => c.OwnerId == User.GetUserId() && !c.IsDisabled && c.Id == channelId);
                if (channel == null)
                    return NotFound();

                currentMedia = await ctx.PlayHistory.Where(p => p.ChannelId == channel.Id).OrderByDescending(p => p.StartDateUTC).FirstOrDefaultAsync();
                playlist = await ctx.ChannelPlaylist.FirstOrDefaultAsync(p => p.ChannelId == channel.Id);
            }

            status.channelStatus = channel.Status;

            string nextMediaId = null;
            if (!string.IsNullOrEmpty(playlist?.Playlist))
            {
                var list = JsonConvert.DeserializeObject<List<VideoInfo>>(playlist.Playlist);
                var firstItem = list.FirstOrDefault();
                nextMediaId = firstItem?.Id;

                if (list != null)
                    status.mediaCountInPlaylist = list.Count;
            }

            status.currentMediaId = currentMedia?.MediaId;
            status.startDateUTC = currentMedia?.StartDateUTC;
            status.currentMediaDuration = currentMedia?.Duration;
            status.nextMediaId = nextMediaId;

            if (status.currentMediaId != null)
            {
                var info = await youTubeCacheService.GetVideoInfo(status.currentMediaId);
                status.currentMediaTitle = info?.Snippet?.Title;
            }

            if (status.nextMediaId != null)
            {
                var info = await youTubeCacheService.GetVideoInfo(status.nextMediaId);
                status.nextMediaTitle = info?.Snippet?.Title;
            }

            return Ok(status);
        }

        [HttpPost("{channelId}/start")]
        public async Task<IActionResult> Start(Guid channelId)
        {
            using (var ctx = DataFactory.GetDataContext())
            {
                var data = await ctx.Channel.FirstOrDefaultAsync(c => c.OwnerId == User.GetUserId() && c.Id == channelId && !c.IsDisabled);

                if (data == null)
                    return NotFound();
                else
                {
                    _log.Information("[{0}] Sending start message to channel", channelId);
                    using (var channel = MessagingFactory.GetConnection().CreateModel())
                    {
                        var name = "channel-controller";
                        channel.QueueDeclare(queue: name,
                                             durable: true,
                                             exclusive: false,
                                             autoDelete: false,
                                             arguments: null);

                        var model = new ChannelControllerMessage()
                        {
                            ChannelId = channelId,
                            Action = ChannelControllerMessageAction.START
                        };

                        string message = model.ToJson();
                        var body = Encoding.UTF8.GetBytes(message);

                        channel.BasicPublish(exchange: "",
                                             routingKey: name,
                                             basicProperties: null,
                                             body: body);
                    }
                    return Ok();
                }
            }
        }

        [HttpPost("{channelId}/stop")]
        public async Task<IActionResult> Stop(Guid channelId)
        {
            using (var ctx = DataFactory.GetDataContext())
            {
                var data = await ctx.Channel.FirstOrDefaultAsync(c => c.OwnerId == User.GetUserId() && c.Id == channelId && !c.IsDisabled);

                if (data == null)
                    return NotFound();
                else
                {
                    _log.Information("[{0}] Sending stop message to channel", channelId);
                    using (var channel = MessagingFactory.GetConnection().CreateModel())
                    {
                        var name = "channel-controller";
                        channel.QueueDeclare(queue: name,
                                             durable: true,
                                             exclusive: false,
                                             autoDelete: false,
                                             arguments: null);

                        var model = new ChannelControllerMessage()
                        {
                            ChannelId = channelId,
                            Action = ChannelControllerMessageAction.STOP
                        };

                        string message = model.ToJson();
                        var body = Encoding.UTF8.GetBytes(message);

                        channel.BasicPublish(exchange: "",
                                             routingKey: name,
                                             basicProperties: null,
                                             body: body);
                    }
                    return Ok();
                }
            }
        }

        public class ChannelForm
        {
            public string channelTitle { get; set; }
            public string channelDescription { get; set; }
        }

        public class ChannelLiveStatus
        {
            public string channelStatus { get; set; }
            //public int usersCount { get; set; }
            public string currentMediaId { get; set; }
            public string currentMediaTitle { get; set; }
            public string nextMediaId { get; set; }
            public string nextMediaTitle { get; set; }
            public DateTime? startDateUTC { get; set; }
            public int? currentMediaDuration { get; set; }
            public int mediaCountInPlaylist { get; set; }
        }


        public class ChannelControllerMessage
        {
            public Guid ChannelId { get; set; }
            public ChannelControllerMessageAction Action { get; set; }
        }

        public enum ChannelControllerMessageAction
        {
            START,
            STOP
        }
    }
}