using System;
using System.Linq;
using System.Threading.Tasks;
using Hotsapp.Data;
using Hotsapp.Data.Model;

namespace Hotsapp.Payment
{
    public class BalanceService
    {
        private DataContext _dataContext;
        public BalanceService(DataContext dataContext)
        {
            _dataContext = dataContext;
        }

        public decimal GetBalance(int userId)
        {
            var account = _dataContext.UserAccount.Where(a => a.UserId == userId).Single();
            return account.Balance;
        }

        public async Task CreateBalance(int userId)
        {
            await _dataContext.UserAccount.AddAsync(new UserAccount()
            {
                Balance = 0,
                UserId = userId
            });
            await _dataContext.SaveChangesAsync();
        }

        public async Task AddCredits(int userId, decimal amount, int? paymentId = null)
        {
            var account = _dataContext.UserAccount.Where(a => a.UserId == userId).Single();
            _dataContext.Transaction.Add(new Transaction()
            {
                Amount = amount,
                UserId = userId,
                DateTimeUtc = DateTime.UtcNow,
                PaymentId = paymentId
            });
            account.Balance += amount;
            if (account.Balance < 0)
                throw new Exception("Not enough credits");
            await _dataContext.SaveChangesAsync();

        }
    }
}
