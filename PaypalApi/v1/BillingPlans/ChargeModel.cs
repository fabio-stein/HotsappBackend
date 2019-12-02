// This class was generated on Tue, 30 Jan 2018 11:14:21 PST by version 0.1.0-dev+6beb51-dirty of Braintree SDK Generator
// ChargeModel.cs
// @version 0.1.0-dev+6beb51-dirty
// @type object
// @data H4sIAAAAAAAC/7xUX2vcOBB/v08x6OkCXvvuOCjsW2kopCV/aEKhhFDG0ng1rSy5o3G2pvS7Fzmb3Syb0paUPvonefT7x3wxV9NAZmleeJQVwWlyFExl3qIwtoHOsC+npjKvadp9HFO2woNyimZprjxB9jwMHFfQEQFGB4qfgWOXpMdyrTaVeS6C0917/1TmDaE7j2Eyyw5DpgJ8GlnIbYELSQOJMmWzvN4xHUUo2umQJfZpjLrHdQsdMm4xE6T2A1mFLglgCNBxxGgZA9xiGGkhFFDJQccUXK4gj9YDZmgxYLRUwYBTT1HBjVTNsnOCXxSrMn5Xa1bhuDpUajcevLfJ0Z5gu3PnUPK1eiFaWI+CVkng5PJ88f9//z6D+9+gDLz526sOedk0jm4pFGL1gNOAobapb1yyueGotJI52saxkNVGKGtzP2hRBuXm6Km5xzGEr9UPDZnj2jPiHjl0Yat1vlLDKa+8QltqC7MskrkQm3tMGQJ/JHh18Q7UowIKQUwKOg1sMYQJuuInp4gBSpPAkeUewxZ/dN7V2fFuXh5bx7fsyBUOCdSnMWN06nMNL5OAegLZOAVx7FsSSN32pSGgpXxX5P00K8hEcH1yeQ4l6l246/W65pzqJKuGc2p86qnJitGhuNzsdSzXXvujJ/Z6zvLmJ9Jktxfl/HmY48lxMaD4Yu+WV1+W1x8qnJbjhyQ3wCN1e0CuVIYqWHu2HjjPSzLJdnn+Hn//+gYAAP//
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.BillingPlans
{
    /// <summary>
    /// The shipping fee and tax information.
    /// </summary>
    [DataContract]
    public class ChargeModel
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public ChargeModel() {}

        /// <summary>
        /// REQUIRED
        /// The base object for all financial value-related fields, such as balance, payment due, and so on.
        /// </summary>
        [DataMember(Name="amount", EmitDefaultValue = false)]
        public Currency Amount;

        /// <summary>
        /// The ID of the charge model.
        /// </summary>
        [DataMember(Name="id", EmitDefaultValue = false)]
        public string Id;

        /// <summary>
        /// REQUIRED
        /// The charge model type, which is tax or shipping.
        /// </summary>
        [DataMember(Name="type", EmitDefaultValue = false)]
        public string Type;
    }
}

