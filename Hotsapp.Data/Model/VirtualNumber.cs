using System;
using System.Collections.Generic;

namespace Hotsapp.Data.Model
{
    public partial class VirtualNumber
    {
        public VirtualNumber()
        {
            NumberPeriod = new HashSet<NumberPeriod>();
            VirtualNumberData = new HashSet<VirtualNumberData>();
            VirtualNumberReservation = new HashSet<VirtualNumberReservation>();
        }

        public string Number { get; set; }
        public DateTime? LastCheckUtc { get; set; }
        public int? OwnerId { get; set; }

        public virtual User Owner { get; set; }
        public virtual ICollection<NumberPeriod> NumberPeriod { get; set; }
        public virtual ICollection<VirtualNumberData> VirtualNumberData { get; set; }
        public virtual ICollection<VirtualNumberReservation> VirtualNumberReservation { get; set; }
    }
}
