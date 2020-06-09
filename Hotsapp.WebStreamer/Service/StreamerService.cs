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
        private readonly object _workersLock = new object();
        private Dictionary<string, StreamWorker> workers = new Dictionary<string, StreamWorker>();
        private readonly StreamWorkerFactory _streamWorkerFactory;
        private readonly IHostEnvironment _environment;
        private bool isShuttingDown = false;
        private readonly StatusUpdaterService _statusUpdaterService;

        public StreamerService(StreamWorkerFactory streamWorkerFactory, IHostEnvironment environment)
        {
            _streamWorkerFactory = streamWorkerFactory;
            _environment = environment;
            _statusUpdaterService = new StatusUpdaterService(this);
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _log.Information("Starting StreamerService");
            _ = _statusUpdaterService.Run(cancellationToken);
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            _log.Information("Received request to stop StreamerService");
            _statusUpdaterService.Stop();
            if (_environment.IsProduction())
            {
                _log.Information("Graceful stop requested, waiting 5s before stopping services");
                isShuttingDown = true;
                await Task.Delay(5000);
            }
            else
            {
                _log.Information("Skipping graceful stop on Debug mode");
            }

            _log.Information("Stopping StreamerService");
            var stopTasks = workers.Select(w => w.Value.StopStream());
            await Task.WhenAll(stopTasks);
            _log.Information("All workers stopped");
        }

        public async Task<bool> RegisterClient(string channelId, HubCallerContext context, IStreamHub client)
        {
            _log.Information("[{0}] Registering client on channel [{1}]", context.ConnectionId, channelId);
            //TODO CHECK IF WE CAN ACCEPT {channelid}

            if (isShuttingDown)
            {
                _log.Information("[{0}] Couldn't register client on channel [{1}], system are shutting down", context.ConnectionId, channelId);
                return false;
            }

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
            if (result != null)
            {
                await result.RemoveClient(connectionId);
            }
        }

        public async Task StopWorker(string channelId)
        {
            StreamWorker worker = null;
            lock (_workersLock)
            {
                if (workers.ContainsKey(channelId))
                {
                    worker = workers[channelId];
                    workers.Remove(channelId);
                }
            }

            if(worker != null)
                await worker.StopStream();
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

        public Dictionary<string, int> GetConnectionStatus()
        {
            var status = new Dictionary<string, int>();
            workers.ToList().ForEach(w => status.Add(w.Key, w.Value.ClientsCount));
            return status;
        }
    }
}
