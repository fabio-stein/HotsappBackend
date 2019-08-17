using System;
using System.Collections.Generic;

namespace Sonoris.Data.Model
{
    public partial class Channel
    {
        public Channel()
        {
            Media = new HashSet<Media>();
            PlaylistMedia = new HashSet<PlaylistMedia>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
        public virtual ICollection<Media> Media { get; set; }
        public virtual ICollection<PlaylistMedia> PlaylistMedia { get; set; }
    }
}
