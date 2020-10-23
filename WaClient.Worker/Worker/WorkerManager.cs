using Hotsapp.Data.Model;
using Hotsapp.Data.Util;
using Microsoft.Extensions.Hosting;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace WaClient.Worker.Worker
{
    public class WorkerManager : BackgroundService
    {
        private readonly ILogger _log = Log.ForContext<WorkerManager>();
        private CancellationToken _ct;
        private PhoneWorkerFactory _phoneWorkerFactory;

        public List<PhoneWorker> workers = new List<PhoneWorker>();

        public WorkerManager(PhoneWorkerFactory phoneWorkerFactory)
        {
            _phoneWorkerFactory = phoneWorkerFactory;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            _ct = stoppingToken;

            await ResumeWorkers();

            while (!stoppingToken.IsCancellationRequested)
            {
                try
                {
                    await Task.Delay(10000, stoppingToken);
                    _log.Information("WorkerManager Up");
                }
                catch (Exception)
                {
                    _log.Information("Worker delay cancelled");
                }
            }

            _log.Information("Waiting workers to stop");
            var tasks = workers.Select(w => w.Stop());
            await Task.WhenAll(tasks);
            _log.Information("All workers stopped");
        }

        private async Task ResumeWorkers()
        {
            List<WaPhone> phones;
            using(var ctx = DataFactory.GetDataContext())
            {
                phones = ctx.WaPhone.Where(p => p.IsConnected).ToList();
            }
            phones.ForEach(p =>
            {
                var worker = _phoneWorkerFactory.CreateWorker();
                workers.Add(worker);
                worker.Start(p, _ct);
            });
        }
    }
}
