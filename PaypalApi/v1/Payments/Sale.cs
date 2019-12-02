// This class was generated on Mon, 09 Apr 2018 18:07:49 UTC by version 0.1.0-dev+291f3f of Braintree SDK Generator
// Sale.cs
// @version 0.1.0-dev+291f3f
// @type object
// @data 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
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.Payments
{
    /// <summary>
    /// The sale transaction details.
    /// </summary>
    [DataContract]
    public class Sale
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public Sale() {}

        /// <summary>
        /// REQUIRED
        /// The payment amount, with details.
        /// </summary>
        [DataMember(Name="amount", EmitDefaultValue = false)]
        public Amount Amount;

        /// <summary>
        /// The ID of the billing agreement. Used as reference to execute this transaction.
        /// </summary>
        [DataMember(Name="billing_agreement_id", EmitDefaultValue = false)]
        public string BillingAgreementId;

        /// <summary>
        /// The date and time when the PayPal eCheck transaction is expected to clear, in [Internet date and time format](https://tools.ietf.org/html/rfc3339#section-5.6).
        /// </summary>
        [DataMember(Name="clearing_time", EmitDefaultValue = false)]
        public string ClearingTime;

        /// <summary>
        /// REQUIRED
        /// The date and time of the sale, in [Internet date and time format](https://tools.ietf.org/html/rfc3339#section-5.6).
        /// </summary>
        [DataMember(Name="create_time", EmitDefaultValue = false)]
        public string CreateTime;

        /// <summary>
        /// The exchange rate for this transaction. Returned only in cross-currency use cases where a merchant bills a buyer in a non-primary currency for that buyer.
        /// </summary>
        [DataMember(Name="exchange_rate", EmitDefaultValue = false)]
        public string ExchangeRate;

        /// <summary>
        /// The Fraud Management Filter (FMF) details that are applied to the payment that result in an accept, deny, or pending action. Returned in a payment response only if the merchant has enabled FMF in the profile settings and one of the fraud filters was triggered based on those settings. For more information, see [Fraud Management Filters Summary](/docs/classic/fmf/integration-guide/FMFSummary/).
        /// </summary>
        [DataMember(Name="fmf_details", EmitDefaultValue = false)]
        public FmfDetails FmfDetails;

        /// <summary>
        /// REQUIRED
        /// The ID of the sale transaction.
        /// </summary>
        [DataMember(Name="id", EmitDefaultValue = false)]
        public string Id;

        /// <summary>
        /// An array of request-related [HATEOAS links](/docs/api/overview/#hateoas-links).
        /// </summary>
        [DataMember(Name="links", EmitDefaultValue = false)]
        public List<LinkDescriptionObject> Links;

        /// <summary>
        /// REQUIRED
        /// The ID of the payment on which this transaction is based.
        /// </summary>
        [DataMember(Name="parent_payment", EmitDefaultValue = false)]
        public string ParentPayment;

        /// <summary>
        /// An array of reasons that PayPal holds the recipient fund. Set only if the payment hold status is `HELD`.
        /// </summary>
        [DataMember(Name="payment_hold_reasons", EmitDefaultValue = false)]
        public List<PaymentHoldReason> PaymentHoldReasons;

        /// <summary>
        /// The recipient fund status. Returned only when the fund status is `held`.
        /// </summary>
        [DataMember(Name="payment_hold_status", EmitDefaultValue = false)]
        public string PaymentHoldStatus;

        /// <summary>
        /// The transaction payment mode. Supported only for PayPal payments.
        /// </summary>
        [DataMember(Name="payment_mode", EmitDefaultValue = false)]
        public string PaymentMode;

        /// <summary>
        /// The processor-provided response codes that describe the submitted payment. Supported only when the `payment_method` is `credit_card`.
        /// </summary>
        [DataMember(Name="processor_response", EmitDefaultValue = false)]
        public ProcessorResponse ProcessorResponse;

        /// <summary>
        /// The merchant protection level in effect for the transaction. Supported only for PayPal payments.
        /// </summary>
        [DataMember(Name="protection_eligibility", EmitDefaultValue = false)]
        public string ProtectionEligibility;

        /// <summary>
        /// The merchant protection type in effect for the transaction. Returned only when `protection_eligibility` is `ELIGIBLE` or `PARTIALLY_ELIGIBLE`. Supported only for PayPal payments.
        /// </summary>
        [DataMember(Name="protection_eligibility_type", EmitDefaultValue = false)]
        public string ProtectionEligibilityType;

        /// <summary>
        /// The ID of the transaction that corresponds to this sale transaction.
        /// </summary>
        [DataMember(Name="purchase_unit_reference_id", EmitDefaultValue = false)]
        public string PurchaseUnitReferenceId;

        /// <summary>
        /// A reason code that describes why the transaction state is pending or reversed. Supported only for PayPal payments.
        /// </summary>
        [DataMember(Name="reason_code", EmitDefaultValue = false)]
        public string ReasonCode;

        /// <summary>
        /// The receipt ID, which is a payment ID number that is returned for guest users to identify the payment.
        /// </summary>
        [DataMember(Name="receipt_id", EmitDefaultValue = false)]
        public string ReceiptId;

        /// <summary>
        /// The currency and amount for a transaction.
        /// </summary>
        [DataMember(Name="receivable_amount", EmitDefaultValue = false)]
        public Currency ReceivableAmount;

        /// <summary>
        /// REQUIRED
        /// The sale transaction state.
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

