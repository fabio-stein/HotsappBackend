using System;
using System.Collections.Generic;

namespace WhatsTroll.Data.Model
{
    public partial class UserAccount
    {
        public int UserId { get; set; }
        public decimal Balance { get; set; }

        public virtual User User { get; set; }
    }
}
