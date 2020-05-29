using System;
using System.Collections.Generic;
using System.Text;

namespace FirebaseApi
{
    public class AccountInfo
    {
        public string kind { get; set; }
        public List<FirebaseUser> users { get; set; }
    }
}
