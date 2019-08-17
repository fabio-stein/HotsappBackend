using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using FirebaseApi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Sonoris.Api.Auth.Model;
using Sonoris.Api.Configuration;
using DbManager.Contexts;
using DbManager.Model;
using System.Security.Claims;
using System.Security.Principal;
using Sonoris.Api.Util;
using FirebaseApi.models;
using System.Threading.Tasks;
using Sonoris.Api.Controllers.MAuth.Model;
using Microsoft.AspNetCore.Authorization;
using Sonoris.Api.Controllers.MChannelPlaylist.Action;

namespace Sonoris.Api.Controllers
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
        public async Task<dynamic> SignIn([FromBody] SignInModel Info,
            [FromServices]SigningConfigurations signingConfigurations,
            [FromServices]FirebaseController firebaseController)
        {
            using (var context = new DataContext())
            {
                DbManager.Model.User user = null;

                if (Info.refreshToken != null)
                {
                    Info.idToken = Info.refreshToken;
                    RefreshToken refresh = new RefreshTokenContext().GetToken(Info.refreshToken);
                    if (refresh.TokRevoked)
                        return Unauthorized();
                    else
                        user = refresh.TokUserNavigation;

                }
                else
                {
                    var info = firebaseController.getAccountInfo(Info.idToken).users[0];
                    user = context.User.SingleOrDefault(q => q.UsrFirebaseUid == info.localId);
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
                    ret.refreshToken = new RefreshTokenContext().CreateRefreshToken(user.UsrId).TokId;
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
                Expires = DateTime.Now.AddSeconds(10),
                NotBefore = DateTime.Now,
            });
            return securityToken;
        }

        private ClaimsIdentity CreateIdentity(DbManager.Model.User user)
        {
            ClaimsIdentity identity = new ClaimsIdentity(
                    new GenericIdentity(user.UsrId.ToString(), "Login"),
                new[] {
                    /*new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                    new Claim(JwtRegisteredClaimNames.UniqueName, user.UsrId.ToString()),*/
                    new Claim("name",user.UsrName),
                    new Claim("picture",$"https://api.adorable.io/avatars/285/{user.UsrUsername}.png"),
                    new Claim("UserId", user.UsrId.ToString())
                });
            return identity;
        }

        private void CreateUser(FirebaseApi.models.User info)
        {
            using (var context = new DataContext())
            {
                DbManager.Model.User user = new DbManager.Model.User()
                {
                    UsrEmail = info.email,
                    UsrFirebaseUid = info.localId,
                    UsrName = info.displayName,
                    UsrUsername = UsernameGenerator.GenerateNew()
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
                var item = context.RefreshToken.Where(t => t.TokUser == user && t.TokId == data.token).SingleOrDefault();
                item.TokRevoked = true;
                context.RefreshToken.Update(item);
                context.SaveChanges();
            }
            return Ok();
        }

    }
}