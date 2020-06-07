using Hotsapp.Data.Util;
using Hotsapp.WebStreamer.Hubs;
using Hotsapp.WebStreamer.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Serilog;

namespace Hotsapp.WebStreamer
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;

            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .WriteTo.Console()
                .CreateLogger();
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();
            services.AddSignalR();

            services.AddTransient<StreamWorker>();
            services.AddSingleton<StreamWorkerFactory>();

            services.AddSingleton<MessagingService>();
            services.AddHostedService(sp => sp.GetRequiredService<MessagingService>());

            //Create a HostedService in a way that we can use it in DI
            services.AddSingleton<StreamerService>();
            services.AddHostedService(sp => sp.GetRequiredService<StreamerService>());

            services.AddDataFactory(Configuration.GetConnectionString("MySql"));
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseCors(options =>
                options.AllowAnyMethod()
                        .AllowAnyHeader()
                        .AllowCredentials()
                        .SetIsOriginAllowed((a) => { return true; }));

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
                endpoints.MapHub<StreamHub>("/streamhub");
            });
        }
    }
}
