// This class was generated on Tue, 30 Jan 2018 11:02:44 PST by version 0.1.0-dev+6beb51-dirty of Braintree SDK Generator
// VerifyWebhookSignatureResponse.cs
// @version 0.1.0-dev+6beb51-dirty
// @type object
// @data H4sIAAAAAAAC/5SPz0tDMQyA7/4VJeeHeO5N8CaozDEPIpJteVuwtjVJlSL736W+UX88Lx6TkI/ve4dlzQQeViQ8VndH631KT+6WdxGtCLkFaU5RCQZYoTCuA13hc3uBAS6pfg0XpBvhbJwieFjuyb1O0LcjVDtUjtBTGOBcBOtkcTbAgnB7HUMFP2JQaouXwkLbvriRlEmMScHfd3814bibS34q8Aab1aMaWtEf3n/f5ynTyaXRWZt6yff/f9WYlF8xsYRweDicfAAAAP//
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.Webhooks
{
    /// <summary>
    /// The verify webhook signature response.
    /// </summary>
    [DataContract]
    public class VerifyWebhookSignatureResponse
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public VerifyWebhookSignatureResponse() {}

        /// <summary>
        /// REQUIRED
        /// The status of the signature verification.
        /// </summary>
        [DataMember(Name="verification_status", EmitDefaultValue = false)]
        public string VerificationStatus;
    }
}

