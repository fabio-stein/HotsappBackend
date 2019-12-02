// This class was generated on Mon, 09 Apr 2018 18:07:49 UTC by version 0.1.0-dev+291f3f of Braintree SDK Generator
// Authorization.cs
// @version 0.1.0-dev+291f3f
// @type object
// @data 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
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.Payments
{
    /// <summary>
    /// The authorization details.
    /// </summary>
    [DataContract]
    public class Authorization
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public Authorization() {}

        /// <summary>
        /// REQUIRED
        /// The payment amount, with details.
        /// </summary>
        [DataMember(Name="amount", EmitDefaultValue = false)]
        public Amount Amount;

        /// <summary>
        /// The date and time when the authorization was created, in [Internet date and time format](https://tools.ietf.org/html/rfc3339#section-5.6).
        /// </summary>
        [DataMember(Name="create_time", EmitDefaultValue = false)]
        public string CreateTime;

        /// <summary>
        /// The Fraud Management Filter (FMF) details that are applied to the payment that result in an accept, deny, or pending action. Returned in a payment response only if the merchant has enabled FMF in the profile settings and one of the fraud filters was triggered based on those settings. For more information, see [Fraud Management Filters Summary](/docs/classic/fmf/integration-guide/FMFSummary/).
        /// </summary>
        [DataMember(Name="fmf_details", EmitDefaultValue = false)]
        public FmfDetails FmfDetails;

        /// <summary>
        /// The ID of the authorization.
        /// </summary>
        [DataMember(Name="id", EmitDefaultValue = false)]
        public string Id;

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
        /// The payment mode of the authorization.
        /// </summary>
        [DataMember(Name="payment_mode", EmitDefaultValue = false)]
        public string PaymentMode;

        /// <summary>
        /// Deprecated. The reason code for the pending transaction state. Obsolete. Use `reason_code` instead.
        /// </summary>
        [DataMember(Name="pending_reason", EmitDefaultValue = false)]
        public string PendingReason;

        /// <summary>
        /// The processor-provided response codes that describe the submitted payment. Supported only when the `payment_method` is `credit_card`.
        /// </summary>
        [DataMember(Name="processor_response", EmitDefaultValue = false)]
        public ProcessorResponse ProcessorResponse;

        /// <summary>
        /// The level of seller protection present for the transaction. Supported for the PayPal payment method only. Value is:<ul><li><code>ELIGIBLE</code>. Merchant is protected by PayPal's Seller Protection Policy for Unauthorized Payments and Item Not Received.</li><li><code>PARTIALLY_ELIGIBLE</code>. Merchant is protected by PayPal's Seller Protection Policy for Item Not Received or Unauthorized Payments. For details, see `protection_eligibility_type`.</li><li><code>INELIGIBLE</code>. Merchant is not protected under the Seller Protection Policy.</li></ul>
        /// </summary>
        [DataMember(Name="protection_eligibility", EmitDefaultValue = false)]
        public string ProtectionEligibility;

        /// <summary>
        /// The type of seller protection present for the transaction. Returned only when the `protection_eligibility` property is `ELIGIBLE` or `PARTIALLY_ELIGIBLE`. Supported for the PayPal payment method only.<br/><br/>Returns one or both of the allowed values.<br/><br/>Value is:<ul><li><code>ITEM_NOT_RECEIVED_ELIGIBLE</code>. Sellers are protected against claims for items not received.</li><li><code>UNAUTHORIZED_PAYMENT_ELIGIBLE</code>. Sellers are protected against claims for unauthorized payments.</li></ul>
        /// </summary>
        [DataMember(Name="protection_eligibility_type", EmitDefaultValue = false)]
        public string ProtectionEligibilityType;

        /// <summary>
        /// The reason code for the pending transaction state.
        /// </summary>
        [DataMember(Name="reason_code", EmitDefaultValue = false)]
        public string ReasonCode;

        /// <summary>
        /// The receipt ID, which identifies the payment. Value is 16-digit numeric payment ID number that is returned for guest users.
        /// </summary>
        [DataMember(Name="receipt_id", EmitDefaultValue = false)]
        public string ReceiptId;

        /// <summary>
        /// The ID of the purchase or transaction unit that corresponds to this authorization transaction.
        /// </summary>
        [DataMember(Name="reference_id", EmitDefaultValue = false)]
        public string ReferenceId;

        /// <summary>
        /// The authorization state.
        /// </summary>
        [DataMember(Name="state", EmitDefaultValue = false)]
        public string State;

        /// <summary>
        /// The date and time when the authorization was last updated, in [Internet date and time format](https://tools.ietf.org/html/rfc3339#section-5.6).
        /// </summary>
        [DataMember(Name="update_time", EmitDefaultValue = false)]
        public string UpdateTime;

        /// <summary>
        /// The date and time when the authorization expires, in [Internet date and time format](https://tools.ietf.org/html/rfc3339#section-5.6).
        /// </summary>
        [DataMember(Name="valid_until", EmitDefaultValue = false)]
        public string ValidUntil;
    }
}

