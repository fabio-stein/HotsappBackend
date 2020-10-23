using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Hotsapp.Data.Model
{
    [Table("wa_phone_area")]
    public class WaPhoneArea
    {
        public int Id { get; set; }
        public string PhoneNumber { get; set; }
        public string Title { get; set; }
    }
}
