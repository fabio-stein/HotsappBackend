using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Hotsapp.ServiceManager.Services;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace Hotsapp.ServiceManager
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Task.Run(async () =>
            {
                await Task.Delay(5000);
                var updater = new ServiceUpdater();
                updater.Start();
                await Task.Delay(6000000);
            });
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>();
    }
}
