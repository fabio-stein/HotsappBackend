using FirebaseApi;
using Hotsapp.Data.Model;
using Hotsapp.WebApi.Configuration;
using Hotsapp.WebApi.Services;
using Hotsapp.WebApi.Util;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace Hotsapp.WebApi.Controllers
{
    [Route("api/auth/[action]")]
    public class AuthController : Controller
    {
        private readonly SigningConfigurations _signingConfigurations;
        private FirebaseService _firebaseService;
        private DataContext _dataContext;
        private ILogger<AuthController> _log;

        public AuthController(SigningConfigurations signingConfigurations, FirebaseService firebaseService, DataContext dataContext, ILogger<AuthController> log)
        {
            _signingConfigurations = signingConfigurations;
            _firebaseService = firebaseService;
            _dataContext = dataContext;
            _log = log;
        }

        [HttpPost]
        public async Task<ActionResult> SignIn([FromBody] SignInModel Info)
        {
            User user;

            if (Info.refreshToken != null)
            {
                _log.LogInformation("New login request through refreshToken");
                Info.idToken = Info.refreshToken;
                var refreshToken = await RefreshTokenService.GetToken(Info.refreshToken);
                if (refreshToken == null || refreshToken.IsRevoked)
                {
                    _log.LogInformation("Invalid refresh token {0}", Info.refreshToken);
                    return Unauthorized();
                }
                else
                {
                    user = refreshToken.User;
                    _log.LogInformation("Accepted refresh token {0}, authenticating user: {1}", Info.refreshToken, user.Id);
                }
            }
            else
            {
                _log.LogInformation("New login request through Firebase");
                var info = (await _firebaseService.getAccountInfo(Info.idToken)).users.First();
                user = _dataContext.User.SingleOrDefault(q => q.FirebaseUid == info.localId);
                _log.LogInformation("Firebase user found");
                if (user == null)
                {
                    if (!info.emailVerified)
                    {
                        _log.LogInformation("User with email not verified");
                        return BadRequest("Email not verified");
                    }
                    user = await CreateUser(info);
                }
            }

            if (user.Disabled)
            {
                _log.LogInformation("User disabled");
                return BadRequest("User disabled");
            }

            ClaimsIdentity identity = CreateIdentity(user);
            SecurityToken securityToken = CreateToken(identity);
            var token = new JwtSecurityTokenHandler().WriteToken(securityToken);

            AuthResponse ret = new AuthResponse()
            {
                authenticated = true,
                //email = info.email,
                expiration = DateTime.Now.AddHours(20),
                accessToken = token,
                message = "OK"
            };
            if (Info.refreshToken == null)
            {
                ret.refreshToken = (await RefreshTokenService.CreateRefreshToken(user.Id)).Id;
            }
            _log.LogInformation("Successfully created session for user {0}", user.Id);
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
            _log.LogInformation("Creating new user");
            var username = await UsernameGeneratorService.GenerateNew();
            _log.LogInformation("Generated username: {0}", username);
            User user = new User()
            {
                Email = info.email,
                FirebaseUid = info.localId,
                Name = info.displayName,
                Username = username
            };
            await _dataContext.User.AddAsync(user);
            await _dataContext.SaveChangesAsync();
            _log.LogInformation("New user saved");
            return user;
        }


        [Authorize]
        [HttpPost]
        public async Task<IActionResult> Logout([FromBody] ActionLogout data)
        {
            if (data.token == null || data.token == "")
                return NoContent();
            await RefreshTokenService.RevokeToken(data.token);
            return Ok();
        }

    }

    public class ActionLogout
    {
        public string token { get; set; }
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