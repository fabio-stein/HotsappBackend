using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Hotsapp.WebStreamer.Service
{
    public class MessagingService : IHostedService
    {
        private ILogger _log = Log.ForContext<MessagingService>();
        private readonly string connectionString;
        private ConnectionFactory factory;
        private IConnection connection;
        private IModel channel;

        public MessagingService(IConfiguration config)
        {
            connectionString = config.GetConnectionString("RabbitMQ");
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            _log.Information("Messaging service starting");
            factory = new ConnectionFactory()
            {
                Uri = new Uri(connectionString)
            };

            connection = factory.CreateConnection();

            _log.Information("Messaging service connected: {0}", connection.IsOpen);
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            _log.Information("Messaging service stopping");
            connection?.Close();
        }

        public ChannelConnection CreateChannel()
        {
            return new ChannelConnection(connection);
        }
    }

    public class ChannelConnection : IDisposable
    {
        private readonly IConnection _connection;
        private IModel channel;
        public event EventHandler<BasicDeliverEventArgs> OnMessageReceived;

        public ChannelConnection(IConnection connection)
        {
            _connection = connection;
        }

        public void Start(string routingKey)
        {
            channel = _connection.CreateModel();
            channel.ExchangeDeclare("channel-playevent", ExchangeType.Topic);

            var appPrefix = "streamer-";
            var name = appPrefix + Guid.NewGuid().ToString();
            channel.QueueDeclare(queue: name,
                                 durable: false,
                                 exclusive: true,
                                 autoDelete: true,
                                 arguments: null);
            channel.QueueBind(name, "channel-playevent", routingKey);
            var consumer = new EventingBasicConsumer(channel);
            consumer.Received += OnMessageReceived;
            channel.BasicConsume(queue: name,
                                 autoAck: true,
                                 consumer: consumer);
        }

        public void Stop()
        {
            channel?.Close();
        }

        public void Dispose()
        {
            Stop();
        }
    }
}
