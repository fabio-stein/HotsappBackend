using System;
using System.Collections.Generic;

namespace Hotsapp.Data.Model
{
    public partial class Phoneservice
    {
        public int Id { get; set; }
        public DateTime CreateDateUtc { get; set; }
        public DateTime LastUpdate { get; set; }
        public string Status { get; set; }
    }
}
