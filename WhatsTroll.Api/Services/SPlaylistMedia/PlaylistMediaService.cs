using WhatsTroll.Data.Context;
using WhatsTroll.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WhatsTroll.Api.Services.SPlaylistMedia
{
    public class PlaylistMediaService
    {
        public PlaylistMediaService()
        {

        }

        public void AddMediaToPlaylist(long mediaId)
        {
            using (var cplContext = new PlaylistMediaContext())
            {
                var media = cplContext.Media.Where(m => m.Id == mediaId).SingleOrDefault();

                cplContext.AddItemToEnd(new PlaylistMedia()
                {
                    ChannelId = media.ChannelId,
                    MediaId = media.Id
                });
                cplContext.SaveChanges();
            }
        }

        public void MoveDown(long id)
        {
            using (var context = new PlaylistMediaContext())
            {
                var item = context.PlaylistMedia.Where(p => p.Id == id).SingleOrDefault();
                var last = context.LastSequenceIndex(item.ChannelId);
                if (item.Index == last)
                    throw new Exception("Cant move already started item");
                else
                {
                    item.Index++;
                    var newSequence = item.Index;
                    context.MoveAllSequences(item.ChannelId, -1, newSequence, newSequence);
                    context.SaveChanges();
                }
            }
        }

        public void MoveUp(long id)
        {
            using (var context = new PlaylistMediaContext())
            {
                var item = context.PlaylistMedia.Where(p => p.Id == id).SingleOrDefault();
                if (item.Index == 1)
                    throw new Exception("Cant move more");
                else
                {
                    item.Index--;
                    var newSequence = item.Index;
                    context.MoveAllSequences(item.ChannelId, 1, newSequence, newSequence);
                    context.SaveChanges();
                }
            }
        }

        public void Remove(long id)
        {
            using (var context = new PlaylistMediaContext())
            {
                var item = context.PlaylistMedia.Where(p => p.Id == id).SingleOrDefault();
                if (item.StartDateUtc != null)
                    throw new Exception("Cannot remove already started item");
                else
                {
                    context.RemoveItem(item);
                    context.SaveChanges();
                }
            }
        }
    }
}
