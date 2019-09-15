using BraintreeHttp;
using PayPalCheckoutSdk.Core;
using PayPalCheckoutSdk.Orders;
using System.Threading.Tasks;

namespace Hotsapp.Payment
{
    public class PaypalClient
    {
        private PayPalEnvironment _environment;
        private HttpClient _client;
        public PaypalClient(string clientId, string clientSecret, bool isSandbox)
        {
            if (isSandbox)
                _environment = new SandboxEnvironment(clientId, clientSecret);
            else
                _environment = new LiveEnvironment(clientId, clientSecret);

            _client = new PayPalHttpClient(_environment);
        }

        public async Task<Order> GetOrder(string orderId)
        {
            OrdersGetRequest request = new OrdersGetRequest(orderId);
            var response = await _client.Execute(request);
            var result = response.Result<Order>();
            return result;
        }

        public async Task<Order> CaptureOrder(string OrderId)
        {
            var request = new OrdersCaptureRequest(OrderId);
            request.Prefer("return=representation");
            request.RequestBody(new OrderActionRequest());
            var response = await _client.Execute(request);
            var result = response.Result<Order>();
            return result;
        }
    }
}