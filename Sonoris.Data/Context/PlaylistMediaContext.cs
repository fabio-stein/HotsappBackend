using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Sonoris.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Sonoris.Data.Context
{
    public class PlaylistMediaContext : DataContext
    {
        public PlaylistMedia getNextToPlay(int Channel)
        {
            return PlaylistMedia.Where(p => p.ChannelId == Channel
            && p.StartDateUtc == null)
                    .OrderBy(p => p.Index)
                    .Include(p => p.Media)
                    .Include(p => p.Channel)
                    .FirstOrDefault();
        }

        public int LastSequenceIndex(int Channel)
        {
            return PlaylistMedia
                .Where(p => p.ChannelId == Channel)
                .DefaultIfEmpty()
                .Max(p => p.Index);
        }

        public EntityEntry<PlaylistMedia> AddItemToEnd(PlaylistMedia cpl)
        {
            var newIndex = LastSequenceIndex(cpl.ChannelId) + 1;
            cpl.Index = newIndex;
            return PlaylistMedia.Add(cpl);
        }

        public void RemoveItem(PlaylistMedia cpl)
        {
            PlaylistMedia.Remove(cpl);
            MoveAllSequences(cpl.ChannelId, -1, cpl.Index + 1);
        }

        public void MoveAllSequences(int channel, int amount, int? startIndex = 1, int? endIndex = null)
        {
            var items = PlaylistMedia.Where(p => p.ChannelId == channel && p.Index >= startIndex && ((endIndex == null) ? true : p.Index <= endIndex)).ToList();
            items.ToList().ForEach(p => p.Index = p.Index + amount);
            PlaylistMedia.UpdateRange(items);
        }

        public List<PlaylistMedia> GetCurrentPlaylist(int channel)
        {
            var items = PlaylistMedia.Where(p => p.Index > 0)
                .OrderBy(p => p.Index)
                .Include(p => p.Media)
                .ToList();
            return items;
        }
    }
}
