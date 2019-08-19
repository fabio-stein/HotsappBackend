using Microsoft.AspNetCore.SignalR;
using System;
using System.Threading.Tasks;
using Sonoris.Api.Hubs.PlayerHub.models;
using Sonoris.Api.Services;

namespace Sonoris.Api.Hubs.PlayerHub
{
    public class PlayerHub : Hub
    {
        ChannelWorkerService _manager;

        public PlayerHub(ChannelWorkerService manager) {
            _manager = manager;
        }
        public override Task OnConnectedAsync()
        {
            Console.WriteLine("NEW CONNECTION");
            var channel = int.Parse(Context.GetHttpContext().Request.Query["channel"].ToString().Replace("{", "").Replace("}", ""));
            Groups.AddToGroupAsync(Context.ConnectionId, channel.ToString()).Wait();
            var worker = _manager.workers.Find(w => w.channel.Id == channel);
            if(worker!=null)
                worker.OnClientConnected(Clients.Caller);
            return base.OnConnectedAsync();
        }
        public override Task OnDisconnectedAsync(Exception exception)
        {
            Console.WriteLine("User disconnected");
            Clients.Others.SendAsync("ReceiveMessage", "User disconnected!");
            return base.OnDisconnectedAsync(exception);
        }

        public void SendClientUpdate(ClientUpdate update, String group)
        {

        }

        public Task SendMessage(string message)
        {
            Console.WriteLine($"MESSAGE {message} FROM {Context.ConnectionId}");
            return Clients.Others.SendAsync("ClientUpdate", message);
        }
    }
}
