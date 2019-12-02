// This class was generated on Tue, 30 Jan 2018 11:02:41 PST by version 0.1.0-dev+6beb51-dirty of Braintree SDK Generator
// Item.cs
// @version 0.1.0-dev+6beb51-dirty
// @type object
// @data H4sIAAAAAAAC/8yUQU8bMRCF7/0VI59AWrKBVkLKDakXRFsQgV4oB2NPsiO89jIeA6uK/16Z7aa7TSNAraKeVvM8Hr8vL/Z3ddE2qGbqWLBWhfqqmfSNwy+6zqoq1Am2v4qPGA1TIxS8mqmLCoEEa7AomlycqEIdMeu2mzkt1Dlqe+pdq2YL7SJm4S4Ro10JZxwaZCGMana1chOFyS/X/ZjEjN60I18Dcd3flVSMuGcqzdoIMhzPT/c+HOwfQr8NTLB4vVPaYGJJXnDJOg8oLTEaKRmjlH3zXm6O5e6bUIXTb6Q+OfdUvIhrBzhD4rG+MZSVPIF5aprAghaCdy0sAoNUCGe6PdMOGt3W6AVqlCrYv43xlXA+f4ZUP4UNOHl1Ap/1I9WpBod+KRVQhP2DQ1ilG7eTS8Nkxt57ZYN5E6L80fx04L2Ah4pMBeSNSxbj7FuaTt+b5J6/2FWOumqO9+jB0pIkwg0uAuNzohYN1TnSQF4m3Z6y3zQecfHG9ofQn6cX+Sa98riyB9hKNHdJeyEZvxADcUNAfceLIW3nDxZv0wigq9e9RwnmFm4RG/JLSJ4EduYnl7urC57htnSfRT+OPHf1ht9b9ON/+SgldiOIrl6HuDz/BBI6FvKLwLXuHtqje00uD8zLmabRLTKQfy6EtY/a5FaoKErg9p+AXT+9+wEAAP//
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.Orders
{
    /// <summary>
    /// The item details.
    /// </summary>
    [DataContract]
    public class Item
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public Item() {}

        /// <summary>
        /// REQUIRED
        /// The [three-character ISO-4217 currency code](/docs/integration/direct/rest/currency-codes/).
        /// </summary>
        [DataMember(Name="currency", EmitDefaultValue = false)]
        public string Currency;

        /// <summary>
        /// The item description. Supported only for the PayPal payment method.
        /// </summary>
        [DataMember(Name="description", EmitDefaultValue = false)]
        public string Description;

        /// <summary>
        /// REQUIRED
        /// The item name. Maximum length is 127 characters.
        /// </summary>
        [DataMember(Name="name", EmitDefaultValue = false)]
        public string Name;

        /// <summary>
        /// REQUIRED
        /// The item cost. Maximum length is 10 characters, which includes:<ul><li>Seven digits before the decimal point.</li><li>The decimal point.</li><li>Two digits after the decimal point.</li></ul>
        /// </summary>
        [DataMember(Name="price", EmitDefaultValue = false)]
        public string Price;

        /// <summary>
        /// REQUIRED
        /// The item quantity. Maximum length is 10 characters.
        /// </summary>
        [DataMember(Name="quantity", EmitDefaultValue = false)]
        public string Quantity;

        /// <summary>
        /// The stock keeping unit (SKU) for the item.
        /// </summary>
        [DataMember(Name="sku", EmitDefaultValue = false)]
        public string Sku;

        /// <summary>
        /// The item tax. Supported only for the PayPal payment method.
        /// </summary>
        [DataMember(Name="tax", EmitDefaultValue = false)]
        public string Tax;

        /// <summary>
        /// The URL to item information. Available to the payer in the transaction history.
        /// </summary>
        [DataMember(Name="url", EmitDefaultValue = false)]
        public string Url;
    }
}

