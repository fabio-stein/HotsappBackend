using System;
using System.Collections.Generic;

namespace Hotsapp.Data.Model
{
    public partial class NumberPeriod
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime StartDateUtc { get; set; }
        public DateTime? EndDateUtc { get; set; }
        public string VirtualNumberId { get; set; }

        public virtual User User { get; set; }
        public virtual VirtualNumber VirtualNumber { get; set; }
    }
}
