using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbManager.Model
{
    [Table("channel")]
    public partial class Channel
    {
        public Channel()
        {
            ChannelPlaylist = new HashSet<ChannelPlaylist>();
            Media = new HashSet<Media>();
        }

        [Column("ch_id")]
        public int ChId { get; set; }
        [Required]
        [Column("ch_name")]
        [StringLength(50)]
        public string ChName { get; set; }
        [Column("ch_owner")]
        public int ChOwner { get; set; }
        [Column("ch_image")]
        [StringLength(100)]
        public string ChImage { get; set; }
        [Column("ch_cover_image")]
        [StringLength(100)]
        public string ChCoverImage { get; set; }

        [ForeignKey("ChOwner")]
        [InverseProperty("Channel")]
        public virtual User ChOwnerNavigation { get; set; }
        [InverseProperty("CplChannelNavigation")]
        public virtual ICollection<ChannelPlaylist> ChannelPlaylist { get; set; }
        [InverseProperty("MedChannelNavigation")]
        public virtual ICollection<Media> Media { get; set; }
    }
}
