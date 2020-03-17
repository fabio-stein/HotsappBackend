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

        public Wallet GetWallet(int userId)
        {
            using (var context = DataFactory.GetContext())
            {
                var wallet = context.Wallet.Where(a => a.UserId == userId).SingleOrDefault();
                return wallet;
            }
        }

        public async Task<Wallet> CreateWallet(int userId)
        {
            using (var context = DataFactory.GetContext())
            {
                var wallet = new Wallet()
                {
                    Amount = 0,
                    UserId = userId
                };
                await context.Wallet.AddAsync(wallet);
                await context.SaveChangesAsync();
                return wallet;
            }
        }

        public async Task CreditsTransaction(int userId, decimal amount, TransactionOptions options = null)
        {
            using (var context = DataFactory.GetContext())
            {
                var account = context.Wallet.Where(a => a.UserId == userId).Single();
                context.WalletTransaction.Add(new WalletTransaction()
                {
                    Amount = amount,
                    WalletId = userId,
                    DateTimeUtc = DateTime.UtcNow,
                    PaymentId = options.paymentId,
                });
                account.Amount += amount;
                if ((options == null || !options.forceBilling) && account.Amount < 0)
                    throw new Exception("Not enough credits");
                await context.SaveChangesAsync();
            }
        }

        public async Task TryTakeCredits(int userId, decimal amount, TransactionOptions options)
        {
            await CreditsTransaction(userId, amount * -1, options);
            //TODO - CONCURRENT TRANSACTIONS
        }

        public class TransactionOptions
        {
            public Guid? paymentId { get; set; }
            public bool forceBilling = false;
        }
    }
}
