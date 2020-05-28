using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotsapp.Data.Model
{
    [Table("user")]
    public class User
    {
        public User()
        {
            RefreshToken = new HashSet<RefreshToken>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string FirebaseUid { get; set; }
        public bool Disabled { get; set; }

        public virtual ICollection<RefreshToken> RefreshToken { get; set; }
    }
}
