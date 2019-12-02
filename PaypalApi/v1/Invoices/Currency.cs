// This class was generated on Tue, 30 Jan 2018 11:02:40 PST by version 0.1.0-dev+6beb51-dirty of Braintree SDK Generator
// Currency.cs
// @version 0.1.0-dev+6beb51-dirty
// @type object
// @data H4sIAAAAAAAC/6TRT0skMRAF8Pt+iiKnXWiG/QcLfdudvYgwIypexEN18nqMpJNYqQiNzHeXHp0ZGgURj6kk8H6vHs3lmGFas6wiiHY0jbli8dwFrHiYbkxjTjEeD/9RrPisPkXTmn9cQKm7g1XqkxCHQL2PHK3nQA8cKkgQWOGo9wiu0NeOA0eLhjKPA6KSq2gIahffTGP+ivD4nOp7Y87Bbh3DaNqeQ8E0uK9e4A6DM0kZoh7FtNcHT1HxcfNaY1+cy+Qwk9ljAXPhLwpQhdD+BdnkQFzIofcRjrqRTi7W9Pvnjz+LTwJiDWHbvKvY9TqLv5/Ms/OQalSqmTTRipzfeCXuJ43eghysHzgUKsgsrNP+jiwfD6zdaqcfnLOkLJ4V8z4+BFepb7lvtl+eAAAA//8=
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.Invoices
{
    /// <summary>
    /// Base object for all financial value related fields (balance, payment due, etc.)
    /// </summary>
    [DataContract]
    public class Currency
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public Currency() {}

        /// <summary>
        /// 3 letter currency code as defined by ISO 4217.
        /// </summary>
        [DataMember(Name="currency", EmitDefaultValue = false)]
        public string CurrencyCode;

        /// <summary>
        /// REQUIRED
        /// amount up to N digit after the decimals separator as defined in ISO 4217 for the appropriate currency code.
        /// </summary>
        [DataMember(Name="value", EmitDefaultValue = false)]
        public string Value;
    }
}

