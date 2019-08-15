using DbManager.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbManager.Contexts
{
    public class RefreshTokenContext : DataContext
    {
        public RefreshToken CreateRefreshToken(int User)
        {
            String token = Guid.NewGuid().ToString().Replace("-", String.Empty);
            RefreshToken refresh = new RefreshToken()
            {
                TokId = token,
                TokUser = User,
                TokRevoked = false
            }   ;
            using (var context = new DataContext())
            {
                context.RefreshToken.Add(refresh);
                context.SaveChanges();
            }
            return refresh;
        }

        public RefreshToken GetToken(String token)
        {
            using (var context = new DataContext())
            {
                var item = context.RefreshToken.Where(t => t.TokId == token)
                    .Include(t => t.TokUserNavigation)
                    .FirstOrDefault();
                return item;
            }
        }

        public void RevokeToken(String token)
        {
            using (var context = new DataContext())
            {
                var item = context.RefreshToken.Where(t => t.TokId == token && !t.TokRevoked).FirstOrDefault();
                item.TokRevoked = true;
                context.RefreshToken.Update(item);
                context.SaveChanges();
            }
        }
    }
}
