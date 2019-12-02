// This class was generated on Tue, 30 Jan 2018 11:02:44 PST by version 0.1.0-dev+6beb51-dirty of Braintree SDK Generator
// Event.cs
// @version 0.1.0-dev+6beb51-dirty
// @type object
// @data H4sIAAAAAAAC/8xWTW/bRhC991cM2B5sgKICuHYT3QQkRYwGdeAovQhGOCJH4lbkLjMztMwW/e/FkiJtilVdoIba487sx3vzZt/u78GiLimYBe/uyWoQBr8gG1zl9DMWPhyEwU9UPw7ekiRsSjXOBrNgDjtaZc5tgfxysE7N2iTo01EQBnNmrNsDXoXBLWF6Y/M6mK0xF/KBr5VhSvvAR3YlsRqSYLbsoYmysZsxtoQJlb6oKWgAcxgfIl5kBCkqAdoU/AzYZWRBM/obKrBDgXbXNARjYXltldiSHuy1dlyg3p1lqqXMplN1LpfIkK4jx5tppkU+5XVycXHx5luhxO89uYyuzv9trWyV53+EzxasYfZF/aSn9RqEx+Vq66EZKiibzYaY0mcKdlI+98Ti0Y4pPWaOsdrP8Jo+ZfQfcDHpgEAzHKO+fgtufdrifzB2C0+QwM3qV0r+wipyY7cyINFFDkzDAnp4ngnT14pEJ0y5v1ywfD9fvLuZf4Jm6d3ZNHWJTLE00wyVHMqkSRxemKuXN5eMaT0gsw+MNUlcUeakBIq8IYXPtx8iWDgocEuNVB25BPM89NNXxraZgjRzKeyMZqCZkYZ26zCfb69BqSj90n/qK1eXP7w6j+DaJnmVtifE38UhxGdx2JhUfB5DkiFjosTit4WSaVKyS0jE2E0EnlHsucZgpNliSzV0sniuzvZ+0IgB2Jeg5djyQZBqJV5fq034RBeprelAuj40Fu/9YvGxk4H3p4MeEe9EDJjyAfx2PMa+9OVvAfp76Q382Ra5fPP6df/0fH8ewi4zSQZCfE8CKIDWm4zvDGzkbYWuLBYrs6lcJXkNaQNlRW1/CBVo1STSWZNfFsEnIlg25nG7RyiP6Ha7XWTQYoMNRczGFmRVpn7tpKN0OIwePI2XeS3vngjhjjgak7iKEzpQow+OJemS/8vnsgM3/gEcZsbELBbU6duT7O6GuqOvZ8v2RASlKgrkekDtMXb4dd1n9t3cvm2+77X/HQw0gh8dAz2gd7oQ4jmUWPueBaw0c2x+G30Vo/hlGvWbPwEAAP//
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.Webhooks
{
    /// <summary>
    /// A webhook event notification.
    /// </summary>
    [DataContract]
    public class Event<T>
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public Event() {}

        /// <summary>
        /// The date and time when the webhook event notification was created, in [Internet date and time format](https://tools.ietf.org/html/rfc3339#section-5.6).
        /// </summary>
        [DataMember(Name="create_time", EmitDefaultValue = false)]
        public string CreateTime;

        /// <summary>
        /// The event that triggered the webhook event notification.
        /// </summary>
        [DataMember(Name="event_type", EmitDefaultValue = false)]
        public string EventType;

        /// <summary>
        /// The event version in the webhook notification.
        /// </summary>
        [DataMember(Name="event_version", EmitDefaultValue = false)]
        public string EventVersion;

        /// <summary>
        /// The ID of the webhook event notification.
        /// </summary>
        [DataMember(Name="id", EmitDefaultValue = false)]
        public string Id;

        /// <summary>
        /// An array of request-related [HATEOAS links](/docs/api/hateoas-links).
        /// </summary>
        [DataMember(Name="links", EmitDefaultValue = false)]
        public List<LinkDescriptionObject> Links;

        /// <summary>
        /// The resource that triggered the webhook event notification.
        /// </summary>
        [DataMember(Name="resource", EmitDefaultValue = false)]
        public T Resource;

        /// <summary>
        /// The name of the resource related to the webhook notification event.
        /// </summary>
        [DataMember(Name="resource_type", EmitDefaultValue = false)]
        public string ResourceType;

        /// <summary>
        /// A summary description for the event notification. For example, `A payment authorization was created.`
        /// </summary>
        [DataMember(Name="summary", EmitDefaultValue = false)]
        public string Summary;
    }
}

