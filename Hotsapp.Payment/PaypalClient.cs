using BraintreeHttp;
using PayPal.Core;
using PayPal.v1.Orders;
using PayPal.v1.Payments;
using PayPal.v1.Subscriptions;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Hotsapp.Payment
{
    public class PayPalClient
    {
        private PayPalEnvironment _environment;
        private PayPalHttpClient _client;
        public PayPalClient(string clientId, string clientSecret, bool isSandbox)
        {
            if (isSandbox)
                _environment = new SandboxEnvironment(clientId, clientSecret);
            else
                _environment = new LiveEnvironment(clientId, clientSecret);

            _client = new PayPalHttpClient(_environment);
        }

        public async Task<Subscription> GetSubscription(string subscriptionId)
        {
            var request = new SubscriptionGetRequest(subscriptionId);
            var response = await _client.Execute(request);
            var result = response.Result<Subscription>();
            return result;
        }

        public async Task CancelSubscription(string subscriptionId, string reason)
        {
            var request = new SubscriptionCancelRequest(subscriptionId);
            request.RequestBody(reason);
            await _client.Execute(request);
        }

        public async Task<Subscription> CreateSubscription(string planId)
        {
            var request = new SubscriptionCreateRequest();
            request.RequestBody(planId);
            var response = await _client.Execute(request);
            var result = response.Result<Subscription>();
            return result;
        }

        public async Task<PayPal.v1.Orders.Order> CaptureOrder(string OrderId)
        {
            var request = new OrdersCaptureRequest(OrderId);
            request.RequestBody();
            var response = await _client.Execute(request);
            var result = response.Result<PayPal.v1.Orders.Order>();
            return result;
        }

        public async Task<PayPal.v1.Orders.Order> GetOrder(string OrderId)
        {
            var request = new OrdersGetRequest(OrderId);
            var response = await _client.Execute(request);
            var result = response.Result<PayPal.v1.Orders.Order>();
            return result;
        }

        public async Task<PayPal.v1.Orders.Order> CreateOrder(int credits, string price)
        {
            var request = new OrdersCreateRequest();
            var purchaseUnits = new List<PurchaseUnit>();
            var items = new List<PayPal.v1.Orders.Item>();
            items.Add(new PayPal.v1.Orders.Item()
            {
                Name = "Créditos",
                Quantity = credits.ToString(),
                Currency = "BRL",
                Price = "0"
            });
            purchaseUnits.Add(new PurchaseUnit() {
                ReferenceId = "LOCALIDCODE",
                Amount = new PayPal.v1.Orders.Amount() {
                    Currency = "BRL",
                    Total = price
                },
                Items = items,
                PaymentDescriptor = "HotsApp.net"
            });
            request.RequestBody(new PayPal.v1.Orders.Order()
            {
                PurchaseUnits = purchaseUnits,
                RedirectUrls = new PayPal.v1.Orders.RedirectUrls()
                {
                    CancelUrl = "https://hotsapp.net",
                    ReturnUrl = "https://hotsapp.net"
                },
                Intent = "SALE"
            });
            var response = await _client.Execute(request);
            var result = response.Result<PayPal.v1.Orders.Order>();
            return result;
        }
    }
}