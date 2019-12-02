// This class was generated on Sun, 08 Apr 2018 17:47:21 UTC by version 0.1.0-dev+291f3f of Braintree SDK Generator
// AdjudicateRequest.cs
// @version 0.1.0-dev+291f3f
// @type object
// @data H4sIAAAAAAAC/6SPwUozQRCE7/9TNH35L4t43lvAm6ASghcR6ezWui2TmU1PjzBI3l02kY1BPHmbqa4q6vvgTZ3ALa/6t9JrJw5aY1+QnRt+FFPZBtzJbvZww7eo588Ncmc6uaY4N5CdguSJ5Fwn1GueioM0EtRHGPkI2pYK+58pGWWEcHwP8p7sihtemUk9TbtueA3p72Oo3A4SMmZhX9TQL8KDpQnmiszt0wKV3TS+/gRZ1mmKL6l4l3a4gPvFcAm8GUFfN0rDkel77q8YsYRweD78+wQAAP//
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.CustomerDisputes
{
    /// <summary>
    /// A request to adjudicate a dispute in either the buyer's or seller's favor.
    /// </summary>
    [DataContract]
    public class AdjudicateRequest
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public AdjudicateRequest() {}

        /// <summary>
        /// The outcome of the adjudication.
        /// </summary>
        [DataMember(Name="adjudication_outcome", EmitDefaultValue = false)]
        public string AdjudicationOutcome;
    }
}

