// This class was generated on Tue, 30 Jan 2018 11:02:44 PST by version 0.1.0-dev+6beb51-dirty of Braintree SDK Generator
// CreditCard.cs
// @version 0.1.0-dev+6beb51-dirty
// @type object
// @data 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
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.Vault
{
    /// <summary>
    /// A vaulted credit card. To fund a payment, use the ID of the vaulted card.
    /// </summary>
    [DataContract]
    public class CreditCard
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public CreditCard() {}

        /// <summary>
        /// A simple postal address with coarse-grained fields. Do not use for an international address. Use for backward compatibility only. Does not contain phone.
        /// </summary>
        [DataMember(Name="billing_address", EmitDefaultValue = false)]
        public SimplePostalAddress BillingAddress;

        /// <summary>
        /// The date and time when the vaulted credit card was created, in [Internet date and time format](https://tools.ietf.org/html/rfc3339#section-5.6). For example, `2017-11-05T13:15:30Z`.
        /// </summary>
        [DataMember(Name="create_time", EmitDefaultValue = false)]
        public string CreateTime;

        /// <summary>
        /// REQUIRED
        /// The one- to two-digit month when the card expires, with no leading zero. For example, `1` or `12`.
        /// </summary>
        [DataMember(Name="expire_month", EmitDefaultValue = false)]
        public string ExpireMonth;

        /// <summary>
        /// REQUIRED
        /// The four-digit year when the card expires. For example, `2017`.
        /// </summary>
        [DataMember(Name="expire_year", EmitDefaultValue = false)]
        public string ExpireYear;

        /// <summary>
        /// The externally-provided ID of the credit card.
        /// </summary>
        [DataMember(Name="external_card_id", EmitDefaultValue = false)]
        public string ExternalCardId;

        /// <summary>
        /// The externally-provided ID of the customer for whom to list credit cards.
        /// </summary>
        [DataMember(Name="external_customer_id", EmitDefaultValue = false)]
        public string ExternalCustomerId;

        /// <summary>
        /// The first name of the credit card holder. Maximum length is 25 characters.
        /// </summary>
        [DataMember(Name="first_name", EmitDefaultValue = false)]
        public string FirstName;

        /// <summary>
        /// The ID of the vaulted credit card, which you can use to fund a payment.
        /// </summary>
        [DataMember(Name="id", EmitDefaultValue = false)]
        public string Id;

        /// <summary>
        /// The last name of the credit card holder.
        /// </summary>
        [DataMember(Name="last_name", EmitDefaultValue = false)]
        public string LastName;

        /// <summary>
        /// An array of request-related [HATEOAS links](/docs/api/overview/#hateoas-links).
        /// </summary>
        [DataMember(Name="links", EmitDefaultValue = false)]
        public List<LinkDescriptionObject> Links;

        /// <summary>
        /// The ID of the merchant for whom to list credit cards.
        /// </summary>
        [DataMember(Name="merchant_id", EmitDefaultValue = false)]
        public string MerchantId;

        /// <summary>
        /// REQUIRED
        /// The credit card number. Valid value is a string of numeric characters with no spaces or punctuation. Must conform to modulo and the length required by its credit card type. *Redacted in responses.*
        /// </summary>
        [DataMember(Name="number", EmitDefaultValue = false)]
        public string Number;

        /// <summary>
        /// A unique ID that you can assign and track when you vault a credit card or use a vaulted credit card to make a payment. This ID can help to avoid unintentional use or misuse of credit cards. Can be any value, such as a UUID, user name, or email address. **This is being deprecated in favor of the `external_customer_id` property.**
        /// </summary>
        [DataMember(Name="payer_id", EmitDefaultValue = false)]
        public string PayerId;

        /// <summary>
        /// The state of the credit card funding instrument.
        /// </summary>
        [DataMember(Name="state", EmitDefaultValue = false)]
        public string State;

        /// <summary>
        /// REQUIRED
        /// The credit card type.
        /// </summary>
        [DataMember(Name="type", EmitDefaultValue = false)]
        public string Type;

        /// <summary>
        /// The date and time when the vaulted credit card was updated, in [Internet date and time format](https://tools.ietf.org/html/rfc3339#section-5.6). For example, `2017-11-05T13:15:30Z`.
        /// </summary>
        [DataMember(Name="update_time", EmitDefaultValue = false)]
        public string UpdateTime;

        /// <summary>
        /// The date and time when the credit card becomes unusable from the vault, in [Internet date and time format](https://tools.ietf.org/html/rfc3339#section-5.6). The `valid_until` parameter is not the same as the expiration month and year. The expiration month and year might be later than the `valid_until` date. For example, the card expires in November 2019 but the `valid_until` date is October 17th, 2019.
        /// </summary>
        [DataMember(Name="valid_until", EmitDefaultValue = false)]
        public string ValidUntil;
    }
}

