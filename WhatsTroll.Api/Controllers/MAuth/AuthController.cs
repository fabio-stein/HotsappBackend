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
using WhatsTroll.Data.Model;
using WhatsTroll.Data.Context;
using System.Transactions;
using WhatsTroll.Data;
using WhatsTroll.Payment;

namespace WhatsTroll.Api.Controllers
{
    [Route("api/auth/[action]")]
    public class AuthController: Controller
    {
        private readonly SigningConfigurations _signingConfigurations;
        private BalanceService _balanceService;
        private UsernameGenerator _usernameGenerator;
        private FirebaseService _firebaseService;
        private DataFactory _dataFactory;

        public AuthController(SigningConfigurations signingConfigurations, BalanceService balanceService, UsernameGenerator usernameGenerator, FirebaseService firebaseService, DataFactory dataFactory)
        {
            _signingConfigurations = signingConfigurations;
            _balanceService = balanceService;
            _usernameGenerator = usernameGenerator;
            _firebaseService = firebaseService;
            _dataFactory = dataFactory;
        }

        [HttpPost]
        public async Task<ActionResult> SignIn([FromBody] SignInModel Info)
        {
            using (var scope = new TransactionScope())
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
                    var info = _firebaseService.getAccountInfo(Info.idToken).users[0];
                    using (var context = DataFactory.CreateNew())
                    {
                        user = context.User.SingleOrDefault(q => q.FirebaseUid == info.localId);
                    }
                    if (user == null)
                    {
                        if (!info.emailVerified)
                            return null;
                        Console.WriteLine("NOT REGISTERED");
                        user = await CreateUser(info);
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
                if (Info.refreshToken == null)
                {
                    ret.refreshToken = new RefreshTokenContext().CreateRefreshToken(user.Id).Id;
                }
                scope.Complete();
                return Ok(ret);
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

        private async Task<User> CreateUser(FirebaseApi.models.User info)
        {
            var username = _usernameGenerator.GenerateNew();
            using (var context = DataFactory.CreateNew())
            {
                User user = new User()
                {
                    Email = info.email,
                    FirebaseUid = info.localId,
                    Name = info.displayName,
                    Username = username
                };
                await context.User.AddAsync(user);
                await context.SaveChangesAsync();
                await _balanceService.CreateBalance(user.Id);
                await context.SaveChangesAsync();
                return user;
            }
        }

        /*
        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Logout([FromBody] ActionLogout data)
        {
            if (data.token == null || data.token == "")
                return Ok();

            var identity = User.Identity as ClaimsIdentity;
            Claim identityClaim = identity.Claims.FirstOrDefault(c => c.Type == "UserId");
            int user = int.Parse(identityClaim.Value);
            using(var context = DataFactory.CreateNew())
            {
                var item = context.RefreshToken.Where(t => t.UserId == user && t.Id == data.token).SingleOrDefault();
                item.IsRevoked = true;
                context.RefreshToken.Update(item);
                context.SaveChanges();
            }
            return Ok();
        }*/

    }
}