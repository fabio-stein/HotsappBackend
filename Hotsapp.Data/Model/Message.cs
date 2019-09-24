using System;
using System.Collections.Generic;

namespace Hotsapp.Data.Model
{
    public partial class Message
    {
        public int Id { get; set; }
        public DateTime DateTimeUtc { get; set; }
        public string Content { get; set; }
        public string InternalNumber { get; set; }
        public string ExternalNumber { get; set; }
        public bool IsInternal { get; set; }
        public bool Processed { get; set; }
    }
}
