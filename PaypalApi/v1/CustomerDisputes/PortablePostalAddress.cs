// This class was generated on Sun, 08 Apr 2018 17:47:21 UTC by version 0.1.0-dev+291f3f of Braintree SDK Generator
// PortablePostalAddress.cs
// @version 0.1.0-dev+291f3f
// @type object
// @data H4sIAAAAAAAC/8xYTXPbSA69769AaS9JFUXF9szslm+Os5OZyeSj4iR78KYkkIRElJvdDLopRdna/76FJimJlmQnMynX3KQG+gMPD+jX/O/o3bqm0fmodhIwMzStnQ9oplgUQt6PktEHFFbLK6zudnxB685nlIyekc+F68DOjs5H70qCfiKwDSQW1YQG2mWgWyaFl1h7CA6uL9qRD2i4iM4vKWCBAT8+KkOo/flksuBQNlmau2qycG5hiE/+aSeGs241tnUTJiu+4cnR1R4D2gJ+effyd/gxPYHriya4ORvDdgFzJxXkzgZxxp9DKAmwCS53VW0oEGAIwlkTaHuk1WqVrs5SJ4vJu7eTMlTmx5OJp3ysa/lUB/6O2y3i8LjfYhxKGu/uMN7s8DgdJaMLEVy3CXuSjN4SFq+tWY/O52g86cCnhoWKzcAbcTVJYPKj8+tNqjso4BkFZHMgxR1602LjsE3tvm0/09bZ8SbbWBTcpbqbC91cCCUGQCHwrqLAFXmwRAUVCjxEDBhtTgkI+5sEnIALJQn4nCwKOw+rkoRgzpbGC0G2mz3YKrIx01DxogyQUbd6Cq9c2NJxxaHUzSpnIZQsBdQoYR1p4Wqy3jWSUwpvqWhsgTb0M+LGZAqfws9OgD6jJi2BWY9Rv0XaDxi2ND2ZAXtofIPGrAF164zbcgA3387uUEp9EKIwtU2VkczisWb9GFY0HAnrmmbfjyo+CNvFPkOyhk3BdhFPMODHbcuQHRegwwUYl8eAOw4I1UKebPCxxmqhij2l8H4DUr9snK9EaOGAyBNjKO/h6x19myXsMzucdytj/2mePDnLc1dQ/EWXgkuy8ItrfDuST7bGP4uubYz5X3IvxAUZXpKsp55kyfkQ5QPG/TLsnaBzSuGN8wHcfM45QeY+J5DhokMkVle9Y1fAHijUHTYPohyO7wfY2tuTwm+NDzB7Jo2sZ8C2+wm/o/3zBfGNcURAD0bSW47H0tLzQc+rPePQabvxo2dVu5ZcvBb763vYCa+i5yyBWcxDArOnrjG0RCn0z6VrRK3awbwDZx8q8Cab9o1iGPnQsB/6nMWHsZOCBMgGDmvIyLgVYNfZNo3KyabLHWxyvsnGBxqdZ7swtF1Gu5hea9/Q5lK4RKvXHcLcYEjABye0TmBunJMExLkqljvqRVeRDd8F9o9fAfzwIjwoLDamI+CDOtxNu76jtTzdpdctep784wx22wT0UUYBoupQkyytFtjqkfhXJQnkJeU3Klq1+aiKUwmiB5s3ZqtpH4bUAwBPj2N7uoft67oVaCnE6qbc2eIrYPYNB0q2LNrg/tDlPAjv7HjkZ/dE3qq/A4EnwPONePxXG79KzNw0xaYdtpo9AqHseSr4hU0CBUtXtoE+B/BNXgJ6mFn9Fxz8G02FsQtqx0BbVCg3eoH9agtG++AkqthOUQj3ynNg2C/OkhclaXnSkkzsbgUv2WvgXf9qtJQSWJWcl0MJXItbchT6PqByygn8evV6fHby00/jU12sXytSsMIW4u7p2Ouc29V9edFqY+sCzC7R8NyJZZyl8AFNQwlk6+2p2J+3Sq8xrcxr/xlu/71/kcJF671OO0nY2255XqlnjONux0u0WKA69+Hf7f8b1mhbd5pTHhq5Z8LVisMXEuWUTrtBG5w9PGXSR/3gLDs9xrLTA4+HnMM6geBWNlJkycbgglK4qtAYEr1nrT6gNotEMk5PZg9fPWfH4jo7EJdWi4oFE+PzTdZIloAlXpSZk9K5IsZbsG6ch3sDPu05fh+t2yaVwlW3ZYYs4uJmu7vfzbPYqOIamyBunXar0wfvcvaxNtGscO0Bl8gmvsizJqgSOrIe5L26aR83CgVo8H81av9wjAI/HP5qMkj3CuUbk342U/eZStgetq+lQft5LjZT7ySo7tT3bqtbY6emQrv484bEemr1UIV2DT8L2byEQCIcnDD5ZHPFdbbnDaPFuynUqrv+Iw4VEKPTyDHwktpLRW9cuCzZ/jUy3V0dU0VqkOlbhv1MX4eVG+clCuaB4k0H8aY7iah/fDQpXO4nbAMtJFbKpBUREyEfJt3yY/X1k8ddkgp9jcyZ2sdF56OEEFrwpu1nxuU3nxoXaBc4H8TZRTvyygXquDLZHY8CqV82kkNv4OdCGOCpcBS+7Pe+pDx/uvf9ZHMn3/Z9/+KA75Z8Gldw9bgVGIWrdEvtKT4eJcLQHVAfVBQnzC5PZ/vHjiSClRNTrLgbU/mGEvtPY7sPsoYKqIVzgkeX7988hopCqcWZob2BPFZofBmI836cta/CIGg9RsXne57ehv1bCBqk+WP87L7P79FzOH7oO31sBGrfEWsK5heuWwxVZn1qeIlGH4/wbl1zHqWc7L6fWtiVkt0bdWfl+Py0g1WuiOB6x2X7TZ1suuIbrknvGSeL9ov+m20cj7/TA/Zv/wcAAP//
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.CustomerDisputes
{
    /// <summary>
    /// The portable international postal address. Maps to [AddressValidationMetadata](https://github.com/googlei18n/libaddressinput/wiki/AddressValidationMetadata) and HTML 5.1 [Autofilling form controls: the autocomplete attribute](https://www.w3.org/TR/html51/sec-forms.html#autofilling-form-controls-the-autocomplete-attribute).
    /// </summary>
    [DataContract]
    public class PortablePostalAddress
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public PortablePostalAddress() {}

        /// <summary>
        /// The non-portable additional address details that are sometimes needed for compliance, risk, or other scenarios where fine-grain address information might be needed. Not portable with common third party and opensource. Redundant with core fields. For example, `address_portable.address_line_1` is usually a combination of `address_details.street_number` and `street_name` and `street_type`.
        /// </summary>
        [DataMember(Name="address_details", EmitDefaultValue = false)]
        public AddressDetails AddressDetails;

        /// <summary>
        /// The first line of the address. For example, number, street, and so on. For example, `173 Drury Lane`. Required for data entry and compliance and risk checks. Must contain the full address.
        /// </summary>
        [DataMember(Name="address_line_1", EmitDefaultValue = false)]
        public string AddressLine1;

        /// <summary>
        /// Optional. The second line of the address. For example, suite, apartment number, and so on.
        /// </summary>
        [DataMember(Name="address_line_2", EmitDefaultValue = false)]
        public string AddressLine2;

        /// <summary>
        /// Optional. The third line of the address, if needed. Examples include street complement for Brazil, direction text such as `next to Walmart`, or landmark in Indian address.
        /// </summary>
        [DataMember(Name="address_line_3", EmitDefaultValue = false)]
        public string AddressLine3;

        /// <summary>
        /// The highest level sub-division in a country, which is usually a province, state, or ISO-3166-2 subdivision. Format for postal delivery. For example, `CA` and not `California`. Value, by country, is:<ul><li>UK. A county.</li><li>US. A state.</li><li>Canada. A province.</li><li>Japan. A prefecture.</li><li>Switzerland. A kanton.</li></ul>
        /// </summary>
        [DataMember(Name="admin_area_1", EmitDefaultValue = false)]
        public string AdminArea1;

        /// <summary>
        /// A city, town, or village. Smaller than `admin_area_level_1`.
        /// </summary>
        [DataMember(Name="admin_area_2", EmitDefaultValue = false)]
        public string AdminArea2;

        /// <summary>
        /// A sub-locality, suburb, neighborhood, or district. Smaller than `admin_area_level_2`. Value is:<ul><li>Brazil. Suburb, bairro, or neighborhood.</li><li>India. Sub-locality or district. Street name information is not always available but a sub-locality or district can be a very small area.</li></ul>
        /// </summary>
        [DataMember(Name="admin_area_3", EmitDefaultValue = false)]
        public string AdminArea3;

        /// <summary>
        /// The neighborhood, ward, or district. Smaller than `admin_area_level_3` or `sub_locality`. Value is:<ul><li>The postal sorting code that is used in Guernsey and many French territories, such as French Guiana.</li><li>The fine-grained administrative levels in China.</li></ul>
        /// </summary>
        [DataMember(Name="admin_area_4", EmitDefaultValue = false)]
        public string AdminArea4;

        /// <summary>
        /// REQUIRED
        /// The [two-character ISO 3166-1 code](/docs/integration/direct/rest/country-codes/) that identifies the country or region.<blockquote><strong>Note:</strong> The country code for Great Britain is <code>GB</code> and not <code>UK</code> as used in the top-level domain names for that country. Use the `C2` country code for China worldwide for comparable uncontrolled price (CUP) method, bank card, and cross-border transactions.</blockquote>
        /// </summary>
        [DataMember(Name="country_code", EmitDefaultValue = false)]
        public string CountryCode;

        /// <summary>
        /// The postal code, which is the zip code or equivalent. Typically required for countries with a postal code or an equivalent. See [postal code](https://en.wikipedia.org/wiki/Postal_code).
        /// </summary>
        [DataMember(Name="postal_code", EmitDefaultValue = false)]
        public string PostalCode;
    }
}

