// This class was generated on Mon, 09 Apr 2018 18:07:49 UTC by version 0.1.0-dev+291f3f of Braintree SDK Generator
// RedirectUrls.cs
// @version 0.1.0-dev+291f3f
// @type object
// @data H4sIAAAAAAAC/8SRwUr0MBSF9/9TXO6y9B9cdzfgTtFhGN2IyJ321AYySb1JlCDz7hKGVsssXCi4zEk4nO/LO+/yCG5Y0RlFG5+S2sA134sa2VvcyKFcc81XyJ+HS4RWzRiNd9zwmgIi+Z6mFrrbXgeKg0TKPtGo/tV0oN4rbSRvxP7fS0BHo+QDXAwrrnmtKvm05qLmLaS7dTZz04sNKMFLMopuDjbqR2g0CNw8zBwhqnHP5wCtuBa20C1QFvESajegYNDbAAXFAWUtlEyYMdGR9BFKA8grhQF0KgzT+0K3oqqa1n9RQNK2Prk4S6iqn2pwydpj/a0LRUzqzlws4t9wIWP5ePyljMfjvw8AAAD//w==
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.Payments
{
    /// <summary>
    /// A set of redirect URLs that you provide for PayPal-based payments.
    /// </summary>
    [DataContract]
    public class RedirectUrls
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public RedirectUrls() {}

        /// <summary>
        /// The URL where the payer is redirected after he or she cancels the payment. **Required for PayPal account payments**.
        /// </summary>
        [DataMember(Name="cancel_url", EmitDefaultValue = false)]
        public string CancelUrl;

        /// <summary>
        /// The URL where the payer is redirected after he or she approves the payment. **Required for PayPal account payments**.
        /// </summary>
        [DataMember(Name="return_url", EmitDefaultValue = false)]
        public string ReturnUrl;
    }
}

