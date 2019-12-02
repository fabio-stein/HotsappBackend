// This class was generated on Tue, 30 Jan 2018 11:02:41 PST by version 0.1.0-dev+6beb51-dirty of Braintree SDK Generator
// PaymentSummary.cs
// @version 0.1.0-dev+6beb51-dirty
// @type object
// @data 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
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.Orders
{
    /// <summary>
    /// The payment summary.
    /// </summary>
    [DataContract]
    public class PaymentSummary
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public PaymentSummary() {}

        /// <summary>
        /// An array of authorizations for a purchase unit. A purchase unit can have zero or more authorizations.
        /// </summary>
        [DataMember(Name="authorizations", EmitDefaultValue = false)]
        public List<Sale> Authorizations;

        /// <summary>
        /// An array of captures for a purchase unit. A purchase unit can have zero or more captures.
        /// </summary>
        [DataMember(Name="captures", EmitDefaultValue = false)]
        public List<Capture> Captures;

        /// <summary>
        /// An array of refunds for a purchase unit. A purchase unit can have zero or more refunds.
        /// </summary>
        [DataMember(Name="refunds", EmitDefaultValue = false)]
        public List<Refund> Refunds;

        /// <summary>
        /// An array of sales for a purchase unit. A purchase unit can have zero or more sales.
        /// </summary>
        [DataMember(Name="sales", EmitDefaultValue = false)]
        public List<Sale> Sales;
    }
}

