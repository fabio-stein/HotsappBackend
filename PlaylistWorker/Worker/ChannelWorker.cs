using Hotsapp.Data.Util;
using Microsoft.EntityFrameworkCore;
using Newtonsoft.Json;
using PlaylistWorker.Service;
using Serilog;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace PlaylistWorker
{
    public class ChannelWorker
    {
        private ILogger _log = Log.ForContext<ChannelWorker>();
        private PlayModel _status;
        private CancellationToken _ct;
        private CancellationTokenSource _cts;
        private readonly PlaylistService _playlistService;
        private readonly MessagingService _messagingService;
        private Task runningTask;
        private Guid _channelId;

        public ChannelWorker(PlaylistService playlistService, MessagingService messagingService)
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
                    _channelId = channelId;

                    _cts = CancellationTokenSource.CreateLinkedTokenSource(ct);
                    _ct = _cts.Token;

                    if (_status == null)
                    {
                        _log.Information("[{0}] Channel status is stopped, trying to initialize", _channelId);
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
                            _log.Information("ChannelWorker delay cancelled");
                        }
                        if (_ct.IsCancellationRequested)
                            break;
                        await PlayNext();
                    }

                    _log.Information("Channel [{0}] stopped", channelId);
                }
                catch (Exception e)
                {
                    _log.Error(e, "Error in channel worker");
                    _ = Stop();
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
            _log.Information("[{0}] Executing next item in playlist", _channelId);
            var result = await _playlistService.PlayNext(_channelId);
            _status = result;
            if (result == null)
            {
                _log.Information("[{0}] No more items in playlist, stopping channel", _channelId);
                await StopEmptyChannel();
                return false;
            }
            else
            {
                _log.Information("[{0}] Playing media id: {1}, duration: {2}", _channelId, _status.MediaId, _status.Duration);
                await PublishPlayEvent();
                return true;
            }
        }

        private async Task StopEmptyChannel()
        {
            using (var ctx = DataFactory.GetDataContext())
            {
                var channel = await ctx.Channel.FirstOrDefaultAsync(c => c.Id == _channelId);
                channel.Status = "STOPPED";
                await ctx.SaveChangesAsync();
            }
            await Stop();
        }

        private async Task PublishPlayEvent()
        {
            _log.Information("[{0}] Sending MessageEvent", _channelId);
            var data = JsonConvert.SerializeObject(_status);
            _messagingService.PublishForTag(data, _channelId.ToString());
        }

        public async Task Stop()
        {
            _log.Information("Stopping channel [{0}]", _channelId);
            if (!_ct.IsCancellationRequested)
                _cts.Cancel();
            if (runningTask == null)
                return;
            await Task.WhenAll(runningTask);
        }
    }
}
