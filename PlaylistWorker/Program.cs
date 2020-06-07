using Hotsapp.Data.Util;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using PlaylistWorker.Service;
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

                    services.Configure<HostOptions>(option =>
                    {
                        option.ShutdownTimeout = System.TimeSpan.FromSeconds(20);
                    });
                }).UseSerilog();
    }
}
