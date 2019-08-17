using Microsoft.Extensions.Configuration;
using StorageManger;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Sonoris.Api.Services.Storage
{
    public class StorageService
    {
        public IStorageProvider provider { get; set; }
        public StorageService()
        {
            var config = new ConfigurationBuilder()
             .AddJsonFile("config.json")
             .Build();
            var options = new Dictionary<string, string>
            {
                { "KEY_ID",  config["AWS_KEY_ID"] },
                { "KEY_SECRET", config["AWS_KEY_SECRET"] }
            };

            provider = StorageProviderService.ConfigureProvider(STORAGE_PROVIDER.AMAZON_S3, options);
        }
    }
}
