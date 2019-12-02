// This class was generated on Tue, 30 Jan 2018 11:14:21 PST by version 0.1.0-dev+6beb51-dirty of Braintree SDK Generator
// PaymentCard.cs
// @version 0.1.0-dev+6beb51-dirty
// @type object
// @data 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
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.BillingAgreements
{
    /// <summary>
    /// A payment card that can be used to fund a payment.
    /// </summary>
    [DataContract]
    public class PaymentCard
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public PaymentCard() {}

        /// <summary>
        /// A simple postal address with coarse-grained fields. Do not use for an international address. Use for backward compatibility only. Does not contain phone.
        /// </summary>
        [DataMember(Name="billing_address", EmitDefaultValue = false)]
        public SimplePostalAddress BillingAddress;

        /// <summary>
        /// The card validation code. Supported only when making a payment but not when saving a payment card for future use.
        /// </summary>
        [DataMember(Name="cvv2", EmitDefaultValue = false)]
        public int? Cvv2;

        /// <summary>
        /// REQUIRED
        /// The two-digit card expiry month.
        /// </summary>
        [DataMember(Name="expire_month", EmitDefaultValue = false)]
        public int? ExpireMonth;

        /// <summary>
        /// REQUIRED
        /// The four-digit card expiry year.
        /// </summary>
        [DataMember(Name="expire_year", EmitDefaultValue = false)]
        public int? ExpireYear;

        /// <summary>
        /// The facilitator-provided ID of the card holder. Required when storing a funding instrument or using a stored funding instrument in the PayPal vault.
        /// </summary>
        [DataMember(Name="external_customer_id", EmitDefaultValue = false)]
        public string ExternalCustomerId;

        /// <summary>
        /// The card holder's first name.
        /// </summary>
        [DataMember(Name="first_name", EmitDefaultValue = false)]
        public string FirstName;

        /// <summary>
        /// The ID of the vaulted payment card.
        /// </summary>
        [DataMember(Name="id", EmitDefaultValue = false)]
        public string Id;

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
        /// The card number.
        /// </summary>
        [DataMember(Name="number", EmitDefaultValue = false)]
        public string Number;

        /// <summary>
        /// The two-digit card start month.
        /// </summary>
        [DataMember(Name="start_month", EmitDefaultValue = false)]
        public int? StartMonth;

        /// <summary>
        /// The four-digit card start year.
        /// </summary>
        [DataMember(Name="start_year", EmitDefaultValue = false)]
        public int? StartYear;

        /// <summary>
        /// The status of the funding instrument.
        /// </summary>
        [DataMember(Name="status", EmitDefaultValue = false)]
        public string Status;

        /// <summary>
        /// REQUIRED
        /// The card type.
        /// </summary>
        [DataMember(Name="type", EmitDefaultValue = false)]
        public string Type;

        /// <summary>
        /// The date and time when the card becomes unusable from the vault, in [Internet date and time format](https://tools.ietf.org/html/rfc3339#section-5.6). The `valid_until` parameter is not the same as the expiration month and year. The expiration month and year might be later than the `valid_until` date. For example, the card expires in November 2019 but the `valid_until` date is October 17th, 2019.
        /// </summary>
        [DataMember(Name="valid_until", EmitDefaultValue = false)]
        public string ValidUntil;
    }
}

