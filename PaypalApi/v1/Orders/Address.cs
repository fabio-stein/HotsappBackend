// This class was generated on Tue, 30 Jan 2018 11:02:41 PST by version 0.1.0-dev+6beb51-dirty of Braintree SDK Generator
// Address.cs
// @version 0.1.0-dev+6beb51-dirty
// @type object
// @data H4sIAAAAAAAC/7xWTXPbRgy991dg2Es8Q5Gy0+agm+MmqZtJ7LHl9qBmbIgLi2iWu8wuGJnp5L93dqkvlu40cju6aEQAD8R7iwX4ZzJta0omyalSjrxP0uRXdIxzTe+xCo4kTd5Su334iXzhuBa2Jpkk05JgzlqzWQB2KYANINTYVmQkgzM0MCegByGjSMG9deBLrusdSJakyalz2HbFjNPkilBdGN0mk3vUnoLhU8OO1MZw6WxNTph8MpltaHhxbBZDFgVL22OyMgzZBAcYrOi/FmUarb+m/16ZbYy49rawivoV9h39Sk9hJks7Kkp0WAg5OL++gOfHL16MjiEAPjzLlS18zkZo4TCgcsWOCskdeclXyUch1udHICUKsCIjfM/kQYISXQxYB44WbE32ezMePy/m2hYfPzVWKD53v4UXZ82is7y3QpPOnO/aYbqTNrw6dsMbRyjw0rEgG2APHTL4O9ibl6tcWxOgUWCsDGJv3j4S66HxpEJjBl5i65Gmz6RB2Sq8Mpy2j6VEGVYFZnDjKQLuzk7uhmWflWwQltZpteSVrbBVjS6cLjSmsEac1ZoU1I4LgmdnN5dHUJGUVqUwR/MRCnQqjWQKZ70fza1T5EAcGo9FODa/Uj3/u+z7tKe45mndqdnQca8t15bhzbln5wWCH+x9FG59veG1dUAPWNWaUjBNNSeXghdHJB17b8Ga7GCUTgaUTgaULuIf1FnsWk+FNeob2PmGhVLAGp2ECbih+zSaTx8sxroKNX+Jl//WC0rje7T/IWB4sOvB3gNAB8jgiqRxhhRYo9t4C2psyXm4d7aClw6/sD4Q5bq0pj9E15YhqejZHA4bmL3Kjk+eBwIVyodnpUjtJ3m+XC4zliZjE0ZnkU9HV6/ORjF2dDIeH49PRuc5maMM3uEDV00FmsxCyjDIfhzDZkL7Q2lgvaAerpO+/RE9oj+OtxSWJReRQejzL1x3Uy+0+aeGP6OOm33a1lyg1i24Vd2rGRgGZVgiS5YyfApsM4cUaHpZrolgdrkN2SpPJlvyR65JMWbWLfLwlF9ueRwdSNLQ6X0x15ahjLNv2b4Rvtm9QTSEm+t4o6JEQfWtRjHASkk72oZrt6P57r4A7o2ncIpswG7mlqdtmgnMTt0ibH2D+xT9Pa5RRynMuju+F34eIQF8hgbVfi8vIiSAz43i/bAcEBEqqNv9oAERoL9gjWYv6B8BEaDv6IELuxe2ipAAnpbIGo3aCy4r0FEaOmt2Y1hIwXUI8Xslajw+OuR+GINns9A0mrdChx94j2y2b9hlq+11mBIluHcLXBmG5QVHuKePf1vc/Xzx7tXtxdXtbxdXb+9SuHtz/np6939/Wnz4+t1fAAAA//8=
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.Orders
{
    /// <summary>
    /// The billing address in a payment. Can be extended for shipping address.
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
        /// A [two-character ISO 3166-1 code](/docs/integration/direct/rest/country-codes/) that identifies the country or region.<blockquote><strong>Note:</strong> The country code for Great Britain is <code>GB</code> and not <code>UK</code> as used in the top-level domain names for that country. Use the `C2` country code for China worldwide for comparable uncontrolled price (CUP) method, bank card, and cross-border transactions.</blockquote>
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
        /// Optional. The second line of the address. For example, suite, apartment number, and so on.
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
        /// The postal code, which is the zip code or equivalent. Typically required for countries with a postal code or an equivalent. See [Postal code](https://en.wikipedia.org/wiki/Postal_code).
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

