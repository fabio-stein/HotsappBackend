// This class was generated on Sun, 08 Apr 2018 17:47:21 UTC by version 0.1.0-dev+291f3f of Braintree SDK Generator
// TrackingInformation.cs
// @version 0.1.0-dev+291f3f
// @type object
// @data H4sIAAAAAAAC/8yRMUv8QBDF+/+nGKYOf6zTCTaiqBynjcgxl0xuBze7cXaCBLnvLklM7jSihRaW897b2ffbfcF11zDmuFYqHiXs4DxUUWsyiQEzvCMV2nq+orpPYYYX3B2GM06FSjOEc1w7Bpv2yGHPf8zwVJW68a6TDFdM5XXwHeYV+cS98NSKcjkLNxobVhNOmN/PLZOphN2yV0GqwroJ/Xjc8YOx7NsbECswx/AWhirqMCcnTc3BJt+UQqKiPw3myEASUEqxEDIu4VnMgTlJUEpqWuOfcofW+332Lfz05JvQ1lvWd/xL74svGzNL/Ek45v9L3K36z6FHY0l8u7oEiyP4QCbG9cz7K/Uf9v9eAQAA//8=
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.CustomerDisputes
{
    /// <summary>
    /// The tracking information.
    /// </summary>
    [DataContract]
    public class TrackingInformation
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public TrackingInformation() {}

        /// <summary>
        /// The name of the carrier for the shipment of the transaction that is associated with this dispute.
        /// </summary>
        [DataMember(Name="carrier_name", EmitDefaultValue = false)]
        public string CarrierName;

        /// <summary>
        /// The tracking number for the shipment for the transaction associated with this dispute.
        /// </summary>
        [DataMember(Name="tracking_number", EmitDefaultValue = false)]
        public string TrackingNumber;

        /// <summary>
        /// The URL to track the item shipment.
        /// </summary>
        [DataMember(Name="tracking_url", EmitDefaultValue = false)]
        public string TrackingUrl;
    }
}

