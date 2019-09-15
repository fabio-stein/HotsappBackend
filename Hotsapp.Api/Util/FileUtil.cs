using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Hotsapp.Api.Util
{
    public class FileUtil
    {
        public static FileStream ReceiveTempUploadedFile(IFormFile formFile)
        {
            var tempFilePath = Path.GetTempFileName();
            var temp = new FileStream(tempFilePath, FileMode.Create, FileAccess.ReadWrite, FileShare.None, 4096, FileOptions.DeleteOnClose);
            formFile.CopyTo(temp);
            return temp;
        }

        public static String SimpleMd5(Stream stream)
        {
            String hash;
            using (var md5 = MD5.Create())
            {
                var h = md5.ComputeHash(stream);
                hash = BitConverter.ToString(h).Replace("-", "").ToLower();
            }
            return hash;
        }
    }
}
