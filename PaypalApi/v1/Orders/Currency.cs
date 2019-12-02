// This class was generated on Tue, 30 Jan 2018 11:02:41 PST by version 0.1.0-dev+6beb51-dirty of Braintree SDK Generator
// Currency.cs
// @version 0.1.0-dev+6beb51-dirty
// @type object
// @data H4sIAAAAAAAC/6TSUYsTMRAH8Hc/xZAnPdJbFUHom5wIItwVPXwp9zBN/tuOZJM4mRUXue8uW69XSgU5fNzZYZL/b/LL3U4VbumuRlXkMDnvvrIKbxKueZj/OO8+YTp+vEcLKtWkZLd0tzvQhhsoPAygsvmGYNQXJU6Jesmcg3CiH5xGLBSJDZF6QYrtkj4UJfzkoSZ42nDiHOCp8jQgG8URnjhHaoVKvnTevVPl6c+lX3r3GRxvcprcsufUMBe+j6KIj4WVlgo1QXPL9WPcZip5ex72kOKqRJwED0efc4C17RRYhB0rB4PSxy83izevX709qoQScfe8iyW0TrJhqzwP6KIognWKZt2heTE3t+7FJa14WnGiWNAoF6M21lrU9rAP3YL2vyx5TOne/9Nmv78TlEPlXISHMmbzNFayQhfXFxRlK9aI+9nHdqCIIAMnaqisbEU9caOIXjIiSab1QfGpbvu3Nx/BtWqpKmw43cSTxEzHv4Hd3T/7DQAA//8=
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.Orders
{
    /// <summary>
    /// The base currency object for all financial value-related fields. For example, balance, payment due, and so on.
    /// </summary>
    [DataContract]
    public class Currency
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public Currency() {}

        /// <summary>
        /// The [three-character ISO-4217 currency code](/docs/integration/direct/rest/currency-codes/). PayPal does not support all currencies.
        /// </summary>
        [DataMember(Name="currency", EmitDefaultValue = false)]
        public string CurrencyCode;

        /// <summary>
        /// REQUIRED
        /// The amount, up to *N* digits after the decimal separator, as defined in [ISO-4217](/docs/integration/direct/rest/currency-codes/) for the appropriate currency code.
        /// </summary>
        [DataMember(Name="value", EmitDefaultValue = false)]
        public string Value;
    }
}

