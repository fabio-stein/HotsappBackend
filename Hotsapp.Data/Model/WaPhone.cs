using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Hotsapp.Data.Model
{
    [Table("wa_phone")]
    public class WaPhone
    {
        [Key]
        public double Number { get; set; }
        public string Session { get; set; }
        public bool IsConnected { get; set; }
        public int OwnerId { get; set; }
    }
}
