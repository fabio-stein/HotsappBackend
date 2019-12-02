// This class was generated on Mon, 09 Apr 2018 18:07:49 UTC by version 0.1.0-dev+291f3f of Braintree SDK Generator
// Address.cs
// @version 0.1.0-dev+291f3f
// @type object
// @data H4sIAAAAAAAC/7xW32/bRgx+319BaC81IEuOu/XBb23WdlmQJkic7cELYlqiLS6nO+WOqqMM/d+HOyn+MbtY3QF+MSCS3x0/HvnRf0fjpqJoFGGeW3IuiqPf0TLOFH3C0juiODqnZv3xC7nMciVsdDSKxgXBjJVivYDuCDAWXMFVtWmbGwsIFTYlaUmiOHprLTbt3YM4uibML7VqotEclSNveKzZUr4yXFlTkRUmF40mq6ydWNaL3aQzlmYr8c6wm7x3gMaS/m9SulbqS/zfmZlai23uM5PTdobbjt1MJ7I0/axAi5mQhbObS3h98uZN/wQ85O5VmpvMpayFFhY9Ls3ZUiapJSdpd3zfx7q0B1KgAOekhedMDsTXoo3xD2hpwUYnf9aDwetspkz28FgbofDd/mZOrNGL1vLJCI1ac7pph/HGsf7q0AgfLaHAO8uCrIEdtEjvb2Ef33VnrU2AOgdtZCf29nxPrIPaUQ6sAy8xVV/RZ1KQm9Jf6d+77clQhi7BBG4dBcD0dDjdTfu0YI2wNFblS+5smSkrtP59odaZ0WKNUpRDZTkjeHV6e9WDkqQweQwz1A+Qoc3jQCazxrn+zNicLIhF7TDzz+a6qqf/LvshDSq2/r7+VKzpZKsxXyy7HTln6wS8H8w8FK4b9wQ+GAv0hGWlKAZdlzOyMTixRNKydwaMTo5GabhDabiXkqPM6PwbOLmahfykYIVWvKp1NI+kI9rYEhU/h0m/d4JSuy2OXwnYpfwi0VsAaAEJXJPUVlMORqsmtHyFDVkHc2tKeGfxmdWRKFeF0dua+WLZJRU8q8ZjDZP3ycnwtSdQoty9KkQqN0rT5XKZsNQJa6+TWTruX78/7YfY/nAwOBkM+2cp6V4CF/jEZV2CIr2QwqvWzwNYybE7Vg2ME1S722PbvqcewR+0LIZlwVlg4Nv7matW4nx3P9b8GZVf0TBuKs5QqQZsl3cneF4V/cZYshR+p69PDuOgt065IYLJRsi68qSTJT9wRTljYuwi9V/p1ZpH70gl9Z2+XcwXy54d/C2rNsBXi7b953N7EyYqlMhXfV2jEGCkoI3a+rHbqPnmcgDeUiX/iqzBrOTK0fqYEUze2oVf8RoPSfpHfEH1Ypi0M34QfhYgHnyKGvPDLs8CxIPPdM6HYdkjAlRQNYdBPcJDf8MK9UHQvzzCQy/oiTNzELYMEA8eF8gKdX4QXDpQL/adNbnVLJTDjQ9xBx1UO9wrcj8NwLFeKOrPGqHjC5549+Zwdobd2fQOPwT79/X018uL9/eX1/d/XF6fT2OYfjz7MJ5+73+Rr/G5+/LDPwAAAP//
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.Payments
{
    /// <summary>
    /// The billing address or shipping address for a payment.
    /// </summary>
    [DataContract]
    public class Address
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public Address() {}

        /// <summary>
        /// The city name.
        /// </summary>
        [DataMember(Name="city", EmitDefaultValue = false)]
        public string City;

        /// <summary>
        /// REQUIRED
        /// The [two-character ISO 3166-1 code](/docs/integration/direct/rest/country-codes/) that identifies the country or region.<blockquote><strong>Note:</strong> The country code for Great Britain is <code>GB</code> and not <code>UK</code> as used in the top-level domain names for that country. Use the `C2` country code for China worldwide for comparable uncontrolled price (CUP) method, bank card, and cross-border transactions.</blockquote>
        /// </summary>
        [DataMember(Name="country_code", EmitDefaultValue = false)]
        public string CountryCode;

        /// <summary>
        /// REQUIRED
        /// The first line of the address. For example, number, street, and so on.
        /// </summary>
        [DataMember(Name="line1", EmitDefaultValue = false)]
        public string Line1;

        /// <summary>
        /// The second line of the address. For example, suite or apartment number.
        /// </summary>
        [DataMember(Name="line2", EmitDefaultValue = false)]
        public string Line2;

        /// <summary>
        /// The address normalization status. Returned only for payers from Brazil.
        /// </summary>
        [DataMember(Name="normalization_status", EmitDefaultValue = false)]
        public string NormalizationStatus;

        /// <summary>
        /// The phone number, in [E.123 format](https://www.itu.int/rec/T-REC-E.123-200102-I/en). Maximum length is 50 characters.
        /// </summary>
        [DataMember(Name="phone", EmitDefaultValue = false)]
        public string Phone;

        /// <summary>
        /// The postal code, which is the zip code or equivalent. Typically required for countries with a postal code or an equivalent. See [postal code](https://en.wikipedia.org/wiki/Postal_code).
        /// </summary>
        [DataMember(Name="postal_code", EmitDefaultValue = false)]
        public string PostalCode;

        /// <summary>
        /// The [code](/docs/integration/direct/rest/state-codes/) for a US state or the equivalent for other countries. Required for transactions if the address is in one of these countries: [Argentina](/docs/integration/direct/rest/state-codes/#argentina), [Brazil](/docs/integration/direct/rest/state-codes/#brazil), [Canada](/docs/integration/direct/rest/state-codes/#canada), [India](/docs/integration/direct/rest/state-codes/#india), [Italy](/docs/integration/direct/rest/state-codes/#italy), [Japan](/docs/integration/direct/rest/state-codes/#japan), [Mexico](/docs/integration/direct/rest/state-codes/#mexico), [Thailand](/docs/integration/direct/rest/state-codes/#thailand), or [United States](/docs/integration/direct/rest/state-codes/#usa). Maximum length is 40 single-byte characters.
        /// </summary>
        [DataMember(Name="state", EmitDefaultValue = false)]
        public string State;

        /// <summary>
        /// The address status.
        /// </summary>
        [DataMember(Name="status", EmitDefaultValue = false)]
        public string Status;

        /// <summary>
        /// The type of address. For example, `HOME_OR_WORK`, `GIFT`, and so on.
        /// </summary>
        [DataMember(Name="type", EmitDefaultValue = false)]
        public string Type;
    }
}

