using System;
using System.Collections.Generic;

namespace Sonoris.Data.Model
{
    public partial class User
    {
        public User()
        {
            Channel = new HashSet<Channel>();
            RefreshToken = new HashSet<RefreshToken>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string FirebaseUid { get; set; }

        public virtual ICollection<Channel> Channel { get; set; }
        public virtual ICollection<RefreshToken> RefreshToken { get; set; }
    }
}
