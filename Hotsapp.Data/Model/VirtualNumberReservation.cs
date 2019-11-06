using System;
using System.Collections.Generic;

namespace Hotsapp.Data.Model
{
    public partial class VirtualNumberReservation
    {
        public VirtualNumberReservation()
        {
            Transaction = new HashSet<Transaction>();
        }

        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime StartDateUtc { get; set; }
        public DateTime? EndDateUtc { get; set; }
        public string NumberId { get; set; }

        public virtual VirtualNumber Number { get; set; }
        public virtual User User { get; set; }
        public virtual ICollection<Transaction> Transaction { get; set; }
    }
}
