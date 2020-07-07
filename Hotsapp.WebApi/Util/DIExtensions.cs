using Newtonsoft.Json;
using System;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

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

        public static string GetMD5Hash(this string text)
        {
            if (text == null)
                throw new Exception("Text cannot be null");

            var bytes = Encoding.ASCII.GetBytes(text);
            var hash = MD5.Create().ComputeHash(bytes);
            var stringHash = BitConverter.ToString(hash)
                .Replace("-", string.Empty)
                .ToLower();
            return stringHash;
        }

        public static string ToJson(this object data)
        {
            return JsonConvert.SerializeObject(data);
        }

        public static T FromJson<T>(this string data)
        {
            return JsonConvert.DeserializeObject<T>(data);
        }
    }
}
