using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SonorisApi.Auth.Model
{
    public class SignInModel
    {
        public string idToken { get; set; }
        public string refreshToken { get; set; }
    }
}
