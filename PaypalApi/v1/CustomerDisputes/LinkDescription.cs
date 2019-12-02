// This class was generated on Sun, 08 Apr 2018 17:47:21 UTC by version 0.1.0-dev+291f3f of Braintree SDK Generator
// LinkDescription.cs
// @version 0.1.0-dev+291f3f
// @type object
// @data H4sIAAAAAAAC/6yUQU/bQBCF7/0VI9MDkRybQ2lpbki0AhUVFEwvEZIn9jheZb1rZsakVsV/r9aGUIgqWrXHfZnJvG/eyD+irG8pmkXnxq3hhKRg06rxLoqjb8gGl5a+YhMqojj6Qv3T49fiWZTVBEy3HYlOmSwqlbA4Pc4+XRxfgTVufbOflr6QFFuT+jviO0ObdK9GJY8yDRUyAeMqzw2G/0yiODpmxn40eBBHc8Lywtk+mlVohYJw2xmmcitcsm+J1ZBEs8UWTZSNW+0C1UzVM6gHYRes8E1rSQkUeUUK1/PzBDIPDa4JdCAfiQu0Ng7lS+PGXxrS2pewMVqD1kZgcT0/g4yaNnRMR1yl8ma/Vm1llqbqvZXEkFaJ51Vaa2NTror3hx8OJsMmE/jsGVqmacu+IBHjVjEYV9iuHIfmb/MY8v08BnQl5JMcihoZCyWWBAJRHlhzMDLUr6mHx6wCq3fkFLRGHQYK4HYFI+PIgyDdUkLoTgf5rzJT7l5E5jpr7+NXcxtX+iy5rbSb3WmWXT6mwA/DQX+T3b8e3R8SMNln9sf3rvdF2P5o0HgH2rf06p0cfjw62hMqQsf03SSGTW2KGoT4jgRQAB2cnUDlGXBId8y5c9gszarzndgeysHKksbzEGrQqSkEfDUI4xVeEcFi+G7MHxzKk7vNZpMYdDh4QxGzcg05lTT0Th+RXj6T7wFj8j/u6Ob+zU8AAAD//w==
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.CustomerDisputes
{
    /// <summary>
    /// The request-related [HATEOAS link](/docs/api/overview/#hateoas-links) information.
    /// </summary>
    [DataContract]
    public class LinkDescription
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public LinkDescription() {}

        /// <summary>
        /// REQUIRED
        /// The complete target URL. To make the related call, combine the method with this [URI Template-formatted](https://tools.ietf.org/html/rfc6570) link. For pre-processing, include the `$`, `(`, and `)` characters. The `href` is the key HATEOAS component that links a completed call with a subsequent call.
        /// </summary>
        [DataMember(Name="href", EmitDefaultValue = false)]
        public string Href;

        /// <summary>
        /// The HTTP method required to make the related call.
        /// </summary>
        [DataMember(Name="method", EmitDefaultValue = false)]
        public string Method;

        /// <summary>
        /// REQUIRED
        /// The [link relation type](https://tools.ietf.org/html/rfc5988#section-4), which serves as an ID for a link that unambiguously describes the semantics of the link. See [Link Relations](https://www.iana.org/assignments/link-relations/link-relations.xhtml).
        /// </summary>
        [DataMember(Name="rel", EmitDefaultValue = false)]
        public string Rel;
    }
}

