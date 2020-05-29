using System;
using System.Collections.Generic;
using System.Text;

namespace FirebaseApi
{
    public class User
    {
        public string localId { get; set; }
        public string email { get; set; }
        public string displayName { get; set; }
        public string photoUrl { get; set; }
        public string passwordHash { get; set; }
        public bool emailVerified { get; set; }
        public long passwordUpdatedAt { get; set; }
        public List<ProviderUserInfo> providerUserInfo { get; set; }
        public string validSince { get; set; }
        public string lastLoginAt { get; set; }
        public string createdAt { get; set; }
    }

}
