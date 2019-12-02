// This class was generated on Sun, 08 Apr 2018 17:47:21 UTC by version 0.1.0-dev+291f3f of Braintree SDK Generator
// Buyer.cs
// @version 0.1.0-dev+291f3f
// @type object
// @data H4sIAAAAAAAC/6ySwYrUQBCG7z5F0RcvIbusjoc5qYgIwioyelEPNd1/ksZOd7a6sjNR9t0lyezsxEEU9BJSH91U1d/fD7MZOpi1edkPEFOYTyyetwHX3I7YFOYthofiFbIV36lP0azNpgE5KPuQqUpC2oBsnzW1ENo1iao+ujzhjocWUUt6nYSw57YLKBYXHmeqvGSlyC0KCnz8Rcs+EDsnyLkgjo5yohRLU5gXIjzMO1wW5gPYvYthMOuKQ8YIbnovcEfwXlIHUY9s1p+P22cVH+vz9afOiwzuyXkQPiok8kg4+O9wy7nLL/3l5RO7Dcl+u+mTYqrnr80qKdYzuU6K9YwvTjl97EgTPXtKtmFhq5BMLCAOIe3gaIsqjWV0dLVa/e4UV4r5peYeNrnDKM8PTR8IZV/Hkt6kHW4h83PViBAOYSC2Fp3CUct73/YtBcRam8kEjsvtyWe6Wp2OXtJm0kLH1OgW4iuP0RXW8XYfp5Dc305J2Pus9ylf/BrzP5oS+xDuij/qMuq6sOUAzmU5kX48U/6P+b7ePfoJAAD//w==
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.CustomerDisputes
{
    /// <summary>
    /// The details for the customer who funds the payment. For example, the customer's first name, last name, email address, and so on.
    /// </summary>
    [DataContract]
    public class Buyer
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public Buyer() {}

        /// <summary>
        /// The internationalized email address.<blockquote><strong>Note:</strong> Up to 64 characters are allowed before and 255 characters are allowed after the <code>@</code> sign. However, the generally accepted maximum length for an email address is 254 characters. The pattern verifies that an unquoted <code>@</code> sign exists.</blockquote>
        /// </summary>
        [DataMember(Name="email", EmitDefaultValue = false)]
        public string Email;

        /// <summary>
        /// The customer's name.
        /// </summary>
        [DataMember(Name="name", EmitDefaultValue = false)]
        public string Name;
    }
}

