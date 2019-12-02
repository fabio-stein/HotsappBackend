// This class was generated on Mon, 09 Apr 2018 18:07:49 UTC by version 0.1.0-dev+291f3f of Braintree SDK Generator
// RefundRequest.cs
// @version 0.1.0-dev+291f3f
// @type object
// @data H4sIAAAAAAAC/+yYUYvcNhDH3/spBj+1h2/30hYK+xYohVDaHM2RlzQsWmlsD5UlZzTKnSn97sUr22uv98KFXJY87NOhmb/k0fxmtNL9m921DWabjLGIzmwZP0QMkuXZW8Wkdhb/VHXnz/Lsd2wPg18xaKZGyLtsk72ENB/6+assz14yqzatfpNnf6Eyr51ts02hbMDO8CESoxkNt+wbZCEM2ebdGJeqfXQn4hnth6hG0zy2uwqhUW2NTiBJcrgnqcCgKLLh+WINwuTKZaw6MqPT7SzaiXEZ7zupGPFaV4qVFmR49eb19c8/vvgFhmmgvcH336+N12FNTrBk1S2wNsSoZc0YZD2IrztxWP+wglvV3ioLxmMA5wVCbBrPAsraYWnCz0uJcDzKiIvW/pcfIdz26V6m5+A4ZOdgWyZHGUPdsNtHkoHa+SggC9Jfn21JhWzvWTWz8KfW5QY6L3ReKBBX8Id6oDrWYNGVUgEFeHEDI/qQw31FugJy2kaDYfN3vLn5SUe7/4tpZCmN3uBHdGCoJAmww8Iz7tNiUFOtLDSenKzSnPUwab7E3WfK7/3wPVV0pfrEz62HDXwhoqNie4xTpZyx5MptgThDdeRY0hoEF1hdyOm8QAOFT7P7E2Xouxql8ga8s+3qPGTJhcjK6TnWqXXJdPReoM6gdtg+TfZMUENFTZM8B6YT4xLp4LwQPduZOqR8ayjoxXXslPfT2GBQXjry2ztmQ9yJF2XnjA/GE2h7Z38XG7dCgnVYwatiP+pfDCNKsOR6TQ5SUYAmBdt2VXB1xf1erq4uXX4W8KIeZszTeIlb1MOFyDMQef8UJotOfLwNZz3YoSjRgPjhtYQIu3Yc8Ap+89y/5kMOjA1jQCdhL+lXkUrJZH6vHhb1TCW5dFh1C15q4kvf0k8pCTMBP39JT+3L8uj/cTORreCtshE7UArS58AXEMiVFq93rSAo21TKxRqZ9ATl2W78Hz1p3LpY75CPrv1HrlN3/70EkiTVMgWIoW8LVvqf/ocn/dh+8/lgVOGI+mh6FHhSzLg/z+n13f8AAAD//w==
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.Payments
{
    /// <summary>
    /// A refund request.
    /// </summary>
    [DataContract]
    public class RefundRequest
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public RefundRequest() {}

        /// <summary>
        /// The payment amount, with details.
        /// </summary>
        [DataMember(Name="amount", EmitDefaultValue = false)]
        public Amount Amount;

        /// <summary>
        /// The refund description. Value is a string of single-byte alphanumeric characters.
        /// </summary>
        [DataMember(Name="description", EmitDefaultValue = false)]
        public string Description;

        /// <summary>
        /// The invoice number that is used to track this payment. Value is a string of single-byte alphanumeric characters.
        /// </summary>
        [DataMember(Name="invoice_number", EmitDefaultValue = false)]
        public string InvoiceNumber;

        /// <summary>
        /// The refund reason description.
        /// </summary>
        [DataMember(Name="reason", EmitDefaultValue = false)]
        public string Reason;
    }
}

