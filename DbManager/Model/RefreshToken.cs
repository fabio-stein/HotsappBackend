using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbManager.Model
{
    [Table("refresh_token")]
    public partial class RefreshToken
    {
        [Column("tok_id")]
        [StringLength(32)]
        public string TokId { get; set; }
        [Column("tok_user")]
        public int TokUser { get; set; }
        [Column("tok_revoked")]
        public bool TokRevoked { get; set; }

        [ForeignKey("TokUser")]
        [InverseProperty("RefreshToken")]
        public virtual User TokUserNavigation { get; set; }
    }
}
