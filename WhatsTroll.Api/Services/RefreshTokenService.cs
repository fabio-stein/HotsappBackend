using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WhatsTroll.Data.Model;

namespace WhatsTroll.Api.Services
{
    public class RefreshTokenService
    {
        private DataContext _dataContext;
        public RefreshTokenService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public RefreshToken CreateRefreshToken(int User)
        {
            String token = Guid.NewGuid().ToString().Replace("-", String.Empty);
            RefreshToken refresh = new RefreshToken()
            {
                Id = token,
                UserId = User,
                IsRevoked = false
            };
            _dataContext.RefreshToken.Add(refresh);
            _dataContext.SaveChanges();
            return refresh;
        }

        public RefreshToken GetToken(String token)
        {
            var item = _dataContext.RefreshToken.Where(t => t.Id == token)
                .Include(t => t.User)
                .FirstOrDefault();
            return item;
        }

        public void RevokeToken(String token)
        {
            var item = _dataContext.RefreshToken.Where(t => t.Id == token && !t.IsRevoked).FirstOrDefault();
            item.IsRevoked = true;
            _dataContext.RefreshToken.Update(item);
            _dataContext.SaveChanges();
        }
    }
}
