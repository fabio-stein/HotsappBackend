using BraintreeHttp;
using PayPal.Core;
using PayPal.v1.Orders;
using PayPal.v1.Subscriptions;
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
    }
}