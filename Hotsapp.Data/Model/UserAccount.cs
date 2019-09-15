using System;
using System.Collections.Generic;

namespace Hotsapp.Data.Model
{
    public partial class UserAccount
    {
        public int UserId { get; set; }
        public decimal Balance { get; set; }

        public virtual User User { get; set; }
    }
}
