// This class was generated on Tue, 30 Jan 2018 11:02:40 PST by version 0.1.0-dev+6beb51-dirty of Braintree SDK Generator
// RefundDetail.cs
// @version 0.1.0-dev+6beb51-dirty
// @type object
// @data H4sIAAAAAAAC/7yVUW/bNhDH3/cpDupLYshWmnQr5res6QBja2qkxrAhCJozebJuo0iOPNXThn73gZKsTHGBbWiRRx+Pp//vf3fmX9mm9ZQtsxsqG6vhigTZZHn2EwbGraFrrNNxlmc/UPvw44qiCuyFnc2W2cp+cKzY7iD0ZXRXJi6yPLsMAdv+I2d5dkOo31rTZssSTaQU+L3hQHoMrIPzFIQpZsvbUd6rJgSyqj1WhrVrrEz0jaGpyu8wErjtr6QEShcAjYGSLVrFaOADmoYgkEEhDSWT0RFOtmjQKsrBY1uTFdAN5UCiFqdfjC1KYLs7JlMD8yunacKnHsyYEl6AIREKcMgA5TQBRtBUsiUN2xZW797Ci/PnLz+3ObYx5mP+rxSdrxP5h8hUe980aDyIg2vQvGMBLBONVASaFNdoIkTyGFBS/x6w2I5YXWvTDfQ+OB8YhaZ+/C9wCc2nuO/+A7lGmYIPgSn3JsEljfuKbCecu20i2GMc9on0Asa80oUaBTjCrG3bdjafvXkzm8+0nsHsz1n+yJbblRUKlgSuUKjYcE3wfVfh7qQS8cuiEOdMXDBJuXBhV1RSmyKU6uLi4ttnkVTSOf968c3pIl0E+gNrbyiH+/Oz5y/mZ+fz85ewfre5f6J5su6Rq0Ng6uolpDBgjE5xt9F7lqqzt7f0idRKQBux8/A964nuo6PjuVhdgSs70Wts12gOf6//uLqAg8wHwvv15S/ryx/vx/TW01PxpuMJZR84ZntElCTCympWKBTTMkg1rP6QktbBI2uQKrhmVx0qdDOZZhyNadPI8/galcbt+825DaRc0EOtu5NCOxUL9FyM2cWzYfHi+z553iefQk1SOQ2x8d4Fib3Hr3/evL65fuxy97FP+Z/2dSiQnhcXYIvqtz0GDcrVHoW3bFjaL9Knu49f/Q0AAP//
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.Invoices
{
    /// <summary>
    /// Invoicing refund details.
    /// </summary>
    [DataContract]
    public class RefundDetail
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public RefundDetail() {}

        /// <summary>
        /// Base object for all financial value related fields (balance, payment due, etc.)
        /// </summary>
        [DataMember(Name="amount", EmitDefaultValue = false)]
        public Currency Amount;

        /// <summary>
        /// The date when the invoice was refunded. The date format is *yyyy*-*MM*-*dd* *z*, as defined in [Internet Date/Time Format](http://tools.ietf.org/html/rfc3339#section-5.6). For example, `2014-02-27 PST`.
        /// </summary>
        [DataMember(Name="date", EmitDefaultValue = false)]
        public string Date;

        /// <summary>
        /// A note associated with the refund.
        /// </summary>
        [DataMember(Name="note", EmitDefaultValue = false)]
        public string Note;

        /// <summary>
        /// The ID of the PayPal refund transaction. Required with the `PAYPAL` refund type.
        /// </summary>
        [DataMember(Name="transaction_id", EmitDefaultValue = false)]
        public string TransactionId;

        /// <summary>
        /// The PayPal refund type. Indicates whether the refund was paid through PayPal or externally in invoicing flow. The [record refund](/docs/api/invoicing/#invoices_record-refund) method supports the `EXTERNAL` refund type. The `PAYPAL` refund type is supported for backward compatibility.
        /// </summary>
        [DataMember(Name="type", EmitDefaultValue = false)]
        public string Type;
    }
}

