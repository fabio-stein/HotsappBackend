using Hotsapp.Data.Model;
using Hotsapp.Data.Util;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Hotsapp
{
    public static class DIExtensions
    {
        public static void AddData(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<DataContext>(options => options.UseMySql(connectionString,
                mySqlOptions =>
                {
                    mySqlOptions.EnableRetryOnFailure(
                    maxRetryCount: 10,
                    maxRetryDelay: TimeSpan.FromSeconds(30),
                    errorNumbersToAdd: null);
                }));
            var sp = services.BuildServiceProvider();
            services.AddSingleton(new DataFactory());
            DataFactory.Initialize(sp, connectionString);
        }

        public static void AddMongoDB(this IServiceCollection services, string connectionString)
        {
            var sp = services.BuildServiceProvider();
            services.AddSingleton(new MongoDataFactory());
            MongoDataFactory.Initialize(sp, connectionString);
        }
    }
}
