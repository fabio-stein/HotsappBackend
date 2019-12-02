// This class was generated on Tue, 30 Jan 2018 11:02:41 PST by version 0.1.0-dev+6beb51-dirty of Braintree SDK Generator
// NameAndValuePair.cs
// @version 0.1.0-dev+6beb51-dirty
// @type object
// @data H4sIAAAAAAAC/6yQwUoDMRCG7z7FMOe0eM5N8CZokVIQ8TA2Uw1mkziZCEH67pJdrdQVRfCYP5P83zevuG6Z0eIlDQwUHWwoVIYVeUGDGxJP94H7LVpEgxfcPg/nXLbis/oU0eL6kSHSwAuKbvEyfpPJCzhW8qEs0eCZCLWp8dTgNZO7iqGh3VEo3IPn6oXdIVhJyizquaC9PbAWFR8f5ni9/AjxPZhjPnGDXRLQ75GXcJMqDLUobJMIB1IeZ6eRvqb+CrRl/puXSv2iFWsIe/Or29h8JPeRzO0myp/8/gH5bn/yBgAA//8=
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.Orders
{
    /// <summary>
    /// The name-and-value pair details.
    /// </summary>
    [DataContract]
    public class NameAndValuePair
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public NameAndValuePair() {}

        /// <summary>
        /// REQUIRED
        /// The key for the name-and-value pair. You must correlate the value and name types.
        /// </summary>
        [DataMember(Name="name", EmitDefaultValue = false)]
        public string Name;

        /// <summary>
        /// REQUIRED
        /// The value for the name-and-value pair.
        /// </summary>
        [DataMember(Name="value", EmitDefaultValue = false)]
        public string Value;
    }
}

