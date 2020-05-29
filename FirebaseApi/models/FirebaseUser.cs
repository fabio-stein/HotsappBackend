using System.Collections.Generic;

namespace FirebaseApi
{
    public class FirebaseUser
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
