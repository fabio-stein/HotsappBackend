using Hotsapp.Data.Model;
using Hotsapp.Data.Util;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Serilog.Context;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;

namespace Hotsapp.ServiceManager.Services
{
    public class NumberManager
    {
        public string currentNumber = null;
        private string yowsupConfigPath;
        private ILogger<NumberManager> _log;
        public NumberManager(IConfiguration config, ILogger<NumberManager> log)
        {
            _log = log;
            yowsupConfigPath = config["YowsupExtractPath"];
            Directory.CreateDirectory(yowsupConfigPath);//Create if not exists
        }
        public async Task<string> TryAllocateNumber()
        {
            using(var context = DataFactory.GetNumberContext())
            {
                var number = await context.TryAllocateNumber();
                currentNumber = number;
                return number;
            }
        }

        public async Task SetNumberError(string errorCode)
        {
            _log.LogInformation("Saving error in number status");
            using (var context = DataFactory.GetContext())
            {
                var number = context.VirtualNumber.Where(n => n.Number == currentNumber).FirstOrDefault();
                number.Error = errorCode;
                number.RetryCount++;
                await context.SaveChangesAsync();
            }
        }

        public async Task ClearNumberError()
        {
            _log.LogInformation("Clearing current error in number status");
            using (var context = DataFactory.GetContext())
            {
                var number = context.VirtualNumber.Where(n => n.Number == currentNumber).FirstOrDefault();
                number.Error = null;
                number.RetryCount = 0;
                await context.SaveChangesAsync();
            }
        }

        public void LoadData()
        {
            var data = GetNumberData();
            ExtractData(currentNumber, data);
        }

        public async Task SaveData()
        {
            _log.LogInformation("Saving data");
            var data = GetCompressedData(currentNumber);
            if (data.Length < 100)
            {
                _log.LogWarning("Data with size < 100 bytes - Ignoring save");
                return;
            }
            _log.LogInformation("Data compressed");
            using (var context = DataFactory.GetContext())
            {
                var numberData = new VirtualNumberData()
                {
                    InsertDateUtc = DateTime.UtcNow,
                    Number = currentNumber,
                    Data = data
                };
                context.VirtualNumberData.Add(numberData);
                await context.SaveChangesAsync();
            }
            _log.LogInformation("Data saved!");
        }

        public async Task PutCheck()
        {
            using (var context = DataFactory.GetContext())
            {
                var dbnumber = context.VirtualNumber.Where(n => n.Number == currentNumber).SingleOrDefault();
                dbnumber.LastCheckUtc = DateTime.UtcNow;
                await context.SaveChangesAsync();
            }
        }

        public async Task<bool> ShouldStop()
        {
            using (var context = DataFactory.GetContext())
            {
                var dbnumber = context.VirtualNumber.Where(n => n.Number == currentNumber).SingleOrDefault();
                return dbnumber.OwnerId == null || dbnumber.Error != null;
            }
        }

        public async Task ReleaseNumber()
        {
            await SaveData();
            using (var context = DataFactory.GetContext())
            {
                var number = context.VirtualNumber.Where(n => n.Number == currentNumber).SingleOrDefault();
                number.LastCheckUtc = null;
                await context.SaveChangesAsync();
            }
            var toDelete = yowsupConfigPath + currentNumber;
            currentNumber = null;
            Directory.Delete(toDelete, true);
        }

        private byte[] GetNumberData()
        {
            using (var context = DataFactory.GetContext())
            {
                var data = context.VirtualNumberData.Where(n => n.Number == currentNumber).OrderByDescending(n => n.InsertDateUtc).FirstOrDefault();
                return (data == null) ? null : data.Data;
            }
        }

        private void ExtractData(string number, byte[] data)
        {
            var zipPath = yowsupConfigPath + number + ".zip";
            File.WriteAllBytes(zipPath, data);
            ZipFile.ExtractToDirectory(zipPath, yowsupConfigPath+number, true);
            File.Delete(zipPath);
        }

        private byte[] GetCompressedData(string number)
        {
            DirectoryInfo from = new DirectoryInfo(yowsupConfigPath + number);
            using (var ms = new MemoryStream())
            {
                using (ZipArchive archive = new ZipArchive(ms, ZipArchiveMode.Create))
                {
                    foreach (FileInfo file in from.AllFilesAndFolders().Where(o => o is FileInfo).Cast<FileInfo>())
                    {
                        var relPath = file.FullName.Substring(from.FullName.Length + 1);
                        ZipArchiveEntry readmeEntry = archive.CreateEntryFromFile(file.FullName, relPath);
                    }
                }
                return ms.ToArray();
            }
        }
    }

    public static class FileExtensions
    {
        public static IEnumerable<FileSystemInfo> AllFilesAndFolders(this DirectoryInfo dir)
        {
            foreach (var f in dir.GetFiles())
                yield return f;
            foreach (var d in dir.GetDirectories())
            {
                yield return d;
                foreach (var o in AllFilesAndFolders(d))
                    yield return o;
            }
        }
    }
}
