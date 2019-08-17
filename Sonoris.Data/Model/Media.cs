using System;
using System.Collections.Generic;

namespace Sonoris.Data.Model
{
    public partial class Media
    {
        public int Id { get; set; }
        public string Source { get; set; }
        public string Title { get; set; }
        public int DurationSeconds { get; set; }
        public int Channel { get; set; }

        public virtual Channel ChannelNavigation { get; set; }
    }
}
