using System;
using System.Collections.Generic;

namespace Hotsapp.Data.Model
{
    public partial class Subscription
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime CreateDateUtc { get; set; }
        public DateTime? StartDateUtc { get; set; }
        public DateTime? EndDateUtc { get; set; }
        public string Status { get; set; }
        public string PaypalRefId { get; set; }

        public virtual User User { get; set; }
    }
}
