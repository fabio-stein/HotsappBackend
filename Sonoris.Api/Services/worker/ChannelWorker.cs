using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Timers;
using Sonoris.Api.Hubs;
using Sonoris.Api.Hubs.PlayerHub;
using Sonoris.Api.Hubs.PlayerHub.models;
using Sonoris.Data.Model;
using Sonoris.Data.Context;

namespace Sonoris.Api.Services
{
    public class ChannelWorker
    {
        public Timer timer;
        public Channel channel;
        public PlaylistMedia playlistItem;
        public IHubContext<PlayerHub> playerHub;
        public ChannelWorkerService manager;
        private ILogger<ChannelWorker> logger;
        public bool idle = false;
        public bool stopping = false;
        public ChannelWorker(ILogger<ChannelWorker> logger, Channel channel, IHubContext<PlayerHub> playerHub, ChannelWorkerService manager)
        {
            this.channel = channel;
            this.playerHub = playerHub;
            this.manager = manager;
            this.logger = logger;
        }

        public PlaylistMedia GetCurrent()
        {
            return playlistItem;
        }

        public void StartWorker()
        {
            using (var context = new DataContext())
            {
                var running = context.PlaylistMedia.Where(t => t.StartDateUtc != null && t.EndDateUtc == null && t.Channel.Id == channel.Id)
                        .Include(t => t.Channel)
                        .Include(t => t.Media)
                        .SingleOrDefault();
                if (running != null)
                    OnResume(running);
                else
                    StartNewSession();
            }
        }

        public void OnResume(PlaylistMedia item)
        {
            logger.LogInformation("Resuming");
            playlistItem = item;
            ScheduleUpdate();
            SendUpdateToAll();
        }

        public void OnUpdate()
        {
            TerminatePlaylistItem();
            StartNewSession();
        }

        public void StartNewSession()
        {
            logger.LogInformation("Starting new session");
            LoadNextPlaylistItem();
            if (playlistItem == null)
                return;
            ScheduleUpdate();
            SendUpdateToAll();
        }
        public void ScheduleUpdate()
        {
            long duration = playlistItem.Media.DurationSeconds;
            DateTime targetTime = ((DateTime)playlistItem.StartDateUtc).AddSeconds(duration);
            if (targetTime <= DateTime.Now)
            {
                logger.LogInformation("Target time is before now. Resuming");
                OnUpdate();
            }
            else
            {
                logger.LogInformation($"Scheduling update to {targetTime}");
                setFixedUpdate(() => { OnUpdate(); }, targetTime);
            }
        }

        public void RequestStop()
        {
            stopping = true;
            CheckIdleStop();
        }

        public void Stop()
        {
            timer?.Dispose();
            Task.Run(() =>
            {
                manager.StopWorker(channel.Id);
            });
        }

        public void TerminatePlaylistItem()
        {
            if (playlistItem == null)
                return;
            logger.LogInformation("Terminating playlist item");
            using(var context = new DataContext())
            {
                var item = context.PlaylistMedia.Where(p => p.Id == playlistItem.Id).SingleOrDefault();
                item.EndDateUtc = DateTime.Now;
                playlistItem = item;
                context.SaveChanges();
            }
        }

        public void LoadNextPlaylistItem()
        {
            logger.LogInformation("Loading next playlist item");
            using(var context = new PlaylistMediaContext())
            {
                playlistItem = context.getNextToPlay(channel.Id);
                if (playlistItem == null)
                {
                    logger.LogInformation("No items found");
                    Stop();
                    return;
                }
                playlistItem.StartDateUtc = DateTime.Now;
                context.MoveAllSequences(channel.Id, -1);

                context.SaveChanges();
            }
        }

        public Task OnClientConnected(IClientProxy client)
        {
            logger.LogInformation("New client conntected! Sending bradcast");
            return Task.Run(() =>
            {
                client.SendAsync(PlayerHubMessage.CLIENT_UPDATE, GetClientUpdate());
            });
        }

        public void SendUpdateToAll()
        {
            logger.LogInformation("Sending broadcast");
            var update = GetClientUpdate();
            playerHub.Clients.Group(channel.Id.ToString()).SendAsync(PlayerHubMessage.CLIENT_UPDATE, update);
        }

        public void setFixedUpdate(Action action, DateTime targetTime)
        {
            idle = true;
            if (CheckIdleStop())
                return;

            var diff = targetTime - DateTime.Now;
            timer = new Timer(diff.TotalMilliseconds);
            
            timer.Elapsed += (Object source, ElapsedEventArgs e) => {
                idle = false;

                timer.Enabled = false;
                timer.Dispose();
                action.Invoke();
            };
            timer.Enabled = true;
        }

        public ClientUpdate GetClientUpdate()
        {
            return new ClientUpdate()
            {
                Channel = channel.Id,
                StartTime = (DateTime)playlistItem.StartDateUtc,
                DurationSeconds = playlistItem.Media.DurationSeconds,
                Name = playlistItem.Media.Title,
                Source = playlistItem.Media.Source
            };
        }

        public bool CheckIdleStop()
        {
            if (stopping && idle)
            {
                Stop();
                return true;
            }
            return false;
        }
    }
}
