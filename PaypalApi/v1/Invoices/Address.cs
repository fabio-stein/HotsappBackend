// This class was generated on Tue, 30 Jan 2018 11:02:40 PST by version 0.1.0-dev+6beb51-dirty of Braintree SDK Generator
// Address.cs
// @version 0.1.0-dev+6beb51-dirty
// @type object
// @data H4sIAAAAAAAC/7yUT28TMRDF73yKkblQabWh4ZZb+XcB0YgCBxBCk/UkO+C13fFsYYX63ZE3m6ZuQIBAucVvXpLfG4/nu3kzRDILc2atUEqmMu9QGFeOXmGXC6YyL2jYH55SaoSjcvBmYR5jIpi+C2H1mRqFPpEFTLBi59hvAKcye0CIOHTkFYIAfVPyliysg8BFyzFm9/RjtanMmQgOW76HlXlNaM+9G8xijS5RFi57FrI3wlJCJFGmZBYfbpIlFfabw2AN61CEm4Qy4BPWATx29FdAKv0dHt87d139Hir0XmX41ARLJVxZKCHn4EiVBCYXZNdxgB17Oi1Id0qJ+JI9wSmENWi7n5gHtKnB992KpIKkQqQVkDYnx4OfH8DPD+DPxw/oIJdh/tMUqWelCjAq3B8z1Cf/OsN/mCK2wZfDslPKFMusTt3Oj/FZfTp/lB9fh3os1JAU3eF0l3qJ/Z7jOM/jyrjs+QpdXiCcoE89OjeATGTjItk+AaYE2qJCi1eUL6ur4XkQcJw0X98dlw3gw2Tesox/mSA6yhtOaE0CGqBVjYvZjHz9lb9wJMtYB9nM8mm23Kc4Uj+Topad3Cm/XBCWxja9vYDRmipAb8dxvtXc7Aja0q12/pdEH6/v/QAAAP//
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.Invoices
{
    /// <summary>
    /// Base Address object used as billing address in a payment or extended for Shipping Address.
    /// </summary>
    [DataContract]
    public class Address
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public Address() {}

        /// <summary>
        /// REQUIRED
        /// City name.
        /// </summary>
        [DataMember(Name="city", EmitDefaultValue = false)]
        public string City;

        /// <summary>
        /// REQUIRED
        /// 2 letter country code.
        /// </summary>
        [DataMember(Name="country_code", EmitDefaultValue = false)]
        public string CountryCode;

        /// <summary>
        /// REQUIRED
        /// Line 1 of the Address (eg. number, street, etc).
        /// </summary>
        [DataMember(Name="line1", EmitDefaultValue = false)]
        public string Line1;

        /// <summary>
        /// Optional line 2 of the Address (eg. suite, apt #, etc.).
        /// </summary>
        [DataMember(Name="line2", EmitDefaultValue = false)]
        public string Line2;

        /// <summary>
        /// Phone number in E.123 format.
        /// </summary>
        [DataMember(Name="phone", EmitDefaultValue = false)]
        public string Phone;

        /// <summary>
        /// Zip code or equivalent is usually required for countries that have them. For list of countries that do not have postal codes please refer to http://en.wikipedia.org/wiki/Postal_code.
        /// </summary>
        [DataMember(Name="postal_code", EmitDefaultValue = false)]
        public string PostalCode;

        /// <summary>
        /// 2 letter code for US states, and the equivalent for other countries.
        /// </summary>
        [DataMember(Name="state", EmitDefaultValue = false)]
        public string State;
    }
}

