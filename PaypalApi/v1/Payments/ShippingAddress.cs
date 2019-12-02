// This class was generated on Mon, 09 Apr 2018 18:07:49 UTC by version 0.1.0-dev+291f3f of Braintree SDK Generator
// ShippingAddress.cs
// @version 0.1.0-dev+291f3f
// @type object
// @data H4sIAAAAAAAC/7xWTY/bRgy991cQ6iUGZMnrtDn4lmyTdBskG+x624Mb2LSGttiMZpQZKo5S5L8XI8sfqhw0TgFfDJjko/g45Jv5O5rWJUWTyOdclmzWc1TKkfdRHP2OjnGp6Q0WISKKo1dUH/78Qj5zXApbE02iaU6wywFtDlAkyNonURw9dQ7r7bdGcXRHqG6NrqPJCrWnYPhQsSO1N7x1tiQnTD6azA5VimOz7teWsdSd+lpDv8bgAIMF/d+iTKX1l/i/K7OVEVfPM6uoW2HX0a90Jhs7zHJ0mAk5uLm/hcdXT54MryBA3j1Klc18ykZo7TDgUsWOMkkdeUnb9MMQ69MBSI4CrMgIr5g8SOjFNgasA0drtib5sxqNHmdLbbP3Hyor1Pzf/mZenDXrreWNFZpszemxHaZHacOnYWUdvHSEAs8cC7IB9rBFBv8W9vJZm+tgAjQKjJVe7MOrE7EeKk8K2DS8xJZDTR9Jg7JF+GQ4b9+U0rShLTCBB08NYHE9XvTLvs7ZIGys02rDrS2zRYkunC9UJrNGnNWaFJSOM4JH1w9vB1CQ5FbFsETzHjJ0Km7IZM56P1xap8iBODQes3Bsvu16+u+2nzOg4qrvm0/Nhq46g7mz9Cdyxc4LBD/YVdO4dtETeGEd0CcsSk0xmKpYkovBiyOSLXtvwZrkYpTGPUrj05JFmTXqGzj5ioXCpmCJTgoy0tK8kI4Y6wrU/LnZ9LkXlMp3OH4loE95J84dAGwBCdyRVM6QAmt03Yx8iTU5DytnC3jm8DPrC1Euc2u6mrmz9Ek1nv3gsYHZ8+Rq/DgQKFDePcpFSj9J081mk7BUCZugk1k6Hd49vx42scPxaHQ1Gg9vUjKDBF7jJy6qAjSZteRBtX4ewV6O/aV6YL2g7t8eXfuJfjT+Rsti2OScNQzCeH/mcitxYbo/VPwRNRlJYFqXnKHWNbi27lbwgiqGG2PDkgMeZ27WwXSy3BPB7Cjk0HkyyYbfc0mKMbFunYZ/6dsDj8GFWuoo45LJyDxcC52u9lz9xgbHTin24YACkrPfa8dlmISd7RLYWU68Jr7l0dDA90+GcPwID/eNNjSHHUgfTrsJsJLT0ZQEATmanuNrDrijr2Ee2YDdC6+nQ5oJzJ66dXisGDyn6B9xhxrEMNuq1Vn4ZQMJ4Gs0qM77eNZAAvjGKD4PywHRQAV1fR40IAL0NyzRnAX9KyAC9DV94syehS0aSABPc2SNRp0FlxY0iMNkzR4MCym4DyH+rESVx5Ny/dMIPJu1puGyFrq8dEtwHy9na+jvZnCEJTj98lj8evv6+fz2bv7H7d2rRQyLlzcvpovvfVV9jc+7Lz/8AwAA//8=
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.Payments
{
    /// <summary>
    /// The shipping address details.
    /// </summary>
    [DataContract]
    public class ShippingAddress
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public ShippingAddress() {}

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
        /// The name of the recipient at this address.
        /// </summary>
        [DataMember(Name="recipient_name", EmitDefaultValue = false)]
        public string RecipientName;

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

