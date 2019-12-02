// This class was generated on Tue, 30 Jan 2018 11:02:44 PST by version 0.1.0-dev+6beb51-dirty of Braintree SDK Generator
// WebhookListEventSubscriptionsRequest.cs
// @version 0.1.0-dev+6beb51-dirty
// @type request
// @data H4sIAAAAAAAC/7yUTW/TQBCG7/yK1Zy3deDAwbeqCbTiK0DEpYqiSTzBC86uuzNusSL/d7S2E7wxUPGhniK/Ga+eZ/zae3iLO4IU7mmdO/f1vDAsK7ojKyuu1rzxphTjLIOGKR0vIYXXhoVVO6miSbV1XqHqD9RqXavr6TloeF+Rr+focUdCniG9WWq4IszIn6YvnN+dZnOUPMr2sKjLwM7ijf0MGj6hN7guKHZamQw0vKK6j0cqi5zU9VS5rZKcDuCtxn1uNrkSp8JaYs1gdOE91h3ERMMHwuydLWpIt1gwheC2Mp4ySMVXpGHuXUleDDGktiqKZtnNEEt3SAhDxKWzTF12tJy1qw4XKux+rPt7yXBPUDzotU/uzyz6YKhx8xO8MVnXJ6lL4ggyzmPeC6swgD3I/PzvmX9VnGxAMuSN8xNelVc7tGeeMAtHqcHwoVot/7+uvG2OftDBhp8hfB+Mq19Zc1v1cCpMPRIhC0oVF+IYjSm7v8ImMe7Df6FdNstGw6WzQrZ/GQHLsjAbDAzJF24f+ZVI+YYkdxmk8HK2gO6zBCkkd08T68Rs+zs46SE52f/4DjVJi3x2qPzsW0kboexjK3fpMoL02WTSPPkOAAD//w==
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
    /// Lists event subscriptions for a webhook, by ID.
    /// </summary>
    public class WebhookListEventSubscriptionsRequest : HttpRequest
    {
        public WebhookListEventSubscriptionsRequest(string WebhookId) : base("/v1/notifications/webhooks/{webhook_id}/event-types?", HttpMethod.Get, typeof(EventTypeList))
        {
            try {
                this.Path = this.Path.Replace("{webhook_id}", Uri.EscapeDataString(Convert.ToString(WebhookId) ));
            } catch (IOException) {}
            
            this.ContentType =  "application/json";
        }
        
    }
}
