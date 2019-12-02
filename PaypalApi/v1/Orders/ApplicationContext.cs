// This class was generated on Tue, 30 Jan 2018 11:02:41 PST by version 0.1.0-dev+6beb51-dirty of Braintree SDK Generator
// ApplicationContext.cs
// @version 0.1.0-dev+6beb51-dirty
// @type object
// @data H4sIAAAAAAAC/+xXX2/bNhB/36c4eA9bANtq0y5FM+yhbdIuWJsYdtZh6AqXJk8SEYrUeFQcYdh3H46SE8tW/rRNu4ftSRB5vPvdv9+Rfw1O6xIH+wNRlkZLEbSzc+lswIswGA7eCq/FwuCxKFhoMBz8gvXVzwGS9LrkQ4P9wWmOsKYGWjWAFyV6jVYiaJs6X8Tt8WA4eOa9qBsAD4aDKQp1Yk092E+FIeSFPyvtUV0uTLwr0QeNNNh/dwmdgtc220a78MKqueWfddyd5a4Hz8CIBRoIuQjgztF7rZAg5AiLirRFIuCDoG1cnIh6IgwIKV1lA7jOaikypDG8ERe6qAowaLOQgyZ4uPsESNvM4GhRBwRhylzYqkCvJchceCEDevrcANnKmL+Ht0bJCKu0zeYMtxOnjY3tXIe6RHAptILRYQgOlKbSiHojHKQDQuo8VIQeZI7yzFVhDKeOV6KkdXa0EdJ13UMgDGzgw3NtjLbZh87pzZMu0/aa869578PXCrCTwmyEdrW0WX7vnr+YjB4/YdhZFcMpsvff5yGUtJ8kwTlDY40hHTufJXkoTLKQ5eMn3xJK1jHa3RnCMtcy1lkhFEJVcoo4Pu+OZiew9+jpaPdKvXQKr/Qvl8uxcXKcufOEgrBKeEWJJhdPJWVeJnxgbjSFcZmXO8Oo2EX8wkQLo4c/PN19DI1bV/Bb7ZXVrCHC1+SibNTJKmnMHu0MQVh1iXj06OHeXtMio12IqfV1iztRTlKibcDMR05JlPYoQ+KRQtLKjliWkp17zjZnMgJ9K0zFxaf9dupLR2Eh5NlciSA6FbC5s1EIFgRD5dQx34yEVaPzaKgU2lNDUMyvQlvAi4Ce48+6hkCVzEFQ02cpomI7QyDpPDaxJQdb/Lt3//y7xby9nMtMcoZ1pIZIAtv+juF3V0FREfvsPRoRmpZvRNilyMpMSF+LNqPpjnerlW33Gpg3OXgfmN/fATXluiwjqXtM0fNM7vjQv9/1aFai1GkNs1YWJpeytP9H9eDBI1mZ+MXmz+j1P27H5v/4ZD77+WgyOTp+1WwlV3sAU1RCBoIVJBBKeR7AqUajCFLvip5xO0XpigKtQtXGPTQjgsOvdKaDMJA5p2jcGu3Cuw7sq8PT+cvpyZv5y6PXhz1wX/FoyXEbLqFBGVDBom4vEjV6no0d3B+FZXZ4Op9MT94eHRwezJ8dHEwPZ7MeSL+2g3GFpPTuXKsrJAV6mQsbxvA8YtIE1gXgcuGg8V7W1dB7wTlKLzWBckj2uwClIAJhLw82TueC1gZGY8M52rJxe2SSVYX9G6xOVVkaLNAG4ettau/d/hx+7yiMJA++9YlT2UYr0osXlkS8CnC2JRLfM/9n+v8g0/P0nzel0MHeXe96cIApv3FgmWPI0XODlh4JbUNtsqLgCvSw1CEHAU0rUvDOZk03vnA2aFutmnR9C5zvOTARNRy7ZZ/86oUAqXHLeNFfYYlkQg0KxvXpapsXwSa9coiaCP3Es0SHLW4dwwGmojKBObMfwk2h6LrWSATO3TrFhRyF6iz47nZrp9XFf7t7dkHlj6y1NbuS2jwTWXeZo71Rbq06euWSLqRkG/LCqfoGHzrCd4zeypbq08TsoVwcY2fWLWNuUm3jMKmZQUEU8XXIvkPtKtBWB71imb7EXGOJu121RdBU6BSb1wd1myW47sxsYDTv0eapRrlbfkoZLaoQnB3Db+xLx6Y0Wp7Rx6kbbqgQdv0G0A1ff2g2yuGuub6+WW9N9RfO8ewacpjfxg5fpBRuILVPqITrtQ07Cde0ukmgAl0UqDiSpr5TCSRbBJCs8dz9jMJv/gEAAP//
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.Orders
{
    /// <summary>
    /// The application context experience information.
    /// </summary>
    [DataContract]
    public class ApplicationContext
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public ApplicationContext() {}

        /// <summary>
        /// A label that overrides the business name in the PayPal account on the PayPal pages. Maximum length is 127 single-byte alphanumeric characters.
        /// </summary>
        [DataMember(Name="brand_name", EmitDefaultValue = false)]
        public string BrandName;

        /// <summary>
        /// The type of landing page to display on the PayPal site for user checkout. To use the non-PayPal account landing page, set to `Billing`. To use the PayPal account login landing page, set to `Login`.
        /// </summary>
        [DataMember(Name="landing_page", EmitDefaultValue = false)]
        public string LandingPage;

        /// <summary>
        /// A [BCP-47 language tag](https://tools.ietf.org/html/bcp47#section-2), which is made up of the [ISO 639-2 language code](https://www.loc.gov/standards/iso639-2/php/code_list.php), the optional [ISO-15924 script tag](http://www.unicode.org/iso15924/codelists.html), and the [ISO-3166 alpha-2 country code](/docs/integration/direct/rest/country-codes/).
        /// </summary>
        [DataMember(Name="locale", EmitDefaultValue = false)]
        public string Locale;

        /// <summary>
        /// An array of name-and-value pairs that contain external data, such as user feedback, score, and so on.
        /// </summary>
        [DataMember(Name="postback_data", EmitDefaultValue = false)]
        public List<NameAndValuePair> PostbackData;

        /// <summary>
        /// Specify Shipping Preferences:<ul><li><code>NO_SHIPPING</code>  Redacts shipping address fields from the PayPal pages. Recommended value to use for digital goods.</li><li><code>GET_FROM_FILE</code>  Get the shipping address selected by the buyer on PayPal pages.</li><li><code>SET_PROVIDED_ADDRESS</code>  Use the address provided by the merchant. Buyer is not able to change the address on the PayPal pages. If merchant doesn't pass an address buyer has the option to choose the address on PayPal pages.</li></ul>.
        /// </summary>
        [DataMember(Name="shipping_preference", EmitDefaultValue = false)]
        public string ShippingPreference;

        /// <summary>
        /// An array of name-and-value pairs that contain supplementary data required by PayPal for transaction processing.
        /// </summary>
        [DataMember(Name="supplementary_data", EmitDefaultValue = false)]
        public List<NameAndValuePair> SupplementaryData;

        /// <summary>
        /// Defines whether to present the customer with a <strong>Continue</strong> or <strong>Pay Now</strong> checkout flow. To present buyers with the <strong>Pay Now</strong> checkout flow, set <code>useraction=commit</code>. Default is the <strong>Continue</strong> checkout flow.<table><thead><tr><th>Checkout&nbsp;flow</th><th>Choose when</th><th>Description</th></tr></thead><tbody><tr><td><strong>Continue</strong></td><td>You do not know the final payment amount when you initiate the checkout flow.</td><td>The default flow. Redirects the customer to the PayPal payment page, which shows the <strong>Continue</strong> button. When the customer clicks <strong>Continue</strong>, the customer can change the payment amount.</td></tr><tr><td><strong>Pay Now</strong></td><td>You know the final payment amount when you initiate the checkout flow.</td><td>Set <code>user_action=commit</code>. Redirects the customer to the PayPal payment page, which shows the <strong>Pay Now</strong> button. When the customer clicks <strong>Pay Now</strong>, the payment is processed immediately.</td></tr></tbody></table>
        /// </summary>
        [DataMember(Name="user_action", EmitDefaultValue = false)]
        public string UserAction;
    }
}

