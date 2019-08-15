using Amazon;
using Amazon.S3;
using Amazon.S3.Transfer;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace StorageManger.Providers
{
    public class S3StorageProvider : IStorageProvider
    {
        AmazonS3Client client;
        TransferUtility transferUtility;
        String bucket { get; set; }

        public void Configure(Dictionary<string, string> options)
        {
            client = new AmazonS3Client(options["KEY_ID"], options["KEY_SECRET"], RegionEndpoint.SAEast1);
            bucket = options["AWS_BUCKET"];
            transferUtility = new TransferUtility(client);
        }

        public Task DeleteAsync(string key)
        {
            return client.DeleteObjectAsync(bucket, key);
        }

        public async Task UploadAsync(Stream stream, String key)
        {
            var req = new TransferUtilityUploadRequest();
            req.CannedACL = S3CannedACL.PublicRead;
            req.InputStream = stream;
            req.Key = key;
            req.BucketName = bucket;
            await transferUtility.UploadAsync(req);
        }
    }
}
