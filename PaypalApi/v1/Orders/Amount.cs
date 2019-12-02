// This class was generated on Tue, 30 Jan 2018 11:02:41 PST by version 0.1.0-dev+6beb51-dirty of Braintree SDK Generator
// Amount.cs
// @version 0.1.0-dev+6beb51-dirty
// @type object
// @data H4sIAAAAAAAC/+yX32vjOBDH3++vGPx0F9w4vTs4yFuhHJTjtmFb9qVbimKN7QFZckejTc3S/31x/CNxvS0t3Q37kKcwPzQafT8aEX+NrusKo2V0VrpgJYqjT4pJrQ1+UGXjj+LoP6x3xjn6lKkScjZaRtcFQqXqEq2A2laIYUNSgEZRZPw8iqMzZlW3uyzi6CMqfWlNHS0zZTw2jvtAjHpwrNhVyELoo+XN0J8XJptP+0sDM9q0HvW555z2eyMFI56khWKVCjJcXF2e/P3n6T/QL4PUabz9PdEu9QlZwZxVUyDRxJhKwugl6ZNPmmSf/DGHlapXyoB26ME6AR+qyrGAMqYvTfg2SYTDE0VsMOYxHmRZdeK3+OC8lX0qkx4CO5V2vqlISmtqzOY8bRqotQsCMiH+8xnnlMndhlU1an/fOz1AE4UmChniHP5XD1SGEgzaXAogD6cLGK6Aj2FTUFoA2dQEjX75OSwWf6XBbH+xtQy11hV+QQuachIPa8wc41YWjSmVykDlyMq8XZP0i8Ylrt+YvnH9fiprruwrt0v6A7wT0ZNL9xynQlltyOZ3GeII1ZPAlFafcITVtNy+G6ghc+3q7mXp565EKZwGZ009PwxZsj6wsukY6753ynSIHqGOoDbYXiZ7IKi+oKpqIzume84p0j54JHqwN7WX/E6TT7u/aFNa+9GXsUGfeZzIX++Z9WEtTpQZM945v4O2C3b/xYajkGDp53CRbS3G+4BeBpRgyHY5MUhBHqq22bq5BbMZd2eZzY5TfhDwoh5GzFt7ilvUw5HIDyBy+xomk0l8fgxHM9igyFGDuP5rCRHW9WDwHP51DIxZsNrHwFgxerTityldFSmU7K3vsvuijikn2z5WTcHjnXjvN/Xt42/fAAAA//8=
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.Orders
{
    /// <summary>
    /// The payment amount, with details.
    /// </summary>
    [DataContract]
    public class Amount
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public Amount() {}

        /// <summary>
        /// REQUIRED
        /// The [three-character ISO-4217 currency code](/docs/integration/direct/rest/currency-codes/). PayPal does not support all currencies.
        /// </summary>
        [DataMember(Name="currency", EmitDefaultValue = false)]
        public string Currency;

        /// <summary>
        /// The additional details about the payment amount.
        /// </summary>
        [DataMember(Name="details", EmitDefaultValue = false)]
        public PaymentAmountDetails Details;

        /// <summary>
        /// REQUIRED
        /// The total amount charged to the payee by the payer. For refunds, represents the amount that the payee refunds to the original payer. Maximum length is 10 characters, which includes:<ul><li>Seven digits before the decimal point.</li><li>The decimal point.</li><li>Two digits after the decimal point.</li></ul>
        /// </summary>
        [DataMember(Name="total", EmitDefaultValue = false)]
        public string Total;
    }
}

