// This class was generated on Tue, 30 Jan 2018 11:02:44 PST by version 0.1.0-dev+6beb51-dirty of Braintree SDK Generator
// SimulateEvent.cs
// @version 0.1.0-dev+6beb51-dirty
// @type object
// @data H4sIAAAAAAAC/6yRQUvDQBCF7/6KYc8heO5NqEJRVNrqRaRsshMzdLOTzu5WgvS/yza1Nuagosd5eZN53743texaVBO1oCZaHRAut+iCytSjFtKFxVvdpO8qU9fYfQ5T9KVQG4jdybYHDQ2Xa3jFomZeA6a/5SpTFyK662+dZ2qO2tw526lJpa3HJGwiCZqjcC/cogRCryZPx5Q+CLmXcbr9mVVIptOcA3mYeFljHw6cbjCHRYslVR2wQ+AKQo3gY5E2CjS90+dwxQKoyxoENxF9yKAV3pJBYGf75d8TB4lfgF20dpd9Sx3FDnD7ecz5ML+BimUPdSzGmZbJhRxmFXBDIaDJBo7ZFMjvQVPMv3b4Q6TD8RWZAdlAHgPOph+dHYxjqvQG/43zvDt7BwAA//8=
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.Webhooks
{
    /// <summary>
    /// Simulates a mock webhook event.
    /// </summary>
    [DataContract]
    public class SimulateEvent
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public SimulateEvent() {}

        /// <summary>
        /// REQUIRED
        /// The event name. Specify one of the subscribed events. For each request, provide only one event.
        /// </summary>
        [DataMember(Name="event_type", EmitDefaultValue = false)]
        public string EventType;

        /// <summary>
        /// The URL for the webhook endpoint. If omitted, the webhook ID is required.
        /// </summary>
        [DataMember(Name="url", EmitDefaultValue = false)]
        public string Url;

        /// <summary>
        /// The ID of the webhook. If omitted, the URL is required.
        /// </summary>
        [DataMember(Name="webhook_id", EmitDefaultValue = false)]
        public string WebhookId;
    }
}

