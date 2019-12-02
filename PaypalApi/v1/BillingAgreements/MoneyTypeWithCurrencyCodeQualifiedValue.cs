// This class was generated on Tue, 30 Jan 2018 11:14:21 PST by version 0.1.0-dev+6beb51-dirty of Braintree SDK Generator
// MoneyTypeWithCurrencyCodeQualifiedValue.cs
// @version 0.1.0-dev+6beb51-dirty
// @type object
// @data H4sIAAAAAAAC/6ySb2vUQBDG3/sphn2lkMuqCMK9KxShSv9giyCl2Lndye3gZjednfQM0u8uudylPSuI4MsMk2fn+T3PT3M1dGSW5jQnGkCHjmDDGsD1IpTcAC57grseIzdMHu4x9mQq8wWFcRXpDNvxd1OZTzQ8fhxTccKdck5maY4m4SYLYIzQcMLkGOOkthCKqOShYYq+1PAhC9APbLtIFawwYnJUQYdDS0nB91QBJg8lQ061qcyRCA6Tj9eV+Uzoz1MczLLBWGgc3PUs5OfBheSORJmKWV7PBIoKp/Vza3sSBxafDA+tXgWCaw1CtHABBZ2SwMnl+eLd2zfvD6nevAyqXVla6+me4nhT3eHQYaxdbq3PrlhOSmvBUdx6FnJqhYravdBiFCr21T9hUOl/o5D6GB+qv6LYh//IYT95DmG2ul2p4ZTXQWFFgAm2rki2hdjtMRWI/J3g9uPF11vQgAooBCnrWB52GOMAzQiUc8IIY5dgAt1FdASeHLcY550/q1+dHT9RL/3K8z178uNNGTTkvmDyGnY11EAgO3CQ+nZFArmZ39q+XKZiH4ZbQSGC65PLcxiTn7JeWrvZbGouuc6ytlyyDbklWxSTR/FlzvXbNtc6aPtfor15ePELAAD//w==
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.BillingAgreements
{
    /// <summary>
    /// A type for all financial value-related fields. For example, balance, payment due, and so on.
    /// </summary>
    [DataContract]
    public class MoneyTypeWithCurrencyCodeQualifiedValue
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public MoneyTypeWithCurrencyCodeQualifiedValue() {}

        /// <summary>
        /// REQUIRED
        /// The [three-character ISO-4217 currency code](https://developer.paypal.com/docs/integration/direct/rest/currency-codes/).
        /// </summary>
        [DataMember(Name="currency", EmitDefaultValue = false)]
        public string Currency;

        /// <summary>
        /// REQUIRED
        /// The currency value. Might be an integer for currencies like `JPY` that are not typically fractional or a three-place decimal fraction for currencies like `TND` that are subdivided into thousandths. For the required number of decimal places for a currency code, see [ISO 4217](http://www.iso.org/iso/home/standards/currency_codes.htm).
        /// </summary>
        [DataMember(Name="value", EmitDefaultValue = false)]
        public string Value;
    }
}

