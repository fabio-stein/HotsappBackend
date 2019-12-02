// This class was generated on Tue, 30 Jan 2018 11:02:44 PST by version 0.1.0-dev+6beb51-dirty of Braintree SDK Generator
// CheckoutOption.cs
// @version 0.1.0-dev+6beb51-dirty
// @type object
// @data H4sIAAAAAAAC/6yRwU7jMBCG7/sUI5/das+5Vbvay0oUoYoLQs3UmdYjnNiMbWiE+u7IDSlULSAER4++sf//85Na9IFUpf5YMnc+J5iHxL5TWl2jMK4cXWBbAKXVf+pfD38pGuEBrtQMzHiB388AIyB02NIEu2bygC4TBGSZKq1mItgPD//W6oqwmXeuV9UaXaQyuM8s1BwGl+IDSWKKqro5RI5JuNucJh2TLIckyxLiKP07wHGjhaWTTgXU8GjZWODSz1gUNImEY2IDfg3YASdqNcRsbJFQG++81OAF6kTblIXq7zrosnM7/WUR+0/40MRIfK5iT07hnxegLbbBkYZ0hhvrt7yxCVYE9cplGnQINXWx6ej86qjrzXJsvU/2ZZ1DcNT8jM3b3a9nAAAA//8=
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.Sync
{
    /// <summary>
    /// A checkout option as a name-and-value pair.
    /// </summary>
    [DataContract]
    public class CheckoutOption
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public CheckoutOption() {}

        /// <summary>
        /// The checkout option name, which is a characteristic of an item, such as `color` or `texture`.
        /// </summary>
        [DataMember(Name="checkout_option_name", EmitDefaultValue = false)]
        public string CheckoutOptionName;

        /// <summary>
        /// The checkout option value. For example, the checkout option `color` might be `blue` or `red` while the checkout option `texture` might be `smooth` or `rippled`.
        /// </summary>
        [DataMember(Name="checkout_option_value", EmitDefaultValue = false)]
        public string CheckoutOptionValue;
    }
}

