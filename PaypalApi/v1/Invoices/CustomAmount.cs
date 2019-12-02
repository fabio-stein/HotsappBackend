// This class was generated on Tue, 30 Jan 2018 11:02:40 PST by version 0.1.0-dev+6beb51-dirty of Braintree SDK Generator
// CustomAmount.cs
// @version 0.1.0-dev+6beb51-dirty
// @type object
// @data H4sIAAAAAAAC/6yTz2ocMQzG730K4VMLw9J/UNhbml5CISlt6KXkoLE1iYrGdmU5YErevcwkuxuTQlqS28wnWeinT/rtzlsmt3XHtVia4WhONZob3HdUxlHoFOcl7Ab3mdrh5xMVr5yNU3Rbd35F4G8L4FoALAHmLG39iMDxOrGnDZxM0FIFjl5qIEAQHEmGVZxrsXuRruDGDe5IFdttu68H95UwnEVpbjuhFFqEX5WVwl74oimTGlNx2x/3QFUp+vaQEXfsB9K91PN+xEKQxp/kDaakgCIwccToGQWuUSqBkqBRgIlJQoGXIwpGTwNkbDNFg1BpADK/efVsbMWU4+VDMn/HfJwCdXz+MIye8B0ImZHCLgN8WlwpEGjiSAHGBiffzuD92zcfnmpOrCI3w6MU61y79ndK3/vdCta8LN8pBL5kA5wWGrsiCOR5RilQKKOiLf4dsDjusVZrlxeYs6asjEb9PP4L3LT+jfviH8jXI+nId8pjd7jmPYs/Fzcv/gAAAP//
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.Invoices
{
    /// <summary>
    /// The custom amount to apply to an invoice. If you include a label, you must include a custom amount.
    /// </summary>
    [DataContract]
    public class CustomAmount
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public CustomAmount() {}

        /// <summary>
        /// Base object for all financial value related fields (balance, payment due, etc.)
        /// </summary>
        [DataMember(Name="amount", EmitDefaultValue = false)]
        public Currency Amount;

        /// <summary>
        /// The custom amount label.
        /// </summary>
        [DataMember(Name="label", EmitDefaultValue = false)]
        public string Label;
    }
}

