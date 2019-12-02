// This class was generated on Sun, 08 Apr 2018 17:47:21 UTC by version 0.1.0-dev+291f3f of Braintree SDK Generator
// DisputeSearchResponse.cs
// @version 0.1.0-dev+291f3f
// @type object
// @data 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
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.CustomerDisputes
{
    /// <summary>
    /// A list of disputes. Includes links that enable you to navigate through the response.
    /// </summary>
    [DataContract]
    public class DisputeSearchResponse
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public DisputeSearchResponse() {}

        /// <summary>
        /// An array of disputes that match the filter criteria. Sorted from latest to earliest creation time order.
        /// </summary>
        [DataMember(Name="items", EmitDefaultValue = false)]
        public List<Dispute> Items;

        /// <summary>
        /// An array of request-related [HATEOAS links](/docs/api/hateoas-links/).
        /// </summary>
        [DataMember(Name="links", EmitDefaultValue = false)]
        public List<LinkDescription> Links;

        /// <summary>
        /// The total number of items. If `total_required=true` was specified in the request, appears in the response.
        /// </summary>
        [DataMember(Name="total_items", EmitDefaultValue = false)]
        public int? TotalItems;

        /// <summary>
        /// The total number of pages. If `total_required=true` was specified in the request, appears in the response.
        /// </summary>
        [DataMember(Name="total_pages", EmitDefaultValue = false)]
        public int? TotalPages;
    }
}

