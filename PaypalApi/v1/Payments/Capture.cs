// This class was generated on Mon, 09 Apr 2018 18:07:49 UTC by version 0.1.0-dev+291f3f of Braintree SDK Generator
// Capture.cs
// @version 0.1.0-dev+291f3f
// @type object
// @data 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
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.Payments
{
    /// <summary>
    /// The capture transaction details.
    /// </summary>
    [DataContract]
    public class Capture
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public Capture() {}

        /// <summary>
        /// The payment amount, with details.
        /// </summary>
        [DataMember(Name="amount", EmitDefaultValue = false)]
        public Amount Amount;

        /// <summary>
        /// The date and time of the capture, in [Internet date and time format](https://tools.ietf.org/html/rfc3339#section-5.6).
        /// </summary>
        [DataMember(Name="create_time", EmitDefaultValue = false)]
        public string CreateTime;

        /// <summary>
        /// The ID of the capture transaction.
        /// </summary>
        [DataMember(Name="id", EmitDefaultValue = false)]
        public string Id;

        /// <summary>
        /// The invoice number to track this payment.
        /// </summary>
        [DataMember(Name="invoice_number", EmitDefaultValue = false)]
        public string InvoiceNumber;

        /// <summary>
        /// Indicates whether to release all remaining held funds.
        /// </summary>
        [DataMember(Name="is_final_capture", EmitDefaultValue = false)]
        public bool? IsFinalCapture;

        /// <summary>
        /// An array of request-related [HATEOAS links](/docs/api/overview/#hateoas-links).
        /// </summary>
        [DataMember(Name="links", EmitDefaultValue = false)]
        public List<LinkDescriptionObject> Links;

        /// <summary>
        /// The ID of the payment on which this transaction is based.
        /// </summary>
        [DataMember(Name="parent_payment", EmitDefaultValue = false)]
        public string ParentPayment;

        /// <summary>
        /// The reason code that describes why the transaction state is pending or reversed.
        /// </summary>
        [DataMember(Name="reason_code", EmitDefaultValue = false)]
        public string ReasonCode;

        /// <summary>
        /// The capture state. Value is:<ul><li><code>pending</code>. The capture is pending.</li><li><code>completed</code>. The capture has successfully completed.</li><li><code>refunded</code>. The capture was fully refunded.</li><li><code>partially_refunded</code>. The capture was partially refunded.</li><li><code>denied</code>. PayPal has declined to process this transaction.</li></ul>
        /// </summary>
        [DataMember(Name="state", EmitDefaultValue = false)]
        public string State;

        /// <summary>
        /// The currency and amount for a transaction.
        /// </summary>
        [DataMember(Name="transaction_fee", EmitDefaultValue = false)]
        public Currency TransactionFee;

        /// <summary>
        /// The date and time when the resource was last updated, in [Internet date and time format](https://tools.ietf.org/html/rfc3339#section-5.6).
        /// </summary>
        [DataMember(Name="update_time", EmitDefaultValue = false)]
        public string UpdateTime;
    }
}

