// This class was generated on Mon, 09 Apr 2018 18:07:49 UTC by version 0.1.0-dev+291f3f of Braintree SDK Generator
// CreditCard.cs
// @version 0.1.0-dev+291f3f
// @type object
// @data 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
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.Payments
{
    /// <summary>
    /// Deprecated. The credit card details. You can use this instrument to fund a payment. Use a payment card instead.
    /// </summary>
    [DataContract]
    public class CreditCard
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public CreditCard() {}

        /// <summary>
        /// The billing address or shipping address for a payment.
        /// </summary>
        [DataMember(Name="billing_address", EmitDefaultValue = false)]
        public Address BillingAddress;

        /// <summary>
        /// The three- to four-digit card validation code.
        /// </summary>
        [DataMember(Name="cvv2", EmitDefaultValue = false)]
        public string Cvv2;

        /// <summary>
        /// REQUIRED
        /// The expiration month with no leading zero. Value is from `1` to `12`.
        /// </summary>
        [DataMember(Name="expire_month", EmitDefaultValue = false)]
        public int? ExpireMonth;

        /// <summary>
        /// REQUIRED
        /// The four-digit expiration year.
        /// </summary>
        [DataMember(Name="expire_year", EmitDefaultValue = false)]
        public int? ExpireYear;

        /// <summary>
        /// The card holder's first name.
        /// </summary>
        [DataMember(Name="first_name", EmitDefaultValue = false)]
        public string FirstName;

        /// <summary>
        /// The card holder's last name.
        /// </summary>
        [DataMember(Name="last_name", EmitDefaultValue = false)]
        public string LastName;

        /// <summary>
        /// An array of request-related [HATEOAS links](/docs/api/overview/#hateoas-links).
        /// </summary>
        [DataMember(Name="links", EmitDefaultValue = false)]
        public List<LinkDescriptionObject> Links;

        /// <summary>
        /// REQUIRED
        /// The credit card number. Value is numeric characters only with no spaces or punctuation. Must conform to the modulo and length required by each credit card type. *Redacted in responses.*
        /// </summary>
        [DataMember(Name="number", EmitDefaultValue = false)]
        public string Number;

        /// <summary>
        /// REQUIRED
        /// The credit card type. Value is `visa`, `mastercard`, `discover`, or `amex`. Do not use these lowercase values for display.
        /// </summary>
        [DataMember(Name="type", EmitDefaultValue = false)]
        public string Type;
    }
}

