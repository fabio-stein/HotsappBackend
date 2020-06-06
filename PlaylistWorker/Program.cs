using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Hotsapp.Data.Util;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using PlaylistWorker.Service;
using RabbitMQ.Client;
using Serilog;

namespace PlaylistWorker
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureServices((hostContext, services) =>
                {
                    var sp = services.BuildServiceProvider();
                    var config = sp.GetRequiredService<IConfiguration>();
                    DataFactory.Initialize(sp, config.GetConnectionString("MySql"));

                    Log.Logger = new LoggerConfiguration()
                        .Enrich.FromLogContext()
                        .WriteTo.Console()
                        .CreateLogger();

                    services.AddSingleton<PlaylistService>();
                    services.AddSingleton<MessagingService>();
                    services.AddTransient<ChannelWorker>();
                    services.AddSingleton<ChannelWorkerFactory>();
                    services.AddHostedService(sprovider => sprovider.GetRequiredService<MessagingService>());
                    services.AddHostedService<Worker>();
                }).UseSerilog();
    }
}
