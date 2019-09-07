using System;
using System.Collections.Generic;

namespace WhatsTroll.Data.Model
{
    public partial class User
    {
        public User()
        {
            RefreshToken = new HashSet<RefreshToken>();
            Transaction = new HashSet<Transaction>();
        }

        public int Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string FirebaseUid { get; set; }

        public virtual UserAccount UserAccount { get; set; }
        public virtual ICollection<RefreshToken> RefreshToken { get; set; }
        public virtual ICollection<Transaction> Transaction { get; set; }
    }
}
