// This class was generated on Tue, 30 Jan 2018 11:02:40 PST by version 0.1.0-dev+6beb51-dirty of Braintree SDK Generator
// Phone.cs
// @version 0.1.0-dev+6beb51-dirty
// @type object
// @data H4sIAAAAAAAC/8SQQUv7QBDF7/9PMcyp5R+KBfWQW0k9CbVo8SJSNtlpOrCZjbsbcJF+d1lTI20QDx48zrw3bx6/N9zEljDH9d4KYYaPyrEqDa1Uk9aY4S3Fr2FJvnLcBraCOW72BG06BOmaktwMM1w4p2IfepHhPSl9JyZivlPGU1q8dOxID4u1sy25wOQxfxrq+OBY6nGfynYSXNxWVtNJtzNh3PNogEoZw1JDMsKkKKYZKA+adiykoYxwM5tfX84g3TTqlZuugco25YdsSOqwB7uDovgvKsUrA+xhfgWaaw7+twikM+aQ/cjh8/e2B3+CYqyNaQzde883DBbnPqisePbBJwSDpskH7qcj1tWymIISDb4r0+t0ekyYPKymf0v3+fDvHQAA//8=
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.Invoices
{
    /// <summary>
    /// The phone number.
    /// </summary>
    [DataContract]
    public class Phone
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public Phone() {}

        /// <summary>
        /// The country calling code (CC), as defined by E.164. The maximum combined length of CC+national is 15 digits.
        /// </summary>
        [DataMember(Name="country_code", EmitDefaultValue = false)]
        public string CountryCode;

        /// <summary>
        /// The national number, as defined by E.164. A national number consists of national destination code (NDC) and subscriber number (SN). The maximum combined length of CC+national is 15 digits.
        /// </summary>
        [DataMember(Name="national_number", EmitDefaultValue = false)]
        public string NationalNumber;
    }
}

