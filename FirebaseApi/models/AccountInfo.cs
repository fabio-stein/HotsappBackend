using System;
using System.Collections.Generic;
using System.Text;

namespace FirebaseApi
{
    public class AccountInfo
    {
        public string kind { get; set; }
        public List<User> users { get; set; }
    }
}
