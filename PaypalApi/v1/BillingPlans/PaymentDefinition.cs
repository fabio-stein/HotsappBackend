// This class was generated on Tue, 30 Jan 2018 11:14:21 PST by version 0.1.0-dev+6beb51-dirty of Braintree SDK Generator
// PaymentDefinition.cs
// @version 0.1.0-dev+6beb51-dirty
// @type object
// @data H4sIAAAAAAAC/+xXT2/cxg+9/z4FodMvgCwlQdECvgVxC7hFYqMxAhRGYHNnKM20oxl1SO1WKPrdi5FW+8daN5vG2EPh00IkRfE9Pr0d/Znd9C1l59k19g15gQuqrLdig8/y7CNGiwtH77FJNVme/UT99uKCWEXbDsXn2Rto1z30pkcOK2OVAU1CsbGeGExYQaiEPKDXUIU4RFzwNYghUB1LaCiCZVAGY026gEuvXKeJhwrrheISHaCsuz9yXz4mhgvAJnRe8uGhYRgZHbCxbWt9DRURDynBP4iLLM/exIj9yM3LPPuZUF9512fnFTqmFPi9s5H0JnAdQ0tRLHF2frth9W0XI3nVz7kc59ljdBPa5/XGECyQCcLiV1IyUIbOQWU9emXRwRJdR2eRHAppqCw5zTlwpwwgwwIdekX5dj0djTxwgOC/CKzE7lGsLNH6eo5UrTm4U0HTHmC1ZWcO+VZMJDpL60MlFOHyw9XZN69ffQfTbZAafvq/EWn5vCw1LcmlwYoW+xZdoUJT6qC4TIqpI6bmpbaRlJSRWMqp0VlqxOWLr92775z7K/8sIcO69oiYInMWNliHkgLe2doILAjQDy9CTXEQxLrOEoOzvxH8eP0LiEEBjAQ+CEjfWoXO9VAlPkf9JyWBJmUbdJv4wX437y+2/bhbaLu0mnSaIYCY0DF6LYYL+CHE4b2La6bAd82CIoRq86TWoSIehby/zRyYCG4vP1xBWvV2uavVqrAcihDr0nIoTWioZEGvMWou9zTGhZHmxVfqetjlp51tvh195F3Q5A6IfMjeNSnL+yJ/kHlgmh4wDZnoOc6Nvn12o6PAPtvRsx39h+3osW1avbfK4XK+x8uLRMDO8WiwpxMJTlJ6d8h14IDcdoZLkqHpPGk5eWMSzGSaTzL7MQSrXjl6YPFTaI5gq7bJ78biUZjWDwdlShL0DCsrBhAi1Z3DePA4zSRwP7a4Bwlw//L+KZT1edhVeoHW7rhFvhudg99kJ7FNiKwHMZZ3kJ0YxN30EXEYzW56DuvoD5ACPiabBIU+ed6CoI6E6c9DDHp49Rqa4JNLnQT8lzrDXH4n8geffnZHXQfmw85HhFR7Gj6Pt7EDY6baAr5HZYZ3H5qOBQwuKYnKEbJA8PQPVpCOTPnmS9b1OSBITOevA3sbH7RzM7ekbGX/3ef4k/yT/e9vAAAA//8=
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.BillingPlans
{
    /// <summary>
    /// A payment definition, which determines how often and for how long the customer is charged. Includes the interval at which the customer is charged, the charge amount, and optional shipping fees and taxes.
    /// </summary>
    [DataContract]
    public class PaymentDefinition
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public PaymentDefinition() {}

        /// <summary>
        /// REQUIRED
        /// The base object for all financial value-related fields, such as balance, payment due, and so on.
        /// </summary>
        [DataMember(Name="amount", EmitDefaultValue = false)]
        public Currency Amount;

        /// <summary>
        /// An array of shipping fees and taxes.
        /// </summary>
        [DataMember(Name="charge_models", EmitDefaultValue = false)]
        public List<ChargeModel> ChargeModels;

        /// <summary>
        /// REQUIRED
        /// The number of payment cycles. For infinite plans with a regular payment definition, set `cycles` to `0`.
        /// </summary>
        [DataMember(Name="cycles", EmitDefaultValue = false)]
        public string Cycles;

        /// <summary>
        /// REQUIRED
        /// The frequency of the payment in this definition.
        /// </summary>
        [DataMember(Name="frequency", EmitDefaultValue = false)]
        public string Frequency;

        /// <summary>
        /// REQUIRED
        /// The interval at which the customer is charged. Value cannot be greater than 12 months.
        /// </summary>
        [DataMember(Name="frequency_interval", EmitDefaultValue = false)]
        public string FrequencyInterval;

        /// <summary>
        /// The ID of the payment definition.
        /// </summary>
        [DataMember(Name="id", EmitDefaultValue = false)]
        public string Id;

        /// <summary>
        /// REQUIRED
        /// The payment definition name.
        /// </summary>
        [DataMember(Name="name", EmitDefaultValue = false)]
        public string Name;

        /// <summary>
        /// REQUIRED
        /// The payment definition type. Each plan must have at least one regular payment definition and, optionally, a trial payment definition. Each definition specifies how often and for how long the customer is charged.
        /// </summary>
        [DataMember(Name="type", EmitDefaultValue = false)]
        public string Type;
    }
}

