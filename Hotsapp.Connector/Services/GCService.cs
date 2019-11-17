using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Hotsapp.Connector.Services
{
    public class GCService : IHostedService, IDisposable
    {
        private Timer _timer;
        public Task StopAsync(CancellationToken cancellationToken)
        {
            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            _timer = new Timer(Collect, null, TimeSpan.Zero,
    TimeSpan.FromSeconds(10));
            return Task.CompletedTask;
        }

        private void Collect(object state)
        {
            GC.Collect();
        }
    }
}
