// This class was generated on Mon, 09 Apr 2018 18:07:49 UTC by version 0.1.0-dev+291f3f of Braintree SDK Generator
// Payee.cs
// @version 0.1.0-dev+291f3f
// @type object
// @data H4sIAAAAAAAC/7xVQW/bPAy9f7+C0KVfgdhO2qEDctvWDiiGdUVX7NIVASMxsQBZ8ii5mTf0vw9y4iSOG7TYgp4CkdTjexT98lvc1iWJsSixJhID8Q1Z49TQFRYxLAbiE9Wbwzl5yboM2lkxFrc5QXMRFrkDJkn6gTyEnGBWWeUBrYJZZWbamGXYsSJOxUC8Y8Z62Xs4EDeE6os1tRjP0HiKgR+VZlLrwDW7kjho8mJ8t2btA2s779OmArXpcG8jfQFNBlApJu8BvXdSYyAFCx3yhnQj8cjDNdbXaACldJUNKXx0DGhB20A2gJsBViF3rH9FnUupgwag26KofIAp9VohSGdnmgtSbatp5bVtaO3t6dHQdheJFkiHnHj8vRoOT2Vlml9anoxent6/qH9J7J1FE/X0uCwBsxaxi3/l9mjcGeKTIFnL+R8XxVbGPA6e3ZaCWOZow0Srzs504/3N6UqBy3OYOd5sTHpY9g3mRGlfGqwnBQVUGLCvZm/dRtjekr7GVVHirKmhrTyszuc/5ymjVRMbD9syOuGnnYmP/GZxY+WBH6WdYZk7+4R97qY33Hcze4z1yENTAbYqpq/hnM0qcz2RTnUJ7yT6fO/CwiUyR0YZiOHy6zA5HZ2dJSNYXYV49f7/PITSj7NM0QOZSC0tsS7RpNIVmXLSZ9Hc5owRO1OaSYaMyYdshZNEHJ8dR/fbtudVOn0d01g+SGdE61B/ONom7RS233MA2sLdRTo6e7OKaDuH0qCNn1iBYTOuxWKR6lCl2sZpyOw2ubn4kDRXk5PhaDgaJZfHB9F+/wL1f/8Hu20dnMJn/KmLqgBDdh5y0B5GJ29hvUb+QIruH//7AwAA//8=
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.Payments
{
    /// <summary>
    /// The payee who receives the funds and fulfills the order.
    /// </summary>
    [DataContract]
    public class Payee
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public Payee() {}

        /// <summary>
        /// The email address associated with the payee's PayPal account. For an intent of authorize or order, the email address must be associated with a confirmed PayPal business account. For an intent of sale, the email can either:<ul><li>Be associated with a confirmed PayPal personal or business account.</li><li>Not be associated with a PayPal account.</li></ul>
        /// </summary>
        [DataMember(Name="email", EmitDefaultValue = false)]
        public string Email;

        /// <summary>
        /// The PayPal account ID for the payee.
        /// </summary>
        [DataMember(Name="merchant_id", EmitDefaultValue = false)]
        public string MerchantId;

        /// <summary>
        /// The display-only metadata for the payee.
        /// </summary>
        [DataMember(Name="payee_display_metadata", EmitDefaultValue = false)]
        public PayeeDisplayMetadata PayeeDisplayMetadata;
    }
}

