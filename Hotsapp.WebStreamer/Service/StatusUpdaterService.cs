using Hotsapp.Data.Model;
using Hotsapp.Data.Util;
using Newtonsoft.Json;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Hotsapp.WebStreamer.Service
{
    public class StatusUpdaterService
    {
        private readonly ILogger _log = Log.ForContext<StatusUpdaterService>();
        private Streamer streamer;
        private CancellationToken _ct;
        private CancellationTokenSource _cts;
        private readonly StreamerService _streamerService;

        public StatusUpdaterService(StreamerService streamerService)
        {
            _streamerService = streamerService;
        }

        public async Task Run(CancellationToken stoppingToken)
        {
            _log.Information("Starting StatusUpdaterService");

            _cts = CancellationTokenSource.CreateLinkedTokenSource(stoppingToken);
            _ct = _cts.Token;

            await RegisterStreamer();
            try
            {
                while (!_ct.IsCancellationRequested)
                {
                    await SendPing();
                    await Task.Delay(5000, _ct);
                }
            }
            catch (OperationCanceledException)
            {
                _log.Information("SendPing Cancelled");
            }
            _log.Information("Stopping StatusUpdaterService");
            await SendStopSignal();
        }

        public void Stop()
        {
            _cts.Cancel();
        }

        private async Task RegisterStreamer()
        {
            _log.Information("[StatusUpdater] Registering new Streamer");
            using (var ctx = DataFactory.GetDataContext())
            {
                streamer = new Streamer()
                {
                    Id = Guid.NewGuid(),
                    IsActive = true,
                    LastPingUTC = DateTime.UtcNow,
                    StartDateUTC = DateTime.UtcNow
                };
                ctx.Streamer.Add(streamer);
                await ctx.SaveChangesAsync();
            }
        }

        private async Task SendPing()
        {
            _log.Information("[StatusUpdater] Send Ping");

            var status = _streamerService.GetConnectionStatus();

            await StopEmptyWorkers(status);

            var channelCount = status.Count;
            var clientsCount = status.Sum(s => s.Value);

            using (var ctx = DataFactory.GetDataContext())
            {
                streamer.LastPingUTC = DateTime.UtcNow;
                streamer.ActiveStreams = channelCount;
                streamer.ActiveClients = clientsCount;
                streamer.StreamsStatus = JsonConvert.SerializeObject(status);
                ctx.Streamer.Update(streamer);
                await ctx.SaveChangesAsync();
            }
        }

        private async Task StopEmptyWorkers(Dictionary<string, int> status)
        {
            var empty = status.Where(s => s.Value == 0).ToList();
            if (empty.Count == 0)
                return;

            _log.Information("Stopping {0} empty channel(s)", empty.Count);
            empty.ForEach(async c =>
            {
                try
                {
                    await _streamerService.StopWorker(c.Key);
                }
                catch (Exception e)
                {
                    _log.Error(e, "[{0}] Error stopping empty worker", c.Key);
                }
            });
        }

        private async Task SendStopSignal()
        {
            _log.Information("[StatusUpdater] Sending Stop Signal");
            using (var ctx = DataFactory.GetDataContext())
            {
                streamer.LastPingUTC = DateTime.UtcNow;
                streamer.IsActive = false;
                ctx.Streamer.Update(streamer);
                await ctx.SaveChangesAsync();
            }
        }
    }
}
