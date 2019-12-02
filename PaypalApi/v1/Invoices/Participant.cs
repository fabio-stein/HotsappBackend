// This class was generated on Tue, 30 Jan 2018 11:02:40 PST by version 0.1.0-dev+6beb51-dirty of Braintree SDK Generator
// Participant.cs
// @version 0.1.0-dev+6beb51-dirty
// @type object
// @data H4sIAAAAAAAC/+yWz47jRBDG7zxFyVwmwsow4c9hbkMWLqDZEbNwAKFRxV2JC9rd3q7y7liId0ft2Ek6zkSzSzZIqz26quz+feXqr/vv7FVbU3ad3WFQLrhGp1me/YqBcWHpFquYzPLsR2q3Dy9IisC1snfpq8Bu6UOFMTPN8uwmBGzXK3yZZz8TmpfOttn1Eq1QDLxuOJDZBO6Crykok2TXv2/YRAO71RgLjeG4EtqHuG5COc6l0Deb/C5zDtIUJaDAohF2JAKlb4L8Vy2usfaffCPoxphAIgcV9YlESR9LFXyHQtB/CfziTyoUGiHT0bO17FbQvwvsAKHGtiKn4APQo5IzZGDpA9yXXNexuv/Yh/9xBWubaOwDqcA5awsOK3onIA3N8eY/CeUbp6F9KLyhFC5NpJAzsKRKAfoqiFXnAbbs6CohHSIp4k/sCK7AL0HL7cRc0GoKrqkWFHIQDUSaA2kxOR/8bAQ/G8G/rPtdGtMwO6hCGlbKAWuFzzsN08mJN+xTKurSu3RYhsieRcZo3+24Gb+fXs2+grXtnAvVi6IdT3caT7F/47qb584yXjf8Bm00EBZopEFrWwg9WWck6y3AJKAlKpT4huLPqqbwgw9gWTT+vr0q48H5vnjN0i0pUFuKDhdoSQHUQ6laX19ekpu+5b+4JsM49WF1GZ8u77YqztRPUdS0k0PkSYMw1LXpl3voSiUHdKYb553mxgqvJe208ySK/niGpuHQe4ium2jbz6QaX5UE9c4toPBVja7dHqLv7OLv/1+oQrYJ+xA5ztxVDQfmaT3wrveEPdIlPiac6+cDlDvmcYaz+b2Owci5OQFxffnoBv5iPp/k8UpiaMmODCza6H7ffj2F+E6Fj1w1VZyYRZe25FZaRp+Yz79wOFzRBK6+AcMrVjnTHA1rP6wbn7RinBt3Y8M+nLEHe3CzXweFd8KiEluwyRkS5fVT39bbF/NJZx/SLOLS8dX+Cxf3t5P/t7vP8ZolB9Gx0STh4zu2Kz2ntVg8RLwbPQ4cKz8E7xP+8tzLySeP+eQxH6fHvKWF8N4tbRs7vln7uhOxfvYvAAAA//8=
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.Invoices
{
    /// <summary>
    /// Participant information.
    /// </summary>
    [DataContract]
    public class Participant
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public Participant() {}

        /// <summary>
        /// Additional information, such as business hours.
        /// </summary>
        [DataMember(Name="additional_info", EmitDefaultValue = false)]
        public string AdditionalInfo;

        /// <summary>
        /// Base Address object used as billing address in a payment or extended for Shipping Address.
        /// </summary>
        [DataMember(Name="address", EmitDefaultValue = false)]
        public Address Address;

        /// <summary>
        /// The participant company business name.
        /// </summary>
        [DataMember(Name="business_name", EmitDefaultValue = false)]
        public string BusinessName;

        /// <summary>
        /// REQUIRED
        /// The participant email address.
        /// </summary>
        [DataMember(Name="email", EmitDefaultValue = false)]
        public string Email;

        /// <summary>
        /// The phone number.
        /// </summary>
        [DataMember(Name="fax", EmitDefaultValue = false)]
        public Phone Fax;

        /// <summary>
        /// The participant first name.
        /// </summary>
        [DataMember(Name="first_name", EmitDefaultValue = false)]
        public string FirstName;

        /// <summary>
        /// The participant last name.
        /// </summary>
        [DataMember(Name="last_name", EmitDefaultValue = false)]
        public string LastName;

        /// <summary>
        /// The phone number.
        /// </summary>
        [DataMember(Name="phone", EmitDefaultValue = false)]
        public Phone Phone;

        /// <summary>
        /// The participant website.
        /// </summary>
        [DataMember(Name="website", EmitDefaultValue = false)]
        public string Website;
    }
}

