using Hotsapp.WebStreamer.Service;
using Microsoft.AspNetCore.SignalR;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
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
            //TODO
            var channelId = "9fc680b0-a6cd-11ea-87a6-02dd375f4dba";
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
