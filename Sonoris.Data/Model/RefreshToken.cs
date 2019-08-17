using System;
using System.Collections.Generic;

namespace Sonoris.Data.Model
{
    public partial class RefreshToken
    {
        public string Id { get; set; }
        public int UserId { get; set; }
        public bool IsRevoked { get; set; }

        public virtual User User { get; set; }
    }
}
