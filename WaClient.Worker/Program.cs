using Hotsapp.Data.Util;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Exceptions;
using Serilog.Extensions.Logging;
using System;
using System.Linq;
using System.Threading.Tasks;
using WaClient.Connector;

namespace WaClient.Worker
{
    class Program
    {
        async static Task Main(string[] args)
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
            .Enrich.WithExceptionDetails()
            .WriteTo.Console()
            .CreateLogger();

        services.Configure<HostOptions>(option =>
        {
            option.ShutdownTimeout = System.TimeSpan.FromSeconds(20);
        });

        services.AddHostedService<DevService>();
    }).UseSerilog();

    }
}
