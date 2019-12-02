// This class was generated on Sun, 08 Apr 2018 17:47:21 UTC by version 0.1.0-dev+291f3f of Braintree SDK Generator
// AcceptClaimRequest.cs
// @version 0.1.0-dev+291f3f
// @type object
// @data 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
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.CustomerDisputes
{
    /// <summary>
    /// A request by a merchant to accept a customer merchandise claim.
    /// </summary>
    [DataContract]
    public class AcceptClaimRequest
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public AcceptClaimRequest() {}

        /// <summary>
        /// The merchant's reason for acceptance of the customer's claim.
        /// </summary>
        [DataMember(Name="accept_claim_reason", EmitDefaultValue = false)]
        public string AcceptClaimReason;

        /// <summary>
        /// The ID of the invoice for the refund.
        /// </summary>
        [DataMember(Name="invoice_id", EmitDefaultValue = false)]
        public string InvoiceId;

        /// <summary>
        /// The merchant's notes about acceptance of the customer's claim.
        /// </summary>
        [DataMember(Name="note", EmitDefaultValue = false)]
        public string Note;

        /// <summary>
        /// The portable international postal address. Maps to [AddressValidationMetadata](https://github.com/googlei18n/libaddressinput/wiki/AddressValidationMetadata) and HTML 5.1 [Autofilling form controls: the autocomplete attribute](https://www.w3.org/TR/html51/sec-forms.html#autofilling-form-controls-the-autocomplete-attribute).
        /// </summary>
        [DataMember(Name="return_shipping_address", EmitDefaultValue = false)]
        public PortablePostalAddress PortablePostalAddress;
    }
}

