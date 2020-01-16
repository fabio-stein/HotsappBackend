using Hotsapp.ServiceManager.Services;
using Hotsapp.Data.Util;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using Hotsapp.Data.Model;
using Hotsapp.ServiceManager.Util;
using Serilog;
using Serilog.Sinks.Elasticsearch;
using Microsoft.Extensions.Logging;
using Serilog.Exceptions;

namespace Hotsapp.ServiceManager
{
    public class Startup
    {
        private readonly IHostingEnvironment _env;
        private readonly IConfiguration _config;
        ILogger<Startup> _logger;

        public Startup(IHostingEnvironment env, IConfiguration config,
            ILogger<Startup> logger)
        {
            _env = env;
            _config = config;
            _logger = logger;

            var elasticUri = config["ElasticSearchConfiguration:Uri"];

            Log.Logger = new LoggerConfiguration()
                .Enrich.FromLogContext()
                .Enrich.WithExceptionDetails()
                .WriteTo.Elasticsearch(new ElasticsearchSinkOptions(new Uri(elasticUri))
                {
                    AutoRegisterTemplate = true,
                })
            .CreateLogger();
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var connectionString = _config.GetConnectionString("MySqlConnectionString");
            new DataFactory(connectionString);
            /*var builder = new DbContextOptionsBuilder<DataContext>();
            builder.UseMySQL(connectionString);
            services.AddSingleton(new DataContext(builder.Options));*/
            services.AddDbContext<DataContext>(options => options.UseMySql(connectionString));
            services.AddSingleton<ProcessManager>();
            services.AddSingleton<PhoneService>();
            services.AddHostedService<ServiceUpdater>();
            services.AddSingleton<NumberManager>();
            services.AddHostedService<GCService>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider, ILoggerFactory loggerFactory)
        {
            DIConfig.Setup(serviceProvider);
            loggerFactory.AddSerilog();
            _logger.LogInformation("Teste msg");
        }
    }
}
