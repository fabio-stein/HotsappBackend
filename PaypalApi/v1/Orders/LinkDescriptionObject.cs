// This class was generated on Tue, 30 Jan 2018 11:02:41 PST by version 0.1.0-dev+6beb51-dirty of Braintree SDK Generator
// LinkDescriptionObject.cs
// @version 0.1.0-dev+6beb51-dirty
// @type object
// @data H4sIAAAAAAAC/6yUQU8bMRCF7/0VI9MDkTa7HEpLc4tEJVBRQSH0EiHtxDuJ3XjtxTNLGlX898q7JDSgilbt0S8z9vvmTfaHmm4aUiN1Yf0KTol1tI3Y4OFy/o20qEx9xWhx7ugL1qlQZeozbZ4Ov/SokRpDpLuWWIaRHApVMDsbTz9djq/BWb+6PSyqoLnAxhbhnuK9pXVxYFAoIA9TBQ9ylalxjLjpnR1lakJYXXq3UaMFOqYk3LU2UrUTrmJoKIolVqPZjoklWr98iWAiLfYwHoV9lKkh0KFuHAmBYFySwM3kIodpgBpXBGIItpQanctS+dz6/peaxIQK1lYMiLHc8WdgPcxuJucgVDepFRYh1ii3h0ak4VFRSAiOc0uyyENcFkZqV8SFfn/84WiQw7nXrq36F8q3ZQblYZkB+grKQQnaYEQtFDldC02kYRODJmbrlzkkojKxlmC5u2JFG9jmk1iDJy8gBqWzy4C7EfSMPQ8Ct3NOQXvp5L/KTGL7LDLfOveQvZpbP9K95HbSy+zOptOrbQrx8XGQ32T3r0v3hwSR3J79/vzS+yxNvzeY/ouyaejVDTn+eHJywKRTx/DdIIO1sdoAU7wnBmRAD+en3WJgl26fc+uxnttlG1p2G6g6K3Pq14OpRi9WM4RFJ6S2HK6JYNZ9MCaPDvnJ3Xq9zi167Lwhs136mrxwkXqHW6Tnx/x7whj8jz26fXjzEwAA//8=
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.Orders
{
    /// <summary>
    /// A request-related [HATEOAS link](/docs/api/overview/#hateoas-links).
    /// </summary>
    [DataContract]
    public class LinkDescriptionObject
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public LinkDescriptionObject() {}

        /// <summary>
        /// REQUIRED
        /// The complete target URL. To make the related call, combine the method with this link, in [URI template format](https://tools.ietf.org/html/rfc6570). Include the `$`, `(`, and `)` characters for pre-processing. The `href` is the key HATEOAS component that links a completed call with a subsequent call.
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

