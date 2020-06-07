using Microsoft.Extensions.DependencyInjection;
using System;

namespace PlaylistWorker
{
    public class ChannelWorkerFactory
    {
        private readonly IServiceProvider _serviceProvider;
        public ChannelWorkerFactory(IServiceProvider sp)
        {
            _serviceProvider = sp;
        }

        public ChannelWorker CreateWorker()
        {
            var worker = _serviceProvider.GetRequiredService<ChannelWorker>();
            return worker;
        }
    }
}
