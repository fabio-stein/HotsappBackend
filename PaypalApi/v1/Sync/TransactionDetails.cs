// This class was generated on Tue, 30 Jan 2018 11:02:44 PST by version 0.1.0-dev+6beb51-dirty of Braintree SDK Generator
// TransactionDetails.cs
// @version 0.1.0-dev+6beb51-dirty
// @type object
// @data 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
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.Sync
{
    /// <summary>
    /// The transaction details.
    /// </summary>
    [DataContract]
    public class TransactionDetails
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public TransactionDetails() {}

        /// <summary>
        /// The auction information.
        /// </summary>
        [DataMember(Name="auction_info", EmitDefaultValue = false)]
        public AuctionInformation AuctionInfo;

        /// <summary>
        /// The cart information.
        /// </summary>
        [DataMember(Name="cart_info", EmitDefaultValue = false)]
        public CartInformation CartInfo;

        /// <summary>
        /// The incentive details.
        /// </summary>
        [DataMember(Name="incentive_info", EmitDefaultValue = false)]
        public IncentiveInformation IncentiveInfo;

        /// <summary>
        /// The payer information.
        /// </summary>
        [DataMember(Name="payer_info", EmitDefaultValue = false)]
        public PayerInformation PayerInfo;

        /// <summary>
        /// The shipping information.
        /// </summary>
        [DataMember(Name="shipping_info", EmitDefaultValue = false)]
        public ShippingInformation ShippingInfo;

        /// <summary>
        /// The store information.
        /// </summary>
        [DataMember(Name="store_info", EmitDefaultValue = false)]
        public StoreInformation StoreInfo;

        /// <summary>
        /// The transaction information.
        /// </summary>
        [DataMember(Name="transaction_info", EmitDefaultValue = false)]
        public TransactionInformation TransactionInfo;
    }
}

