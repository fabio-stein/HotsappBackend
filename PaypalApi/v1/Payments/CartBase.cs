// This class was generated on Mon, 09 Apr 2018 18:07:49 UTC by version 0.1.0-dev+291f3f of Braintree SDK Generator
// CartBase.cs
// @version 0.1.0-dev+291f3f
// @type object
// @data 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
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.Payments
{
    /// <summary>
    /// The cart.
    /// </summary>
    [DataContract]
    public class CartBase
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public CartBase() {}

        /// <summary>
        /// REQUIRED
        /// The payment amount, with details.
        /// </summary>
        [DataMember(Name="amount", EmitDefaultValue = false)]
        public Amount Amount;

        /// <summary>
        /// A free-form field for the client's use.
        /// </summary>
        [DataMember(Name="custom", EmitDefaultValue = false)]
        public string Custom;

        /// <summary>
        /// The purchase description.
        /// </summary>
        [DataMember(Name="description", EmitDefaultValue = false)]
        public string Description;

        /// <summary>
        /// The invoice number to track this payment.
        /// </summary>
        [DataMember(Name="invoice_number", EmitDefaultValue = false)]
        public string InvoiceNumber;

        /// <summary>
        /// An array of items that are being purchased.
        /// </summary>
        [DataMember(Name="item_list", EmitDefaultValue = false)]
        public ItemList ItemList;

        /// <summary>
        /// Optional. A note to the recipient of the funds in this transaction.
        /// </summary>
        [DataMember(Name="note_to_payee", EmitDefaultValue = false)]
        public string NoteToPayee;

        /// <summary>
        /// The URL to send payment notifications.
        /// </summary>
        [DataMember(Name="notify_url", EmitDefaultValue = false)]
        public string NotifyUrl;

        /// <summary>
        /// The URL on the merchant site related to this payment.
        /// </summary>
        [DataMember(Name="order_url", EmitDefaultValue = false)]
        public string OrderUrl;

        /// <summary>
        /// The payee who receives the funds and fulfills the order.
        /// </summary>
        [DataMember(Name="payee", EmitDefaultValue = false)]
        public Payee Payee;

        /// <summary>
        /// The payment options for this transaction.
        /// </summary>
        [DataMember(Name="payment_options", EmitDefaultValue = false)]
        public PaymentOptions PaymentOptions;

        /// <summary>
        /// The purchase order number or ID. Identifies this payment.
        /// </summary>
        [DataMember(Name="purchase_order", EmitDefaultValue = false)]
        public string PurchaseOrder;

        /// <summary>
        /// Optional. The merchant-provided ID for the purchase unit.
        /// </summary>
        [DataMember(Name="reference_id", EmitDefaultValue = false)]
        public string ReferenceId;

        /// <summary>
        /// The soft descriptor to use to charge this funding source. If the string's length is greater than the maximum allowed length, the API truncates the string.
        /// </summary>
        [DataMember(Name="soft_descriptor", EmitDefaultValue = false)]
        public string SoftDescriptor;
    }
}

