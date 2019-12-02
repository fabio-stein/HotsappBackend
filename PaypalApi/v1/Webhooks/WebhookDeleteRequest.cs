// This class was generated on Tue, 30 Jan 2018 11:02:44 PST by version 0.1.0-dev+6beb51-dirty of Braintree SDK Generator
// WebhookDeleteRequest.cs
// @version 0.1.0-dev+6beb51-dirty
// @type request
// @data H4sIAAAAAAAC/2SQzU7jMBSF9/MU1llbTWc0K+9QE9SKvwIVG1Qht74lhtQ29g0QVX13ZBIELdtPx77fOTtc6i1B4Y1WtffPI0MNMUGipLSONrD1DgrlJ05CiyEoxaoTs3IEieuWYjfXUW+JKSao+6XElLSheExPfdwes7nm+oDtsOhCdkocrXuExJ2OVq8aOnR9sAYSZ9QN+Jf0oiYxK4XfCK7pS1ywF33J7H4So+76c2OJG9LmyjUd1EY3iTJ4aW0kA8WxJYl59IEiW0pQrm2a/bLPUOL+kwwzSsG7RD/ZxDsmN8SgQ2jsWmfR4il5B4kpc7ggrr3Je1fn1aJCvw4Uite/hfNsN8OjVAx1UrH7nmMPieo90JrJ3LLmNk28Iah/4//7Px8AAAD//w==
// DO NOT EDIT
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Collections.Generic;
using BraintreeHttp;


namespace PayPal.v1.Webhooks
{
    /// <summary>
    /// Deletes a webhook, by ID.
    /// </summary>
    public class WebhookDeleteRequest : HttpRequest
    {
        public WebhookDeleteRequest(string WebhookId) : base("/v1/notifications/webhooks/{webhook_id}?", HttpMethod.Delete, typeof(void))
        {
            try {
                this.Path = this.Path.Replace("{webhook_id}", Uri.EscapeDataString(Convert.ToString(WebhookId) ));
            } catch (IOException) {}
            
            this.ContentType =  "application/json";
        }
        
    }
}
