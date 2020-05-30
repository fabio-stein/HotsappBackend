using Hotsapp.Data.Model;
using Hotsapp.Data.Util;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace Hotsapp.WebApi.Services
{
    public class RefreshTokenService
    {
        public static async Task<RefreshToken> CreateRefreshToken(int User)
        {
            using (var ctx = DataFactory.GetDataContext())
            {
                var token = Guid.NewGuid().ToString().Replace("-", string.Empty);
                var refresh = new RefreshToken()
                {
                    Id = token,
                    UserId = User,
                    IsRevoked = false,
                    CreateDateUTC = DateTime.UtcNow
                };
                await ctx.RefreshToken.AddAsync(refresh);
                await ctx.SaveChangesAsync();
                return refresh;
            }
        }

        public static async Task<RefreshToken> GetToken(string token)
        {
            using (var ctx = DataFactory.GetDataContext())
            {
                var item = await ctx.RefreshToken.Where(t => t.Id == token)
                .Include(t => t.User)
                .FirstOrDefaultAsync();
                return item;
            }
        }

        public static async Task RevokeToken(string token)
        {
            using (var ctx = DataFactory.GetDataContext())
            {
                var item = await ctx.RefreshToken.Where(t => t.Id == token && !t.IsRevoked).FirstOrDefaultAsync();
                item.IsRevoked = true;
                ctx.RefreshToken.Update(item);
                ctx.SaveChanges();
            }
        }
    }
}
