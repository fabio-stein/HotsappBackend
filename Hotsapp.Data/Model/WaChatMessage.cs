using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Hotsapp.Data.Model
{
    [Table("wa_chat_message")]
    public class WaChatMessage
    {
        [Key]
        public int MessageId { get; set; }
        public int ChatId { get; set; }
        public string ChatPhoneNumber { get; set; }
        public string Body { get; set; }
        public DateTime DateTimeUTC { get; set; }
        public bool IsFromMe { get; set; }
        public bool IsProcessed { get; set; }
    }
}
