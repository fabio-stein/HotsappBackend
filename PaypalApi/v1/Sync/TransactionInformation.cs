// This class was generated on Tue, 30 Jan 2018 11:02:44 PST by version 0.1.0-dev+6beb51-dirty of Braintree SDK Generator
// TransactionInformation.cs
// @version 0.1.0-dev+6beb51-dirty
// @type object
// @data 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
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.Sync
{
    /// <summary>
    /// The transaction information.
    /// </summary>
    [DataContract]
    public class TransactionInformation
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public TransactionInformation() {}

        /// <summary>
        /// The percentage, as a fixed-point, signed decimal number. For example, define a 19.99% interest rate as `19.99`.
        /// </summary>
        [DataMember(Name="annual_percentage_rate", EmitDefaultValue = false)]
        public string AnnualPercentageRate;

        /// <summary>
        /// The currency and amount for a financial value-related field. For example, balance or payment due.
        /// </summary>
        [DataMember(Name="available_balance", EmitDefaultValue = false)]
        public Money AvailableBalance;

        /// <summary>
        /// The bank reference ID. The bank provides this value for an ACH transaction.
        /// </summary>
        [DataMember(Name="bank_reference_id", EmitDefaultValue = false)]
        public string BankReferenceId;

        /// <summary>
        /// The currency and amount for a financial value-related field. For example, balance or payment due.
        /// </summary>
        [DataMember(Name="credit_promotional_fee", EmitDefaultValue = false)]
        public Money CreditPromotionalFee;

        /// <summary>
        /// The credit term. The time span covered by the installment payments as expressed in the term length plus the length time unit code.
        /// </summary>
        [DataMember(Name="credit_term", EmitDefaultValue = false)]
        public string CreditTerm;

        /// <summary>
        /// The currency and amount for a financial value-related field. For example, balance or payment due.
        /// </summary>
        [DataMember(Name="credit_transactional_fee", EmitDefaultValue = false)]
        public Money CreditTransactionalFee;

        /// <summary>
        /// The merchant-provided custom text.<blockquote><strong>Note:</strong> Usually, this field includes the unique ID for payments made with MassPay type transaction.</blockquote>
        /// </summary>
        [DataMember(Name="custom_field", EmitDefaultValue = false)]
        public string CustomField;

        /// <summary>
        /// The currency and amount for a financial value-related field. For example, balance or payment due.
        /// </summary>
        [DataMember(Name="discount_amount", EmitDefaultValue = false)]
        public Money DiscountAmount;

        /// <summary>
        /// The currency and amount for a financial value-related field. For example, balance or payment due.
        /// </summary>
        [DataMember(Name="ending_balance", EmitDefaultValue = false)]
        public Money EndingBalance;

        /// <summary>
        /// The currency and amount for a financial value-related field. For example, balance or payment due.
        /// </summary>
        [DataMember(Name="fee_amount", EmitDefaultValue = false)]
        public Money FeeAmount;

        /// <summary>
        /// The currency and amount for a financial value-related field. For example, balance or payment due.
        /// </summary>
        [DataMember(Name="insurance_amount", EmitDefaultValue = false)]
        public Money InsuranceAmount;

        /// <summary>
        /// The invoice ID that is sent by the merchant with the transaction.<blockquote><strong>Note:</strong> If an invoice ID was sent with the capture request, the value is reported. Otherwise, the invoice ID of the authorizing transaction is reported.</blockquote>
        /// </summary>
        [DataMember(Name="invoice_id", EmitDefaultValue = false)]
        public string InvoiceId;

        /// <summary>
        /// The currency and amount for a financial value-related field. For example, balance or payment due.
        /// </summary>
        [DataMember(Name="other_amount", EmitDefaultValue = false)]
        public Money OtherAmount;

        /// <summary>
        /// The payment method that was used for a transaction. Value is <code>PUI</code>, <code>installment</code>, or <code>mEFT</code>.<blockquote><strong>Note:</strong> Appears only for pay upon invoice (PUI), installment, and mEFT transactions. Merchants and partners in the EMEA region can use this attribute to note transactions that attract turn-over tax.</blockquote>
        /// </summary>
        [DataMember(Name="payment_method_type", EmitDefaultValue = false)]
        public string PaymentMethodType;

        /// <summary>
        /// The payment tracking ID, which is a unique ID that partners specify to either get information about a payment or request a refund.
        /// </summary>
        [DataMember(Name="payment_tracking_id", EmitDefaultValue = false)]
        public string PaymentTrackingId;

        /// <summary>
        /// The ID of the PayPal account of the payee.
        /// </summary>
        [DataMember(Name="paypal_account_id", EmitDefaultValue = false)]
        public string PaypalAccountId;

        /// <summary>
        /// The PayPal-generated base ID. PayPal exclusive. Cannot be altered. Defined as a related, pre-existing transaction or event.
        /// </summary>
        [DataMember(Name="paypal_reference_id", EmitDefaultValue = false)]
        public string PaypalReferenceId;

        /// <summary>
        /// The PayPal reference ID type. Value is:<ul><li><code>ODR</code>. An order ID.</li><li><code>TXN</code>. A transaction ID.</li><li><code>SUB</code>. A subscription ID.</li><li><code>PAP</code>. A preapproved payment ID.</li></ul>
        /// </summary>
        [DataMember(Name="paypal_reference_id_type", EmitDefaultValue = false)]
        public string PaypalReferenceIdType;

        /// <summary>
        /// Indicates whether the transaction is eligible for protection. Value is:<ul><li><code>01</code>. Eligible.</li><li><code>02</code>. Not eligible</li><li><code>03</code>. Partially eligible.</li></ul>
        /// </summary>
        [DataMember(Name="protection_eligibility", EmitDefaultValue = false)]
        public string ProtectionEligibility;

        /// <summary>
        /// The currency and amount for a financial value-related field. For example, balance or payment due.
        /// </summary>
        [DataMember(Name="sales_tax_amount", EmitDefaultValue = false)]
        public Money SalesTaxAmount;

        /// <summary>
        /// The currency and amount for a financial value-related field. For example, balance or payment due.
        /// </summary>
        [DataMember(Name="shipping_amount", EmitDefaultValue = false)]
        public Money ShippingAmount;

        /// <summary>
        /// The currency and amount for a financial value-related field. For example, balance or payment due.
        /// </summary>
        [DataMember(Name="shipping_discount_amount", EmitDefaultValue = false)]
        public Money ShippingDiscountAmount;

        /// <summary>
        /// The currency and amount for a financial value-related field. For example, balance or payment due.
        /// </summary>
        [DataMember(Name="shipping_tax_amount", EmitDefaultValue = false)]
        public Money ShippingTaxAmount;

        /// <summary>
        /// The currency and amount for a financial value-related field. For example, balance or payment due.
        /// </summary>
        [DataMember(Name="tip_amount", EmitDefaultValue = false)]
        public Money TipAmount;

        /// <summary>
        /// The currency and amount for a financial value-related field. For example, balance or payment due.
        /// </summary>
        [DataMember(Name="transaction_amount", EmitDefaultValue = false)]
        public Money TransactionAmount;

        /// <summary>
        /// A five-digit transaction event code that classifies the transaction type based on money movement and debit or credit. For example, <code>T0001</code>. See [Transaction event codes](/docs/integration/direct/sync/transaction-event-codes/).
        /// </summary>
        [DataMember(Name="transaction_event_code", EmitDefaultValue = false)]
        public string TransactionEventCode;

        /// <summary>
        /// The PayPal-generated transaction ID.
        /// </summary>
        [DataMember(Name="transaction_id", EmitDefaultValue = false)]
        public string TransactionId;

        /// <summary>
        /// The date and time when work on a transaction began in the PayPal system, as expressed in the time zone of the account on this side of the payment. Specify the value in [Internet date and time format](https://tools.ietf.org/html/rfc3339#section-5.6).
        /// </summary>
        [DataMember(Name="transaction_initiation_date", EmitDefaultValue = false)]
        public string TransactionInitiationDate;

        /// <summary>
        /// A special note that the payer passes to the payee. Might contain special customer requests, such as shipping instructions.
        /// </summary>
        [DataMember(Name="transaction_note", EmitDefaultValue = false)]
        public string TransactionNote;

        /// <summary>
        /// A code that indicates the transaction status. Value is:<table><thead><tr><th>Status&nbsp;code</th><th>Description</th></tr></thead><tbody><tr><td><code>D</code></td><td>PayPal or merchant rules denied the transaction.</td></tr><tr><td><code>F</code></td><td>The original recipient partially refunded the transaction.</td></tr><tr><td><code>P</code></td><td>The transaction is pending. The transaction was created but waits for another payment process to complete, such as an ACH transaction, before the status changes to <code>S</code>.</td></tr><tr><td><code>S</code></td><td>The transaction successfully completed without a denial and after any pending statuses.</td></tr><tr><td><code>V</code></td><td>A successful transaction was reversed and funds were refunded to the original sender.</td></tr></tbody></table>
        /// </summary>
        [DataMember(Name="transaction_status", EmitDefaultValue = false)]
        public string TransactionStatus;

        /// <summary>
        /// The subject of payment. The payer passes this value to the payee. The payer controls this data through the interface through which he or she sends the data.
        /// </summary>
        [DataMember(Name="transaction_subject", EmitDefaultValue = false)]
        public string TransactionSubject;

        /// <summary>
        /// The date and time when the transaction was last changed, as expressed in the time zone of the account on this side of the payment. Specify the value in [Internet date and time format](https://tools.ietf.org/html/rfc3339#section-5.6).
        /// </summary>
        [DataMember(Name="transaction_updated_date", EmitDefaultValue = false)]
        public string TransactionUpdatedDate;
    }
}

