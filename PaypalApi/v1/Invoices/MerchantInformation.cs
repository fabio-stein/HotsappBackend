// This class was generated on Tue, 30 Jan 2018 11:02:40 PST by version 0.1.0-dev+6beb51-dirty of Braintree SDK Generator
// MerchantInformation.cs
// @version 0.1.0-dev+6beb51-dirty
// @type object
// @data H4sIAAAAAAAC/+xWTW/jNhC991cM1EuMCk7jfhxyS50WWLTNBs22hxaFdySOrGkpUktSWQtF/3tBSrJNK2skqVcFihw5M6Leexw+zl/Jm7am5DL5kUxeonLwShXaVOhYqyRNfkHDmEm6wcpXJWnyPbW7xTXZ3HAdivf2yBrLiqwF3m0GrkQHWNeExkJYE7C615zTPEmTK2Ow7cB8niY/EYrXSrbJZYHSkg+8a9iQ2AZuja7JOCabXP62pWGdYbUeA0ch2KNAufKYIh7jXEzrapvf55OCbfIS0O7Ylrox9t9yUY2Uf6dPJbSSmJE8RmtbcUAOQhwKbcKJvD347C0UTFKcmNWVEIasfZBWn4iI9LEY+jdoCfqdQGd/UO6gsSTCmbCUrNbQfwusAKHGtiLlQBugjSMlSATedyXXta/uN/v47ZizayOOfSAmuGTXgsLqaffDmeZ5LZXrRjnTrnItKAYXJ2KQC5DkHBnoq8BXTQNYsqKLCOkQiSH+wIrgAnQROnzomDNaz0E1VUYmBesMkUuBXD6bDvxiBH4xAv+67r3Hp2HxIAvbsKMUsHbwaeAwn01kQ3WpVdwsQyRmceujvdr+Mn47v1h8AZ2ZTgVVW4dy3N1xPIb9K9ehn4NlvGv4HqU3ELbQ2AalbMH0yIKRdFeAyXaPXYn35A+rmsN32oBk6/zxHVQJDUr3xR2W8EsLtSTvcIYKMuA0lM7Vl+fnpObv+U+uSTDOtVmf+9X57Y7FRHpahy5Wcoh80CAEBZl+voNQalNAJUI774nrK7QraU/OkzD6/RGchqd85V034naYiTm+KQmqYfrJdVWjandzwZMt/PmHQhVyPAYMkSOAQ8nwVJ7W/W57NziAWeAmAtmtxxDrPduY4FV+1gPocW7fPuzGjtDqZ8vlLPXDiKCCFQnIWu97X385hyA/brhqKt8uWUhLUmtXeodYLj9TOIycFi6+AsFrdlPNlsO/V53wkRTj3FiNLfbhdX1Qg6vDOsi1smyd9RJsc4Ks427Vy3pzvZwF47BN5n/tP+13OLu7mf236j7GZQo21o0tJgofua6hbkpTkfgQ3P3oEbS+7GOA/YCzPHYgeXGXF3f5f7qLw82KRSTrNnTknjrcwKvriXrgPWWWD6bHXewIyr7oRGJ+8g8AAAD//w==
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.Invoices
{
    /// <summary>
    /// Merchant business information that appears on the invoice.
    /// </summary>
    [DataContract]
    public class MerchantInformation
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public MerchantInformation() {}

        /// <summary>
        /// Additional information, such as business hours.
        /// </summary>
        [DataMember(Name="additional_info", EmitDefaultValue = false)]
        public string AdditionalInfo;

        /// <summary>
        /// A label for the `additional_info` field.
        /// </summary>
        [DataMember(Name="additional_info_label", EmitDefaultValue = false)]
        public string AdditionalInfoLabel;

        /// <summary>
        /// Base Address object used as billing address in a payment or extended for Shipping Address.
        /// </summary>
        [DataMember(Name="address", EmitDefaultValue = false)]
        public Address Address;

        /// <summary>
        /// The merchant company business name.
        /// </summary>
        [DataMember(Name="business_name", EmitDefaultValue = false)]
        public string BusinessName;

        /// <summary>
        /// REQUIRED
        /// The merchant email address.
        /// </summary>
        [DataMember(Name="email", EmitDefaultValue = false)]
        public string Email;

        /// <summary>
        /// The phone number.
        /// </summary>
        [DataMember(Name="fax", EmitDefaultValue = false)]
        public Phone Fax;

        /// <summary>
        /// The merchant first name.
        /// </summary>
        [DataMember(Name="first_name", EmitDefaultValue = false)]
        public string FirstName;

        /// <summary>
        /// The merchant last name.
        /// </summary>
        [DataMember(Name="last_name", EmitDefaultValue = false)]
        public string LastName;

        /// <summary>
        /// The phone number.
        /// </summary>
        [DataMember(Name="phone", EmitDefaultValue = false)]
        public Phone Phone;

        /// <summary>
        /// The merchant tax ID.
        /// </summary>
        [DataMember(Name="tax_id", EmitDefaultValue = false)]
        public string TaxId;

        /// <summary>
        /// The merchant website.
        /// </summary>
        [DataMember(Name="website", EmitDefaultValue = false)]
        public string Website;
    }
}

