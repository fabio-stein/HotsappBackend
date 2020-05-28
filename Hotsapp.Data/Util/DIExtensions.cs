using Hotsapp.Data.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotsapp.Data.Util
{
    public static class DIExtensions
    {
        public static void AddDataFactory(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<DataContext>(options => options.UseMySql(connectionString));
            var sp = services.BuildServiceProvider();
            services.AddSingleton(new DataFactory(sp, connectionString));
        }
    }
}
