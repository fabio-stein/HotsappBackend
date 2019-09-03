using System;
using System.Collections.Generic;

namespace WhatsTroll.Data.Model
{
    public partial class UserAccount
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public decimal Balance { get; set; }
    }
}
