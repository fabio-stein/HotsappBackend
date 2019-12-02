// This class was generated on Mon, 09 Apr 2018 18:07:49 UTC by version 0.1.0-dev+291f3f of Braintree SDK Generator
// ProcessorResponse.cs
// @version 0.1.0-dev+291f3f
// @type object
// @data H4sIAAAAAAAC/8SUQW8aPxDF7/9PMfLln0iU7ZkbSm+VWhSivUQRDPYQW/La7ox30abKd68MYVPYSI2aNj3yZvD6/TzzvqubPpGaqcRRk0jkFZOkGITURNXIDjeevmBTetREfab++ccnEs0uZReDmqkbSzCc8iFx7JwhA8fjQEdDAtliBrP/44YgWwJpN43LmQwk7BsKeQrLNqXIRYrB97CzFPat66eOVUPZRrMGJ7DWTMbllUY266maqDkz9gdXHyfqmtB8Db5Xsy16oSJ8ax2TGYQFx0ScHYma3Q48JLML92MGaDqnaVXMnOA41cdkGmJtMWQ4NEIMYOMOcgSLwXgCQ9q7QALbyMCkWy4XODKRtzoLrfePk1/b6+QFb8/i2Njt3BgmEaiJ3dZpLDVY9pKpgYt5vby8u7A5J5lVlaGOfLnTNGGf0E91bKodbTAleS5WJmqptEcRpytMrprXy+unMboqU1Rdno7VO8HRXTeG85P4Apyruv4r9uXA919QIO1Ww86eoDivvCofsM02sns4zM3R0Dt5OX5u/KznlbGXBfYL9BAiN+jdw3nUTWBnnbYlou4pEGOJsy3HZp9kA4j/BSSRLpvzhtfM3P4egC6hnPh+El71dLUTLBiIYd5mSyEP60+8T7mLejFfXoJkzO2fibC7x/9+AAAA//8=
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.Payments
{
    /// <summary>
    /// The processor-provided response codes that describe the submitted payment. Supported only when the `payment_method` is `credit_card`.
    /// </summary>
    [DataContract]
    public class ProcessorResponse
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public ProcessorResponse() {}

        /// <summary>
        /// The merchant advice on how to handle declines for recurring payments.
        /// </summary>
        [DataMember(Name="advice_code", EmitDefaultValue = false)]
        public string AdviceCode;

        /// <summary>
        /// The [Address Verification System (AVS)](https://developer.paypal.com/webapps/developer/docs/classic/api/AVSResponseCodes/) response code.
        /// </summary>
        [DataMember(Name="avs_code", EmitDefaultValue = false)]
        public string AvsCode;

        /// <summary>
        /// The [CVV](https://developer.paypal.com/webapps/developer/docs/classic/api/AVSResponseCodes/) system response code.
        /// </summary>
        [DataMember(Name="cvv_code", EmitDefaultValue = false)]
        public string CvvCode;

        /// <summary>
        /// The processor-provided authorization response.
        /// </summary>
        [DataMember(Name="eci_submitted", EmitDefaultValue = false)]
        public string EciSubmitted;

        /// <summary>
        /// REQUIRED
        /// The PayPal normalized response code, which is generated from the processor's specific response code.
        /// </summary>
        [DataMember(Name="response_code", EmitDefaultValue = false)]
        public string ResponseCode;

        /// <summary>
        /// The processor-provided Visa Payer Authentication Service (VPAS) status.
        /// </summary>
        [DataMember(Name="vpas", EmitDefaultValue = false)]
        public string Vpas;
    }
}

