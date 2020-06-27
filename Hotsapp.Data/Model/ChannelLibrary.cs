using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Hotsapp.Data.Model
{
    [Table("channel_library")]
    public class ChannelLibrary
    {
        [Key]
        public Guid ChannelId { get; set; }
        public string Library { get; set; }
    }
}
