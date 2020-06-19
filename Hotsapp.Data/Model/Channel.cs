using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotsapp.Data.Model
{
    [Table("channel")]
    public class Channel
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public DateTime CreateDateUTC { get; set; }
        public string Status { get; set; }
        public int OwnerId { get; set; }
    }
}
