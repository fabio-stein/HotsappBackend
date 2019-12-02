// This class was generated on Mon, 09 Apr 2018 18:07:49 UTC by version 0.1.0-dev+291f3f of Braintree SDK Generator
// AmountDetails.cs
// @version 0.1.0-dev+291f3f
// @type object
// @data H4sIAAAAAAAC/+yWz6/TMAzH7/wVVo5TtTfEbTckLggBE0xcAE1e466W0iQvcdgq9P531PXHVvr0AIEmDj1V9teO7XyatN/Vtvak1gorl6zsNAmyiSpTnzAw7g29w6rRVabeUH0xXlHMA3thZ9VabUsC1JobEw10qwDuXRKQksBjXZEVaMssVaZehoB1W3yVqQ+E+r01tVoXaCI1jvvEgfTg2ATnKQhTVOvPQ9tRAtvDtN0DF7I7BvSjvq+90wEaFRoVCqIlvMUTV6kCQ/YgJXCE5yvISwyYC4WYwbHkvAS2uUma4vpLWq1e5Mmcn9RahlvrI30jC5oPLBH2VLhA523RlHOFBrxjK8s2565PGi+x/cPwo+vrYSEUfrfcXT/AXyKyyZiH7JecSrTasD3sCqIRqp+EKa0+YIbVtJy8d0FIQ+Ha7A3Wmya5O3cVSek0OGvq5W3Iso0poM3HWK+9U6aDOkMdQW2wPU32RlBjyd63yoXplXOKtBdnoje7U/st32mOefO5fZTWtfo0Nugj5xP5/12zMe3FCZox44vzEbSd2P2LDaOwUBWX8Lo4W4HuE0UZUIJh28VkICVH8G2zdfMWLBahm2WxmE/5TcALnkbMW3uKW/A0E/kHRL4+PPsBAAD//w==
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.Payments
{
    /// <summary>
    /// The additional details about the payment amount.
    /// </summary>
    [DataContract]
    public class AmountDetails
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public AmountDetails() {}

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

