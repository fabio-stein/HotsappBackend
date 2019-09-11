using Microsoft.Extensions.DependencyInjection;
using System;

namespace Hotsapp.ServiceManager.Util
{
    public class DIConfig
    {
        private static IServiceProvider _serviceProvider;
        public static void Setup(IServiceProvider serviceProvider) {
            _serviceProvider = serviceProvider;
        }
        public static T GetSetvice<T>() => _serviceProvider.GetService<T>();
    }
}
