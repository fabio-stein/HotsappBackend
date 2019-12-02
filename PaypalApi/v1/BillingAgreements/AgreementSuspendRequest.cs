// This class was generated on Tue, 30 Jan 2018 11:14:21 PST by version 0.1.0-dev+6beb51-dirty of Braintree SDK Generator
// AgreementSuspendRequest.cs
// @version 0.1.0-dev+6beb51-dirty
// @type request
// @data H4sIAAAAAAAC/6STT28TMRDF73wKa86mWxAn36IG1ApBA4m4oKqarCdZo41tZmYRqyjfHZnd5q9UhHrct8/2782zt/AZNwQOcM1EG4p6JZ1kih4sTElqDllDiuBgPuhi0CxD24a4NvtF1ix7cze9AgtfOuJ+howbUmIB9/3Bwi2hJz5XPyTenGsz1OZE28Kiz4VQlENcg4VvyAGXLZ2TP4YC/ZH68cdFgkVD5m5q0spoQwd4o8mMoUuACTP2w5nXFr4S+vvY9uBW2AoV4WcXmDw45Y4szDhlYg0k4GLXtruHwUOiwyb7AJP9gXNFJfMEl/i5UFK8j/7Ye4j4rO00/MT4w/fTDOqOuQD9XX0xmP+axigcj+Pf3cWkdBJoFC57Y0JJ0awSn5U3oNcNxjW9FHjob1dcklMUGvYpsoWbFJXiWCpgzm2osRBWPyRFsHCrmj+RNsmDg9n9fAHDdQYH1a83Vca+AEs1vp7X+wxSbY8v8a46PMH3vzPVSr7cmE5ukidwb6/f7V79AQAA//8=
// DO NOT EDIT
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Collections.Generic;
using BraintreeHttp;


namespace PayPal.v1.BillingAgreements
{
    /// <summary>
    /// Suspends a billing agreement, by ID.
    /// </summary>
    public class AgreementSuspendRequest : HttpRequest
    {
        public AgreementSuspendRequest(string AgreementId) : base("/v1/payments/billing-agreements/{agreement_id}/suspend?", HttpMethod.Post, typeof(void))
        {
            try {
                this.Path = this.Path.Replace("{agreement_id}", Uri.EscapeDataString(Convert.ToString(AgreementId) ));
            } catch (IOException) {}
            
            this.ContentType =  "application/json";
        }
        
        public AgreementSuspendRequest RequestBody(AgreementStateDescriptor AgreementStateDescriptor)
        {
            this.Body = AgreementStateDescriptor;
            return this;
        }
    }
}
