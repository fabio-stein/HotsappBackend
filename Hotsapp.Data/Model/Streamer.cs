using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Hotsapp.Data.Model
{
    [Table("streamer")]
    public class Streamer
    {
        public Guid Id { get; set; }
        public DateTime StartDateUTC { get; set; }
        public DateTime LastPingUTC { get; set; }
        public int ActiveClients { get; set; }
        public int ActiveStreams { get; set; }
        public bool IsActive { get; set; }
    }
}
