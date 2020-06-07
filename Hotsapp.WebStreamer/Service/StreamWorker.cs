using Dapper;
using Hotsapp.Data.Util;
using Hotsapp.WebStreamer.Hubs;
using Microsoft.AspNetCore.SignalR;
using Newtonsoft.Json;
using RabbitMQ.Client.Events;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hotsapp.WebStreamer.Service
{
    public class StreamWorker
    {
        private readonly ILogger _log = Log.ForContext<StreamWorker>();
        private readonly MessagingService _messagingService;
        private string channelId;
        private ChannelConnection channelConnection;
        private bool streamRunning = false;
        private readonly object _clientsLock = new object();
        private Dictionary<string, ClientInfo> clients = new Dictionary<string, ClientInfo>();
        private readonly IHubContext<StreamHub, IStreamHub> _hub;
        private PlayModel _status;

        public StreamWorker(MessagingService messagingService, IHubContext<StreamHub, IStreamHub> hub)
        {
            _messagingService = messagingService;
            _hub = hub;
        }

        public void Initialize(string channelId)
        {
            this.channelId = channelId;
        }

        public async Task StartStream()
        {
            await LoadStatus();
            streamRunning = true;
            await SendPlayEvent();

            channelConnection = _messagingService.CreateChannel();
            channelConnection.OnMessageReceived += OnPlayEventReceived;
            channelConnection.Start(channelId);
        }

        private void OnPlayEventReceived(object sender, BasicDeliverEventArgs e)
        {
            _log.Information("[{0}] PlayEvent Received", channelId);
            var body = e.Body;
            var message = Encoding.UTF8.GetString(body.ToArray());

            _status = JsonConvert.DeserializeObject<PlayModel>(message);

            _ = SendPlayEvent();
        }

        public async Task AddClient(HubCallerContext context, IStreamHub client)
        {
            lock (_clientsLock)
            {
                clients.Add(context.ConnectionId, new ClientInfo()
                {
                    Client = client,
                    Context = context
                });
            }

            await _hub.Groups.AddToGroupAsync(context.ConnectionId, channelId);

            if (streamRunning)
            {
                await SendPlayEvent(context.ConnectionId);
            }
        }

        public async Task RemoveClient(string connectionId)
        {
            await _hub.Groups.RemoveFromGroupAsync(connectionId, channelId);
            //TODO
        }

        public bool ClientExists(string connectionId)
        {
            return clients.ContainsKey(connectionId);
        }

        private async Task LoadStatus()
        {
            using(var conn = DataFactory.OpenConnection())
            {
                _status = await conn.QueryFirstOrDefaultAsync<PlayModel>(@"SELECT ph.ChannelId, ph.MediaId, ph.StartDateUTC, ph.Duration FROM play_history ph
WHERE ph.ChannelId = @channelId
ORDER BY ph.StartDateUTC
LIMIT 1", new { channelId });
            }
        }

        private async Task SendPlayEvent(string connectionId = null)
        {
            var eventData = new
            {
                videoId = _status.MediaId
            };

            if (connectionId == null)
            {
                _log.Information("[{0}] Sending PlayEvent to connected clients", channelId);
                await _hub.Clients.Group(channelId).PlayEvent(eventData);
            }
            else
            {
                _log.Information("[{0}] Sending PlayEvent to single client [{1}]", channelId, connectionId);
                await _hub.Clients.Client(connectionId).PlayEvent(eventData);
            }
        }

        public async Task StopStream()
        {
            //TODO DISCONNECT ALL CLIENTS
            //TODO STOP SERVICES
        }

        private class ClientInfo
        {
            public HubCallerContext Context { get; set; }
            public IStreamHub Client { get; set; }
        }

        private class PlayModel
        {
            public Guid ChannelId { get; set; }
            public string MediaId { get; set; }
            public DateTime StartDateUTC { get; set; }
            public int Duration { get; set; }
        }
    }
}
