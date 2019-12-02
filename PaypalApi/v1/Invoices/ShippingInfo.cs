// This class was generated on Tue, 30 Jan 2018 11:02:40 PST by version 0.1.0-dev+6beb51-dirty of Braintree SDK Generator
// ShippingInfo.cs
// @version 0.1.0-dev+6beb51-dirty
// @type object
// @data H4sIAAAAAAAC/7yVT2/UPBDG7++nGPm9UCnK0uW2t/JPQiBa0cIBVFWzyWQz4NiuPSlEqN8dOZvs1k0RW1jtLXlm7Pye8WT8U110jtRCndfsHJsVvDGVVZn6hJ5xqek9NjGsMvWWuu3LSwqFZydsjVqoi5ogjBuwqaxvMIagsh6kJmBzY7kg8FSwYzKSq0ydeI/d+vNPM/WBsDw1ulOLCnWgKFy37KncCGfeOvLCFNTiywb8pCw9hTBFxk1gS77VUgPPMRAMO4FdfqVCoA1UAgZYstbR17AW2ACCw64hI2A90A8hU1LZm92Ucdhsfz6DeDarqc2CpUs8DkJq8AVLBwYbehSQ+PYej2m1vs3+DGVbI767KmxJKVwaSCHnoEmEPAxZELMOA6zZ0HFCOiop4js2BMdgq76tx455QqscTNssyWcQxBNJBiTF0eHg5xP4+QT+tH9ADTEM8wddhJaFMkAn8H/vIT/61x7e0YWrrUmbZVRSF2dRHaodf8ZX+fH8GaxnzqFQbRDU0+5O9RT7M7u+n/uRcd3yDeo4QDhAG1rUugM/kPWDZP0LMAWQGgVqvKF4WE0Or60HzUHi8d3LKi0YOySvWfpPBnCa4oTzVJEHsVCLuMVsRib/zt/YUcmYW7+axbfZ2dbFgeoZBCWt5Kj8dkCU1Jfp4zn0qSEDNGXfzneKGzOs1HSnnHtxdLmDp2Ub2FAIV3HqJt7uR6Z36eS6hMI2Dk0H49rHz/K/P52KfZCpjUTexUO/4JDgGh/ivqvugh3z90d9efvfLwAAAP//
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.Invoices
{
    /// <summary>
    /// The shipping information for the invoice recipient.
    /// </summary>
    [DataContract]
    public class ShippingInfo
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public ShippingInfo() {}

        /// <summary>
        /// Base Address object used as billing address in a payment or extended for Shipping Address.
        /// </summary>
        [DataMember(Name="address", EmitDefaultValue = false)]
        public Address Address;

        /// <summary>
        /// The invoice recipient company business name.
        /// </summary>
        [DataMember(Name="business_name", EmitDefaultValue = false)]
        public string BusinessName;

        /// <summary>
        /// The invoice recipient first name.
        /// </summary>
        [DataMember(Name="first_name", EmitDefaultValue = false)]
        public string FirstName;

        /// <summary>
        /// The invoice recipient last name.
        /// </summary>
        [DataMember(Name="last_name", EmitDefaultValue = false)]
        public string LastName;
    }
}

