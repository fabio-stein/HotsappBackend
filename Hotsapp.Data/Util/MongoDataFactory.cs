using Microsoft.Extensions.DependencyInjection;
using MongoDB.Driver;
using System;

namespace Hotsapp.Data.Util
{
    public class MongoDataFactory
    {
        private static string _connectionString { get; set; }
        private static ServiceProvider _serviceProvider { get; set; }
        private static IMongoDatabase _db;

        public static void Initialize(ServiceProvider serviceProvider, string connectionString)
        {
            _connectionString = connectionString;
            _serviceProvider = serviceProvider;

            var client = new MongoClient(_connectionString);
            _db = client.GetDatabase("youtube");
        }

        public static IMongoDatabase GetYoutubeDb()
        {
            if (_db == null)
                throw new Exception("Mongo client not configured");

            return _db;
        }
    }
}
