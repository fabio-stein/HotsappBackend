using System;
using System.Collections.Generic;

namespace WhatsTroll.Data.Model
{
    public partial class Message
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string Text { get; set; }
        public DateTime? SentDateUtc { get; set; }
        public string PhoneNumber { get; set; }
    }
}
