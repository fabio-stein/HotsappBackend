// This class was generated on Tue, 30 Jan 2018 11:02:44 PST by version 0.1.0-dev+6beb51-dirty of Braintree SDK Generator
// IncentiveDetails.cs
// @version 0.1.0-dev+6beb51-dirty
// @type object
// @data H4sIAAAAAAAC/7xV32sUMRB+968Y8tTC3m39AcK9FYtQxbZoEaQe7VwyexvMJutk0nOR/u+S+9m7PWvF4tOSzGTm+758mf2pLruW1Eidek1e7C3BCQlaF1WhPiNbnDg6wyanqEK9p26zOKGo2bZig1cjdVkT2HURsygyVIU6ZsZu0eWoUB8Jzbl3nRpV6CLlje/JMpn1xgWHllgsRTW6WuP7EDx1fUzrjtfYhORlC+OeYB+zTszkdQfoDSzyoAoMCJX16LVFB7foEg2YHAoZqCw5M4S3gYF+YNM6KmCCDr0mCAwtdg15AZPo6ehHYeunff4r9Nc6GNoivxvpM7+SmokGukZGLcRw+ul88OrF89cbTfLZ8UFpgo6l9UJTxlygNJZJS8kUpVwlD3JyLA9BahSwJktfWYog91T+K0WE044gPjl3V/xRlfl9bamx2umrMI8UMKutrqGx01pgQqOv6ejopU5u/qXFytnF6tjDXAviuVGW1DJTZ78R3Ly7+HKzEAGZwAcB6Vqr0bkOqiy1DR7dcFG0XFXd6QGGtG3QrU/s73V5dnKvV0wTY2+tIZMRBpA6pIjeSB33tytXDLOZ8z3xUnzwqZkQQ6jWQFqHmuLybWw5pIBIBFdv7u9FGGQ/QfbT+KAWaeOoLGez2dDGMAw8LW0Mc7cNtg00rKVxh0/hk/EjnLIZEb0H1AvtmR3BUM/u6DdzsICYdA0Ys2QhtcH/60h45AvYgG85TBmbh/jtpDw015epv2EODbGu0Qu40KGTLs/D3uH/LoHkxP3Ul6E+5RzI7t97lbGl+X8hVFV+I/yUdzu+e/YLAAD//w==
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.Sync
{
    /// <summary>
    /// The incentive details.
    /// </summary>
    [DataContract]
    public class IncentiveDetails
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public IncentiveDetails() {}

        /// <summary>
        /// The currency and amount for a financial value-related field. For example, balance or payment due.
        /// </summary>
        [DataMember(Name="incentive_amount", EmitDefaultValue = false)]
        public Money IncentiveAmount;

        /// <summary>
        /// The code that identifies an incentive, such as a coupon.
        /// </summary>
        [DataMember(Name="incentive_code", EmitDefaultValue = false)]
        public string IncentiveCode;

        /// <summary>
        /// The incentive program code that identifies a merchant loyalty or incentive program.
        /// </summary>
        [DataMember(Name="incentive_program_code", EmitDefaultValue = false)]
        public string IncentiveProgramCode;

        /// <summary>
        /// The type of incentive, such as a special offer or coupon.
        /// </summary>
        [DataMember(Name="incentive_type", EmitDefaultValue = false)]
        public string IncentiveType;
    }
}

