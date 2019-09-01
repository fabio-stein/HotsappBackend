using System;
using System.Collections.Generic;

namespace WhatsTroll.Data.Model
{
    public partial class Media
    {
        public Media()
        {
            PlaylistMedia = new HashSet<PlaylistMedia>();
        }

        public int Id { get; set; }
        public string Source { get; set; }
        public string Title { get; set; }
        public int DurationSeconds { get; set; }
        public int ChannelId { get; set; }

        public virtual Channel Channel { get; set; }
        public virtual ICollection<PlaylistMedia> PlaylistMedia { get; set; }
    }
}
