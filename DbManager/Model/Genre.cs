using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbManager.Model
{
    [Table("genre")]
    public partial class Genre
    {
        [Column("gen_id")]
        public int GenId { get; set; }
        [Required]
        [Column("gen_name")]
        [StringLength(15)]
        public string GenName { get; set; }
    }
}
