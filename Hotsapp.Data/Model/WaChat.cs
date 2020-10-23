using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Hotsapp.Data.Model
{
    [Table("wa_chat")]
    public class WaChat
    {
        [Key]
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime StartDateUTC { get; set; }
        public DateTime? ClosedDateUTC { get; set; }
        public bool IsActive { get; set; }
        public string RemoteNumber { get; set; }
        public int? Area { get; set; }
    }
}
