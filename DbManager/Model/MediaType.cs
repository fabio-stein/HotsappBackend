using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbManager.Model
{
    [Table("media_type")]
    public partial class MediaType
    {
        public MediaType()
        {
            Media = new HashSet<Media>();
        }

        [Column("mt_id")]
        public int MtId { get; set; }
        [Required]
        [Column("mt_type", TypeName = "character varying")]
        public string MtType { get; set; }

        [InverseProperty("MedTypeNavigation")]
        public virtual ICollection<Media> Media { get; set; }
    }
}
