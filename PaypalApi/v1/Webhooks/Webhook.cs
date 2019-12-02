// This class was generated on Tue, 30 Jan 2018 11:02:44 PST by version 0.1.0-dev+6beb51-dirty of Braintree SDK Generator
// Webhook.cs
// @version 0.1.0-dev+6beb51-dirty
// @type object
// @data H4sIAAAAAAAC/7xWX2/bNhB/36c4qHuIC1nuw9p1eQvQAi0WLIHjbA9GMJ2ps8WZIhXyFE8Y9t2HoyTXipZ2xYo82TzyxN8f3pF/Jau2puQ8+Y02pXP7JE1+Ra9xY+gXrGQiSZOfqf00eEdBeV2zdjY5T64sgfNQOU9w6D4BbvMHKQ5ZkiYX3mPb7fAqTZaExZU1bXK+RRNIAveN9lQcA9fe1eRZU0jO10ds7x/IMsTBBB7J3O/c1hRGSMfxMegLCyjAwG2hqYEdMFmIGUFGh1KrUv6EZiN5G4LWNX4gmMHqdIodoDFDurbKNIW2O7B0GIIYgEtqAT0BFgUVKYSalN62EgcMTF6HPZzlL/MZHLQpQKEv4kaeaoOK4sL8hFXecRh/KX+ZP0o3OnDEF5q6dp6p6EGlsO7mHlAbEbSP3529OIbmMTSX/TJZPHvk6ZvPesq+edLSwF7b3dTO4sSoUzvH8Ud2QtlUaOeesIhEThaLxSJMJPJ/T6RtjPk7/SIHKz+n4PvAGPWqJGisvm96cCCrnglhYORmXC/H0BRlNyVK4rHGv52ed/8Bry5GWONwivPju8HtoVC/rZqX2u7hZFu4io1uCtdoux+rO0Se7kOe7hsKPPdkUIp0/eFi9f7q4gZi6t3ZonAqLLDWixKZHIZ5nFh8XUl+ts0+pX7paTti0wemDihX1YaYgNHviOF2eRmbUIX7roEN7BQak8ryjbbdTEVcugIOmkvgUofIOwVtYX27/AhMVS2psHW+Qr47K5nrcL5YsHMmZJp4mzm/W5RcmYXfqjevf3w1y+Bj7MZ98/w+TyE/y1NAW0A+y0GV6FEx+SCfhdrTvPZOUQja7jIQRrlwzUHHBg57amHwRbg6K4XLJXJnE+BRgo5jxwfjbSEGW47hZyrzTtORdcfQ1LwPq9X1YIPvd5fL7V/NeyYGnswIfjeeYl+L/B1AKUy5sL54RF7/9Pbti0BKMuY/zNL+2g/kHyhe2WilpcjJwGhvZ3RjsdroXeOaYNr+qtlQdz4CVWhZqzA0IknL4IYI1rF7LHuE4RO6w+GQabQYsWEIemcruYcXkjsfKD0eZn8KjdmzdeDGj43oxlMjbpeXnUw6gHJ2q3dNf4zk/UAWnIXcOIWmdIHzqK62ylXyYsqvr25WOVjHeqtVZ2VFIeAu6ossn2TU/VsNtO26gXb2q4SYPkx6Hb77BwAA//8=
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.Webhooks
{
    /// <summary>
    /// One or more webhook objects.
    /// </summary>
    [DataContract]
    public class Webhook
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public Webhook() {}

        /// <summary>
        /// REQUIRED
        /// An array of up to ten events to which to subscribe your webhook. To subscribe to all events including new events as they are added, specify the asterisk (`*`) wild card. To replace the `event_types` array, specify the `*` wild card. To list all supported events, [list available events](#available-event-type.list).
        /// </summary>
        [DataMember(Name="event_types", EmitDefaultValue = false)]
        public List<EventType> EventTypes;

        /// <summary>
        /// The ID of the webhook.
        /// </summary>
        [DataMember(Name="id", EmitDefaultValue = false)]
        public string Id;

        /// <summary>
        /// An array of request-related [HATEOAS links](/docs/api/hateoas-links/).
        /// </summary>
        [DataMember(Name="links", EmitDefaultValue = false)]
        public List<LinkDescriptionObject> Links;

        /// <summary>
        /// REQUIRED
        /// The URL that is configured to listen on `localhost` for incoming `POST` notification messages that contain event information.
        /// </summary>
        [DataMember(Name="url", EmitDefaultValue = false)]
        public string Url;
    }
}

