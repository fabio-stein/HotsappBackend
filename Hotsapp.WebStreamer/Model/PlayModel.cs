using System;

namespace Hotsapp.WebStreamer.Model
{
    public class PlayModel
    {
        public Guid ChannelId { get; set; }
        public string MediaId { get; set; }
        public DateTime StartDateUTC { get; set; }
        public int Duration { get; set; }
    }
}
