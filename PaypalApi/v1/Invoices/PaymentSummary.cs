// This class was generated on Tue, 30 Jan 2018 11:02:40 PST by version 0.1.0-dev+6beb51-dirty of Braintree SDK Generator
// PaymentSummary.cs
// @version 0.1.0-dev+6beb51-dirty
// @type object
// @data H4sIAAAAAAAC/+yST2sVMRTF936KS1YKQ/EfCLPTuhGhLba4kS7uJGf6Ipkk3twIQfrdZdq+eQYrIuquyzncuTm/e843c9EyzGjOuC2ISud1WViaGcxHFs9TwAkv64AZzHu0w8dbFCs+q0/RjOZiB8p3Kzg6Esw1Oiq3247MYF6LcLt97OlgPoDdaQzNjDOHglX4Ur3AbcKZpAxRj2LGT5vN4yqCaO/xl3QH6Uzuld7pGy6gNH2GVZqTEIdAs48credAXzlUkCCwwtHsEVyhxxMHjhbDhugqBoLaoyf/jKyo+Hj1M5e9Iz5ODh2ePZyiJ3xBAaoQ2k+QTQ7EhRxmH+FoavTu/JRePn/26m+jiTWE6+G3FDd37ezvld47L6lGpZpJE52Q81deieeVRncgB+sXDoUKMgvrmt8By8cN6yba9Q/OWVIWz4r+Hn8ErlLv4778gfzXzczcMocOfpMeuvnQzf/VzcvrR98BAAD//w==
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.Invoices
{
    /// <summary>
    /// The payment and refund summary.
    /// </summary>
    [DataContract]
    public class PaymentSummary
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public PaymentSummary() {}

        /// <summary>
        /// Base object for all financial value related fields (balance, payment due, etc.)
        /// </summary>
        [DataMember(Name="other", EmitDefaultValue = false)]
        public Currency Other;

        /// <summary>
        /// Base object for all financial value related fields (balance, payment due, etc.)
        /// </summary>
        [DataMember(Name="paypal", EmitDefaultValue = false)]
        public Currency Paypal;
    }
}

