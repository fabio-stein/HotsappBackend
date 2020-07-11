using Hotsapp.Data.Util;
using Hotsapp.PlaylistWorker.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Hotsapp.PlaylistWorker
{
    public class WorkerManager : BackgroundService
    {
        private readonly ILogger _log = Log.ForContext<WorkerManager>();
        private readonly PlaylistWorkerMessagingService _messagingService;
        private readonly PlaylistRepository _playlistService;
        private readonly ChannelWorkerFactory _channelWorkerFactory;
        private CancellationToken _ct;

        private List<ChannelWorker> workerList = new List<ChannelWorker>();
        private object _workerListLock = new object();

        public WorkerManager(PlaylistWorkerMessagingService messagingService, PlaylistRepository playlistService, ChannelWorkerFactory channelWorkerFactory)
        {
            _messagingService = messagingService;
            _playlistService = playlistService;
            _channelWorkerFactory = channelWorkerFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _ct = stoppingToken;

            await ResumeRunningChannels();
            RegisterPlaylistMessagingController();

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    await Task.Delay(10000, stoppingToken);
                    _log.Information("WorkerManager Up");
                }
                catch (Exception)
                {
                    _log.Information("Worker delay cancelled");
                }
            }

            _log.Information("Waiting workers to stop");
            var tasks = workerList.Select(w => w.Stop());
            await Task.WhenAll(tasks);
            _log.Information("All workers stopped");
        }

        private async Task ResumeRunningChannels()
        {
            _log.Information("Resuming already running channels");

            List<Guid> channelsToResume;
            using (var ctx = DataFactory.GetDataContext())
            {
                channelsToResume = await ctx.Channel.Where(c => c.Status == "RUNNING").Select(c => c.Id).ToListAsync();
            }

            await StartChannels(channelsToResume);
            _log.Information("Finished resuming channels");
        }

        private async Task StartChannels(List<Guid> channelIds)
        {
            foreach(var channel in channelIds.ToList())
            {
                lock (_workerListLock)
                {
                    if (workerList.Any(w => w.ChannelId == channel))
                    {
                        _log.Information("[{0}] Skipping channel already in list");
                        channelIds.Remove(channel);
                    }
                }
            }

            var runningMedia = (await _playlistService.LoadCurrentChannelMedia(channelIds)).ToList();

            if (runningMedia.Count > 0)
            {
                _log.Information("Resuming {0} channels with already running media", runningMedia.Count());
                foreach (var channel in runningMedia)
                {
                    var worker = _channelWorkerFactory.CreateWorker();
                    lock (_workerListLock)
                    {
                        workerList.Add(worker);
                    }
                    worker.LoadStatus(channel);
                    worker.Start(_ct, channel.ChannelId);
                }
            }

            var channelsToInitialize = channelIds.Where(c => !runningMedia.Any(m => m.ChannelId == c)).ToList();

            if (channelsToInitialize.Count > 0)
            {
                _log.Information("Starting {0} channels with new media", channelsToInitialize.Count);
                foreach (var channel in channelsToInitialize)
                {
                    var worker = _channelWorkerFactory.CreateWorker();
                    lock (_workerListLock)
                    {
                        workerList.Add(worker);
                    }
                    worker.Start(_ct, channel);
                }
            }
        }

        private async Task StopChannels(List<Guid> channelIds)
        {
            var workers = workerList.Where(w => channelIds.Contains(w.ChannelId)).ToList();
            foreach (var worker in workers)
            {
                try
                {
                    _ = Task.Run(async () =>
                      {
                          try
                          {
                              await worker.Stop();
                          }
                          catch (Exception e)
                          {
                              _log.Error(e, "[{0}] Failed to stop channel", worker.ChannelId);
                          }

                          lock (_workerListLock)
                          {
                              workerList.Remove(worker);
                          }
                          _log.Information("[{0}] Channel stopped", worker.ChannelId);
                      });
                }
                catch (Exception e)
                {
                    _log.Error(e, "[{0}] Failed to remove channel", worker.ChannelId);
                }
            }
        }

        private void RegisterPlaylistMessagingController()
        {
            _messagingService.OnChannelControllerMessage += (async (obj, message) =>
            {
                if (message.Action == PlaylistWorkerMessagingService.ChannelControllerMessageAction.START)
                {
                    _log.Information("[{0}] Received message to start channel", message.ChannelId);
                    await StartChannels(new List<Guid>() { message.ChannelId });
                }
                else if (message.Action == PlaylistWorkerMessagingService.ChannelControllerMessageAction.STOP)
                {
                    _log.Information("[{0}] Received message to stop channel", message.ChannelId);
                    await StopChannels(new List<Guid>() { message.ChannelId });
                }
            });
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
