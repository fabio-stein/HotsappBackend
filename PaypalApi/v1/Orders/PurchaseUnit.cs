// This class was generated on Tue, 30 Jan 2018 11:02:41 PST by version 0.1.0-dev+6beb51-dirty of Braintree SDK Generator
// PurchaseUnit.cs
// @version 0.1.0-dev+6beb51-dirty
// @type object
// @data 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
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.Orders
{
    /// <summary>
    /// A purchase unit. Establishes a contract between the payer and payee.
    /// </summary>
    [DataContract]
    public class PurchaseUnit
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public PurchaseUnit() {}

        /// <summary>
        /// REQUIRED
        /// The payment amount, with details.
        /// </summary>
        [DataMember(Name="amount", EmitDefaultValue = false)]
        public Amount Amount;

        /// <summary>
        /// The client-provided external ID. Used to reconcile client transactions with PayPal transactions. Returned in transaction and settlement reports. Only supported for the PayPal payment method.
        /// </summary>
        [DataMember(Name="custom", EmitDefaultValue = false)]
        public string Custom;

        /// <summary>
        /// The purchase description.
        /// </summary>
        [DataMember(Name="description", EmitDefaultValue = false)]
        public string Description;

        /// <summary>
        /// The partner-provided external invoice number for this order. Only supported for the PayPal payment method.
        /// </summary>
        [DataMember(Name="invoice_number", EmitDefaultValue = false)]
        public string InvoiceNumber;

        /// <summary>
        /// An array of items.
        /// </summary>
        [DataMember(Name="items", EmitDefaultValue = false)]
        public List<Item> Items;

        /// <summary>
        /// Metadata.
        /// </summary>
        [DataMember(Name="metadata", EmitDefaultValue = false)]
        public Metadata Metadata;

        /// <summary>
        /// The payment notifications URL.
        /// </summary>
        [DataMember(Name="notify_url", EmitDefaultValue = false)]
        public string NotifyUrl;

        /// <summary>
        /// The partner fee that is collected for the original transaction.
        /// </summary>
        [DataMember(Name="partner_fee_details", EmitDefaultValue = false)]
        public PartnerFeeDetails PartnerFeeDetails;

        /// <summary>
        /// The payee who receives the funds and fulfills the order.
        /// </summary>
        [DataMember(Name="payee", EmitDefaultValue = false)]
        public Payee Payee;

        /// <summary>
        /// The payment descriptor on the buyer credit card statement of account activity.
        /// </summary>
        [DataMember(Name="payment_descriptor", EmitDefaultValue = false)]
        public string PaymentDescriptor;

        /// <summary>
        /// An ID that groups multiple linked purchase units. The purchase transactions are linked only for the payment and not for refund. A refund is processed only for the specific transaction within the same linked group.
        /// </summary>
        [DataMember(Name="payment_linked_group", EmitDefaultValue = false)]
        public int? PaymentLinkedGroup;

        /// <summary>
        /// The payment summary.
        /// </summary>
        [DataMember(Name="payment_summary", EmitDefaultValue = false)]
        public PaymentSummary PaymentSummary;

        /// <summary>
        /// The reason code for a transaction state of `pending` or `reversed`. Eventually, this field will replace `pending_reason`. Only supported for the PayPal payment method.
        /// </summary>
        [DataMember(Name="reason_code", EmitDefaultValue = false)]
        public string ReasonCode;

        /// <summary>
        /// REQUIRED
        /// The merchant ID for the purchase unit.
        /// </summary>
        [DataMember(Name="reference_id", EmitDefaultValue = false)]
        public string ReferenceId;

        /// <summary>
        /// The shipping address details.
        /// </summary>
        [DataMember(Name="shipping_address", EmitDefaultValue = false)]
        public ShippingAddress ShippingAddress;

        /// <summary>
        /// The shipping method. For example, `USPSParcel`.
        /// </summary>
        [DataMember(Name="shipping_method", EmitDefaultValue = false)]
        public string ShippingMethod;

        /// <summary>
        /// The transaction state.
        /// </summary>
        [DataMember(Name="status", EmitDefaultValue = false)]
        public string Status;
    }
}

