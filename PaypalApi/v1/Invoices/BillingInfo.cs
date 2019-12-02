// This class was generated on Tue, 30 Jan 2018 11:02:40 PST by version 0.1.0-dev+6beb51-dirty of Braintree SDK Generator
// BillingInfo.cs
// @version 0.1.0-dev+6beb51-dirty
// @type object
// @data H4sIAAAAAAAC/8RXTW8bNxO+v79isO/FRheS7bQ9+FRHToGgiaPGSQ9tDWvEndVOzSXX/LCzKPzfC3IpWZTswnFd9SJAM8Pl88w3/yw+9R0Vx8VrlpLVAt6qWhdl8QsaxrmkM2yDtiiLn6i//3NKVhjuHGu1dpZVrU2LQQq1NuAaAlY3mgWBIcEdk3KjoixOjMF+uPigLD4SVh+U7IvjGqWlILj2bKhaCaZGd2Qcky2Of1tBts6wWmyDxarigAHlJQ9s7rFv63IqJyv9OpsSrBcNoIW5t6zIWmi0N/afclFeyrtyReikqgxZ+yCjpMiYJNlGMNASpC+Bnv9BwoG3VEX0KVDpLLAChA77lpQDbYC+OFIVVTF65w13XbBOH/v3AyfY9RnHJMgJTtj1oLClrwLkjP975z8KSnvlTH8pdEU5uFyRgzwCSc6RgWQFwWo3gCUrOsyQLiU5xHesCA5B17FOlxmzR4sRKN/OyZRgnSFyJZAT+7sDf7QF/mgL/IcuVWlQw9GDLKxnRyVg5+D/kcNo/4UL9jEWXaNVnixLSc5iGqTJ26EY34wOj17B0HZ2BVVbh3I7u3N5DvtX7mI+x5Zx7fkGZWggbMFbj1L2YBKy2EiGEmCy4Bp00OANhWC1I/hRG5BsXQjfhlWlQelkPGCJV1roJIUOZ6gmA05D41x3PB6TGt3yFXdUMY60WYzDv/H0nsWO/GkdutyTS8mjDaKi6KbP5xBNbQmoqpjOa84NFto1tObOF2F08QROy6F3Gbpuxm1Tk3P89ND8B6HbDlV/P0q/upc/PzrUIsuMwVLyFOTRdjk8R7/7g4NXYi61uLr22lH8P/wK64xWi0Fyph0dD+Lxuvw11doQ9NrDghwg/PwxJkMZRa23DoQhdASoVmBibdiOBNehVGbXJml+6LDvUI6EbmGGNqbPI8hDpwnqWVoH4iY0S7vCCD5bAgThrdMtmY2jWskeuI4Qb1G5UIGDxdqyl1wz3vTNTiZIzca67UzNxE8Jdjywy9yUqBYeFznsNeE26KUyBPS24bChqhQNgQrmBJaGEGXZEENcDaG8bUht5IpEcWUBYYr9FCWgiA1nZ054KHjr0qfELtjvMnRKO65ZxLfCpWhQKcq7zCMG21y6ONfC5Fw/AunI6lW1FstTqtHLOH1nb96fvH03G+bq7Pz9+awEhFncPWZwg9JTMFsO5xd2zjStOM/chSL7tX1oB8+NZ232AedqqcfhPRVn+N5ksl+GV1ZFNSuqYN6Hhe77b0cQzrT4hVvfhvE3j2pJauGasPpMJt8oXL46LRx+BxUv2NldZW+6+3JwfJ64W7ptb6ywL58ND/rgZNMOhFaWrbPBBStdRdaxSlkf3Xp2OtmPG5H183B1OJq+sHd+tv/fevfi7uLuf38BAAD//w==
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.Invoices
{
    /// <summary>
    /// Billing information for the invoice recipient.
    /// </summary>
    [DataContract]
    public class BillingInfo
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public BillingInfo() {}

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
        /// The invoice recipient company business name.
        /// </summary>
        [DataMember(Name="business_name", EmitDefaultValue = false)]
        public string BusinessName;

        /// <summary>
        /// REQUIRED
        /// The invoice recipient email address.<blockquote><strong>Note:</strong>Before you get a QR code, you must create an invoice that specifies `qrinvoice@paypal.com `as the recipient email address in the `billing_info` object. Use a customer email address only if you want to email the invoice.</blockquote>
        /// </summary>
        [DataMember(Name="email", EmitDefaultValue = false)]
        public string Email;

        /// <summary>
        /// The invoice recipient first name.
        /// </summary>
        [DataMember(Name="first_name", EmitDefaultValue = false)]
        public string FirstName;

        /// <summary>
        /// The language in which an email can be sent to the recipient. Used only when the recipient lacks a PayPal account.
        /// </summary>
        [DataMember(Name="language", EmitDefaultValue = false)]
        public string Language;

        /// <summary>
        /// The invoice recipient last name.
        /// </summary>
        [DataMember(Name="last_name", EmitDefaultValue = false)]
        public string LastName;

        /// <summary>
        /// The preferred notification channel for the recipient. Default is `EMAIL`. For `SMS`, a `phone` value is required.
        /// </summary>
        [DataMember(Name="notification_channel", EmitDefaultValue = false)]
        public string NotificationChannel;

        /// <summary>
        /// The phone number.
        /// </summary>
        [DataMember(Name="phone", EmitDefaultValue = false)]
        public Phone Phone;
    }
}

