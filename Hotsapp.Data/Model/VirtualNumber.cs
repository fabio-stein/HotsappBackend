using System;
using System.Collections.Generic;

namespace Hotsapp.Data.Model
{
    public partial class VirtualNumber
    {
        public VirtualNumber()
        {
            VirtualNumberData = new HashSet<VirtualNumberData>();
        }

        public string Number { get; set; }
        public DateTime? LastCheckUtc { get; set; }

        public virtual ICollection<VirtualNumberData> VirtualNumberData { get; set; }
    }
}
