// This class was generated on Tue, 30 Jan 2018 11:02:44 PST by version 0.1.0-dev+6beb51-dirty of Braintree SDK Generator
// EventResend.cs
// @version 0.1.0-dev+6beb51-dirty
// @type object
// @data H4sIAAAAAAAC/5TPwUrEMBAG4LtPMcw5iCcPvS3UwyKoLOJFRKbtVAfjpM6kSpB9d4krleppj/mTzHz/J96WibHBi3fWDDt21gED3pEJdZGv6LXeYsBLLr+Hlr03mbIkxQYPvxwIPrh7TukF+Huapiyj9FSfBegKbNtTDLgxo3JYexZwxzRcayzYjBSda/A2i/GwBDeWJrYs7NjcL2DPJvr0n/pDeJTBV+p1vi6wUaCKgjQuFajv06wZtq3/QZ8fi9Y5xv3D/uQLAAD//w==
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.Webhooks
{
    /// <summary>
    /// Resends a webhook event notification, by ID.
    /// </summary>
    [DataContract]
    public class EventResend
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public EventResend() {}

        /// <summary>
        /// An array of webhook account IDs.
        /// </summary>
        [DataMember(Name="webhook_ids", EmitDefaultValue = false)]
        public List<string> WebhookIds;
    }
}

