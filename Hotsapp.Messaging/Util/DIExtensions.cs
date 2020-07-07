using Hotsapp.Messaging;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Hotsapp
{
    public static class DIExtensions
    {
        public static void AddMessaging(this IServiceCollection services, string connectionString)
        {
            services.AddSingleton(new MessagingService(connectionString));
            services.AddHostedService(sp => sp.GetRequiredService<MessagingService>());

            var sp = services.BuildServiceProvider();
            MessagingFactory.Initialize(sp.GetRequiredService<MessagingService>());
        }
    }
}
