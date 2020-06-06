using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Hotsapp.Data.Model
{
    [Table("channel")]
    public class Channel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime CreateDateUTC { get; set; }
        public string Status { get; set; }
    }
}
