// This class was generated on Tue, 30 Jan 2018 11:02:44 PST by version 0.1.0-dev+6beb51-dirty of Braintree SDK Generator
// EventList.cs
// @version 0.1.0-dev+6beb51-dirty
// @type object
// @data H4sIAAAAAAAC/+xWT2/bNhS/71M8aDvEgCwXyJK1vhlohwYLmiJ1dzGC6Fl6FjlLpEo+2XWHfveBoqREVowMS+btkKMe/+j3h/w9/hnMdyUF04A2pBhyaTkIg9/RSFzm9AELNxaEwW+0u/t4SzYxsmSpVTANLqVl0CvY0lJovbZQb2WjIAxmxuDO/+BVGFwTplcq3wXTFeaWXOFLJQ2lXeGj0SUZlmSD6aKDJhVTRmaIK9GV4h64ttJHOBcEqiqWZBxOyVRYkAoIEwEGVUaubMhWOdsIPmgmYIEMLMiVS60sQSEzwSBwQ7CiLZlmHxaomolfKrJMKcQlZnRr5TeKYYN5RU+VQlV5/j3s9Hjn9B2q4WXvydGV+nrMFKCD87hr5//cNctGquwB0wwh0y3LgvrW9epDA1NkAlQpuBmwFeRlb/B7+KA0y5VM0K2DLVrwu6ah83txoZiMIt7ba6VNgXxzIphLO51MWOvcRpJ4FWmTTQQX+cSsktPT0zc/Wkrc3uOz6Hz0zLYeEqxmdstu0sDbtjyUy+vhj7GRWUaG0kcEOyqfDRnr0A4p3Y0cYtXMcJ7eZ/QfcJFpj0D9OUR98dbdtKOKfynVGu4hgavlH5Q8kBq5VOt+aLSVw5nRRN3YUO4uFyzez+bvrmafoF56czJJdWInWMqJQCaNdlwPjP79cBGGVj0yTWHoSaKLMieX9GgyYvh8fRnBXEOBa2ry3JNLMM9DN30plR8piIVOYStZAAtpa9o+YT5fXwBTUbqlfzdXzs9+eTWK4EIleZX6P8Q/xSHEJ3FYh1Q8iiERaDBhMtZtC6WhcWl0QtZKlUXgGMWOawzS1lusaQetLY6rVl0e1GYAdhJ4jp4Pgq2W1vmruC4f6SJ5TXvWdaWhee/n84+tDab5O/AB847EwFDeg++/h9gXTn4P0N1LF+CPHpGzN69fd63n51EIWyETAZbMhiygBVQuZNzJwNpeb3SlsFjKrNKVzXeQ1lCW5M+HpQIVy8S20eSWRfCJCBZ1eFw3CO0duu12G0lUWGNDa2WmCvdomLi145bS/mf01dF4nm55c88IfSDRDFldmYT23OiKQ0vawf9lu2zBDV8A+yMPPHqxoNbfjmR7N1gf7J6e7ZEI2qoo0Ox61O5qe10ImpHmNPve5s49d6+DnkfwqzZAX9ElXQjxDErcuTMLWLHQRn4bPBWj+LkP6rP34pc2+tJGX9roSxt9QjrdfP/hLwAAAP//
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.Webhooks
{
    /// <summary>
    /// List of webhooks events.
    /// </summary>
    [DataContract]
    public class EventList<T>
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public EventList() {}

        /// <summary>
        /// The number of items in each range of results. Note that the response might have fewer items than the requested `page_size` value.
        /// </summary>
        [DataMember(Name="count", EmitDefaultValue = false)]
        public int? Count;

        /// <summary>
        /// An array of webhooks events.
        /// </summary>
        [DataMember(Name="events", EmitDefaultValue = false)]
        public List<Event<T>> Events;

        /// <summary>
        /// </summary>
        [DataMember(Name="links", EmitDefaultValue = false)]
        public List<LinkDescriptionObject> Links;
    }
}

