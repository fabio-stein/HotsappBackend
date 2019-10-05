using System;
using System.Collections.Generic;

namespace Hotsapp.Data.Model
{
    public partial class SingleMessage
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Content { get; set; }
        public string ToNumber { get; set; }
        public DateTime CreateDateUtc { get; set; }
        public bool Processed { get; set; }

        public virtual User User { get; set; }
    }
}
