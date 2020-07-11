using Hotsapp.Data.Util;
using Hotsapp.PlaylistWorker.Service;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Hotsapp.PlaylistWorker
{
    public class ChannelWorker
    {
        private ILogger _log = Log.ForContext<ChannelWorker>();
        private PlayModel _status;
        private CancellationToken _ct;
        private CancellationTokenSource _cts;
        private readonly PlaylistRepository _playlistService;
        private readonly PlaylistWorkerMessagingService _messagingService;
        private Task runningTask;
        public Guid ChannelId { get; private set; }

        public ChannelWorker(PlaylistRepository playlistService, PlaylistWorkerMessagingService messagingService)
        {
            _playlistService = playlistService;
            _messagingService = messagingService;
        }

        public void LoadStatus(PlayModel status)
        {
            _status = status;
            _log.ForContext("channelId", _status.ChannelId)
                .Information("[{0}] Loading channel status", _status.ChannelId);
        }

        public void Start(CancellationToken ct, Guid channelId)
        {
            runningTask = Task.Run(async () =>
            {
                try
                {
                    _log = _log.ForContext("channelId", channelId);
                    _log.Information("[{0}] Starting channel", channelId);
                    ChannelId = channelId;

                    _cts = CancellationTokenSource.CreateLinkedTokenSource(ct);
                    _ct = _cts.Token;

                    if (_status == null)
                    {
                        _log.Information("[{0}] Channel status is stopped, trying to initialize", ChannelId);
                        await InitializeChannel(channelId);
                    }
                    else
                    {
                        _log.Information("[{0}] Channel already running, resuming media: {1}, duration: {2}", _status.ChannelId, _status.MediaId, _status.Duration);
                    }

                    while (!_ct.IsCancellationRequested)
                    {
                        var endDate = _status.StartDateUTC.AddSeconds(_status.Duration);
                        var remainingTime = (int)(endDate - DateTime.UtcNow).TotalSeconds * 1000;
                        if (remainingTime < 0)
                            remainingTime = 0;
                        try
                        {
                            await Task.Delay(remainingTime, _ct);
                        }
                        catch (OperationCanceledException e)
                        {
                            _log.Information("[{0}] ChannelWorker delay cancelled", ChannelId);
                        }
                        if (_ct.IsCancellationRequested)
                            break;
                        if (!await PlayNext())
                            _log.Information("[{0}] Stopped due to false return on PlayNext()", ChannelId);
                    }

                    _log.Information("[{0}] Task Finished", channelId);
                }
                catch (Exception e)
                {
                    _log.Error(e, "Error in channel worker");
                    StopInternal();
                }
            });
        }

        private async Task InitializeChannel(Guid channelId)
        {
            _log.Information("[{0}] Initializing channel", channelId);
            if (await PlayNext())
            {
                using (var ctx = DataFactory.GetDataContext())
                {
                    var channel = await ctx.Channel.FirstOrDefaultAsync(c => c.Id == channelId);
                    channel.Status = "RUNNING";
                    await ctx.SaveChangesAsync();
                }
            }
        }

        private async Task<bool> PlayNext()
        {
            _log.Information("[{0}] Executing next item in playlist", ChannelId);
            PlayModel result = null;
            try
            {
                result = await _playlistService.PlayNext(ChannelId);
            }
            catch (Exception e)
            {
                _log.Information(e, "[{0}] Failed to load next playlist item, trying to restart channel", ChannelId);
                StopInternal();
                return false;
            }

            _status = result;

            if (result == null)
            {
                _log.Information("[{0}] Channel playlist is empty", ChannelId);
                await StopEmptyChannel();
                return false;
            }
            else
            {
                _log.Information("[{0}] Playing media id: {1}, duration: {2}", ChannelId, _status.MediaId, _status.Duration);
                await PublishPlayEvent();
                return true;
            }
        }

        private async Task StopEmptyChannel()
        {
            using (var ctx = DataFactory.GetDataContext())
            {
                var channel = await ctx.Channel.FirstOrDefaultAsync(c => c.Id == ChannelId);
                channel.Status = "STOPPED";
                await ctx.SaveChangesAsync();
            }
            StopInternal();
        }

        private async Task PublishPlayEvent()
        {
            _log.Information("[{0}] Sending MessageEvent", ChannelId);
            var data = JsonConvert.SerializeObject(_status);
            _messagingService.PublishPlayEvent(data, ChannelId.ToString());
        }

        //We should not wait Stop() inside worker, waiting here may cause infinite loop
        private void StopInternal()
        {
            _log.Information("[{0}] StopInternal()", ChannelId);
            _ = Stop();
        }

        //Should only be called from other classes
        public async Task Stop()
        {
            _log.Information("[{0}] Stopping channel", ChannelId);
            if (!_ct.IsCancellationRequested)
                _cts.Cancel();
            if (runningTask == null)
                return;
            await Task.WhenAll(runningTask);
        }
    }
}
