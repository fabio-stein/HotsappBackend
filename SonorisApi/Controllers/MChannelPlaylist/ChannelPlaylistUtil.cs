using DbManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SonorisApi.Modules.MChannelPlaylist
{
    public class ChannelPlaylistUtil
    {
        public static PlaylistItemView ToPlaylistView(ChannelPlaylist cpl)
        {
            var item = new PlaylistItemView();
            item.id = cpl.CplId;
            item.index = cpl.CplSequenceIndex;
            item.name = cpl.CplMediaNavigation.MedName;
            return item;
        }
    }
}
