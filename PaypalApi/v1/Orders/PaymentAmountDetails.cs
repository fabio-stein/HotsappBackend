// This class was generated on Tue, 30 Jan 2018 11:02:41 PST by version 0.1.0-dev+6beb51-dirty of Braintree SDK Generator
// PaymentAmountDetails.cs
// @version 0.1.0-dev+6beb51-dirty
// @type object
// @data H4sIAAAAAAAC/+yWzY7TMBDH7zzFyMcq6hZx622lvSAEVLDiAqiaxpNmJMf22mPaCO27ozQfbchqAYEqDjlFM/8Zz4x/sZPv6r72pNZqg3VFVuC2cskK3JEgm6gy9QkD487QO6yaOJWpN1SfjTuKeWAv7Kxaq/uSALXmxkQDul0FcOeSgJQEviuDpzJLlanbELBum1hl6gOhfm9NrdYFmkiN4yFxID04NsF5CsIU1frz0H6UwHY/bXfPhWwPAf2o70vvdIBGhUaFgmgJb/HIVarAkN1LCRzh5QryEgPmQiFmcCg5L4FtbpKmuP6SVqtXeTKnJ7WW4db6SN/IguY9S4QdFS7QaVs05VyhAe/YyrLNuemTxkvc/2H4wfX1sBAKv1vuph/gLxHZZMxj9ktOJVpt2O63BdEI1U/ClFYfMMNqWk7euyCkoXBt9gbrTZPcnbuKpHQanDX18jpk2cYU0OZjrJfeKdNBnaGOoDbYnid7JaixZO9b5cz0wjlF2osz0avdqf2WbzXHvPncPknrUn0eG/SR84n8/67ZmHbiBM2Y8dn5BNpO7P7FhlFYqIpLeF2crEAPiaIMKMGw7WIykJIj+LbZunkLFovQzbJYzKf8KuAFjyPmrT3FLXicifwDIl8fX/wAAAD//w==
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.Orders
{
    /// <summary>
    /// The additional details about the payment amount.
    /// </summary>
    [DataContract]
    public class PaymentAmountDetails
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public PaymentAmountDetails() {}

        /// <summary>
        /// The gift wrap fee. Maximum length is 10 characters, which includes:<ul><li>Seven digits before the decimal point.</li><li>The decimal point.</li><li>Two digits after the decimal point.</li></ul>
        /// </summary>
        [DataMember(Name="gift_wrap", EmitDefaultValue = false)]
        public string GiftWrap;

        /// <summary>
        /// The handling fee. Maximum length is 10 characters, which includes:<ul><li>Seven digits before the decimal point.</li><li>The decimal point.</li><li>Two digits after the decimal point.</li></ul>Supported for the PayPal payment method only.
        /// </summary>
        [DataMember(Name="handling_fee", EmitDefaultValue = false)]
        public string HandlingFee;

        /// <summary>
        /// The insurance fee. Maximum length is 10 characters, which includes:<ul><li>Seven digits before the decimal point.</li><li>The decimal point.</li><li>Two digits after the decimal point.</li></ul>Supported only for the PayPal payment method.
        /// </summary>
        [DataMember(Name="insurance", EmitDefaultValue = false)]
        public string Insurance;

        /// <summary>
        /// The shipping fee. Maximum length is 10 characters, which includes:<ul><li>Seven digits before the decimal point.</li><li>The decimal point.</li><li>Two digits after the decimal point.</li></ul>
        /// </summary>
        [DataMember(Name="shipping", EmitDefaultValue = false)]
        public string Shipping;

        /// <summary>
        /// The shipping fee discount. Maximum length is 10 characters, which includes:<ul><li>Seven digits before the decimal point.</li><li>The decimal point.</li><li>Two digits after the decimal point.</li></ul>Supported for the PayPal payment method only.
        /// </summary>
        [DataMember(Name="shipping_discount", EmitDefaultValue = false)]
        public string ShippingDiscount;

        /// <summary>
        /// The subtotal amount for the items. If the request includes line items, this property is **required**. Maximum length is 10 characters, which includes:<ul><li>Seven digits before the decimal point.</li><li>The decimal point.</li><li>Two digits after the decimal point.</li></ul>
        /// </summary>
        [DataMember(Name="subtotal", EmitDefaultValue = false)]
        public string Subtotal;

        /// <summary>
        /// The tax. Maximum length is 10 characters, which includes:<ul><li>Seven digits before the decimal point.</li><li>The decimal point.</li><li>Two digits after the decimal point.</li></ul>
        /// </summary>
        [DataMember(Name="tax", EmitDefaultValue = false)]
        public string Tax;
    }
}

