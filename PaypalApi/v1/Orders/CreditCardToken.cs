// This class was generated on Tue, 30 Jan 2018 11:02:41 PST by version 0.1.0-dev+6beb51-dirty of Braintree SDK Generator
// CreditCardToken.cs
// @version 0.1.0-dev+6beb51-dirty
// @type object
// @data H4sIAAAAAAAC/7yVQW/bOgzH7+9TED4GfsHrwzvlnYrmUgzYiiEtMAxDzVpMTFSWXFJK6g797oOUpLXr9VCs6C2mJOr/E/9kfharvqNiUZwJGQ5whmJg5W/JFWVxhcJ4Y+kztmlLURafqH/+WJLWwl1g74pFsWoIQjrID2Sg3qerUzpDAdnqHL75CDU6iEoQGlZgp0FiSy5A8LCOzgBCh32KzIuyOBXBfi/wn7L4Smi+ONsXizVapRS4iyxkngIX4juSwKTF4vsTmgZht5ny7DVeJ43XbEZ0k6Up6/kS/HrEGRoMwAoavJABdhAaggvsL9DCFqN9G1OQ+ALJRWsfyycudoE2JFMwuu9Y6Lr1LjQjrBcLU6i8AVMA8ibYcWjAebCEht0GHkj8HK7QRkqoa/EtVCdVKl918m/1p0V7I2FPKL8DPMSnfGsf5W/DGw5D1LT9nZW/5jmLGv4bST5GpmLTSlYMWbEmvyVHHfw1tJ6L7Q19FEOHPcnLjhkExySnEB3fxdwwuUP6wxRAVd44QGcgCNa3sGvI5dUMCDgiPHRTbiPwkmcI7j/HbzGHVRot58t8SUO2S+bErWeTlLhALilDm1N4gZY1/xo1s47T3BCg62GbfZ8k7ny0BizfUs6u6mvGQPt+yUXCbdKFYkrQWDeACgiXl+fLMl0s4LClMt1PLbIFNEZIdQ6z2bFGzw/yKizwGhCq4+NXsEMFL7xhh9b20InfshmmOiZJGoevNpt9jHlCWh4a5xCY2n80WvuOBmOn2rJiVULVogaStCV9Gdbab0mq/K4VtnRfHU4poFAykfW7dEDpfzAenA+HfyNS2pdXYe1Tx2lnsX+Xjvrx+NcvAAAA//8=
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.Orders
{
    /// <summary>
    /// The tokenized credit card details. You can use this instrument to fund a payment.
    /// </summary>
    [DataContract]
    public class CreditCardToken
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public CreditCardToken() {}

        /// <summary>
        /// REQUIRED
        /// The ID of credit card that is stored in the PayPal vault.
        /// </summary>
        [DataMember(Name="credit_card_id", EmitDefaultValue = false)]
        public string CreditCardId;

        /// <summary>
        /// The expiration month with no leading zero. Value is from `1` to `12`.
        /// </summary>
        [DataMember(Name="expire_month", EmitDefaultValue = false)]
        public int? ExpireMonth;

        /// <summary>
        /// The four-digit expiration year.
        /// </summary>
        [DataMember(Name="expire_year", EmitDefaultValue = false)]
        public int? ExpireYear;

        /// <summary>
        /// The last four digits of the stored credit card number.
        /// </summary>
        [DataMember(Name="last4", EmitDefaultValue = false)]
        public string Last4;

        /// <summary>
        /// A unique ID that you can assign and track when you store a credit card in the vault or use a vaulted credit card. This ID can help to avoid unintentional use or misuse of credit cards. This ID can be any value you would like to associate with the saved card, such as a UUID, user name, or email address. **Required when you use a vaulted credit card if a `payer_id` was originally provided when you vaulted the credit card.**
        /// </summary>
        [DataMember(Name="payer_id", EmitDefaultValue = false)]
        public string PayerId;

        /// <summary>
        /// The credit card type. Value is `visa`, `mastercard`, `discover`, or `amex`. Values are in lowercase; do not use these values for display.
        /// </summary>
        [DataMember(Name="type", EmitDefaultValue = false)]
        public string Type;
    }
}

