using Hotsapp.WebStreamer.Service;
using Microsoft.AspNetCore.SignalR;
using Serilog;
using System;
using System.Threading.Tasks;

namespace Hotsapp.WebStreamer.Hubs
{
    public class StreamHub : Hub<IStreamHub>
    {
        private readonly ILogger _log = Log.ForContext<StreamHub>();
        private readonly StreamerService _streamerService;

        public StreamHub(StreamerService streamerService)
        {
            _streamerService = streamerService;
        }

        public override async Task OnConnectedAsync()
        {
            await base.OnConnectedAsync();
            var channelId = Context.GetHttpContext().Request.Query["channelId"];

            if (!Guid.TryParse(channelId, out _))
            {
                _log.Information("Invalid ChannelId on client connection: [{0}]", channelId);
                Context.Abort();
            }

            var registerSuccess = await _streamerService.RegisterClient(channelId, Context, Clients.Caller);
            if (!registerSuccess)
                Context.Abort();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {
            await base.OnDisconnectedAsync(exception);
            await _streamerService.UnRegisterClient(Context.ConnectionId);
        }
    }
}
