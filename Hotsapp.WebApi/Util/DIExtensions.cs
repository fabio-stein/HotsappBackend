using System;
using System.Security.Claims;

namespace Hotsapp.WebApi
{
    public static class DIExtensions
    {

        public static int GetUserId(this ClaimsPrincipal user)
        {
            var id = user.FindFirst("UserId")?.Value;
            if (id == null)
                throw new Exception("Unknown user id");
            else
                return int.Parse(id);
        }
    }
}
