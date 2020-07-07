using RabbitMQ.Client;
using System;
using System.Collections.Generic;
using System.Text;

namespace Hotsapp.Messaging
{
    public class MessagingFactory
    {
        private static MessagingService _messagingService;
        public static void Initialize(MessagingService messagingService)
        {
            _messagingService = messagingService;
        }

        public static IConnection GetConnection()
        {
            if (_messagingService == null)
                throw new Exception("MessagingService not initialized");

            return _messagingService.GetConnection();
        }
    }
}
