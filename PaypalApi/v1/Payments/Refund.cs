// This class was generated on Mon, 09 Apr 2018 18:07:49 UTC by version 0.1.0-dev+291f3f of Braintree SDK Generator
// Refund.cs
// @version 0.1.0-dev+291f3f
// @type object
// @data H4sIAAAAAAAC/+xZ32/bthN///4VB/X70ASylC79mbcA3dBg3RokboEhC+yzdLa4UKRKnuIIQ//3gaJkS5bbpmjm9cFPBo9H6u4+x+OH57+DcVVQcBIYmpcqDcLgAxqBM0m/Y+7kQRj8StV68JpsYkTBQqvgJBhnBCkxCmlhrg0g+H2ADSqLiVOLgjA4NQYr/6WjMLggTN8pWQUnc5SWnOBjKQylK8G50QUZFmSDk6uVjZjrUvHQxpV8belKNLS3wConxeBVQlgKzlonHs5Wy0aoxdDWpDSGVFL1rO0Ih/ZecWaIRkmGBhMmA2eX70ZPf3ryAtplkOiUrh/HqU5sLBTTwqDbIE6FoYRjQ5bjVnnklG18EME5VucoIdVkQWkGWxaFNgwoZbu1oG8LCZtyIyKqlPJTuAHhpAn3MDzriXV01rJhcDBNhRs6P5o8xJkuGXiA9L+P7ULMebI0WPTM70qHDrhZcLMwJ4rgN7wTeZmDJLXgDISFJ0ewgt6GsMxEkoFQiSxTsid/lkdHx0kp61/yIyn86JJuSUEqFoItzGiuDdVhSSkROUootFAc+TVxu6i/xfgb1Ze6/R7OXare83Nx68B3QrSRbJ/DKUOVSqEWkzlRD6qNiSFarcIeLGeyrxeU1qXfrW4qSnvucuJMp6CVrKLdICuULQ2qpA9rVzrEdDW7B7UHqoPty8juCFSbiaLwM2tMO8IhpO3kHtGd1dQ25JNU2GRAx7bNfhk2aDX3J/LHK7O2nLFmlH2M18It0DaTDRdbuSKYchvB2bweGfpYkuUVlCCFanRC4ExYKLyxlcuCw0PT+HJ4uD/lOwGe8a6HuR8P4Wa82yPyAIhc3weTwUn8/DHsnUEHxYJSYN2+lohgVq0GJoJftGle9DYEQ4UhS4ptrdLswhlyZ32j3W6qjVgI5YuV23CfE9/7lr5PSiRYcGloItJ+m6ErHibH2WvQvg5blNRt4cCM3LXssaVd8b7EEDJNWOR9Ot+Xb2lIIROgSsFpwDIj1VwudWdqiRb8DmkIQsHVmWIyinhj3VybHPn6ccZc2JM4Zq2ljQTxPNJmEWecy9jMk+Pj41ePLNVhGj2Lnh/sKDhpx+1+s6QrHwaniUJHbVdPs34ufjUHH76ReO835K0WCU1Umc/IbDwkN6b6DvyhSwN6qaDRA0dyDCY37vCcvQa/LIIPKEtytQ/BG+F8tkItJI1mlUtCWWSoypyMSDrV8YEDIIW6mXQSYaJnf1Gypb/qFPstuVbS9/9UATrznDsNlRsZku6owdWb0/HP704voV7aNiuxELG+JXMraBk/ypBJox3VKpsH6fnD9+syQ/N+/8cLhmmZ6LyQxI7YmAUxvL94G8FYQ4431GSrdzNBKUOnPnPM1c007LzuMtcU9ur9xRmMKS/cipEvM0zpVyvN82cvjg7q8Pl7uTA0KoxOyLrUCds7s/7o9P/TEKaPp2Fdz6YH024WgfNo6nyduiR0+jdUQQuQ81Uraq/2GgzAVQi8j94fdLzeOqQdnUApd3REfUx70K1EQ/DejMfnLQzti8Hxk63g7cgDQ33K5sdbmv8u/N5Adw9zVdBXE+XZq5cvV1fS04OWU1kyt2QBLaBy1cj/X1PvXwNdKsxnYlHq0sqquSBm5PPDUo6KRWLb6uzT8JIIrt66HS4aC+3auuVyGQlUWNuG1oqFcs9VG7u1o9alzWF059x4mFv0PlSpQEOKJ81buofJYOpL11X7GNeqCXd91rscSliYod0ZezKEdoMbrETbaIGbWpP5TcP/C/7nWOgmhV3Lfnz+ahm5z1xbyZb+iJvpU58dWVkW6VaW3Zd/A8u2ujQJ1TxbomXwG/3AZPv60//+AQAA//8=
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.Payments
{
    /// <summary>
    /// The details for a refund transaction.
    /// </summary>
    [DataContract]
    public class Refund
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public Refund() {}

        /// <summary>
        /// The payment amount, with details.
        /// </summary>
        [DataMember(Name="amount", EmitDefaultValue = false)]
        public Amount Amount;

        /// <summary>
        /// The ID of the sale transaction being refunded.
        /// </summary>
        [DataMember(Name="capture_id", EmitDefaultValue = false)]
        public string CaptureId;

        /// <summary>
        /// The date and time when the refund was created, in [Internet date and time format](https://tools.ietf.org/html/rfc3339#section-5.6).
        /// </summary>
        [DataMember(Name="create_time", EmitDefaultValue = false)]
        public string CreateTime;

        /// <summary>
        /// The refund description.
        /// </summary>
        [DataMember(Name="description", EmitDefaultValue = false)]
        public string Description;

        /// <summary>
        /// The ID of the refund transaction.
        /// </summary>
        [DataMember(Name="id", EmitDefaultValue = false)]
        public string Id;

        /// <summary>
        /// Your own invoice or tracking ID number. Value is a string of single-byte alphanumeric characters.
        /// </summary>
        [DataMember(Name="invoice_number", EmitDefaultValue = false)]
        public string InvoiceNumber;

        /// <summary>
        /// An array of request-related [HATEOAS links](/docs/api/overview/#hateoas-links).
        /// </summary>
        [DataMember(Name="links", EmitDefaultValue = false)]
        public List<LinkDescriptionObject> Links;

        /// <summary>
        /// The ID of the payment on which this transaction is based.
        /// </summary>
        [DataMember(Name="parent_payment", EmitDefaultValue = false)]
        public string ParentPayment;

        /// <summary>
        /// The reason that the transaction is being refunded.
        /// </summary>
        [DataMember(Name="reason", EmitDefaultValue = false)]
        public string Reason;

        /// <summary>
        /// The ID of the sale transaction being refunded.
        /// </summary>
        [DataMember(Name="sale_id", EmitDefaultValue = false)]
        public string SaleId;

        /// <summary>
        /// The state of the refund.
        /// </summary>
        [DataMember(Name="state", EmitDefaultValue = false)]
        public string State;

        /// <summary>
        /// The date and time when the resource was last updated, in [Internet date and time format](https://tools.ietf.org/html/rfc3339#section-5.6).
        /// </summary>
        [DataMember(Name="update_time", EmitDefaultValue = false)]
        public string UpdateTime;
    }
}

