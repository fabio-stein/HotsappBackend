// This class was generated on Sun, 08 Apr 2018 17:47:21 UTC by version 0.1.0-dev+291f3f of Braintree SDK Generator
// Merchant.cs
// @version 0.1.0-dev+291f3f
// @type object
// @data H4sIAAAAAAAC/7yT0YvTQBDG3/0rhn0OueO0PvRJ4RBFPIucvqjIdHfSLG52crOTtlHuf5dN2mtjEAXFl5b9TXbmmy9fvpvbviWzNG9IbI1RTWE+oHhcB7rBJldMYV5TfzpcU7LiW/UczdLc1gSOFH1IULGA1gTNoRfsagYhS35LaahUXXQJMDqoulD5EEbM4khKeMECtMemDVScmry6LsByVLQK1KAPgM4JpVQMjRIDx9IU5rkI9uM2l4V5R+jextCbZYUhUQZ3nRdyD2Al3JKop2SWHx98SCo+buYuDJMnVhzJ3A8flSRiJhj8N3JT3eWn7vLysV0Htl/vOlYazuOvTSocNyO5YaXliC/OObxvQRmePgFbo6BVkgQoBBgC78jBmirOx+jgarH41VNYKY0vbJxh2R2kPDsMPRFIfhNLeMk72pIUw60NRRIMoQe0llolBw3ufdM1EChutB4CgXG6PfgEV4tz6SVk01rU7BpsSXzlh7yg5ttdHExyf6oSaO+THl2++Nnmv0xK7EK4L34bl2N6v3g3Cc2Uz6Ozwn6FIRvK3ZD92UdV/p8FYv47V34Ac8m5AFz9e5Gf7x/9AAAA//8=
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.CustomerDisputes
{
    /// <summary>
    /// The details for the merchant who receives the funds and fulfills the order. For example, merchant ID, contact email address, and so on.
    /// </summary>
    [DataContract]
    public class Merchant
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public Merchant() {}

        /// <summary>
        /// The internationalized email address.<blockquote><strong>Note:</strong> Up to 64 characters are allowed before and 255 characters are allowed after the <code>@</code> sign. However, the generally accepted maximum length for an email address is 254 characters. The pattern verifies that an unquoted <code>@</code> sign exists.</blockquote>
        /// </summary>
        [DataMember(Name="email", EmitDefaultValue = false)]
        public string Email;

        /// <summary>
        /// The PayPal account ID for the merchant.
        /// </summary>
        [DataMember(Name="merchant_id", EmitDefaultValue = false)]
        public string MerchantId;

        /// <summary>
        /// The name of the merchant.
        /// </summary>
        [DataMember(Name="name", EmitDefaultValue = false)]
        public string Name;
    }
}

