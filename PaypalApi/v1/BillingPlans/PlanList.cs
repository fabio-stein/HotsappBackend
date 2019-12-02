// This class was generated on Tue, 30 Jan 2018 11:14:21 PST by version 0.1.0-dev+6beb51-dirty of Braintree SDK Generator
// PlanList.cs
// @version 0.1.0-dev+6beb51-dirty
// @type object
// @data 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
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.BillingPlans
{
    /// <summary>
    /// A list of plans. Contains details for each plan and a set of [HATEOAS links](/docs/api/overview/#hateoas-links).
    /// </summary>
    [DataContract]
    public class PlanList
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public PlanList() {}

        /// <summary>
        /// An array of request-related [HATEOAS links](/docs/api/overview/#hateoas-links).
        /// </summary>
        [DataMember(Name="links", EmitDefaultValue = false)]
        public List<LinkDescriptionObject> Links;

        /// <summary>
        /// An array of plans.
        /// </summary>
        [DataMember(Name="plans", EmitDefaultValue = false)]
        public List<Plan> Plans;

        /// <summary>
        /// The total number of plans in the list.
        /// </summary>
        [DataMember(Name="total_items", EmitDefaultValue = false)]
        public string TotalItems;

        /// <summary>
        /// The total number of pages in the response. The `page_size` request value determines how many plans appear on each page. The `total_items` and `page_size` request values are used to calculate the total number of pages in the response.
        /// </summary>
        [DataMember(Name="total_pages", EmitDefaultValue = false)]
        public string TotalPages;
    }
}

