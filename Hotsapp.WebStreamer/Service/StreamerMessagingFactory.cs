using Hotsapp.Messaging;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Serilog;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Hotsapp.WebStreamer.Service
{
    public class StreamerMessagingFactory
    {
        public static ChannelConnection CreateChannel()
        {
            return new ChannelConnection(MessagingFactory.GetConnection());
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
