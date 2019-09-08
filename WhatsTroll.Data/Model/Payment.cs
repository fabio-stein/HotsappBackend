using System;
using System.Collections.Generic;

namespace WhatsTroll.Data.Model
{
    public partial class Payment
    {
        public int Id { get; set; }
        public decimal Amount { get; set; }
        public string PaypalOrderId { get; set; }
        public DateTime DateTimeUtc { get; set; }
        public int UserId { get; set; }

        public virtual User User { get; set; }
    }
}
