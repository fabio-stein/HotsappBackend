using System.Collections.Generic;

namespace FirebaseApi
{
    public class AccountInfo
    {
        public string kind { get; set; }
        public List<FirebaseUser> users { get; set; }
    }
}
