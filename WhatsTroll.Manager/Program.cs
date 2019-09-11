
using Renci.SshNet;
using Renci.SshNet.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using WhatsTroll.Data.Model;
using System.Linq;
using WhatsTroll.Data;
using Microsoft.Extensions.Configuration;

namespace WhatsTroll.Manager
{
    class Program
    {
        static async Task Main(string[] args)
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("");
            new DataFactory("server=localhost;port=3306;user=root;password=sonorisdev;database=whatstroll");
            var service = new ServiceUpdater();

            await Task.Delay(600000);
            return;
            var phone = new PhoneService();
            await phone.Start();
            await phone.Login();
            await phone.SendMessage("555599436679", "oieee");
            Thread.Sleep(50000);
        }
    }
}
