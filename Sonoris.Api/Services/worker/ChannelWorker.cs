using DbManager.Contexts;
using DbManager.Model;
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

namespace Sonoris.Api.Services
{
    public class ChannelWorker
    {
        public Timer timer;
        public Channel channel;
        public ChannelPlaylist playlistItem;
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

        public ChannelPlaylist GetCurrent()
        {
            return playlistItem;
        }

        public void StartWorker()
        {
            using (var context = new DataContext())
            {
                var running = context.ChannelPlaylist.Where(t => t.CplStartDate != null && t.CplEndDate == null && t.CplChannelNavigation.ChId == channel.ChId)
                        .Include(t => t.CplChannelNavigation)
                        .Include(t => t.CplMediaNavigation)
                        .SingleOrDefault();
                if (running != null)
                    OnResume(running);
                else
                    StartNewSession();
            }
        }

        public void OnResume(ChannelPlaylist item)
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
            long duration = playlistItem.CplMediaNavigation.MedDurationSeconds;
            DateTime targetTime = ((DateTime)playlistItem.CplStartDate).AddSeconds(duration);
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
                manager.StopWorker(channel.ChId);
            });
        }

        public void TerminatePlaylistItem()
        {
            if (playlistItem == null)
                return;
            logger.LogInformation("Terminating playlist item");
            using(var context = new DataContext())
            {
                var item = context.ChannelPlaylist.Where(p => p.CplId == playlistItem.CplId).SingleOrDefault();
                item.CplEndDate = DateTime.Now;
                playlistItem = item;
                context.SaveChanges();
            }
        }

        public void LoadNextPlaylistItem()
        {
            logger.LogInformation("Loading next playlist item");
            using(var context = new ChannelPlaylistContext())
            {
                playlistItem = context.getNextToPlay(channel.ChId);
                if (playlistItem == null)
                {
                    logger.LogInformation("No items found");
                    Stop();
                    return;
                }
                playlistItem.CplStartDate = DateTime.Now;
                context.MoveAllSequences(channel.ChId, -1);

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
            playerHub.Clients.Group(channel.ChId.ToString()).SendAsync(PlayerHubMessage.CLIENT_UPDATE, update);
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
                Channel = channel.ChId,
                StartTime = (DateTime)playlistItem.CplStartDate,
                DurationSeconds = playlistItem.CplMediaNavigation.MedDurationSeconds,
                MedType = playlistItem.CplMediaNavigation.MedType,
                Name = playlistItem.CplMediaNavigation.MedName,
                Source = playlistItem.CplMediaNavigation.MedSource
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
