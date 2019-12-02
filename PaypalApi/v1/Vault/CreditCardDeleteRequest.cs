// This class was generated on Tue, 30 Jan 2018 11:02:44 PST by version 0.1.0-dev+6beb51-dirty of Braintree SDK Generator
// CreditCardDeleteRequest.cs
// @version 0.1.0-dev+6beb51-dirty
// @type request
// @data H4sIAAAAAAAC/2yRzW4aMRDH730Ka84uS3v0rWK3AvWLtiiXCKFhPWQdGdsZz6KsEO8emeUAJNefZzz/jyP8xj2BgZbJOvncItuJJU9CoKGm3LJL4mIAA/UZZ4XqgL0XsmpcUmVJq+2gFvUENPztiYclMu5JiDOYx7WGOaElvqffI+/v2RKlu2FHWA2paMzCLjyBhgdkh1tPN9o3RcbGWdDwg4bL0zsTq47UolZxp6Sjj4woiWoMoHj5xozDeH6q4R+h/RP8AGaHPlMBL71jsmCEe9Kw5JiIxVEGE3rvT+txhrKMnxRYUE4xZLpmsxiEwmUMMCXvWiyiq+ccA2iYi6RfJF20pYvmZ7NqYEwLDFSHL9XZTHVVZK6Ot9GcQEPzmqgVsv8Fpc+zaAnM1+n09OkNAAD//w==
// DO NOT EDIT
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Collections.Generic;
using BraintreeHttp;


namespace PayPal.v1.Vault
{
    /// <summary>
    /// Deletes a vaulted credit card, by ID.
    /// </summary>
    public class CreditCardDeleteRequest : HttpRequest
    {
        public CreditCardDeleteRequest(string CreditCardId) : base("/v1/vault/credit-cards/{credit_card_id}?", HttpMethod.Delete, typeof(void))
        {
            try {
                this.Path = this.Path.Replace("{credit_card_id}", Uri.EscapeDataString(Convert.ToString(CreditCardId) ));
            } catch (IOException) {}
            
            this.ContentType =  "application/json";
        }
        
    }
}
