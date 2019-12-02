// This class was generated on Tue, 30 Jan 2018 11:02:40 PST by version 0.1.0-dev+6beb51-dirty of Braintree SDK Generator
// InvoiceItem.cs
// @version 0.1.0-dev+6beb51-dirty
// @type object
// @data H4sIAAAAAAAC/+xX32/bNhB+319x0DCgNRRZXtYNzluXYEAwtB22oC9F0JzJU3wDRarkyY029H8faMs/ONlIg7lBB+TJ0PEofd93dx/pv7OrrqHsLLu0C8eK4FKozvLsLXrGmaHXWMfVLM9+pW77cEFBeW6End3Za9gSsFANbCvna4zrRZZnL73HbvWhMs9+J9RvrOmyswpNoBj40LInvQn85l1DXphCdvZuAzGIZ3s7BKdRKAHYB1KQV3OCuAAf52RB5j1S5yGQX0T4HzFA492CNekCNvkrJsABRl3XdaOT0atXo5OR1iMY/TXKAQNoqtiSBrbw7tIKeUsCFyg0vuKa4JflG66fzUWas/FYnDOhYJKqcP52PJfajH2lTk9Pp98GUhHvyYvix+f/VTnbGvMpv1++HZkSFZP4UMylfDtJR4Z77oLsActBudZKinQbHMJULkisEUJDXpGVWHK0gHXcAgs0LRWxREB3WDeGchAHoSHFVQeT8rscKJYUbiblTQEvTSwvCi/IdEnq9p2ughebXS9ujjcB5633ZFU31GX15USVTSjV5GcMBG72JymJrQ1oDFRs0SpGs5IDPBkU0lAxGR3g2QwNWkU5NNjVUULdUg4kqnj+xadb9ZzPnU6nXG3FSBmegiGJ2q8zQDlNu3M66+Dyjzfww/eTnx5pyJa6JvDXkRR730FtEzvrNWi+ZQGsIptoWZoU12gCBGrQo8T6JfazprUsbdyBTeNd4zk6WaLHg4iLb/fxvt5hbtt6Rn7IvJ+6hPs2tn9e83Rg+xl9i4Z136EcoPKuhjLqNCnLo5Tx+jMKaePPLpc+cMAf4+oxlL5f5w8tWmHpEnA7wQMA1xn75T2ZlGW51viBKt/L5ArvhjRkGdwyWD3/CzzefZkbxpO/Pvnr1+qvh5izTmgvH4ez7im41sf7/cUjVeTzjVLw7hF98qHnUUTnUQ6dP0VZTmIvTafFdDp9rKK3luW9q97XhKH1qc7DtSGpmBOvqX3Oppt59U9OL8+GY1/oD5rrEnHjWe0hsg5/NSY7rNqTx/6/Pfb60zf/AAAA//8=
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.Invoices
{
    /// <summary>
    /// Invoice line item information.
    /// </summary>
    [DataContract]
    public class InvoiceItem
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public InvoiceItem() {}

        /// <summary>
        /// The date when the item or service was provided. The date format is *yyyy*-*MM*-*dd* *z*, as defined in [Internet Date/Time Format](http://tools.ietf.org/html/rfc3339#section-5.6).
        /// </summary>
        [DataMember(Name="date", EmitDefaultValue = false)]
        public string Date;

        /// <summary>
        /// The item description.
        /// </summary>
        [DataMember(Name="description", EmitDefaultValue = false)]
        public string Description;

        /// <summary>
        /// The cost as a percent or an amount value. For example, to specify 10%, enter `10`. Alternatively, to specify an amount of 5, enter `5`.
        /// </summary>
        [DataMember(Name="discount", EmitDefaultValue = false)]
        public Cost Discount;

        /// <summary>
        /// REQUIRED
        /// The item name.
        /// </summary>
        [DataMember(Name="name", EmitDefaultValue = false)]
        public string Name;

        /// <summary>
        /// REQUIRED
        /// The item quantity. Valid value is from -10000 to 10000.
        /// </summary>
        [DataMember(Name="quantity", EmitDefaultValue = false)]
        public double? Quantity;

        /// <summary>
        /// Tax information.
        /// </summary>
        [DataMember(Name="tax", EmitDefaultValue = false)]
        public Tax Tax;

        /// <summary>
        /// The unit of measure for the invoiced item.
        /// </summary>
        [DataMember(Name="unit_of_measure", EmitDefaultValue = false)]
        public string UnitOfMeasure;

        /// <summary>
        /// REQUIRED
        /// Base object for all financial value related fields (balance, payment due, etc.)
        /// </summary>
        [DataMember(Name="unit_price", EmitDefaultValue = false)]
        public Currency UnitPrice;
    }
}

