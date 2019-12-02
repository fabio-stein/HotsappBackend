// This class was generated on Tue, 30 Jan 2018 11:02:40 PST by version 0.1.0-dev+6beb51-dirty of Braintree SDK Generator
// PaymentDetail.cs
// @version 0.1.0-dev+6beb51-dirty
// @type object
// @data H4sIAAAAAAAC/7yVzW7rNhCF932Kge4mEWSprfuDeude3wJBm8RIjaJFYCRjcmSzpUiWHMVQi7x7oR/LVpwgvYiRXTIcUuc7hxz/Gy0qR9EkmmNVkGGYEaPSURL9hl7hStMVFvV6lEQ/U7X/Z0ZBeOVYWXOwWza7Qxol0dR7rNrDv0yiG0J5bXQVTXLUgerC36XyJPvC3FtHnhWFaHLby/pYek9GVMeCsLCl4YGsvjQU9yMGArv6kwRDbj2g1pArg0Yo1PCAuiTwpJFJQq5IywBnK9RoBCXgdmQlJUAs0vOTsQX2yqyPyUTH/NFKGvCJvRlDwjFoYiYPuw4QVhJgAEm5MiRhVcHFr9fwzddfff/WcEyp9WPyKkXj60D+rjLU3oYGpQO2cAVSrRUD5jUNbwgkCVWgDhDIoUeu89tjKdNjNdHWO9A5b51XyDT047PA2ZfPcS//B7lEHoJ3hSH3ooarNW43ZBrhyjxYJQi2GMChkin0Pbn1BTKoAHFVVVU8ii8v41EsZQzxP3HyxJLbC8PkDTHMkClbqILgp+aE5dmG2U2yjK3VIVXEeWr9OttwoTOfi/F4/MOHQKLWOPo2/e78nS5LQbyxcmBaXzq2bfcmi/qSWw9tawo7JbBVvGksvf/0++LTzdX0l/t+E1fuJDfhdShjn9yDrjAEum7+QJ3CFOoGwBCsUM006jk68e+UBns0AZtLcKeGqRwtHadzMWunLMyxmqPeG7/f+mxU8+kf8zcFdRrg+rMvIneLx9AHTe8q/EjsSwIPXa1nBJpu3iizhlzbbTttbj0J6yV4yksjl2eZtCJk6FTWd2cfukEV7trmUdt83r1DCKVz1nN4+gLbttae5mN95Acr9YzrDqh/jq2HFYq/tuglCFs4ZLVSWnF1EoOXj1/8BwAA//8=
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.Invoices
{
    /// <summary>
    /// Payment details.
    /// </summary>
    [DataContract]
    public class PaymentDetail
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public PaymentDetail() {}

        /// <summary>
        /// Base object for all financial value related fields (balance, payment due, etc.)
        /// </summary>
        [DataMember(Name="amount", EmitDefaultValue = false)]
        public Currency Amount;

        /// <summary>
        /// The date when the invoice was paid. The date format is *yyyy*-*MM*-*dd* *z*, as defined in [Internet Date/Time Format](http://tools.ietf.org/html/rfc3339#section-5.6).
        /// </summary>
        [DataMember(Name="date", EmitDefaultValue = false)]
        public string Date;

        /// <summary>
        /// REQUIRED
        /// The payment mode or method. Required with the `EXTERNAL` payment type.
        /// </summary>
        [DataMember(Name="method", EmitDefaultValue = false)]
        public string Method;

        /// <summary>
        /// Optional. A note associated with the payment.
        /// </summary>
        [DataMember(Name="note", EmitDefaultValue = false)]
        public string Note;

        /// <summary>
        /// The ID for a PayPal payment transaction. Required with the `PAYPAL` payment type.
        /// </summary>
        [DataMember(Name="transaction_id", EmitDefaultValue = false)]
        public string TransactionId;

        /// <summary>
        /// The transaction type.
        /// </summary>
        [DataMember(Name="transaction_type", EmitDefaultValue = false)]
        public string TransactionType;

        /// <summary>
        /// The payment type in an invoicing flow. The [record refund](/docs/api/invoicing/#invoices_record-refund) method supports the `EXTERNAL` refund type. The `PAYPAL` refund type is supported for backward compatibility.
        /// </summary>
        [DataMember(Name="type", EmitDefaultValue = false)]
        public string Type;
    }
}

