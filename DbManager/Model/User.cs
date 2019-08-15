using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace DbManager .Model
{
    [Table("user")]
    public partial class User
    {
        public User()
        {
            Channel = new HashSet<Channel>();
            RefreshToken = new HashSet<RefreshToken>();
        }

        [Column("usr_id")]
        public int UsrId { get; set; }
        [Required]
        [Column("usr_username")]
        [StringLength(15)]
        public string UsrUsername { get; set; }
        [Column("usr_email")]
        [StringLength(50)]
        public string UsrEmail { get; set; }
        [Required]
        [Column("usr_firebase_uid")]
        [StringLength(30)]
        public string UsrFirebaseUid { get; set; }
        [Column("usr_name")]
        [StringLength(30)]
        public string UsrName { get; set; }
        [Column("usr_active")]
        public bool? UsrActive { get; set; }

        [InverseProperty("ChOwnerNavigation")]
        public virtual ICollection<Channel> Channel { get; set; }
        [InverseProperty("TokUserNavigation")]
        public virtual ICollection<RefreshToken> RefreshToken { get; set; }
    }
}
