using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WhatsTroll.Api.Hubs;
using WhatsTroll.Api.Hubs.PlayerHub;
using WhatsTroll.Data.Model;

namespace WhatsTroll.Api.Services
{
    public class ChannelWorkerService
    {
        public List<ChannelWorker> workers = new List<ChannelWorker>();
        public object _workersLock = new object();

        IHubContext<PlayerHub> playerHub;
        ILogger<ChannelWorkerService> logger;
        ILogger<ChannelWorker> workerLogger;
        public ChannelWorkerService(IHubContext<PlayerHub> playerHub, ILogger<ChannelWorkerService> _logger, ILogger<ChannelWorker> workerLogger)
        {
            this.playerHub = playerHub;
            logger = _logger;
            this.workerLogger = workerLogger;
        }
        public void StartWorkers()
        {
            using(var context = new DataContext())
            {
                var runningList = context.PlaylistMedia.Where(t => t.StartDateUtc!=null && t.EndDateUtc == null)
                    .Include(t => t.Channel)
                    .Include(t => t.Media)
                    .ToList();
                foreach(var item in runningList){
                    Task.Run(() =>
                    {
                        logger.LogInformation($"Starting new worker - Count: {workers.Count+1}");
                        lock (_workersLock)
                        {
                            var worker = new ChannelWorker(workerLogger, item.Channel, playerHub, this);
                            workers.Add(worker);
                            worker.OnResume(item);
                        }
                    });
                }
            }
        }

        public void StartChannelWorker(int channel)
        {
            //Already started
            if(workers.Where(w => w.channel.Id == channel).Count() > 0)
            {
                return;
            }
            using (var context = new DataContext())
            {
                var item = context.Channel.Where(c => c.Id == channel).SingleOrDefault();
                Task.Run(() =>
                {
                    logger.LogInformation($"Starting new worker ({workers.Count + 1})");
                    lock (_workersLock)
                    {
                        var worker = new ChannelWorker(workerLogger, item, playerHub, this);
                        workers.Add(worker);
                        worker.StartWorker();
                    }
                });
            }
        }

        public Task RequestWorkerStop(int channel)
        {
            return Task.Run(() =>
            {
                var active = workers.Where(w => w.channel.Id == channel);
                for (int i = 0; i < workers.Count; i++)
                {
                    var worker = workers[i];
                    logger.LogInformation($"Stopping worker ({workers.Count})");
                    worker.RequestStop();
                }
            });
        }

        public void StopWorker(int channel)
        {
            var active = workers.Where(w => w.channel.Id == channel);
            for(int i = 0; i < workers.Count; i++)
            {
                logger.LogInformation($"Worker stopped ({workers.Count - 1})");
                lock (_workersLock)
                {
                    var worker = workers[i];
                    workers.RemoveAt(i);
                    i--;
                }
            }
        }
    } 
}
