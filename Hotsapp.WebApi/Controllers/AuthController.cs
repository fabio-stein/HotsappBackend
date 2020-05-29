using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using FirebaseApi;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;
using Hotsapp.Data.Model;
using Hotsapp.Data.Util;
using Hotsapp.WebApi.Configuration;
using Hotsapp.WebApi.Util;
using Hotsapp.WebApi.Services;

namespace Hotsapp.Api.Controllers
{
    [Route("api/auth/[action]")]
    public class AuthController: Controller
    {
        private readonly SigningConfigurations _signingConfigurations;
        private UsernameGeneratorService _usernameGenerator;
        private FirebaseService _firebaseService;
        private DataContext _dataContext;
        private RefreshTokenService _refreshTokenService;

        public AuthController(SigningConfigurations signingConfigurations, UsernameGeneratorService usernameGenerator, FirebaseService firebaseService, DataContext dataContext, RefreshTokenService refreshTokenService)
        {
            _signingConfigurations = signingConfigurations;
            _usernameGenerator = usernameGenerator;
            _firebaseService = firebaseService;
            _dataContext = dataContext;
            _refreshTokenService = refreshTokenService;
        }

        [HttpPost]
        public async Task<ActionResult> SignIn([FromBody] SignInModel Info)
        {
            User user = null;

            if (Info.refreshToken != null)
            {
                Info.idToken = Info.refreshToken;
                RefreshToken refresh = _refreshTokenService.GetToken(Info.refreshToken);
                if (refresh.IsRevoked)
                    return Unauthorized();
                else
                    user = refresh.User;

            }
            else
            {
                var info = _firebaseService.getAccountInfo(Info.idToken).users[0];
                user = _dataContext.User.SingleOrDefault(q => q.FirebaseUid == info.localId);
                if (user == null)
                {
                    if (!info.emailVerified)
                        return null;
                    Console.WriteLine("NOT REGISTERED");
                    user = await CreateUser(info);
                }
            }

            if (user.Disabled)
                return BadRequest("User disabled");

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
                ret.refreshToken = _refreshTokenService.CreateRefreshToken(user.Id).Id;
            }
            return Ok(ret);

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

        private async Task<User> CreateUser(FirebaseUser info)
        {
            var username = _usernameGenerator.GenerateNew();
            User user = new User()
            {
                Email = info.email,
                FirebaseUid = info.localId,
                Name = info.displayName,
                Username = username
            };
                await _dataContext.User.AddAsync(user);
                await _dataContext.SaveChangesAsync();
            return user;
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

    public class AuthResponse
    {
        public bool authenticated { get; set; }
        public string email { get; set; }
        public DateTime expiration { get; set; }
        public string accessToken { get; set; }
        public string message { get; set; }
        public string refreshToken { get; set; }
    }

    public class SignInModel
    {
        public string idToken { get; set; }
        public string refreshToken { get; set; }
    }
}