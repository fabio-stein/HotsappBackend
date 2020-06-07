using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotsapp.WebStreamer.Service
{
    public class StreamWorkerFactory
    {
        private readonly IServiceProvider _serviceProvider;
        public StreamWorkerFactory(IServiceProvider sp)
        {
            _serviceProvider = sp;
        }

        public StreamWorker CreateWorker(string channelId)
        {
            var worker = _serviceProvider.GetRequiredService<StreamWorker>();
            worker.Initialize(channelId);
            return worker;
        }
    }
}
