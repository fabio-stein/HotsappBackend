using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbManager.Model
{
    [Table("channel_playlist")]
    public partial class ChannelPlaylist
    {
        [Column("cpl_id")]
        public long CplId { get; set; }
        [Column("cpl_channel")]
        public int CplChannel { get; set; }
        [Column("cpl_start_date", TypeName = "timestamp with time zone")]
        public DateTime? CplStartDate { get; set; }
        [Column("cpl_end_date", TypeName = "timestamp with time zone")]
        public DateTime? CplEndDate { get; set; }
        [Column("cpl_media")]
        public long CplMedia { get; set; }
        [Column("cpl_sequence_index")]
        public int CplSequenceIndex { get; set; }

        [ForeignKey("CplChannel")]
        [InverseProperty("ChannelPlaylist")]
        public virtual Channel CplChannelNavigation { get; set; }
        [ForeignKey("CplMedia")]
        [InverseProperty("ChannelPlaylist")]
        public virtual Media CplMediaNavigation { get; set; }
    }
}
