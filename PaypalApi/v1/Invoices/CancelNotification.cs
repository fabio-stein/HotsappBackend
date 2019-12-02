// This class was generated on Tue, 30 Jan 2018 11:02:40 PST by version 0.1.0-dev+6beb51-dirty of Braintree SDK Generator
// CancelNotification.cs
// @version 0.1.0-dev+6beb51-dirty
// @type object
// @data H4sIAAAAAAAC/7yUQY/TMBCF7/yKkc9RtxISh96qclkQLaIrLoCqqTPZGBxP6plQRWj/O3LSdpu0K4QW9lLJz+7M9zzP+WXu2prMzCwwWPKwZHWFs6iOg8nMZ4wOt56WWKVDJjPvqX1cvCWx0dXd4WMJAQxAFToPHGH9YQ3hrObEZGYeI7Z922lmPhHmq+BbMyvQCyVh17hI+Un4GLmmqI7EzL6cgEWjC/eXjNZuuu4ygD1Xh9TzAJiAgAvgQAm64kiwWMx6GzKB2wJaboArp6ClE6gxYkVKEYrIFWhJ8G69WkKkXUOisOW8zQAH1sEJCAUFZUDvHxsA5nkkERLQEhUwUmqgiShVduEnO0sTWGlJce+EMpCarCvaMY0yeNdT0mVxhn3pbPkE1+RrM52+tlvP9seuYaVu3f9a0cjhvleWrDTr5ZtzHeZ57lJF9Be9k6fACtLUNUel/NDtZtxumI83f5uP0Hj/kP0xJIGVBvk4CKNoJGRK95aus8aW4nPzO+LbMnvCKy9NKOQb5U1F0ZYYdAB7ZXMIfhvyNFwS2JeUQpM8pH91RgbDP5g7lnppf92lXjV33Hmus/8xtqdiJc32O9nRsE7a0MldSXDYOz70f/mh7Ii/Pbz6DQAA//8=
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.Invoices
{
    /// <summary>
    /// Cancels an email or SMS notification.
    /// </summary>
    [DataContract]
    public class CancelNotification
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public CancelNotification() {}

        /// <summary>
        /// An array of one or more CC: emails. If you omit this parameter from the JSON request body, a notification is sent to all CC: email addresses that are part of the invoice. Otherwise, specify this parameter to limit the email addresses to which a notification is sent.<blockquote><strong>Note:</strong> Additional email addresses are not supported.</blockquote>
        /// </summary>
        [DataMember(Name="cc_emails", EmitDefaultValue = false)]
        public List<string> CcEmails;

        /// <summary>
        /// A note to the payer.
        /// </summary>
        [DataMember(Name="note", EmitDefaultValue = false)]
        public string Note;

        /// <summary>
        /// Indicates whether to send the notification to the merchant.
        /// </summary>
        [DataMember(Name="send_to_merchant", EmitDefaultValue = false)]
        public bool? SendToMerchant;

        /// <summary>
        /// Indicates whether to send the notification to the payer.
        /// </summary>
        [DataMember(Name="send_to_payer", EmitDefaultValue = false)]
        public bool? SendToPayer;

        /// <summary>
        /// The subject of the notification.
        /// </summary>
        [DataMember(Name="subject", EmitDefaultValue = false)]
        public string Subject;
    }
}

