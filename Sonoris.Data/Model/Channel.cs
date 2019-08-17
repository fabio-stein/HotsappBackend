using System;
using System.Collections.Generic;

namespace Sonoris.Data.Model
{
    public partial class Channel
    {
        public Channel()
        {
            Media = new HashSet<Media>();
        }

        public int Id { get; set; }
        public string Name { get; set; }
        public int Owner { get; set; }

        public virtual User OwnerNavigation { get; set; }
        public virtual ICollection<Media> Media { get; set; }
    }
}
