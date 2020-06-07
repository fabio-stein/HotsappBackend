using Hotsapp.Data.Model;
using Hotsapp.Data.Util;
using Hotsapp.WebStreamer.Hubs;
using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Hotsapp.WebStreamer.Service
{
    public class StreamerService : IHostedService
    {
        private readonly ILogger _log = Log.ForContext<StreamerService>();
        private readonly IHubContext<StreamHub, IStreamHub> _hub;
        private readonly object _workersLock = new object();
        private Dictionary<string, StreamWorker> workers = new Dictionary<string, StreamWorker>();
        private readonly StreamWorkerFactory _streamWorkerFactory;

        public StreamerService(IHubContext<StreamHub, IStreamHub> hub, StreamWorkerFactory streamWorkerFactory)
        {
            _hub = hub;
            _streamWorkerFactory = streamWorkerFactory;
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _log.Information("Starting StreamerService");
            using(var ctx = DataFactory.GetDataContext())
            {
                ctx.Streamer.Add(new Streamer()
                {
                    Id = Guid.NewGuid(),
                    IsActive = true,
                    LastPingUTC = DateTime.UtcNow,
                    StartDateUTC = DateTime.UtcNow
                });
                await ctx.SaveChangesAsync();
            }
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            _log.Information("Starting StreamerService");
        }

        public async Task<bool> RegisterClient(string channelId, HubCallerContext context, IStreamHub client)
        {
            _log.Information("[{0}] Registering client on channel [{1}]", context.ConnectionId, channelId);
            //TODO CHECK IF WE CAN ACCEPT {channelid}
            var isNewWorker = false;
            lock (_workersLock)
            {
                if (!workers.ContainsKey(channelId))
                {
                    isNewWorker = true;
                    var worker = _streamWorkerFactory.CreateWorker(channelId);
                    workers.Add(channelId, worker);
                }
            }

            await workers[channelId].AddClient(context, client);

            if (isNewWorker)
                _ = workers[channelId].StartStream();

            return true;
        }

        public async Task UnRegisterClient(string connectionId)
        {
            var result = FindClientWorker(connectionId);
            if(result != null)
            {
                await result.RemoveClient(connectionId);
            }
        }

        private StreamWorker FindClientWorker(string connectionId)
        {
            return workers.FirstOrDefault(w =>
            {
                try
                {
                    if (w.Value.ClientExists(connectionId))
                        return true;
                }
                catch (Exception e)
                {
                    _log.Information(e, "FindClientWorker error");
                }
                return false;
            }).Value;
        }

        public async Task LoopStart()
        {
            while (true)
            {
                await PlayVideo();
                await Task.Delay(5000);
            }
        }


        private async Task PlayVideo()
        {
            _log.Information("Sending PlayVideoEvent");
            await _hub.Clients.All.PlayEvent(new
            {
                videoId = GetVideo()
            });
        }


        private string GetVideo()
        {
            var dev = new string[]
            {
                "Gp-lWgUDcKk",
"Tx9zMFodNtA",
"GAly0cOLMc8",
"Zy4KtD98S2c",
"8ATu1BiOPZA",
"WsWmlhiHe-Q"
            };
            var index = new Random().Next(0, dev.Length);
            return dev[index];
        }
    }
}
