using System;
using System.Collections.Generic;

namespace Hotsapp.Data.Model
{
    public partial class VirtualNumberData
    {
        public int Id { get; set; }
        public string Number { get; set; }
        public DateTime? InsertDateUtc { get; set; }
        public byte[] Data { get; set; }

        public virtual VirtualNumber NumberNavigation { get; set; }
    }
}
