// This class was generated on Tue, 30 Jan 2018 11:02:41 PST by version 0.1.0-dev+6beb51-dirty of Braintree SDK Generator
// ExecuteOrder.cs
// @version 0.1.0-dev+6beb51-dirty
// @type object
// @data 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
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.Orders
{
    /// <summary>
    /// An execute order request.
    /// </summary>
    [DataContract]
    public class ExecuteOrder
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public ExecuteOrder() {}

        /// <summary>
        /// REQUIRED
        /// Indicates whether to disburse money instantly or later.
        /// </summary>
        [DataMember(Name="disbursement_mode", EmitDefaultValue = false)]
        public string DisbursementMode;

        /// <summary>
        /// The payer. The payer funds the payment.
        /// </summary>
        [DataMember(Name="payer", EmitDefaultValue = false)]
        public Payer Payer;
    }
}

