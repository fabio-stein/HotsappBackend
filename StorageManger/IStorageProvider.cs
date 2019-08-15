using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Threading.Tasks;

namespace StorageManger
{
    public interface IStorageProvider
    {
        void Configure(Dictionary<string, string> options);
        Task UploadAsync(Stream stream, String key);
        Task DeleteAsync(String key);
    }
}
