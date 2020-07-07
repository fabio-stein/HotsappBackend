using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotsapp.Data.Model
{
    [Table("play_history")]
    public class PlayHistory
    {
        [Key]
        public int Id { get; set; }
        public Guid ChannelId { get; set; }
        public string MediaId { get; set; }
        public DateTime StartDateUTC { get; set; }
        public int Duration { get; set; }
    }
}
