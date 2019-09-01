using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using FirebaseApi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using WhatsTroll.Api.Auth.Model;
using WhatsTroll.Api.Configuration;
using System.Security.Claims;
using System.Security.Principal;
using WhatsTroll.Api.Util;
using System.Threading.Tasks;
using WhatsTroll.Api.Controllers.MAuth.Model;
using Microsoft.AspNetCore.Authorization;
using WhatsTroll.Api.Controllers.MChannelPlaylist.Action;
using WhatsTroll.Data.Model;
using WhatsTroll.Data.Context;

namespace WhatsTroll.Api.Controllers
{
    [Route("api/auth/[action]")]
    public class AuthController: Controller
    {
        private readonly SigningConfigurations _signingConfigurations;

        public AuthController(SigningConfigurations signingConfigurations)
        {
            _signingConfigurations = signingConfigurations;
        }

        [HttpPost]
        public async Task<object> SignIn([FromBody] SignInModel Info,
            [FromServices]SigningConfigurations signingConfigurations,
            [FromServices]FirebaseController firebaseController)
        {
            using (var context = new DataContext())
            {
                User user = null;

                if (Info.refreshToken != null)
                {
                    Info.idToken = Info.refreshToken;
                    RefreshToken refresh = new RefreshTokenContext().GetToken(Info.refreshToken);
                    if (refresh.IsRevoked)
                        return Unauthorized();
                    else
                        user = refresh.User;

                }
                else
                {
                    var info = firebaseController.getAccountInfo(Info.idToken).users[0];
                    user = context.User.SingleOrDefault(q => q.FirebaseUid == info.localId);
                    if (user == null)
                    {
                        if (!info.emailVerified)
                            return null;
                        Console.WriteLine("NOT REGISTERED");
                        CreateUser(info);
                    }
                }

                ClaimsIdentity identity = CreateIdentity(user);
                SecurityToken securityToken = CreateToken(identity);
                String token = new JwtSecurityTokenHandler().WriteToken(securityToken);

                AuthResponse ret = new AuthResponse()
                {
                    authenticated = true,
                    //email = info.email,
                    expiration = DateTime.Now.AddSeconds(10),
                    accessToken = token,
                    message = "OK"
                };
                if(Info.refreshToken == null)
                {
                    ret.refreshToken = new RefreshTokenContext().CreateRefreshToken(user.Id).Id;
                }
                return ret;
            }
        }

        public SecurityToken CreateToken(ClaimsIdentity identity)
        {
            var handler = new JwtSecurityTokenHandler();
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                SigningCredentials = _signingConfigurations.SigningCredentials,
                Subject = identity,
                Expires = DateTime.Now.AddHours(12),
                NotBefore = DateTime.Now,
            });
            return securityToken;
        }

        private ClaimsIdentity CreateIdentity(User user)
        {
            ClaimsIdentity identity = new ClaimsIdentity(
                    new GenericIdentity(user.Id.ToString(), "Login"),
                new[] {
                    /*new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                    new Claim(JwtRegisteredClaimNames.UniqueName, user.UsrId.ToString()),*/
                    new Claim("name",user.Name),
                    new Claim("picture",$"https://api.adorable.io/avatars/285/{user.Username}.png"),
                    new Claim("UserId", user.Id.ToString())
                });
            return identity;
        }

        private void CreateUser(FirebaseApi.models.User info)
        {
            using (var context = new DataContext())
            {
                User user = new User()
                {
                    Email = info.email,
                    FirebaseUid = info.localId,
                    Name = info.displayName,
                    Username = UsernameGenerator.GenerateNew()
                };
                context.User.Add(user);
                context.SaveChanges();
            }
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Logout([FromBody] ActionLogout data)
        {
            if (data.token == null || data.token == "")
                return Ok();

            var identity = User.Identity as ClaimsIdentity;
            Claim identityClaim = identity.Claims.FirstOrDefault(c => c.Type == "UserId");
            int user = int.Parse(identityClaim.Value);
            using(var context = new DataContext())
            {
                var item = context.RefreshToken.Where(t => t.UserId == user && t.Id == data.token).SingleOrDefault();
                item.IsRevoked = true;
                context.RefreshToken.Update(item);
                context.SaveChanges();
            }
            return Ok();
        }

    }
}