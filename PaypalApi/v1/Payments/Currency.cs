// This class was generated on Mon, 09 Apr 2018 18:07:49 UTC by version 0.1.0-dev+291f3f of Braintree SDK Generator
// Currency.cs
// @version 0.1.0-dev+291f3f
// @type object
// @data H4sIAAAAAAAC/6SS0WsUMRDG3/0rhvhiYW+jIgj7VvDlELzDFl+OUqbJ7O1gNomTSWWR/u+Slm0tp4j4OLPzffvNb/LDXC6ZzGBcFaHoFtOZLyiMN4E+4dy+mM58pOWp+EDFCWflFM1gLieCVQsYPeCcalQYkwCCCsaCrs32pjPnIrg8/PB1Zz4T+l0MixlGDIVa41tlIf/Y2EvKJMpUzHB4jFpUOB5Pg64xrl3y9Cz1L8udpj/oJEQbN6GgUxLYXuw2796+ef+0VzO8emV9csVyVDoKNgPrWcipFSpq1+FNGy72rIc9LnsM4BMViEmh1JyTKGAIqzVT+V8usYZw1/0Vzi2G+hzK2jkl8nDCHrbRheqpgE4EJZPjkclDrPMNCaQRPB9ZC+DYsHlyPGOAQhkFNcn9G2jSw5+ITqq5DNZS7L/zV87kGfskR9squ73YXTfVy3OnfEv3Zy1n/8RLpf4O19Xdi58AAAD//w==
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.Payments
{
    /// <summary>
    /// The currency and amount for a transaction.
    /// </summary>
    [DataContract]
    public class Currency
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public Currency() {}

        /// <summary>
        /// The [three-character ISO-4217 currency code](/docs/integration/direct/rest/currency-codes/). PayPal does not support all currencies.
        /// </summary>
        [DataMember(Name="currency", EmitDefaultValue = false)]
        public string CurrencyCode;

        /// <summary>
        /// REQUIRED
        /// The amount. Includes the specified number of digits after decimal separator for the [ISO-4217 currency code](https://en.wikipedia.org/wiki/ISO_4217#Active_codes).
        /// </summary>
        [DataMember(Name="value", EmitDefaultValue = false)]
        public string Value;
    }
}

