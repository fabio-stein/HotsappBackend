using System;
using System.Linq;
using System.Threading.Tasks;
using Hotsapp.Data;
using Hotsapp.Data.Model;
using Hotsapp.Data.Util;

namespace Hotsapp.Payment
{
    public class BalanceService
    {
        public BalanceService()
        {
        }

        public decimal GetBalance(int userId)
        {
            using (var context = DataFactory.GetContext())
            {
                var account = context.UserAccount.Where(a => a.UserId == userId).Single();
                return account.Balance;
            }
        }

        public async Task CreateBalance(int userId)
        {
            using (var context = DataFactory.GetContext())
            {
                await context.UserAccount.AddAsync(new UserAccount()
                {
                    Balance = 0,
                    UserId = userId
                });
                await context.SaveChangesAsync();
            }
        }

        public async Task AddCredits(int userId, decimal amount, int? paymentId = null)
        {
            using (var context = DataFactory.GetContext())
            {
                var account = context.UserAccount.Where(a => a.UserId == userId).Single();
                context.Transaction.Add(new Transaction()
                {
                    Amount = amount,
                    UserId = userId,
                    DateTimeUtc = DateTime.UtcNow,
                    PaymentId = paymentId
                });
                account.Balance += amount;
                if (account.Balance < 0)
                    throw new Exception("Not enough credits");
                await context.SaveChangesAsync();
                //TODO - CONCURRENT TRANSACTIONS
            }
        }

        public async Task TryTakeCredits(int userId, decimal amount)
        {
            await AddCredits(userId, amount * -1);
            //TODO - CONCURRENT TRANSACTIONS
        }
    }
}
