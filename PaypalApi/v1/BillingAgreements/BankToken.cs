// This class was generated on Tue, 30 Jan 2018 11:14:21 PST by version 0.1.0-dev+6beb51-dirty of Braintree SDK Generator
// BankToken.cs
// @version 0.1.0-dev+6beb51-dirty
// @type object
// @data H4sIAAAAAAAC/7ySQW/aQBCF7/0Voz2BZKGefXMLh6pSiwr0UlXW2DuGFetZd3YXakX892hNAoEoRFGk3Oy3zzvfG787tew7Urn6gryFpdsSq0z9RjFYWfqBbTpTmfpO/fllSr4W0wXjWOWqgJA+g8YJIFTpnhpFT+ArMlQE0ZOG4KCJrAGhw74lDhOVqUIE++P8z5n6Rah/su1V3qD1lIR/0QjpkzAX15EEQ17lf07kPojh9XPqRFIafQF/1i4zLDcE36bgGggbgh1GG0g/yfIW2CDxipWjtYfsVWD6H0gYbVlHH1xLck3/guFWlEcn7DcO3J79oH5wsBZZY6BSqCEhrqnk2FYkF+FumG4F1EaoDqCpMgEe7kht26E16XkCi9h1TtL/dGz7oaYLw2tLMIviYH7so4dCCGG0mM2L8XFBWNcuphPDw6hk7wgZVmwcw2i2Gr+3xcMC/x4+3QMAAP//
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.BillingAgreements
{
    /// <summary>
    /// A token for a bank card. Can be used to fund a payment.
    /// </summary>
    [DataContract]
    public class BankToken
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public BankToken() {}

        /// <summary>
        /// REQUIRED
        /// The ID of the vaulted bank card.
        /// </summary>
        [DataMember(Name="bank_id", EmitDefaultValue = false)]
        public string BankId;

        /// <summary>
        /// REQUIRED
        /// The ID of the customer who owns the bank card.
        /// </summary>
        [DataMember(Name="external_customer_id", EmitDefaultValue = false)]
        public string ExternalCustomerId;

        /// <summary>
        /// The ID of the direct debit mandate to validate. Supported only for Single Euro Payments Area (SEPA) bank accounts in the European Union (EU).
        /// </summary>
        [DataMember(Name="mandate_reference_number", EmitDefaultValue = false)]
        public string MandateReferenceNumber;
    }
}

