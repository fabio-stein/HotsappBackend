// This class was generated on Tue, 30 Jan 2018 11:02:44 PST by version 0.1.0-dev+6beb51-dirty of Braintree SDK Generator
// ItemDetails.cs
// @version 0.1.0-dev+6beb51-dirty
// @type object
// @data H4sIAAAAAAAC/+yaX4/bNgzA3/cpCAPDWiB/2m3Y0Hs7tBvQDWuLrRgwdEXCSEzMVZZcib5LMOy7D/KfXBzbbYdd7+X0dLBIWSRN/sSL9Hf2+lBSdpE9FyrgGQmyCdks+x0948bQCyyiNJtlP9Ph5uEZBeW5FHY2u8he5wQc5+tm/iKbZZfe46F596NZ9iuhfmnNIbvYogkUB95X7EkfB155V5IXppBdvDla9YuzdBiag/qvKkhBVlZYuMpKz74x6dBgVXlPVh0ArYZGD7bOA8KWLVrFaOAKTUVzTwaFNGyZjF7Aj84D7bEoDc1ggwatInAeSjzENUFXdHsBCOLZ7oYR6KxfKaep5/25ZOj5G8k90Vzl6FEJeXj+28v5t18//v4mJnHu2wdL7VRYshXaeYwvWGr2pGTpKciyU55H5bB8CJKjAGuywlumAHIS5f8UEfHVWUBsZcw/s49Gpf5evWh0I8Mo1JIZXOescih4lwts6OLP6tGjb1Rl6r/UPBluni4t1LEgXydK61r01PA7gvVPr/5YN0FAT2CdgBxKVmjMAbYx1OwsmkXz0mX31rM1QJPiAs1xxvhar188O1krVBvNV6xJRwsdSO6qgFZLHsaXW3YexmSO38m3wQdbFRvy4LZHQ0qDikJbG70MmUEggjdPT8cCzGM+Qcyntw9ykTJcLJfX19cLDm7h/G7JwdXZNu8n0CKXwjy8jTx5e5IpEwDZYGC1CjmXJdvdGESmNBJIEkgSSO4fSJ7mpN65SuBl8+2HhdQqrFytEPq1NBT2E+nSAkZrY7w6ZWiVF/ADqrx9ghwDIFgsqAZOnX1nzn73GTDRd2AV1/+Qh53CCC773tWedNXD0bUjTjgIqxgQtHV7OYNQqRwwwFo54/w6wnIttJfK0/r/ovITyXDu55AUUxofD0XzLfv7gozode53sIH1xlTUhMOTXsdoGhqf2oXrZHIonJO8nc5laUjfTjQ/YSPWHFTcMce24KEsbb5p802bb+ri27SgvXj8YBc/pZFAkkCSQJJA0qbFjreyuvZYjjFkRJjwkfCR8JHw0aZFjlabiQ5kKEvwSPBI8EjwaNOCbah8LNwxeowIEz4SPhI+7h8+pjKF7ZVjRavG3TN6nIlGrm00Km2wFnBpAU2Zo60K8qygWXVQEAgbNrGtaYNZkFc5WrnlH+GnkClUjNKyN55AmUCZQJlA2aPGoHZORwdHsvWltigcAWCHvK8C7JzTIfIgkL9iRXd0FFmbrk9sHvjVF05e2jsO36XhgxPk09EJU6P0Lm0cO8o/E0xYejy6b+QbCt0JrMrjhhvA2boKyyqmUaBYftLNZgvBFdTep7xLj99XaIXlMHT5RDL0+QYhnT8aKssS4tCxPPAzFciH2oRoxar0rEaSrSdL7UJqF1K7cP/aBcH9ME0E9+0/En3498enr3AJ7ltiBDB0xaRhcwCEnbsib2sIjPD/vI8It3evawKRN/5MuJnAmMCYwHiPwPgp/0lFPJTkFVnBHQ3I0RMNs+dGPIP6LuuW96TnpWMrMwi8s6SPEex+l+qRQ9OWLQHC4yeLJ0++rFMr1hV4FKrvh9aC9d20meIEzWrqN6kxaSJqImoi6v0h6hf/AgAA//8=
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.Sync
{
    /// <summary>
    /// The item details.
    /// </summary>
    [DataContract]
    public class ItemDetails
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public ItemDetails() {}

        /// <summary>
        /// The currency and amount for a financial value-related field. For example, balance or payment due.
        /// </summary>
        [DataMember(Name="adjustment_amount", EmitDefaultValue = false)]
        public Money AdjustmentAmount;

        /// <summary>
        /// The currency and amount for a financial value-related field. For example, balance or payment due.
        /// </summary>
        [DataMember(Name="basic_shipping_amount", EmitDefaultValue = false)]
        public Money BasicShippingAmount;

        /// <summary>
        /// An array of checkout options. Each option has a name and value.
        /// </summary>
        [DataMember(Name="checkout_options", EmitDefaultValue = false)]
        public List<CheckoutOption> CheckoutOptions;

        /// <summary>
        /// The currency and amount for a financial value-related field. For example, balance or payment due.
        /// </summary>
        [DataMember(Name="discount_amount", EmitDefaultValue = false)]
        public Money DiscountAmount;

        /// <summary>
        /// The currency and amount for a financial value-related field. For example, balance or payment due.
        /// </summary>
        [DataMember(Name="extra_shipping_amount", EmitDefaultValue = false)]
        public Money ExtraShippingAmount;

        /// <summary>
        /// The currency and amount for a financial value-related field. For example, balance or payment due.
        /// </summary>
        [DataMember(Name="gift_wrap_amount", EmitDefaultValue = false)]
        public Money GiftWrapAmount;

        /// <summary>
        /// The currency and amount for a financial value-related field. For example, balance or payment due.
        /// </summary>
        [DataMember(Name="handling_amount", EmitDefaultValue = false)]
        public Money HandlingAmount;

        /// <summary>
        /// The currency and amount for a financial value-related field. For example, balance or payment due.
        /// </summary>
        [DataMember(Name="insurance_amount", EmitDefaultValue = false)]
        public Money InsuranceAmount;

        /// <summary>
        /// The invoice number. An alphanumeric string that identifies a billing for a merchant.
        /// </summary>
        [DataMember(Name="invoice_number", EmitDefaultValue = false)]
        public string InvoiceNumber;

        /// <summary>
        /// The currency and amount for a financial value-related field. For example, balance or payment due.
        /// </summary>
        [DataMember(Name="item_amount", EmitDefaultValue = false)]
        public Money ItemAmount;

        /// <summary>
        /// An item code that identifies a merchant's goods or service.
        /// </summary>
        [DataMember(Name="item_code", EmitDefaultValue = false)]
        public string ItemCode;

        /// <summary>
        /// The item description.
        /// </summary>
        [DataMember(Name="item_description", EmitDefaultValue = false)]
        public string ItemDescription;

        /// <summary>
        /// The item name.
        /// </summary>
        [DataMember(Name="item_name", EmitDefaultValue = false)]
        public string ItemName;

        /// <summary>
        /// The item options. Describes option choices on the purchase of the item in some detail.
        /// </summary>
        [DataMember(Name="item_options", EmitDefaultValue = false)]
        public string ItemOptions;

        /// <summary>
        /// The number of purchased units of goods or a service.
        /// </summary>
        [DataMember(Name="item_quantity", EmitDefaultValue = false)]
        public string ItemQuantity;

        /// <summary>
        /// The currency and amount for a financial value-related field. For example, balance or payment due.
        /// </summary>
        [DataMember(Name="item_unit_price", EmitDefaultValue = false)]
        public Money ItemUnitPrice;

        /// <summary>
        /// An array of tax amounts levied by a government on the purchase of goods or services.
        /// </summary>
        [DataMember(Name="tax_amounts", EmitDefaultValue = false)]
        public List<Tax> TaxAmounts;

        /// <summary>
        /// The percentage, as a fixed-point, signed decimal number. For example, define a 19.99% interest rate as `19.99`.
        /// </summary>
        [DataMember(Name="tax_percentage", EmitDefaultValue = false)]
        public string TaxPercentage;

        /// <summary>
        /// The currency and amount for a financial value-related field. For example, balance or payment due.
        /// </summary>
        [DataMember(Name="total_item_amount", EmitDefaultValue = false)]
        public Money TotalItemAmount;
    }
}

