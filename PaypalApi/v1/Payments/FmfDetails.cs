// This class was generated on Mon, 09 Apr 2018 18:07:49 UTC by version 0.1.0-dev+291f3f of Braintree SDK Generator
// FmfDetails.cs
// @version 0.1.0-dev+291f3f
// @type object
// @data H4sIAAAAAAAC/7ySwWrcQAyG730KMacE3HXPeysEQynbljT0EkJQPLItGGtcSaaYkncv4102G9KllJSejH/9kj6N9DPcLBOFbejG7j6SIycLVfiGyviQ6BOOJRiq8JGWp58rslZ5cs4StuFmIGgU5wg7FOxpJHFoODkpXDS75hIOhcEHdEAlwGlKTBE8gw8EEy5r0hpXsjk5sAAKYNvS5BVEkqWCrDCRRJYesC3dN3BNPqtQXP3HQko2ZTGCLGkB7tYuI2k7oDgMaEBS5ovQ7JqSulJo7jgRGLmz9AYoEbIQ5H1+t87YrYMZ/EADV+57UorwgEbFDD5keyqxgSYrjFkJWLqsIxbqCowIbs+8mcHXeRxRl7uLOubW6jahGbd1N3Y1i1Ova5W3/cyR6mbXHPz15SZU4b0qLvulvqvCNWH8LGkJ2w6TURG+z6wUj8IXzROpM1nY3h7PwVxZ+peXEE82f3oUz/WX97F/NTixvZZV5pQeqz8C7xvfc3yGe6qehf1w9VeMrvOrEL24fgN50M9ilvj/AZXyOSU8CGfRSvyf7Pnu8c0vAAAA//8=
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.Payments
{
    /// <summary>
    /// The Fraud Management Filter (FMF) details that are applied to the payment that result in an accept, deny, or pending action. Returned in a payment response only if the merchant has enabled FMF in the profile settings and one of the fraud filters was triggered based on those settings. For more information, see [Fraud Management Filters Summary](/docs/classic/fmf/integration-guide/FMFSummary/).
    /// </summary>
    [DataContract]
    public class FmfDetails
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public FmfDetails() {}

        /// <summary>
        /// The filter description.
        /// </summary>
        [DataMember(Name="description", EmitDefaultValue = false)]
        public string Description;

        /// <summary>
        /// REQUIRED
        /// The filter ID.
        /// </summary>
        [DataMember(Name="filter_id", EmitDefaultValue = false)]
        public string FilterId;

        /// <summary>
        /// REQUIRED
        /// The filter type.
        /// </summary>
        [DataMember(Name="filter_type", EmitDefaultValue = false)]
        public string FilterType;

        /// <summary>
        /// The filter name.
        /// </summary>
        [DataMember(Name="name", EmitDefaultValue = false)]
        public string Name;
    }
}

