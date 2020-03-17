using System;
using System.Collections.Generic;

namespace Hotsapp.Data.Model
{
    public partial class User
    {
        public User()
        {
            Campaign = new HashSet<Campaign>();
            ConnectionFlow = new HashSet<ConnectionFlow>();
            Message = new HashSet<Message>();
            Payment = new HashSet<Payment>();
            RefreshToken = new HashSet<RefreshToken>();
            Subscription = new HashSet<Subscription>();
            VirtualNumber = new HashSet<VirtualNumber>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string FirebaseUid { get; set; }
        public bool Disabled { get; set; }

        public virtual ICollection<Campaign> Campaign { get; set; }
        public virtual ICollection<ConnectionFlow> ConnectionFlow { get; set; }
        public virtual ICollection<Message> Message { get; set; }
        public virtual ICollection<Payment> Payment { get; set; }
        public virtual ICollection<RefreshToken> RefreshToken { get; set; }
        public virtual ICollection<Subscription> Subscription { get; set; }
        public virtual ICollection<VirtualNumber> VirtualNumber { get; set; }
    }
}
