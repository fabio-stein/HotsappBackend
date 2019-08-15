using DbManager.Contexts;
using DbManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SonorisApi.Services.SChannelPlaylist
{
    public class ChannelPlaylistService
    {
        public ChannelPlaylistService()
        {

        }

        public void AddMediaToPlaylist(long mediaId)
        {
            using (var cplContext = new ChannelPlaylistContext())
            {
                var media = cplContext.Media.Where(m => m.MedId == mediaId).SingleOrDefault();

                cplContext.AddItemToEnd(new ChannelPlaylist()
                {
                    CplChannel = media.MedChannel,
                    CplMedia = media.MedId
                });
                cplContext.SaveChanges();
            }
        }

        public void MoveDown(long id)
        {
            using (var context = new ChannelPlaylistContext())
            {
                var item = context.ChannelPlaylist.Where(p => p.CplId == id).SingleOrDefault();
                var last = context.LastSequenceIndex(item.CplChannel);
                if (item.CplSequenceIndex == last)
                    throw new Exception("Cant move already started item");
                else
                {
                    item.CplSequenceIndex++;
                    var newSequence = item.CplSequenceIndex;
                    context.MoveAllSequences(item.CplChannel, -1, newSequence, newSequence);
                    context.SaveChanges();
                }
            }
        }

        public void MoveUp(long id)
        {
            using (var context = new ChannelPlaylistContext())
            {
                var item = context.ChannelPlaylist.Where(p => p.CplId == id).SingleOrDefault();
                if (item.CplSequenceIndex == 1)
                    throw new Exception("Cant move more");
                else
                {
                    item.CplSequenceIndex--;
                    var newSequence = item.CplSequenceIndex;
                    context.MoveAllSequences(item.CplChannel, 1, newSequence, newSequence);
                    context.SaveChanges();
                }
            }
        }

        public void Remove(long id)
        {
            using (var context = new ChannelPlaylistContext())
            {
                var item = context.ChannelPlaylist.Where(p => p.CplId == id).SingleOrDefault();
                if (item.CplStartDate != null)
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
