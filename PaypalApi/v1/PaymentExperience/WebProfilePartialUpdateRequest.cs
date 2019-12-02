// This class was generated on Tue, 30 Jan 2018 11:02:41 PST by version 0.1.0-dev+6beb51-dirty of Braintree SDK Generator
// WebProfilePartialUpdateRequest.cs
// @version 0.1.0-dev+6beb51-dirty
// @type request
// @data H4sIAAAAAAAC/7SVUU/bQAzH3/cpLD8fLZumPeQNwSbYNOgG2suEwE1ccii9O3wOJUL97tMlaUtTNMamvbX/cxz//Hd8j3hKc8YMFzzdC+JntuJRIFFL1V4dClJGg0ccc7FBrXeY4aQ7rpo+IALBgqfAD4HFsssZ+kwGpg2cHI3gxIGWDJ/Pz05B+K7mqDD1RWMgBs7trAGCQJqX4Ke3nKtpwwNpCX7W/e4yQuVzSnWAeuheb4BcAQSOF3BPVc0jNPitZmkmJDRnZYmY/bw0eMxUsAzVT17mQ21CWm5pj3jRhNSnqGLdDRr8QWJpWnHfv76+K1ugwS/c9PJO8y5KhpOjIZV6CKuu9liJ4kCEmu7F+wa/MxVnrmowm1EVOQl3tRUuMFOp2eBEfGBRyxEzV1fV8rKL4ahdkjVFa8QkNfwZkiRf9S5twQxPtskOHFCqN7G1+Z8aGhMihVA1K1BYDY96EI6+lpzjAPrDb6F74Sn1yz7NxM+3oHphwNITeOuUJZWY3FrPnu3GWUluWKHweT1np5BSwaK0eZmemPt7bsO6oYRV4TDz0urXKeIaUvVt2lc5/gx8a7l5sQM+bPG3f3dndF1VQsn9PFT8ypn8+wrTdz8cvPIPPKIXHSLd+LOCagP/lwnd9O8itjOxxbhSdq1oT9bfzwiSdi08mB4oPEdwXtsFa4WBNuvwn4kulykqBu8id3mSbPDQO2XXrxdMBdrOgfFt9A4NHquGr6ylL9LNcXBxeIzdesUMx/dvx4Ga5Mze5vIYP7mK4vhxs1iXaPDjQ+BcuThX0joe+oIxe7f/fvnmFwAAAP//
// DO NOT EDIT
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Collections.Generic;
using BraintreeHttp;


namespace PayPal.v1.PaymentExperience
{
    /// <summary>
    /// Partially-updates a web experience profile, by ID. In the JSON request body, specify a patch object, the path of the profile location to update, and a new value.
    /// </summary>
    public class WebProfilePartialUpdateRequest<T> : HttpRequest
    {
        public WebProfilePartialUpdateRequest(string ProfileId) : base("/v1/payment-experience/web-profiles/{profile_id}?", new HttpMethod("PATCH"), typeof(void))
        {
            try {
                this.Path = this.Path.Replace("{profile_id}", Uri.EscapeDataString(Convert.ToString(ProfileId) ));
            } catch (IOException) {}
            
            this.ContentType =  "application/json";
        }
        
        public WebProfilePartialUpdateRequest<T> RequestBody(List<JsonPatch<T>> PatchRequest)
        {
            this.Body = PatchRequest;
            return this;
        }
    }
}
