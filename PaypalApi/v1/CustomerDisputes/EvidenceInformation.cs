// This class was generated on Sun, 08 Apr 2018 17:47:21 UTC by version 0.1.0-dev+291f3f of Braintree SDK Generator
// EvidenceInformation.cs
// @version 0.1.0-dev+291f3f
// @type object
// @data H4sIAAAAAAAC/8ySQY/TMBCF7/yKkc8B7YlDbisthxUI0KpwQVU1TSbNCMcO40lQhPrfkZPWbZpShEBoj5734rxvnn+Y1dCSyc2bnktyBcGjq7w0qOydycxnFMatpffYRJfJzFsaTocHCoVwO5pzs6oJ6HDPSyGLSiXw6b5XJjP3IjhM/7zLzBNh+cHZweQV2kBx8K1joTINPopvSZQpmPxLShtU2O2W+YSqzpUbLsMs6Ww8z3zvAGMk8BVMNnh8CFB5Aa0JVNAFLKIZ2PXe9iMSaM0BSg5tp3SB9fpPsVxn7T5LbCvB4iu73e0m9ODaxP3OYC+VW7yWenQKx0/Oy/qvK/h9swWKMMnGxeM57oWwfJFRiLSR5WBObKHmtiGnR/2cVWtU4AAYgi94fMvfWetb3Hd/Wf2v4FOlrmu2JNfrTtpyBanfybPEv9b1c+LuxF6HnoQl8aend6B+Ah/JWKlJvP8k/nq/3r/4CQAA//8=
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.CustomerDisputes
{
    /// <summary>
    /// The evidence-related information.
    /// </summary>
    [DataContract]
    public class EvidenceInformation
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public EvidenceInformation() {}

        /// <summary>
        /// An array of refund IDs for the transaction involved in this dispute.
        /// </summary>
        [DataMember(Name="refund_ids", EmitDefaultValue = false)]
        public List<string> RefundIds;

        /// <summary>
        /// An array of relevant tracking information for the transaction involved in this dispute.
        /// </summary>
        [DataMember(Name="tracking_info", EmitDefaultValue = false)]
        public List<TrackingInformation> TrackingInfo;
    }
}

