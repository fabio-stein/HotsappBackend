using System;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hotsapp.Data.Model
{
    [Table("refresh_token")]
    public partial class RefreshToken
    {
        public string Id { get; set; }
        public int UserId { get; set; }
        public DateTime CreateDateUTC { get; set; }
        public bool IsRevoked { get; set; }

        public virtual User User { get; set; }
    }
}
