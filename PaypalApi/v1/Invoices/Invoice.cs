// This class was generated on Tue, 30 Jan 2018 11:02:40 PST by version 0.1.0-dev+6beb51-dirty of Braintree SDK Generator
// Invoice.cs
// @version 0.1.0-dev+6beb51-dirty
// @type object
// @data H4sIAAAAAAAC/+w9bXPbOI/f71dwsnNzbc91nHR3n2k/XTbpzmWuL7kkfe6l7diwBNu8UKRKUkl1N/ffn+GbLEpy6uax1W1XX3YbgKIBkAQBCID+7+C6zPHgxcE5vxU0wYPRwV9BUpgzfAOZQRyMDv4Ny/UfZ6gSSXNNBV8/RlLUQJkaH4wOTqSE0s06GR1cIqRvOSsPXiyAKTSATwWVmFaACylylJqiOnjxvqJnLgRD4G16gDFxN81BagpsmkOZIdcRkZtGNClPaQIaFblboV6hJHqFhHp+7ByKAPHTED/NmJwvyMxSPhtVo7NCaTJHkgNNCeVkUTDmRmpZmIEdUzcm/rtFxwvG/n+0rfw0zTtk5qBfIyfkZmplYUmhtMjMAEGQa5QEiKY5gUwUXJO0kJQvY0F2iEetnOBrTy4ospQoQfQKdPxTCfCO34pXqT57KlARLrT9mY5f2fEq/E4ZkhOtIVn5TdhcjQqn4vWI4PGKvKJKE7EgC+okD5qAROIewdSIv8Zyg6NfH34klTYL2OaBm//VifeAmOrrFRKDMJQb8ipyDRs7FvsmSgvJIkLd3206312+6iRzRO5WNFnZXTc3m+mOMwEp7mbbfKxx8BtlzJyWc74QbT7mDjulDrtmqIFocyY9FdWBkJjQnCLXBDOgjECaSlSKAE8J8JII+zQw4qcmZmqZgYGOyVWR50JqRQRnJRG8Nt/+9x2kKXXEtQXRxsWyOKnwdYZGRBXJioAi80JRbuSwEoXctW4+cTLu5MgjIk48LObgN1BI/ExEzP8HE00Khaml3q9VWEzK7U1mFS8RkuBnjTw1m1pIcrWieW5G+8l2d4dvWriE6jLi0QNiBk+pLq3G+CqCzI3yIN2QmEtAltNEpLE2ayBiIo8JQ22uHz+KmFH9EMwox6OI0gBpXhccyVHQZ2HHPMLlmPAim6McEaUloh4R1Mnj/og/bhF/3CL+bVA/Bk2OO7lQBdU4IpBr8pPlYfy4p/skXwkeb5YAibm4MFAvbXMYX46Pjp8Rp3b6IlUoDay9u2N4TPZ/09zuZ6syPhX0FphRIFSRQhXAWLm+TowicUeABptkBbdoFisbk9+FJMxbLY1RqbDmmB3saLE/qUjO0Gg4iQtnUa60zl8cHiIf39EbmmNKYSzk8tD8dXix5qIneSoNOpZkgGxUEClaMb27InaoGtlL1mznmnDNCGHN7EpQOzcuNvEULr1py6JrYtqGRdueSESWGwuiukq/Wpc/fHWsLRNxECDbUB5ZQuMPxWTyLJkzkdx8KoRG+7f7b6K0FHzpIG+ExhcOfFiH/4YLIZGUoiBL1ATIv1/azTCyIOs6JhJBIwFeEWPPhsoxoQtzVGafpMf8Sw5lDmyciIzMwDlem2w4yi16VrcKZ95WGJN3CgmsPan4UWvP0YUl8Q64tj6dHVF3LTy3Tdn0s8YLKpVub9UIvM1q2wf63JwM+LKAZUx2DdgmOiDNijoPxLi9djm8K6LQrVG0Hewap24t71bIG5uFQXJjPO0LKC+AEUisxulNCF2LV4dus3ZmfJ9Lx4WmC5pYZ2GarIBzjNXMhgFtXnJ7sZmrs/4I8Y/Ya6Cxlme4gILZ63f28vXJ+auZu1hnV6+vZiMCZGaNjxm5BVagGRZu5x0L58LbOA80hiz3NYOoB3/jQaa9obOy6sE5VPYSf3R6+nhk3KwUF5RjSualseh+/XlMzDMZfKZZkZn7b27RDPlSr4ztc3r6zxyC26nI0S8kpUu689jf5kCNd4md4BsxmyauK3zjaQ9+Q6cMTprjSCK4okorI4IKl6LSlPtdb8X65uz0sTWJVDE3P20e9TM8unrz+NtK92NkQV2A1DShOXTF9JKkHY9Yw2KxmgPs1ZpySnxeOs0+suEUIUlmrIfodja2s/AXgRbmsZQAOT19QRKRl8FHquuVZqSmOV3BU5QuJO24GqI3Q/RmiN4M0ZshejNEb4bozQ8fvand/N9N3KZOcxyx6cXdWcDnOO5g/x5cncHV+f5dnX0F3+pH9huE3b4+4lQneF+xpiGcMuiYQcd0yPcO54o2zLQ17P7D6sftnNZT+7qEnNiUsY6jYdHxoQigjuPgJvP5Z1oQyHNW2n9Ub4JsKlspCkJ5wooUCRAGc2S1t0drTDTh7hTBaSEl8qTsCHkEOdQiHgHUEfDwgQ5jJQNjZEE58IQC8yFriQy0TbVCliryaA4MeIKjKviRFuhdxP0rOc/zaUvJrYURc/is8hX8CHcO40N9fvWW/Hx89JeeVJSVa0R+gMS0+y1Y5GbzvXEHncBC+2zPFBOaAVNEYQ4StFm/NVuUV2xV7y0gz6XIJQWNsTx2EaD4uNVtP2+8mgmQL51DO273ikOoDn2RUpW0TlAN2HWFKm2EDyRHmfiIIPBAvF1e57LjZ8hyhiMbIrZvkktyNPnHkc+XnR1NZmNywjRKo+ZvkZXR0PWcYkF+qZ76ZTbolUGv/Ph6pbLbmma5O3WxYV7Bus/rKD6w/oz+FRhN1y9rF1JkZGLkdDSZ9GZj0TTixP7ZZuL8LIRuu5PK97XN/K9N02a0roFoU2wQ65yHkDhwB8pXLKTO/LXDXCTXrMGTsizLJ0+fvH795OmTNH1Cnvzvk1FjS74/N4qQoyZnoPHwmmZo1G0G+uMjH+XUQjA1pqgXNsa50hk7lIvk2bNnz39SmBgyn/4y/nXXce5Qi3OuMeuQpcYsfjcVIB2JFgZjtmIwLWkkxzE5WWcqJWAcDq7BvqYK/oRYmG3sJtr/u8TW/th2X2jMzP2pUN6G/ZFLcUvTH3KDbBRfTUyRFCN49zYhtUE7JncwmQaTaTCZBpPpD2YybV/uZvXjHiLGmwT9qQCum9kZNeAGCsOIbvk+PZpMJkHIOxLzmpVr+9aswYduvFrTXa/W4HNUijZo2EHD/mmDXdt5cRKVKKRxEM56e0OyrarU8HkP2WK7upEMdRL0phtoPJkcmb30/Pn4+fPnfS16wameisU0Q1CFjOXcxrWZMmOMoerHVLvZO3apvRx2bdJvVK6W4ly6FhQNRgJ4ULKDkt2Xkq2fuFeU35AaO+St3WWdeZA3qpkHedMdU/nXk+uXb0+uiB3hsud8qKHapWA9f9U8iWQOrozHt74wvOt1vwwNuughxoI8sSOi5KwK1uY3w5QC0WVeq1oyvnIxz6gmKWgIUSWJnwpUfaVSriQuIiY84N4uEGGF6otouCmU5U4Vc2WY4NqmNvSVgGBF3FqUOvS+ZWnmG1z+fkqOJz//OvKpneiSBlyJoWMY5BJ1b8zplUgbnHlQx+m6vr4gDh+ntdZXz6xNT9TLxstHueHVoyXNqBhfu+dEvDbV/P4z4h+Tq5UoWErm6EpDHKqqBrBLtJ6vzDFa3osLgCuzWVda5+rF4WGeA6jDVCTqUGngKchUHa7KHKXdI/3ISVPN4u0bIB1VkHYPGnRvvj4TSzFtdo2pAdtELgrGrOZwWRxmdaTNgBdLQWgGy10HA16jTFbAtW0V473hrtPkRrVrbZqYmKVq9iobuOZ0+95DeY4gVbifHvKGqH0r/8D1Q1syNG1nMGwa0WDOZTBU2m/WeGy2l05XQ1XUUBU1VEUNVVFDVdRQFfWjVEUF0+i7KYmqCH54PdQXtd9QDjWUKgylCjsph6qO63dRC1VROxRCDdpl0C49ahcNn6eNV7wV6J5zquFzf696v7ZYq6JyX5Vam+PKPt6VYbYhEuYxzbBKLuktaCRzIW5uEG18wQytIi1hgp1H+DSkoKEzRh4wUZQ8ABscFCnVUfxuHSB34eYeVCbwBBnDdDpvhEtiRHvDQKKFJHcrQdxQTHdK+rYRlYrMVs5xC7Uh+9g6SDTDeks+H+2/A1Vx1xdDtvVkeznq4DYjjWaRvlW6ayDofGA/wTdZI097e4VixAPXx00y7rPJpUKu2+y0cQ/jyFmfCvvt/Wjpbuy6BuIh+84ap64bZv87b01/a7FaqIetVcVenxwVedqlI9q4By8YpvQbKYuIie5Va2D/joVzbPYVHYUS5fSW4l3rDWYLFfP07vIVkZhLNBvNWDnaVteXKP9JEfPUPqrBPm6VJpZRbsz0qUsvmqaNXKRO9JA2NqSNfbvcXC4aOsUDmt6FAYcsEHvW+nLeO3z2za56wemnYp2Z5iMtoUeFyKjR6lRVnjy1r1ag0OIp5YlEc3rMwZIic5xKvKWiUM0ZdxxZ8sf2qsgykGWXrqTptCO/P4Z3tRxxExvlL3FR2CCD/Y0+ChLsO5WI3gAZVN6g8vav8jbvTPeRgqbN4UDD3hz2Zh9Z3EHpX6PMOneowU61w0b7tI7YrPPNgKYhHC7CUBE8M4Omusxx5ho2JcDt1wcDPi1cE4OZe3Fuq9BvUSrYfygu/HRcSF18dVOFIA+qzDkck2tz/9uh4bOYQBaFLqSbYGzL4n/4mvpq4eOwfQ3aUWZkdtS8DMnym2W8a38rHJUz+xXXjYdFdR2Uzd+nrLSz+zZss6xhdyULQ8nmcA99b27hg1uW1FrZGO/kT9Sm5OsqQsKZzHyynxs6JoEScke1U7Kzl/95/fLyzcmr2fpuL/MePym0RXwg5Iza1+BCm2OrREKtOqoYCZ9W7umGk8CVK1lrvZ1uojpbSlk1G74+VUl+/WjnWl2c/NfFN1qpOlftm72N7Ljg14N6JbxF7CYC61K1GfahzxPlS7Jg4s6pm/cSEyFDyOPjI1dFBDk9rEYf/hQ+azN1g5+6wY9DlZYKH6RpHEEfRrHisT9WLXkNY5Scn8An6s4hubkDmbpcTU3nlFFd9pZVYFN6kTeql+vQWNiXAWMrIdeVJxdvq9CZFgTSL3zNe++BMSdz7AyOtXFDgGww/gbjbwiQDXvzewiQXTp9vMnpd+padaj8zS6/V/GDxz8crMHj34PHH0yuP4TXH7fMnB1Pjn5+Ojl+evwXcnF1PftDuc/3OM1OpN+Lz+zfN3inOXhEW/rMddfqj+Z5Njiy3t85T2kCGpU5DLZ+cL1gVQCM6JUUxXIVZvCl4JLbYk46OLCxdqoq47u76yqPniYOXSsFbWDaSxhGdDTwhKWNwUUdd4eOjYMx8MMbA0N/0+G0DKdl6G869De9JxBR2STnrlnTJpuk1eepibnHJukqewuelcSE5hR3+cm0oR3S0A5paIc0tEMa2iEN7ZB+lHZIrevym/ZFeljLlTYP30XvlTbZu23C8nHL41Co1nko1L0U+/bU5D9WyG0G9HuFIJOVPQUhwvalAJx75HHtm7chgdoWGzlzFZT9AJMRRTM0/cFT+uHgBXn/4eDy5e/v3py9PPtw8HHXYeq5EAyBd/fwSIAlhfWKp9Ydm3Z+y+pLI2NZd8dIjUFPFVlPQ+a4ENIF4awnCCRMaZPWZ5a12ej+p5sPGdtg4zOt3+lR0va7dYreYrtpSg2zjSTtVxLsBwjCx/CU4bW3LPIsN9JsvSyI4Pe9KQgjnStXtWF3XQzi2oV3ChcF8/d8XpJFwRNnmu0qEL1d2rxqpcx3q5glcpTAbNq82u8HKjcHzbQwVklH6KyBGAJoQwDt2wXQCknjz6rYv7s+eXC+n9r+f/gbAAAA//8=
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.Invoices
{
    /// <summary>
    /// Invoice details.
    /// </summary>
    [DataContract]
    public class Invoice
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public Invoice() {}

        /// <summary>
        /// Indicates whether the invoice allows a partial payment. If `false`, invoice must be paid in full. If `true`, the invoice allows partial payments.
        /// </summary>
        [DataMember(Name="allow_partial_payment", EmitDefaultValue = false)]
        public bool? AllowPartialPayment;

        /// <summary>
        /// Indicates whether the invoice enables the customer to enter a tip amount during payment. If `true`, the invoice shows a tip amount field so that the customer can enter a tip amount. If `false`, the invoice does not show a tip amount field.
        /// </summary>
        [DataMember(Name="allow_tip", EmitDefaultValue = false)]
        public bool? AllowTip;

        /// <summary>
        /// List of files that are attached to the invoice.
        /// </summary>
        [DataMember(Name="attachments", EmitDefaultValue = false)]
        public List<FileAttachment> Attachments;

        /// <summary>
        /// The required invoice recipient email address and any optional billing information. Supports only one recipient.
        /// </summary>
        [DataMember(Name="billing_info", EmitDefaultValue = false)]
        public List<BillingInfo> BillingInfo;

        /// <summary>
        /// For invoices sent by email, one or more email addresses to which to send a CC: copy of the notification. Supports only email addresses under participant.
        /// </summary>
        [DataMember(Name="cc_info", EmitDefaultValue = false)]
        public List<Participant> CcInfo;

        /// <summary>
        /// The custom amount to apply to an invoice. If you include a label, you must include a custom amount.
        /// </summary>
        [DataMember(Name="custom", EmitDefaultValue = false)]
        public CustomAmount Custom;

        /// <summary>
        /// The cost as a percent or an amount value. For example, to specify 10%, enter `10`. Alternatively, to specify an amount of 5, enter `5`.
        /// </summary>
        [DataMember(Name="discount", EmitDefaultValue = false)]
        public Cost Discount;

        /// <summary>
        /// The ID of the invoice.
        /// </summary>
        [DataMember(Name="id", EmitDefaultValue = false)]
        public string Id;

        /// <summary>
        /// The date when the invoice was enabled. The date format is *yyyy*-*MM*-*dd* *z*, as defined in [Internet Date/Time Format](http://tools.ietf.org/html/rfc3339#section-5.6).
        /// </summary>
        [DataMember(Name="invoice_date", EmitDefaultValue = false)]
        public string InvoiceDate;

        /// <summary>
        /// The items to include in the invoice. An invoice can contain a maximum of 100 items.
        /// </summary>
        [DataMember(Name="items", EmitDefaultValue = false)]
        public List<InvoiceItem> Items;

        /// <summary>
        /// The HATEOAS links that provide related actions for the invoice based on the current invoice status.
        /// </summary>
        [DataMember(Name="links", EmitDefaultValue = false)]
        public List<LinkDescriptionObject> Links;

        /// <summary>
        /// The full URL to an external logo image.
        /// </summary>
        [DataMember(Name="logo_url", EmitDefaultValue = false)]
        public string LogoUrl;

        /// <summary>
        /// REQUIRED
        /// Merchant business information that appears on the invoice.
        /// </summary>
        [DataMember(Name="merchant_info", EmitDefaultValue = false)]
        public MerchantInformation MerchantInfo;

        /// <summary>
        /// A private bookkeeping memo for the merchant.
        /// </summary>
        [DataMember(Name="merchant_memo", EmitDefaultValue = false)]
        public string MerchantMemo;

        /// <summary>
        /// Audit information for the resource.
        /// </summary>
        [DataMember(Name="metadata", EmitDefaultValue = false)]
        public Metadata Metadata;

        /// <summary>
        /// Base object for all financial value related fields (balance, payment due, etc.)
        /// </summary>
        [DataMember(Name="minimum_amount_due", EmitDefaultValue = false)]
        public Currency MinimumAmountDue;

        /// <summary>
        /// A note to the payer.
        /// </summary>
        [DataMember(Name="note", EmitDefaultValue = false)]
        public string Note;

        /// <summary>
        /// The unique invoice number. If you omit this number, it is auto-incremented from the previous invoice number.
        /// </summary>
        [DataMember(Name="number", EmitDefaultValue = false)]
        public string Number;

        /// <summary>
        /// The payment and refund summary.
        /// </summary>
        [DataMember(Name="paid_amount", EmitDefaultValue = false)]
        public PaymentSummary PaidAmount;

        /// <summary>
        /// The payment term of the invoice. If you specify `term_type`, you cannot specify `due_date`, and vice versa.
        /// </summary>
        [DataMember(Name="payment_term", EmitDefaultValue = false)]
        public PaymentTerm PaymentTerm;

        /// <summary>
        /// List of payment details for the invoice.
        /// </summary>
        [DataMember(Name="payments", EmitDefaultValue = false)]
        public List<PaymentDetail> Payments;

        /// <summary>
        /// Reference data, such as PO number, to add to the invoice.
        /// </summary>
        [DataMember(Name="reference", EmitDefaultValue = false)]
        public string Reference;

        /// <summary>
        /// The payment and refund summary.
        /// </summary>
        [DataMember(Name="refunded_amount", EmitDefaultValue = false)]
        public PaymentSummary RefundedAmount;

        /// <summary>
        /// List of refund details for the invoice.
        /// </summary>
        [DataMember(Name="refunds", EmitDefaultValue = false)]
        public List<RefundDetail> Refunds;

        /// <summary>
        /// The shipping cost, as a percentage or amount value.
        /// </summary>
        [DataMember(Name="shipping_cost", EmitDefaultValue = false)]
        public ShippingCost ShippingCost;

        /// <summary>
        /// The shipping information for the invoice recipient.
        /// </summary>
        [DataMember(Name="shipping_info", EmitDefaultValue = false)]
        public ShippingInfo ShippingInfo;

        /// <summary>
        /// The invoice status. When you [search for invoices](/docs/api/invoicing/#invoices_search), you must specify this value as an array. For example, `"status": ["REFUNDED"]`.
        /// </summary>
        [DataMember(Name="status", EmitDefaultValue = false)]
        public string Status;

        /// <summary>
        /// Indicates whether the tax is calculated before or after a discount. If `false`, the tax is calculated before a discount. If `true`, the tax is calculated after a discount.
        /// </summary>
        [DataMember(Name="tax_calculated_after_discount", EmitDefaultValue = false)]
        public bool? TaxCalculatedAfterDiscount;

        /// <summary>
        /// Indicates whether the unit price includes tax.
        /// </summary>
        [DataMember(Name="tax_inclusive", EmitDefaultValue = false)]
        public bool? TaxInclusive;

        /// <summary>
        /// The ID of the template from which to create the invoice. Useful for copy functionality.
        /// </summary>
        [DataMember(Name="template_id", EmitDefaultValue = false)]
        public string TemplateId;

        /// <summary>
        /// The general terms of the invoice.
        /// </summary>
        [DataMember(Name="terms", EmitDefaultValue = false)]
        public string Terms;

        /// <summary>
        /// Base object for all financial value related fields (balance, payment due, etc.)
        /// </summary>
        [DataMember(Name="total_amount", EmitDefaultValue = false)]
        public Currency TotalAmount;

        /// <summary>
        /// The URI of the invoice.
        /// </summary>
        [DataMember(Name="uri", EmitDefaultValue = false)]
        public string Uri;
    }
}

