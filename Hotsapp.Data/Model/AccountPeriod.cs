using System;
using System.Collections.Generic;

namespace Hotsapp.Data.Model
{
    public partial class AccountPeriod
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime StartDateUtc { get; set; }
        public DateTime EndDateUtc { get; set; }
        public string Type { get; set; }
    }
}
