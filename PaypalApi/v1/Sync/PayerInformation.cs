// This class was generated on Tue, 30 Jan 2018 11:02:44 PST by version 0.1.0-dev+6beb51-dirty of Braintree SDK Generator
// PayerInformation.cs
// @version 0.1.0-dev+6beb51-dirty
// @type object
// @data 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
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.Sync
{
    /// <summary>
    /// The payer information.
    /// </summary>
    [DataContract]
    public class PayerInformation
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public PayerInformation() {}

        /// <summary>
        /// The PayPal` customer account ID.
        /// </summary>
        [DataMember(Name="account_id", EmitDefaultValue = false)]
        public string AccountId;

        /// <summary>
        /// A simple postal address with coarse-grained fields. Do not use for an international address. Use for backward compatibility only. Does not contain phone.
        /// </summary>
        [DataMember(Name="address", EmitDefaultValue = false)]
        public SimplePostalAddress Address;

        /// <summary>
        /// The address status of the payer. Value is either:<ul><li><code>Y</code>. Verified.</li><li><code>N</code>. Not verified.</li></ul>
        /// </summary>
        [DataMember(Name="address_status", EmitDefaultValue = false)]
        public string AddressStatus;

        /// <summary>
        /// The [two-character ISO 3166-1 code](/docs/integration/direct/rest/country-codes/) that identifies the country or region.<blockquote><strong>Note:</strong> The country code for Great Britain is <code>GB</code> and not <code>UK</code> as used in the top-level domain names for that country. Use the `C2` country code for China worldwide for comparable uncontrolled price (CUP) method, bank card, and cross-border transactions.</blockquote>
        /// </summary>
        [DataMember(Name="country_code", EmitDefaultValue = false)]
        public string CountryCode;

        /// <summary>
        /// The internationalized email address.<blockquote><strong>Note:</strong> Up to 64 characters are allowed before and 255 characters are allowed after the <code>@</code> sign. However, the generally accepted maximum length for an email address is 254 characters. The pattern verifies that an unquoted <code>@</code> sign exists.</blockquote>
        /// </summary>
        [DataMember(Name="email_address", EmitDefaultValue = false)]
        public string EmailAddress;

        /// <summary>
        /// The name of the party.
        /// </summary>
        [DataMember(Name="payer_name", EmitDefaultValue = false)]
        public Name PayerName;

        /// <summary>
        /// The status of the payer. Value is `Verified` or `Unverified`.
        /// </summary>
        [DataMember(Name="payer_status", EmitDefaultValue = false)]
        public string PayerStatus;

        /// <summary>
        /// The phone number, in its canonical international [E.164 numbering plan format](https://www.itu.int/rec/T-REC-E.164/en).
        /// </summary>
        [DataMember(Name="phone_number", EmitDefaultValue = false)]
        public Phone PhoneNumber;
    }
}

