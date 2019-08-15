using DbManager.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbManager.Contexts
{
    public class ChannelPlaylistContext : DataContext
    {
        public ChannelPlaylist getNextToPlay(int Channel)
        {
            return ChannelPlaylist.Where(p => p.CplChannel == Channel
            && p.CplStartDate == null)
                    .OrderBy(p => p.CplSequenceIndex)
                    .Include(p => p.CplMediaNavigation)
                    .Include(p => p.CplChannelNavigation)
                    .FirstOrDefault();
        }

        public int LastSequenceIndex(int Channel)
        {
            return ChannelPlaylist
                .Where(p => p.CplChannel == Channel)
                .DefaultIfEmpty()
                .Max(p => p.CplSequenceIndex);
        }

        public EntityEntry<ChannelPlaylist> AddItemToEnd(ChannelPlaylist cpl)
        {
            var newIndex = LastSequenceIndex(cpl.CplChannel) + 1;
            cpl.CplSequenceIndex = newIndex;
            return ChannelPlaylist.Add(cpl);
        }

        public void RemoveItem(ChannelPlaylist cpl)
        {
            ChannelPlaylist.Remove(cpl);
            MoveAllSequences(cpl.CplChannel, -1, cpl.CplSequenceIndex + 1);
        }

        public void MoveAllSequences(int channel, int amount, int? startIndex = 1, int? endIndex = null)
        {
            var items = ChannelPlaylist.Where(p => p.CplChannel == channel && p.CplSequenceIndex >= startIndex && ((endIndex == null) ? true : p.CplSequenceIndex <= endIndex)).ToList();
            items.ToList().ForEach(p => p.CplSequenceIndex = p.CplSequenceIndex+amount);
            ChannelPlaylist.UpdateRange(items);
        }

        public List<ChannelPlaylist> GetCurrentPlaylist(int channel)
        {
            var items = ChannelPlaylist.Where(p => p.CplSequenceIndex > 0)
                .OrderBy(p => p.CplSequenceIndex)
                .Include(p => p.CplMediaNavigation)
                .ToList();
            return items;
        }
    }
}
