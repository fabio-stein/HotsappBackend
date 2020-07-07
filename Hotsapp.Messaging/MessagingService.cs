using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hotsapp.Messaging
{
    public class MessagingService : IHostedService
    {
        //private ILogger _log = Log.ForContext<MessagingService>();
        private readonly string _connectionString;
        private ConnectionFactory factory;
        private IConnection connection;

        public MessagingService(string connectionString)
        {
            _connectionString = connectionString;

            factory = new ConnectionFactory()
            {
                Uri = new Uri(_connectionString)
            };

            connection = factory.CreateConnection();
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            //
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            //_log.Information("Messaging service stopping");
            connection?.Close();
        }

        public IConnection GetConnection()
        {
            return connection;
        }
    }
}
