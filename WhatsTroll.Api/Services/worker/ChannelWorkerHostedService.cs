using Microsoft.AspNetCore.SignalR;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using WhatsTroll.Api.Hubs;
using WhatsTroll.Api.Hubs.PlayerHub;

namespace WhatsTroll.Api.Services
{
    public class ChannelWorkerHostedService : IHostedService, IDisposable
    {
        private readonly IHubContext<PlayerHub> _playerHub;
        private readonly ILogger _logger;
        ChannelWorkerService _manager;

        public ChannelWorkerHostedService(ILogger<ChannelWorkerHostedService> logger, IHubContext<PlayerHub> playerHub, ChannelWorkerService manager)
        {
            _playerHub = playerHub;
            _logger = logger;
            _manager = manager;
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            return Task.Run(() => { _manager.StartWorkers(); });
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            //return _service.StopAsync(cancellationToken);
            return null;
        }

        public void Dispose()
        {
            //_service.Dispose();
        }
    }
}
