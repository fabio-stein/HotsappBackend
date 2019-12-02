// This class was generated on Tue, 30 Jan 2018 11:02:41 PST by version 0.1.0-dev+6beb51-dirty of Braintree SDK Generator
// PaymentDetails.cs
// @version 0.1.0-dev+6beb51-dirty
// @type object
// @data H4sIAAAAAAAC/6yRQUszMRCG79+vGOa8fHjem9BLEbRI8SJSps1bdyCbrJNZJEj/u6ytlUXFgx7zJpk8T94XXtcB3PJKao/ktICLxsIN34mpbCOupZ8OcMNXqB+LBcrOdHDNiVted6DhNCIcR9A+G3kHyhZg/7nhSzOpx/cuGr6FhJsUK7d7iQVT8DSqIZyDleUB5orC7f2ZtLhpevwMGLRsRyuYGDZ9DpgRf7U7V1imoDtxFHru4B2MPNP7NepzQiVNxSV5rJSNovjvvdIY46H5Ue70txsNM6tZ/H0jy8XflvEG/XD49woAAP//
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.Orders
{
    /// <summary>
    /// The payment details for the order.
    /// </summary>
    [DataContract]
    public class PaymentDetails
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public PaymentDetails() {}

        /// <summary>
        /// Indicates whether to disburse money instantly or later.
        /// </summary>
        [DataMember(Name="disbursement_mode", EmitDefaultValue = false)]
        public string DisbursementMode;

        /// <summary>
        /// The payment ID for the order.
        /// </summary>
        [DataMember(Name="payment_id", EmitDefaultValue = false)]
        public string PaymentId;
    }
}

