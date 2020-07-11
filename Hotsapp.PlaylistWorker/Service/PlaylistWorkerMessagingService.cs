using Hotsapp.Messaging;
using Newtonsoft.Json;
using RabbitMQ.Client;
using RabbitMQ.Client.Events;
using Serilog;
using System;
using System.Text;

namespace Hotsapp.PlaylistWorker
{
    public class PlaylistWorkerMessagingService
    {
        private ILogger _log = Log.ForContext<PlaylistWorkerMessagingService>();
        private IModel playEventModel;
        private IModel channelControllerModel;
        public event EventHandler<ChannelControllerMessage> OnChannelControllerMessage;

        public PlaylistWorkerMessagingService()
        {
            RegisterPlayEvent();
            RegisterChannelController();
        }

        private void RegisterPlayEvent()
        {
            playEventModel = MessagingFactory.GetConnection().CreateModel();
            playEventModel.ExchangeDeclare("channel-playevent", ExchangeType.Topic);
        }

        public void PublishPlayEvent(string data, string routingKey)
        {
            var body = Encoding.UTF8.GetBytes(data);

            playEventModel.BasicPublish(exchange: "channel-playevent",
                                 routingKey: routingKey,
                                 basicProperties: null,
                                 body: body);
        }

        private void RegisterChannelController()
        {
            channelControllerModel = MessagingFactory.GetConnection().CreateModel();
            var name = "channel-controller";
            channelControllerModel.QueueDeclare(queue: name,
                                 durable: true,
                                 exclusive: false,
                                 autoDelete: false,
                                 arguments: null);

            var consumer = new EventingBasicConsumer(channelControllerModel);
            consumer.Received += (model, ea) =>
            {
                var body = ea.Body.ToArray();
                var message = Encoding.UTF8.GetString(body);
                var result = JsonConvert.DeserializeObject<ChannelControllerMessage>(message);
                _log.Information("[{0}] New ChannelControllerMessage Received", result.ChannelId);

                OnChannelControllerMessage?.Invoke(this, result);
            };
            channelControllerModel.BasicConsume(queue: name,
                                 autoAck: true,
                                 consumer: consumer);
        }

        public class ChannelControllerMessage
        {
            public Guid ChannelId { get; set; }
            public ChannelControllerMessageAction Action { get; set; }
        }

        public enum ChannelControllerMessageAction
        {
            START,
            STOP
        }
    }
}
