// This class was generated on Mon, 09 Apr 2018 18:07:49 UTC by version 0.1.0-dev+291f3f of Braintree SDK Generator
// Item.cs
// @version 0.1.0-dev+291f3f
// @type object
// @data H4sIAAAAAAAC/8yUwWobMRCG732KQacEbG8TCgHfAr2UNI2Jk15CDmPt2DtYK21Go8ZLybsXdeutt8a0pcXkZObfkfg+jeSv5q5tyEwNK9VmZD6jMC4cfcI6p2Zkrqj9WbynaIUb5eDN1NxVBHkdlKTILk7MyFyKYNvt+XZkbgnLG+9aM12ii5SDp8RCZR/MJDQkyhTN9KGniSrsV/s8NomQt+2Aayfc53vQSojGtkJBqyTwYX4zfnd+dgHbZWBDSY8nRRlsLNgrrQTzBkXJQlYLoajFtnmcm2Nx+leqKukXU5+cexn9Vrfc0dk1HuYHh9LHE5inpgmiVELwroVlENCKYIbtDB002NbkFWrSKpT/OsY/lPP5Z9fqR3BAJ3+dwDVuuE41OPIrrYAjnJ1fQD/deCT2RtgO4bfJAXobovZTiKDPAUqyXOfDd2gpHudCPSX0yjp8PzvhAfptxwSuU1RYECA8V8ER+FQvSI4DH9dpwN3V+8hRg13Dmqhhv4LkWeFkfnV/2t/67HSki6K4GTB39YFjVty8ypeaxA0kunpf4v72I2joXNgvg9TY/ftcfkF2ecP8Ods02JIA+++FCvqINrdCxVGDtP9F7PHlzTcAAAD//w==
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.Payments
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
        /// The item name. Maximum length is 127 characters.
        /// </summary>
        [DataMember(Name="name", EmitDefaultValue = false)]
        public string Name;

        /// <summary>
        /// REQUIRED
        /// The item cost. Supports two decimal places.
        /// </summary>
        [DataMember(Name="price", EmitDefaultValue = false)]
        public string Price;

        /// <summary>
        /// REQUIRED
        /// The item quantity. Must be a whole number.
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

