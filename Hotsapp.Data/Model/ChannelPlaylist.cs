using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotsapp.Data.Model
{
    [Table("channel_playlist")]
    public class ChannelPlaylist
    {
        [Key]
        public Guid ChannelId { get; set; }
        public string Playlist { get; set; }
    }
}
