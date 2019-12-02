// This class was generated on Tue, 30 Jan 2018 11:02:44 PST by version 0.1.0-dev+6beb51-dirty of Braintree SDK Generator
// EventType.cs
// @version 0.1.0-dev+6beb51-dirty
// @type object
// @data H4sIAAAAAAAC/6zQzU7DMAwH8DtPYfkcEOfeJsEJCRCauCAOHvVoROZ0jgOK0N4dZZ1Kyw6Ij1OVf1znZ7/jsvSMDV6+shjsDw7vST2tAl/Tpt6hwysun4cLTk/qe/NRsMGFAO9/ttLzGTpcqFIZ2p47vGNqbyQUbNYUEtdgm71yOwa3GntW85yweRhBydTL8zGmnTw+dc3zL0To8obkVJna2gomxRDXYB0PM/yVLzmEnft2BqmfKf4QzNXLjiGL3+YDDmrVj4Sm+XfAZGQ5zYhjdIwcruoiCd541cX48o/rfNydfAAAAP//
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.Webhooks
{
    /// <summary>
    /// An event type.
    /// </summary>
    [DataContract]
    public class EventType
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public EventType() {}

        /// <summary>
        /// A human-readable description of the event.
        /// </summary>
        [DataMember(Name="description", EmitDefaultValue = false)]
        public string Description;

        /// <summary>
        /// REQUIRED
        /// The unique event name.
        /// </summary>
        [DataMember(Name="name", EmitDefaultValue = false)]
        public string Name;

        /// <summary>
        /// The status of a webhook event.
        /// </summary>
        [DataMember(Name="status", EmitDefaultValue = false)]
        public string Status;
    }
}

