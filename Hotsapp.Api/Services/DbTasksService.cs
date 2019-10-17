using Dapper;
using Hotsapp.Data.Util;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Hotsapp.Api.Services
{
    public class DbTasksService : IHostedService, IDisposable
    {
        private Timer _timer;

        public DbTasksService()
        {

        }

        public Task StartAsync(CancellationToken stoppingToken)
        {
            Console.WriteLine("Starting DbTasksService");

            _timer = new Timer(RunTasks, null, TimeSpan.Zero,
                TimeSpan.FromSeconds(1));

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken stoppingToken)
        {
            Console.WriteLine("Stopping DbTasksService");

            _timer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }

        private void RunTasks(object state)
        {
            using(var conn = DataFactory.OpenConnection())
            {
                conn.Query(@"UPDATE virtual_number vn
  LEFT JOIN number_period np ON (np.StartDateUTC <= UTC_TIMESTAMP() AND (np.EndDateUTC IS NULL OR np.EndDateUTC >= UTC_TIMESTAMP()))
  SET vn.CurrentOwnerId = np.UserId");
            }
        }

    }
}
