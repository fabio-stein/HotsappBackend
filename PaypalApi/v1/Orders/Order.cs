// This class was generated on Tue, 30 Jan 2018 11:02:41 PST by version 0.1.0-dev+6beb51-dirty of Braintree SDK Generator
// Order.cs
// @version 0.1.0-dev+6beb51-dirty
// @type object
// @data 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
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.Orders
{
    /// <summary>
    /// An order.
    /// </summary>
    [DataContract]
    public class Order
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public Order() {}

        /// <summary>
        /// The application context experience information.
        /// </summary>
        [DataMember(Name="application_context", EmitDefaultValue = false)]
        public ApplicationContext ApplicationContext;

        /// <summary>
        /// The date and time when the resource was created, in [Internet date and time format](https://tools.ietf.org/html/rfc3339#section-5.6).
        /// </summary>
        [DataMember(Name="create_time", EmitDefaultValue = false)]
        public string CreateTime;

        /// <summary>
        /// The ID of the order.
        /// </summary>
        [DataMember(Name="id", EmitDefaultValue = false)]
        public string Id;

        /// <summary>
        /// The intent.
        /// </summary>
        [DataMember(Name="intent", EmitDefaultValue = false)]
        public string Intent;

        /// <summary>
        /// An array of request-related [HATEOAS links](/docs/api/overview/#hateoas-links). To complete the buyer approval, use the `approval_url` link with the `GET` method and do not use the link that shows the `REDIRECT` method.
        /// </summary>
        [DataMember(Name="links", EmitDefaultValue = false)]
        public List<LinkDescriptionObject> Links;

        /// <summary>
        /// Metadata.
        /// </summary>
        [DataMember(Name="metadata", EmitDefaultValue = false)]
        public Metadata Metadata;

        /// <summary>
        /// The payer information.
        /// </summary>
        [DataMember(Name="payer_info", EmitDefaultValue = false)]
        public PayerInformation PayerInfo;

        /// <summary>
        /// The payment details for the order.
        /// </summary>
        [DataMember(Name="payment_details", EmitDefaultValue = false)]
        public PaymentDetails PaymentDetails;

        /// <summary>
        /// REQUIRED
        /// An array of purchase units. Each purchase unit establishes a contract between the payer and payee.
        /// </summary>
        [DataMember(Name="purchase_units", EmitDefaultValue = false)]
        public List<PurchaseUnit> PurchaseUnits;

        /// <summary>
        /// REQUIRED
        /// The redirect URLs. Required only for the PayPal payment method. The supported settings are return and cancel URLs.
        /// </summary>
        [DataMember(Name="redirect_urls", EmitDefaultValue = false)]
        public RedirectUrls RedirectUrls;

        /// <summary>
        /// The status of the order. After the customer approves the order, the status is `APPROVED`. After the payment is made for the order and the order completes, the status is `COMPLETED`.
        /// </summary>
        [DataMember(Name="status", EmitDefaultValue = false)]
        public string Status;

        /// <summary>
        /// The date and time when the resource was last updated, in [Internet date and time format](https://tools.ietf.org/html/rfc3339#section-5.6).
        /// </summary>
        [DataMember(Name="update_time", EmitDefaultValue = false)]
        public string UpdateTime;
    }
}

