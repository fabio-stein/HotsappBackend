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
        private Timer _cleanerTimer;
        private IHostingEnvironment _env;

        public DbTasksService(IHostingEnvironment env)
        {
            _env = env;
        }

        public Task StartAsync(CancellationToken stoppingToken)
        {
            if (_env.IsDevelopment())
                return Task.CompletedTask;

            Console.WriteLine("Starting DbTasksService");

            _timer = new Timer(RunTasks, null, TimeSpan.Zero,
                TimeSpan.FromSeconds(1));
            _cleanerTimer = new Timer(CleanOldBackups, null, TimeSpan.Zero,
                TimeSpan.FromMinutes(1));

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken stoppingToken)
        {
            Console.WriteLine("Stopping DbTasksService");

            _timer?.Change(Timeout.Infinite, 0);
            _cleanerTimer?.Change(Timeout.Infinite, 0);

            return Task.CompletedTask;
        }

        public void Dispose()
        {
            _timer?.Dispose();
            _cleanerTimer?.Dispose();
        }

        bool running = false;
        Dictionary<string, int> count = new Dictionary<string, int>();
        private void RunTasks(object state)
        {
            if (running)
                return;
            running = true;


            
            using (var conn = DataFactory.OpenConnection())
            {
                var numbers = conn.Query<string>(@"WITH mensagens AS(
SELECT InternalNumber, MAX(DateTimeUTC) AS data FROM message
  WHERE IsInternal
  GROUP BY InternalNumber
  )
SELECT DISTINCT(m2.InternalNumber) FROM mensagens m1
  INNER JOIN message m2 ON m1.data = m2.DateTimeUTC AND m1.InternalNumber = m2.InternalNumber
  WHERE m2.Processed
  AND (m2.DateTimeUTC) < (UTC_TIMESTAMP - INTERVAL 1 MINUTE)").ToList();

                numbers.ForEach(n =>
                {
                    if (count.ContainsKey(n))
                        count[n]++;
                    else
                        count.Add(n, 1);
                    var insert = conn.Query($@"INSERT INTO message (DateTimeUTC, Content, InternalNumber, ExternalNumber, IsInternal, UserId) VALUES (UTC_TIMESTAMP, '{count[n]}', '{n}', '555599436679', TRUE, 20)");
                });
            }

            running = false;
        }

        private void CleanOldBackups(object state)
        {
            using (var conn = DataFactory.OpenConnection())
            {
                conn.Query(@"DELETE vd.* FROM hotsapp.virtual_number_data vd
  LEFT JOIN (SELECT vd.Number, MAX(vd.Id) AS LastId FROM hotsapp.virtual_number_data vd
  GROUP BY vd.Number) tk ON tk.LastId = vd.Id
  WHERE tk.LastId IS NULL");
            }
        }

    }
}
