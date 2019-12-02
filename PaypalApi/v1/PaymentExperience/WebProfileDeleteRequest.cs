// This class was generated on Tue, 30 Jan 2018 11:02:41 PST by version 0.1.0-dev+6beb51-dirty of Braintree SDK Generator
// WebProfileDeleteRequest.cs
// @version 0.1.0-dev+6beb51-dirty
// @type request
// @data H4sIAAAAAAAC/2SRT4/TMBDF73wKa87eTeHoG9oE7Yp/BSouaIWc+JUYObYZT9hGVb87Colo6V5/Gnt+896RPtgBZOgJ7U3mtPcBtw4BAtJUo3Tss/gUyVD9Fxdl1RNahUMGe8QOan2nVTuph/qWNH0awdPWsh0g4ELm26Ome1gHvqZvEg/XbGul/48daTflWbMI+/iDNH217G0bsOqvCt+9I01vMa342Q27HuqhVmmvpP8nriSp5ebZ/TWznZZ1G02fYd3HGCYyexsKZvBr9AxHRniEpi2nDBaPQiaOIZwelxkUWT6Z4YxKTrHgkt2lKIjrGNmcg+/sLFr9LCmSpnuR/B7SJzfH37xrdg0t6ZCh6vfLKttpQJSbcxnVRZGlOp5zOZGm5pDRCdwXsTKWu+RA5tVmc3rxBwAA//8=
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
    /// Deletes a web experience profile, by ID.
    /// </summary>
    public class WebProfileDeleteRequest : HttpRequest
    {
        public WebProfileDeleteRequest(string ProfileId) : base("/v1/payment-experience/web-profiles/{profile_id}?", HttpMethod.Delete, typeof(void))
        {
            try {
                this.Path = this.Path.Replace("{profile_id}", Uri.EscapeDataString(Convert.ToString(ProfileId) ));
            } catch (IOException) {}
            
            this.ContentType =  "application/json";
        }
        
    }
}
