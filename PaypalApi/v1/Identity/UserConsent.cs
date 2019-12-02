using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Collections.Generic;
using BraintreeHttp;
using PayPal.Core;

namespace PayPal.v1.Identity
{
    public class UserConsent
    {       
        private string URL;

        public UserConsent(PayPalEnvironment Environment)
        {
            this.URL = $"{Environment.WebUrl()}/signin/authorize?client_id={Environment.ClientId()}&";
        }

        public UserConsent ResponseType(string ResponseType)
        {
            this.URL = $"{this.URL}response_type={ResponseType}&";
            return this;
        }
        public UserConsent Scope(string Scope)
        {
            this.URL = $"{this.URL}scope={Scope}&";
            return this;
        }
        public UserConsent RedirectUri(string RedirectUri)
        {
            this.URL = $"{this.URL}redirect_uri={RedirectUri}&";
            return this;
        }
        public UserConsent Nonce(string Nonce)
        {
            this.URL = $"{this.URL}nonce={Nonce}&";
            return this;
        }
        public UserConsent State(string State)
        {
            this.URL = $"{this.URL}state={State}&";
            return this;
        }

        public string Build()
        {
            return this.URL;
        }
    }
}
