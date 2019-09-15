using System;
using System.Collections.Generic;

namespace Hotsapp.Data.Model
{
    public partial class MessageReceived
    {
        public int Id { get; set; }
        public DateTime ReceiveDateUtc { get; set; }
        public string Message { get; set; }
        public string FromNumber { get; set; }
        public string ToNumber { get; set; }
    }
}
