// This class was generated on Tue, 30 Jan 2018 11:02:41 PST by version 0.1.0-dev+6beb51-dirty of Braintree SDK Generator
// Capture.cs
// @version 0.1.0-dev+6beb51-dirty
// @type object
// @data H4sIAAAAAAAC/+xZ3W/bOBJ/v79ioN5DE8hSetevy1vQ3qLBdpsgcfclG8RjcSRxQ5EqScUxFv3fFxRF2bLcr21qLBZ+MjhD0jPzmy+O/oimy5qi4+gV1rbRFMXRr6g5zgW9w8oxojj6mZarxWsymea15UpGx9EJZP4gWI3SYOboSRRHJ1rj0t99FEcXhOxMimV0nKMw5AgfGq6J9YRzrWrSlpOJjq96qU4q1Ug7FgoDfSVaTxoKOC0JalxWJC34LTEsuC2BkUUuzMPJaqzmshjLmjVak8yWA2nXiGN5r2ypiSZZiRozSxpOL88mT//z5AWEY5ApRtePU6Yyk3JpqdDoLkgZ15TZVJOxadg8cZtNepDAOS7PUQBTZEAqC6apa6UtoBDhak7fZhKrmw2LyEaIj3FvlvPO+B5KeO3NPjYT6xkrK61oYyMhY9wtnT5+G+BcNRbsCPEfj3HBc3uz0FgPxF+njhVwXHBcyIkS+AXvedVUIEgWtgRu4MkR9C5gYliUPCuBy0w0jMzxb83R0X+zRrS/5FeC+9Ul3ZEExgtuDcwpVy4+SwJGGa9QQK24tIk/k4ZDwyum37h9ocL/Ye5c9iv/Lg0KfCdEG073KZxKlExwWdzkRAOoNhhjtMKGPVhOZJ83iEGu/Okus4S4q8iWioGSYpnsBlkuTaNRZkNY16ljTHvuHtQBqA62zyO7I1BNyevac1aYrhHHkAbmHtGd5dRg8hvGTTZqy7ZxPw8bhJ37iPz7pVnTzK2yKIYYr4hboO2YXS/Wq8ItVSaB07xdafrQkLE9lCC47PbEYEtuoPbCLp0XHB7qTpfDw32U7wR4i/cDzP16DLfF+z0iD4DI9ddgMorET4fhIAYdFAUxsCq8lohgvuwXOoGflAZNeSOZiUFTrcmQtKbd0t1iS7Rr57vd4VKlecGlT1buwr1PfO+b+mtcgrNh/8u2OsPpa1A+7/6A6c1GQnnL5S2siQBn898p2zLTEVzeDp//gbIxcpKATjynQlc2JpoEujp59eZk+v+zk0toj4YBCdY8VXek7zgt0kclWlJoJu2Wgw1tnz/8bKDUlA/fmp4whiVTVS3IuiSqC7Lw/uJtAlMFFd5SVyW9mhkKEbvtc1clHafrBNrJVlsunXYxcAlX7y9OwVJVu6Ou+lZorx+X1tbmOE2tUsIknGyeKF2kpa1EqvPs+bMXRwcJnPpgbP9h9u9ZDLPHsxhQMpgdzNaCty3qtaZJrVVGxnBZJOA0mjldZy7Y3RW3tIQAkNNVSQpppAUDsDeB19Hrg66HMA5pl7pQiB31Ot6mA+h60hi8N9PpeYAhdCcuF24Fb0caaBqWB7/eMnB05vcCugi1y5q+6CLP/vfy5SNDbcqYPD0I+duQviMDaAClyzPOM7CF1wPdSKzmvGhUY8QSWCvKnLx/GKpQWp6ZkJ3csQQuieCqTSMXnYRmJd1isUg4SmxlQ2N4IV1rbFJ3dhJU2lwm906Ng2RXlVoTGiVvMsVoA5B1+uZo3XPbWa83HpeMZ2g7c3Xs0FCvpXAw1gW7ymFWk2RcFjNQGmaa7kgbYrNdvRYs2maY03vSlpdCEHo3henVagS/2Vet/nM0KBzzxorM0dBqVK/aeucDQQjIuUSZcRRwh6KhvnTlnAQzvvGie3RpMIY5CpQZxf2LjzXkE7BR8JAfWr708eLVpuf+Yz5g/HXvbvEbGCVQtnyt6D49NbWrCYfvDj/dTRqqUaNVOnZZlFHOJbG2kgcrfqvd+hSBtXtFa+7ibIBE8iDt6fXHf/0JAAD//w==
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.Orders
{
    /// <summary>
    /// A capture transaction.
    /// </summary>
    [DataContract]
    public class Capture
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public Capture() {}

        /// <summary>
        /// The payment amount, with details.
        /// </summary>
        [DataMember(Name="amount", EmitDefaultValue = false)]
        public Amount Amount;

        /// <summary>
        /// The ID of the capture transaction.
        /// </summary>
        [DataMember(Name="id", EmitDefaultValue = false)]
        public string Id;

        /// <summary>
        /// An array of request-related [HATEOAS links](/docs/api/overview/#hateoas-links).
        /// </summary>
        [DataMember(Name="links", EmitDefaultValue = false)]
        public List<LinkDescriptionObject> Links;

        /// <summary>
        /// A reason code that indicates the reason for the transaction state of `pending` or `reversed`.
        /// </summary>
        [DataMember(Name="reason_code", EmitDefaultValue = false)]
        public string ReasonCode;

        /// <summary>
        /// The state of the capture transaction.
        /// </summary>
        [DataMember(Name="status", EmitDefaultValue = false)]
        public string Status;

        /// <summary>
        /// The base currency object for all financial value-related fields. For example, balance, payment due, and so on.
        /// </summary>
        [DataMember(Name="transaction_fee", EmitDefaultValue = false)]
        public Currency TransactionFee;
    }
}

