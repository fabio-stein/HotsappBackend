using Amazon;
using Amazon.S3;
using Amazon.S3.Transfer;
using StorageManger.Providers;
using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace StorageManger
{
    public class StorageProviderService
    {
        public static IStorageProvider ConfigureProvider(STORAGE_PROVIDER provider, dynamic options)
        {
            switch (provider)
            {
                case STORAGE_PROVIDER.AMAZON_S3:
                    var s = new S3StorageProvider();
                    s.Configure(options);
                    return s;
                default:
                    throw new Exception("Invalid Provider");
            }
        }
    }
}
