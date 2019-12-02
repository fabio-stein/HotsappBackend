// This class was generated on Tue, 30 Jan 2018 11:02:41 PST by version 0.1.0-dev+6beb51-dirty of Braintree SDK Generator
// CreditCard.cs
// @version 0.1.0-dev+6beb51-dirty
// @type object
// @data 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
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.Orders
{
    /// <summary>
    /// [DEPRECATED] The credit card details. You can use this instrument to fund a payment. Use a payment card instead.
    /// </summary>
    [DataContract]
    public class CreditCard
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public CreditCard() {}

        /// <summary>
        /// The billing address in a payment. Can be extended for shipping address.
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
        /// The credit card type. Value is `visa`, `mastercard`, `discover`, or `amex`.
        /// </summary>
        [DataMember(Name="type", EmitDefaultValue = false)]
        public string Type;
    }
}

