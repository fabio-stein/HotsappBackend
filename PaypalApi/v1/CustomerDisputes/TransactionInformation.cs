// This class was generated on Sun, 08 Apr 2018 17:47:21 UTC by version 0.1.0-dev+291f3f of Braintree SDK Generator
// TransactionInformation.cs
// @version 0.1.0-dev+291f3f
// @type object
// @data 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
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.CustomerDisputes
{
    /// <summary>
    /// Information about the disputed transaction.
    /// </summary>
    [DataContract]
    public class TransactionInformation
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public TransactionInformation() {}

        /// <summary>
        /// The details for the customer who funds the payment. For example, the customer's first name, last name, email address, and so on.
        /// </summary>
        [DataMember(Name="buyer", EmitDefaultValue = false)]
        public Buyer Buyer;

        /// <summary>
        /// The ID, as seen by the customer, for this transaction.
        /// </summary>
        [DataMember(Name="buyer_transaction_id", EmitDefaultValue = false)]
        public string BuyerTransactionId;

        /// <summary>
        /// The date and time, in [Internet date and time format](https://tools.ietf.org/html/rfc3339#section-5.6). Seconds are required while fractional seconds are optional.<blockquote><strong>Note:</strong> The regular expression provides guidance but does not reject all invalid dates.</blockquote>
        /// </summary>
        [DataMember(Name="create_time", EmitDefaultValue = false)]
        public string CreateTime;

        /// <summary>
        /// A free-text field that is entered by the merchant during checkout.
        /// </summary>
        [DataMember(Name="custom", EmitDefaultValue = false)]
        public string Custom;

        /// <summary>
        /// The currency and amount for a financial value-related field. For example, balance or payment due.
        /// </summary>
        [DataMember(Name="gross_amount", EmitDefaultValue = false)]
        public Money GrossAmount;

        /// <summary>
        /// The ID of the invoice that is associated with the payment.
        /// </summary>
        [DataMember(Name="invoice_number", EmitDefaultValue = false)]
        public string InvoiceNumber;

        /// <summary>
        /// An array of items that were purchased as part of the transaction.
        /// </summary>
        [DataMember(Name="items", EmitDefaultValue = false)]
        public List<ItemInformation> Items;

        /// <summary>
        /// The details for the merchant who receives the funds and fulfills the order. For example, merchant ID, contact email address, and so on.
        /// </summary>
        [DataMember(Name="seller", EmitDefaultValue = false)]
        public Merchant Seller;

        /// <summary>
        /// The ID, as seen by the merchant, for this transaction.
        /// </summary>
        [DataMember(Name="seller_transaction_id", EmitDefaultValue = false)]
        public string SellerTransactionId;

        /// <summary>
        /// The transaction status. Value is:<ul><li><code>COMPLETED</code>. The transaction processing is completed.</li><li><code>UNCLAIMED</code>. The items in the transaction are unclaimed. If they are not claimed within 30 days, the funds are returned to the sender.</li><li><code>DENIED</code>. The transaction was denied.</li><li><code>FAILED</code>. The transaction failed.</li><li><code>HELD</code>. The transaction is on hold.</li><li><code>PENDING</code>. The transaction is waiting to be processed.</li><li><code>PARTIALLY_REFUNDED</code>. Payment for the transaction was partially refunded.</li><li><code>REFUNDED</code>. Payment for the transaction was successfully refunded.</li><li><code>REVERSED</code>. Payment for the transaction was reversed due to a chargeback or other type of reversal.</li></ul>
        /// </summary>
        [DataMember(Name="transaction_status", EmitDefaultValue = false)]
        public string TransactionStatus;
    }
}

