using System.Threading.Tasks;
using System.Net.Http.Headers;
using BraintreeHttp;

namespace PayPal.Core
{
    public class PayPalHttpClient : HttpClient
    {
        private string refreshToken;
        private IInjector gzipInjector;
        private IInjector authorizationInjector;

        public PayPalHttpClient(PayPalEnvironment environment) : this(environment, null)
        { }

        public PayPalHttpClient(PayPalEnvironment environment, string refreshToken) : base(environment)
        {
            this.refreshToken = refreshToken;
            gzipInjector = new GzipInjector();
            authorizationInjector = new AuthorizationInjector(this, environment, refreshToken);

            AddInjector(this.gzipInjector);
            AddInjector(this.authorizationInjector);
        }

        protected override string GetUserAgent()
        {
            return UserAgent.GetUserAgentHeader();
        }

        class AuthorizationInjector : IInjector
        {
            private HttpClient client;
            private PayPalEnvironment environment;
            private AccessToken accessToken;
            private string refreshToken;

            public AuthorizationInjector(HttpClient client, PayPalEnvironment environment, string refreshToken)
            {
                this.environment = environment;
                this.client = client;
                this.refreshToken = refreshToken;
            }

            public void Inject(HttpRequest request)
            {
                if (!request.Headers.Contains("Authorization") && !(request is AccessTokenRequest || request is RefreshTokenRequest))
                {
                    if (this.accessToken == null || this.accessToken.IsExpired())
                    {
                        var accessTokenResponse = fetchAccessToken();
                        this.accessToken = accessTokenResponse.Result<AccessToken>();
                    }
                    request.Headers.Authorization = new AuthenticationHeaderValue("Bearer", accessToken.Token);
                }
            }

            private HttpResponse fetchAccessToken()
            {
                AccessTokenRequest request = new AccessTokenRequest(environment, refreshToken);
                var executeTask = this.client.Execute(request);
                return executeTask.Result;
            }
        }

        private class GzipInjector : IInjector
        {
            public void Inject(HttpRequest request)
            {
                request.Headers.AcceptEncoding.Add(new StringWithQualityHeaderValue("gzip"));
            }
        }
    }
}
