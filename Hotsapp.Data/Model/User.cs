using System;
using System.Collections.Generic;

namespace Hotsapp.Data.Model
{
    public partial class User
    {
        public User()
        {
            Message = new HashSet<Message>();
            NumberPeriod = new HashSet<NumberPeriod>();
            Payment = new HashSet<Payment>();
            RefreshToken = new HashSet<RefreshToken>();
            SingleMessage = new HashSet<SingleMessage>();
            Transaction = new HashSet<Transaction>();
            VirtualNumber = new HashSet<VirtualNumber>();
            VirtualNumberReservation = new HashSet<VirtualNumberReservation>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string FirebaseUid { get; set; }
        public bool Disabled { get; set; }

        public virtual UserAccount UserAccount { get; set; }
        public virtual ICollection<Message> Message { get; set; }
        public virtual ICollection<NumberPeriod> NumberPeriod { get; set; }
        public virtual ICollection<Payment> Payment { get; set; }
        public virtual ICollection<RefreshToken> RefreshToken { get; set; }
        public virtual ICollection<SingleMessage> SingleMessage { get; set; }
        public virtual ICollection<Transaction> Transaction { get; set; }
        public virtual ICollection<VirtualNumber> VirtualNumber { get; set; }
        public virtual ICollection<VirtualNumberReservation> VirtualNumberReservation { get; set; }
    }
}
