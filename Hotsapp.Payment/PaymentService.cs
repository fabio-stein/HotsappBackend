using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;
using Hotsapp.Data;
using Hotsapp.Data.Model;

namespace Hotsapp.Payment
{
    public class PaymentService
    {
        private PayPalClient _paypalClient;
        private BalanceService _balanceService;
        private DataContext _dataContext;
        public PaymentService(IConfiguration configuration, BalanceService balanceService, DataContext dataContext)
        {
            _balanceService = balanceService;
            _dataContext = dataContext;

            var clientId = configuration.GetSection("Payment")["PaypalClientId"];
            var clientSecret = configuration.GetSection("Payment")["PaypalClientSecret"];
            var isLive = configuration.GetSection("Payment")["Mode"] == "Live";
            _paypalClient = new PayPalClient(clientId, clientSecret, !isLive);
        }

        public async Task CaptureOrder(string orderId, int userId)
        {
            /*DISABLED
            using (var scope = new TransactionScope(TransactionScopeAsyncFlowOption.Enabled))
            {
                var order = await _paypalClient.CaptureOrder(orderId);

                if (order.Status != "COMPLETED")
                    throw new Exception("Order not completed");

                var amount = order.PurchaseUnits[0].AmountWithBreakdown;
                var value = decimal.Parse(amount.Value, CultureInfo.InvariantCulture);
                if (amount.CurrencyCode != "BRL" || value < 5)
                    throw new Exception("Invalid Operation");

                var payment = new Data.Model.Payment()
                {
                    Amount = value,
                    DateTimeUtc = DateTime.UtcNow,
                    PaypalOrderId = order.Id,
                    UserId = userId
                };
                await _dataContext.Payment.AddAsync(payment);
                await _dataContext.SaveChangesAsync();
                await _balanceService.AddCredits(userId, value, new BalanceService.TransactionOptions { paymentId = payment.Id });
                scope.Complete();
            }*/
        }
    }
}
