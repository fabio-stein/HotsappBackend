using System;
using System.Collections.Generic;

namespace Hotsapp.Data.Model
{
    public partial class ConnectionFlow
    {
        public Guid Id { get; set; }
        public int UserId { get; set; }
        public DateTime CreateDateUtc { get; set; }
        public string PhoneNumber { get; set; }
        public bool? IsActive { get; set; }
        public string ConfirmCode { get; set; }
        public string ErrorMessage { get; set; }
        public bool? IsSuccess { get; set; }
        public int CountryCode { get; set; }

        public virtual User User { get; set; }
    }
}
