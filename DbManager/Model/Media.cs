using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbManager.Model
{
    [Table("media")]
    public partial class Media
    {
        public Media()
        {
            ChannelPlaylist = new HashSet<ChannelPlaylist>();
        }

        [Column("med_id")]
        public long MedId { get; set; }
        [Required]
        [Column("med_source", TypeName = "character varying")]
        public string MedSource { get; set; }
        [Column("med_type")]
        public int MedType { get; set; }
        [Required]
        [Column("med_name")]
        [StringLength(100)]
        public string MedName { get; set; }
        [Column("med_channel")]
        public int MedChannel { get; set; }
        [Column("med_duration_seconds")]
        public long MedDurationSeconds { get; set; }

        [ForeignKey("MedChannel")]
        [InverseProperty("Media")]
        public virtual Channel MedChannelNavigation { get; set; }
        [ForeignKey("MedType")]
        [InverseProperty("Media")]
        public virtual MediaType MedTypeNavigation { get; set; }
        [InverseProperty("CplMediaNavigation")]
        public virtual ICollection<ChannelPlaylist> ChannelPlaylist { get; set; }
    }
}
