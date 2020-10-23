using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace WaClient.Worker.Worker
{
    public class PhoneWorkerFactory
    {
        private readonly IServiceProvider _serviceProvider;
        public PhoneWorkerFactory(IServiceProvider sp)
        {
            _serviceProvider = sp;
        }

        public PhoneWorker CreateWorker()
        {
            var worker = _serviceProvider.GetRequiredService<PhoneWorker>();
            return worker;
        }
    }
}
