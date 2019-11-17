using Hotsapp.Data.Model;
using Hotsapp.Data.Util;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.IO.Compression;
using System.Linq;
using System.Threading.Tasks;

namespace Hotsapp.Connector.Services
{
    public class NumberManager
    {
        public string currentFlowId = null;
        public ConnectionFlow currentFlow = null;
        private string yowsupConfigPath;
        public NumberManager(IConfiguration config)
        {
            yowsupConfigPath = config["YowsupExtractPath"];
            Directory.CreateDirectory(yowsupConfigPath);//Create if not exists
        }
        public async Task<string> TryGetFlow()
        {
            using(var context = DataFactory.GetConnectionFlowContext())
            {
                var flowId = await context.TryGetFlow();
                currentFlowId = flowId;
                return flowId;
            }
        }

        public async Task SaveData()
        {
            var data = GetCompressedData(currentFlow.PhoneNumber);
            using (var context = DataFactory.GetContext())
            {
                var numberData = new VirtualNumberData()
                {
                    InsertDateUtc = DateTime.UtcNow,
                    Number = currentFlow.PhoneNumber,
                    Data = data
                };
                context.VirtualNumberData.Add(numberData);
                await context.SaveChangesAsync();
            }
        }

        public async Task<bool> ShouldStop()
        {
            using (var context = DataFactory.GetContext())
            {
                if (currentFlow.IsActive != null && currentFlow.IsActive == false)
                    return true;
                return false;
            }
        }

        public async Task SaveNumber()
        {
            await SaveData();
            using (var context = DataFactory.GetContext())
            {
                var number = context.VirtualNumber.Where(n => n.Number == currentFlow.PhoneNumber).SingleOrDefault();
                number.LastCheckUtc = null;
                await context.SaveChangesAsync();
            }
            var toDelete = yowsupConfigPath + currentFlow.PhoneNumber;
            Directory.Delete(toDelete, true);
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
