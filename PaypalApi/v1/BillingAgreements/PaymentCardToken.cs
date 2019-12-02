// This class was generated on Tue, 30 Jan 2018 11:14:21 PST by version 0.1.0-dev+6beb51-dirty of Braintree SDK Generator
// PaymentCardToken.cs
// @version 0.1.0-dev+6beb51-dirty
// @type object
// @data H4sIAAAAAAAC/7yUT4+UQBDF736KSp9x4xpPc9u4F2OiGzPZhBgDNdPF0LHpxupq147Z726agVkZ0Phnszeo9yjejwd8V9vUk9qoG0wdOYHXyBq2/jM5VahbZIM7S++wyx5VqLeUHk6uKezZ9GK8Uxt1BZIvg8YzIPTjvn3eJy3mIwc7ghhIg3hootMPvgtVqCtmTMc4Lwr1gVC/dzapTYM2UB58iYZJnwY37HtiMRTU5uMJxDihA/EyPX3rDVPVeSftjORMmFNtW4LBkGAwQMO+A2kJvmK0QnogvIBbtJHAhKNeX9aZsb58Wf8vmYvW3hd/jJcIeY1unC/hGh/5uTYHIxNntq5jFmAc1GVZlnWuuUN5ZLogbNxhDU6IHdpqH4P4jrgy+oxy1bDEfXMNvhnAJifctR78nQsgrQmzF/ev6ITjv8FZDPJqRjNNlvGzMlQGQ2XhBJM/Mxe7Hf2iuicqanx6Vb7leUdL7Xf1TOGfvg/J8s/Bx8Ey7fHnlnp6jGCf7p/9AAAA//8=
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.BillingAgreements
{
    /// <summary>
    /// A token for a payment card that can be used to fund a payment.
    /// </summary>
    [DataContract]
    public class PaymentCardToken
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public PaymentCardToken() {}

        /// <summary>
        /// The expiry month from the vaulted card. Value is from `1` to `12`.
        /// </summary>
        [DataMember(Name="expire_month", EmitDefaultValue = false)]
        public int? ExpireMonth;

        /// <summary>
        /// The four-digit expiry year from the vaulted card, in `YYYY` format.
        /// </summary>
        [DataMember(Name="expire_year", EmitDefaultValue = false)]
        public int? ExpireYear;

        /// <summary>
        /// REQUIRED
        /// The ID of the customer who owns this payment card.
        /// </summary>
        [DataMember(Name="external_customer_id", EmitDefaultValue = false)]
        public string ExternalCustomerId;

        /// <summary>
        /// The last four digits of the card number from the vaulted card.
        /// </summary>
        [DataMember(Name="last4", EmitDefaultValue = false)]
        public string Last4;

        /// <summary>
        /// REQUIRED
        /// The ID of the vaulted payment card.
        /// </summary>
        [DataMember(Name="payment_card_id", EmitDefaultValue = false)]
        public string PaymentCardId;

        /// <summary>
        /// REQUIRED
        /// The card type.
        /// </summary>
        [DataMember(Name="type", EmitDefaultValue = false)]
        public string Type;
    }
}

