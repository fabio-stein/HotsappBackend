// This class was generated on Tue, 30 Jan 2018 11:02:41 PST by version 0.1.0-dev+6beb51-dirty of Braintree SDK Generator
// PayerInformation.cs
// @version 0.1.0-dev+6beb51-dirty
// @type object
// @data H4sIAAAAAAAC/+xa3XLbOg6+36fAuBfbzFiW7bTdae7S9GeznTaZ/OxeeDMOLcIWthSpklAdd6cz+xr7eudJzpCSfxTZp3Gb8emFbzIRiI8CIBAgvuS/ratZjq2j1rmYoYVTPTY2E0xGt9qtfwpLYqTwo8i8Sqvdeo+z5cNrdImlPCgfta5ShDxsQstNOq1269haMSvf0m23LlDIM61mraOxUA694HNBFuVCcG5NjpYJXetosLDvWEqLzjWtGpFSpCdDsVBYGtlca9pc6UClA6RBeEcy1NyBE6FhhIB3jFqihLGx4FLK8xXI4znp2JKeNH1MiGc1xypB0xu/AFpk+LNG6UKpb+3vW2YKzXY2TIzEuoX1hbqlxzDgqYmSVFiRsM+7yzM47L14EfXAA26extIkLibNOLEhk2JJFhOOLTqOq80jr+viA+BUMJBEzTQmdMA+EqUOGAsWJz4X/110u4fJSJnk0+fCMIbn8mfi2Bo9KSUfDeNRKY5X5XC1sq1/dciGdxYFwytLLEgDOSiRfr2EvXtV7bUUgdAStOGG7vX7NboOCofSJ6b3i00eKfyCCqTJ/Cv913bBlBCGysAOXDsMgNuT/m3T7JOUtICpsUpOqZIlJsuF9V8XCp0YzdYohRJySwnC05Pr8wPIkFMj2zAS+hMkwsp2cCaxxrloZKxEC2yFdiLxn81VUY/vh32b9GRb/Fh2KtLYq6XlXNI8OWOyjsGvgxmHwM2PN7w1FvBOZLnCNugiG6Ftg2OLyKX3zsCWte6nXOo3XOo3XDoLvwjVCVnrMDFaPsA7VxBjG0QuLPsKuHD3x9z88cKifQtR9DUc/qFjwUW9tm9QaH7YeWGvAaAEdOACubAaJRitZuEUhCbmYGxNBq+s+EpqRy7nqdH1IjqXrOm0fmXxcUjD4E2n1z+EsvPePE2Zc3cUx9PptENcdEj70pnEV9HFm5Mo6Eb9brfX7UenMeqDDnwQd5QVGSjUE059IXvehUWFdruKgXEsVLOd1OVr4hHWQ3lrwzSlJHjg8/wr5WXV82n+uaAvQoXOfjXLKRFKzcBWdlc10BdK30SmxKm/Cix39lsIXdvlEhEG50uVZeRRd6b0iXKUJDrGTmL/FJ8v/TjYUUh9pteDOZc0wzh4SPcN8EXv9UETcH0ZTlQIkY/6MkZBwXCKK7H1x24l5qv9AqhWnvxXJA1mUbccLrc5gsGxnfiur8U2Rj8Rc9RBGwblGd8KPwoQDz4RWsjtXp4EiAefaknbYckjApSFmm0H9QgP/YfIhd4K+h+P8NAPeEeJ2QqbBYgHX6WClNByKzhXoIO2z6zBtSZGCZdexW21UeHE2iL3rAuO9ERhNJox7r7grelsD+hlVffajYnsl1cNrARN8/yCP6fr7xa3fz/78GZ4djH819nF+9s23L47fXt1+9hXi5sHeDQiy+lQ3q+LNfG6SdFyCjJUubJIhatC2X5PNaPVyOX6/TbMxijXIeRxaAUpZyq24+Tw8PDlE4eh8kXPOy8O7kes9/JlN+o+i3r92196oFsM/391zdGuGy1Gu+UQsuWItyPvMROkam7PJZv9DRrLlG+WmF7/b7uvK2GcGfrZsOZOTbzZp3IY2iGPoMQ6a1elm431Wru0NSMpFTatrcs321vq7dLi8OYhyfqVeils2nouZudCRcI5mvjpCHViZ7nvvSXHd/r6VxyKqgCvDkfrDmT/zxhsvE3DRiutiTeNeX55V9cRoQqe878rV5JV8ebAL9Ue2dzLOeW6kQaek7JreeA1i00n7tO6IJEFqT29u6d39/Tunt7d07t7endP7+7p3V+N3rWYUE6o14xPjaVmYP3CvGQs1EEwcErusf7AvSeq90T1nqjeE9V7onpbotoV4zHd1YM+F/3BGB5UdhV0cXefWVqINpj42//+74DFHZy+7sBlkefG8rzCLrin+f9gVSNJuMDt1KUmWVOXf9+5krjZvYc33/7yOwAAAP//
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.Orders
{
    /// <summary>
    /// The payer information.
    /// </summary>
    [DataContract]
    public class PayerInformation
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public PayerInformation() {}

        /// <summary>
        /// The billing address in a payment. Can be extended for shipping address.
        /// </summary>
        [DataMember(Name="billing_address", EmitDefaultValue = false)]
        public Address BillingAddress;

        /// <summary>
        /// The birth date of the payer, in [Internet date format](https://tools.ietf.org/html/rfc3339#section-5.6). For example, `1990-04-12`.
        /// </summary>
        [DataMember(Name="birth_date", EmitDefaultValue = false)]
        public string BirthDate;

        /// <summary>
        /// The payer's [two-character IS0-3166-1 country code](/docs/integration/direct/rest/country-codes/).
        /// </summary>
        [DataMember(Name="country_code", EmitDefaultValue = false)]
        public string CountryCode;

        /// <summary>
        /// The payer's email address. Maximum length is 127 characters.
        /// </summary>
        [DataMember(Name="email", EmitDefaultValue = false)]
        public string Email;

        /// <summary>
        /// The payer's first name.
        /// </summary>
        [DataMember(Name="first_name", EmitDefaultValue = false)]
        public string FirstName;

        /// <summary>
        /// The payer's last name.
        /// </summary>
        [DataMember(Name="last_name", EmitDefaultValue = false)]
        public string LastName;

        /// <summary>
        /// The payer's middle name.
        /// </summary>
        [DataMember(Name="middle_name", EmitDefaultValue = false)]
        public string MiddleName;

        /// <summary>
        /// The PayPal-assigned encrypted payer ID.
        /// </summary>
        [DataMember(Name="payer_id", EmitDefaultValue = false)]
        public string PayerId;

        /// <summary>
        /// The payer's phone number. Maximum length is 20 characters.
        /// </summary>
        [DataMember(Name="phone", EmitDefaultValue = false)]
        public string Phone;

        /// <summary>
        /// The phone type.
        /// </summary>
        [DataMember(Name="phone_type", EmitDefaultValue = false)]
        public string PhoneType;

        /// <summary>
        /// The payer's salutation.
        /// </summary>
        [DataMember(Name="salutation", EmitDefaultValue = false)]
        public string Salutation;

        /// <summary>
        /// The shipping address details.
        /// </summary>
        [DataMember(Name="shipping_address", EmitDefaultValue = false)]
        public ShippingAddress ShippingAddress;

        /// <summary>
        /// The payer's suffix.
        /// </summary>
        [DataMember(Name="suffix", EmitDefaultValue = false)]
        public string Suffix;

        /// <summary>
        /// The payer’s tax ID. Supported for the PayPal payment method only.
        /// </summary>
        [DataMember(Name="tax_id", EmitDefaultValue = false)]
        public string TaxId;

        /// <summary>
        /// The payer’s tax ID type. Supported for the PayPal payment method only.
        /// </summary>
        [DataMember(Name="tax_id_type", EmitDefaultValue = false)]
        public string TaxIdType;
    }
}

