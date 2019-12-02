// This class was generated on Tue, 30 Jan 2018 11:14:21 PST by version 0.1.0-dev+6beb51-dirty of Braintree SDK Generator
// Currency.cs
// @version 0.1.0-dev+6beb51-dirty
// @type object
// @data H4sIAAAAAAAC/6RS34sTMRB+968Y8qSw3agIQt/EQzjF6+EVQcohs8lsE80m68xsyyL3v8v2+oPSAxEf82XyZb4fv81y7MnMzfuBmbIbTWW+IkdsEt1gN92Yynyi8XS4InEce40lm7lZBoIGhaA0P8gptIUBU4I2ZswuYoINpoFmTAmVPLSRkpcKZHABUKDBhNlRBT2OHWUFP1AFmD1IgZJrU5l3zDg+rvmyMl8I/SKn0cxbTEIT8GuITP4I3HLpiTWSmPnqKFCUY15fynN74d9d8XSm1Z0sudS80sBEMxeQ0SkxXN8tZm9ev3oLh2cwEd4/D6q9zK31tKE0LVb3OPaYalc664sTG7PSmnEitz4yObVMovZANJuIxL74Xy/ykNJD9VdDdnmdGXFALl04at2N1PA5roNCQ4AZdrKId43Yz0USSPEnwcfbb6ABFZAJclHQsY8OUxqhnfyMJWOCqUrgycUO0xF/km95c3Xik6HxcRM9+WmHAhrKIJi9BqnhQ2HQQMB7pyAPXUMMpT3+1Cd0JI9NPk+zAiGC1fXdAqaoT+Fut9s6SqkLr22UYkPpyIpi9she7FnHpA7a/VuYysNTWd4/PPsDAAD//w==
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.BillingPlans
{
    /// <summary>
    /// The base object for all financial value-related fields, such as balance, payment due, and so on.
    /// </summary>
    [DataContract]
    public class Currency
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public Currency() {}

        /// <summary>
        /// The [three-character ISO-4217 currency code](https://developer.paypal.com/docs/integration/direct/rest/currency-codes/).
        /// </summary>
        [DataMember(Name="currency", EmitDefaultValue = false)]
        public string CurrencyCode;

        /// <summary>
        /// REQUIRED
        /// The currency value. Might be an integer for currencies like JPY that are not typically fractional or a decimal fraction for currencies like TND that are subdivided into thousandths. For the required number of decimal places for a currency code, see [ISO 4217](https://www.iso.org/iso/home/standards/currency_codes.htm).
        /// </summary>
        [DataMember(Name="value", EmitDefaultValue = false)]
        public string Value;
    }
}

