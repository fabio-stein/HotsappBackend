using Hotsapp.ServiceManager.Services;
using Hotsapp.ServiceManager.Util;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using System.Threading;
using System.Threading.Tasks;
using Hotsapp.Data.Model;

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
        }

        public void ConfigureServices(IServiceCollection services)
        {
                        var connectionString = _config.GetConnectionString("MySqlConnectionString");

            /*var builder = new DbContextOptionsBuilder<DataContext>();
            builder.UseMySQL(connectionString);
            services.AddSingleton(new DataContext(builder.Options));*/
            services.AddDbContext<DataContext>(options => options.UseMySQL(connectionString));
            services.AddSingleton<ServiceUpdater>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env, IServiceProvider serviceProvider)
        {
            DIConfig.Setup(serviceProvider);
        }
    }
}
