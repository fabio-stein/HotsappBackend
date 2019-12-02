// This class was generated on Tue, 30 Jan 2018 11:02:40 PST by version 0.1.0-dev+6beb51-dirty of Braintree SDK Generator
// Notification.cs
// @version 0.1.0-dev+6beb51-dirty
// @type object
// @data H4sIAAAAAAAC/6yUQW/TQBCF7/yK0Z6ttBISB9+qcimIBJGKC6Bosh7XC+sdZ2ZMZKH+d7RxksZJEUL0Ymnf2vO+2XneX+5+6MiVbs4W6uDRAidXuM8oAdeR5tjmXVe49zQ8Ld6Segnd7uXS3TcE1GKIwALLD0tIJ8VmrnA3IjiMRteF+0RYLVIcXFljVMrCpg9C1VH4KNyRWCB15ZcjopqE9HAJ5/1q564TylN1inuTADMQcA2cKEO3LAS3t+XYhs7groaBe+A2GFgTFDoUbMlIoBZuwRqCd8vFHIQ2PanBmquhAJy0DkFBKRkYA8b4ZABYVUKqpGANGqBQNrBMlCuH9JODpxksrCHZBqUCtCMf6uGcxhhiGCnpsjjDtgm+mVDpzi5zzb7219ev/Tqy/7Hp2Wi3Hp9eTTg9jMqcjcpRvjrV4aaqQq6J8cI7myQ20L7rWIyqvdvVud00H2/+NR+pj/Gx+GtIEhtN8rEXzqKRkSmfWz7ODgeS/83vGd+aORI+84sppWplvGpJfIPJJrDPbE7B71KVx0sK24ZyaHIP+StA8NwNh2SNU9r3d6j2wi3+aQTar7+TP2vsqF1eKfu9A/pLXio74m+Pr34DAAD//w==
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.Invoices
{
    /// <summary>
    /// The email or SMS notification.
    /// </summary>
    [DataContract]
    public class Notification
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public Notification() {}

        /// <summary>
        /// An array of one or more CC: emails. If you omit this parameter from the JSON request body, a notification is sent to all CC: email addresses that are part of the invoice. Otherwise, specify this parameter to limit the email addresses to which notifications are sent.<blockquote><strong>Note:</strong> Additional email addresses are not supported.</blockquote>
        /// </summary>
        [DataMember(Name="cc_emails", EmitDefaultValue = false)]
        public List<string> CcEmails;

        /// <summary>
        /// A note to the payer.
        /// </summary>
        [DataMember(Name="note", EmitDefaultValue = false)]
        public string Note;

        /// <summary>
        /// Indicates whether to send a copy of the email to the merchant.
        /// </summary>
        [DataMember(Name="send_to_merchant", EmitDefaultValue = false)]
        public bool? SendToMerchant;

        /// <summary>
        /// The subject of the notification.
        /// </summary>
        [DataMember(Name="subject", EmitDefaultValue = false)]
        public string Subject;
    }
}

