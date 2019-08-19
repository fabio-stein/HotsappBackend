using Sonoris.Data.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sonoris.Api.Modules.MChannelPlaylist
{
    public class ChannelPlaylistUtil
    {
        public static PlaylistItemView ToPlaylistView(PlaylistMedia cpl)
        {
            var item = new PlaylistItemView();
            item.id = cpl.Id;
            item.index = cpl.Index;
            item.name = cpl.Media.Title;
            return item;
        }
    }
}
