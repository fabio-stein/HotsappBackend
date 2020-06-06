using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using Hotsapp.Data.Model;
using Hotsapp.Data.Util;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using PlaylistWorker.Service;
using Serilog;

namespace PlaylistWorker
{
    public class Worker : BackgroundService
    {
        private readonly ILogger _log = Log.ForContext<Worker>();
        private readonly MessagingService _messagingService;
        private readonly PlaylistService _playlistService;
        private readonly ChannelWorkerFactory _channelWorkerFactory;
        private CancellationToken _ct;
        private List<ChannelWorker> workerList = new List<ChannelWorker>();

        private List<Guid> channels;

        public Worker(MessagingService messagingService, PlaylistService playlistService, ChannelWorkerFactory channelWorkerFactory)
        {
            _messagingService = messagingService;
            _playlistService = playlistService;
            _channelWorkerFactory = channelWorkerFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _ct = stoppingToken;
            await StartRunningChannels();
            while (!stoppingToken.IsCancellationRequested)
            {
/*                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);
                await _messagingService.PublishForTag(DateTime.UtcNow.ToString(), "dev");
                await _playlistService.PlayNext(new Guid("1e602dbd-a6cc-11ea-87a6-02dd375f4dba"));*/
                try
                {
                    await Task.Delay(5000, stoppingToken);
                }catch(Exception e)
                {
                    _log.Information("Worker delay cancelled");
                }
            }

            _log.Information("Waiting workers to stop");
            var tasks = workerList.Select(w => w.Stop());
            await Task.WhenAll(tasks);
            _log.Information("All workers stopped");
        }

        private async Task StartRunningChannels()
        {
            _log.Information("Starting already running channels");
            using(var ctx = DataFactory.GetDataContext())
            {
                channels = await ctx.Channel.Where(c => c.Status == "RUNNING").Select(c => c.Id).ToListAsync();
            }
            var runningMedia = await _playlistService.LoadCurrentChannelMedia(channels);

            _log.Information("Resuming {0} channels with already running media", runningMedia.Count());
            foreach (var channel in runningMedia)
            {
                var worker = _channelWorkerFactory.CreateWorker();
                workerList.Add(worker);
                worker.LoadStatus(channel);
                worker.Start(_ct, channel.ChannelId);
            }

            var pendingChannels = channels.Where(c => !runningMedia.Any(m => m.ChannelId == c)).ToList();

            _log.Information("Starting {0} channels with new media", pendingChannels.Count);
            foreach (var channel in pendingChannels)
            {
                var worker = _channelWorkerFactory.CreateWorker();
                workerList.Add(worker);
                worker.Start(_ct, channel);
            }
        }
    }

    public class PlayModel
    {
        public Guid ChannelId { get; set; }
        public string MediaId { get; set; }
        public DateTime StartDateUTC { get; set; }
        public int Duration { get; set; }
    }
}
