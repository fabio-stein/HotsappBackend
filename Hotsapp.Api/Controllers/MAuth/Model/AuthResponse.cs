using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hotsapp.Api.Controllers.MAuth.Model
{
    public class AuthResponse
    {
        public bool authenticated { get; set; }
        public string email { get; set; }
        public DateTime expiration { get; set; }
        public string accessToken { get; set; }
        public string message { get; set; }
        public string refreshToken { get; set; }
    }
}
