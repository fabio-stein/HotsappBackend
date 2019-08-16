using System;
using System.Collections.Generic;

namespace Sonoris.Data.Model
{
    public partial class User
    {
        public int UserId { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Name { get; set; }
        public string FirebaseUid { get; set; }
    }
}
