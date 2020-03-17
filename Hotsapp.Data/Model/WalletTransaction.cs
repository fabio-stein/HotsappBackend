using System;
using System.Collections.Generic;

namespace Hotsapp.Data.Model
{
    public partial class WalletTransaction
    {
        public Guid Id { get; set; }
        public decimal Amount { get; set; }
        public DateTime DateTimeUtc { get; set; }
        public Guid? PaymentId { get; set; }
        public int WalletId { get; set; }
    }
}
