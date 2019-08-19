using System;
using System.Collections.Generic;

namespace Sonoris.Data.Model
{
    public partial class PlaylistMedia
    {
        public int Id { get; set; }
        public int MediaId { get; set; }
        public int ChannelId { get; set; }
        public DateTime? StartDateUtc { get; set; }
        public DateTime? EndDateUtc { get; set; }
        public int Index { get; set; }

        public virtual Channel Channel { get; set; }
        public virtual Media Media { get; set; }
    }
}
