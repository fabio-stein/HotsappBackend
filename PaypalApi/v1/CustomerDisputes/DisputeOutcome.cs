// This class was generated on Sun, 08 Apr 2018 17:47:21 UTC by version 0.1.0-dev+291f3f of Braintree SDK Generator
// DisputeOutcome.cs
// @version 0.1.0-dev+291f3f
// @type object
// @data H4sIAAAAAAAC/6xV227jRgx971cQeukuYFvpBSjgN9fWomnT2EicFEEaeOkZKhp0NKNyqLhC0X8vxpKdOMrmguyTMDeew8ND6t9k2VSUjJOZCVUtBPNalC8pGSSXyAbXlk6xjBeSQfIbNfeLGQXFphLjXTJOlgWBb5+CzwFBt/FGySCZMGPTwhwNkjNCPXe2ScY52kBx4+/aMOn9xoJ9RSyGQjK+3hP83Ttq+rSw9LWTFVNeO036gGX/rE9a1czkVAPoNLQPIPcMCLlx6JRBC3doaxoyWRTSkBuyegSfPAP9g2VlaQBrtOgUgWeosCnJCej6KyYfhI277We/Y79SXtNB7o9P+plfS8FEQ1UgoxJiOD6fD3/8/ruf7jWJb28+pNqrkBondMsYA6TaMClJmYKku8vDeDmkH0EKFDCanJjcUAB5oPKbFBGuHwniamv/G7yoyrZeB2rsdvoqbE8GsCmMKqA0t4XAmsZ/1kdHP6jabr/UrqxpVxMHWy2It0bpUouZWvMXwedfF1efWxGQCZwXkKYyCq1tII9SG+/Qjtqg6S7qIwzQpEyJdv/iaazl6ewBVqjX2twZTToy9CCFrwM6LUV4Gi7dZRjNHOvEnfjg6nJNHFt5R6SyqCh0vXHgkAEEIriePtwLMIx+guinmw+FSBXGabrZbEYm+JHn29QEv3Xb8NBAo0JK+/Fr+OTmFU7pRla/fR4dvDDsmIK3d6T3Uw8uo63AhGed1K4iRLs+y87nJ5fZbPXzxVV2tvo0uZxfnHWVur81gojfIcEGwz28cV23BfEl8bcBcrzz/LzXvsjiPDs5eQ+NklgV6OSdNP44Xv6yWkyu5hfLJ0gssFlEd7Jvjf8QGLYt02oBGyNFvCbU9lOc91uxMMRC7dm/jeV0cjrNTmLJrtqqfUGnPQ0V/xO2I7qzy5sgJ9Nptlhms1dUBJWiSt6a0yw7PX5VeE3OvBQ8Kytp+k/jWHxe8f1seudPtJsF3/wPAAD//w==
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.CustomerDisputes
{
    /// <summary>
    /// The outcome of a dispute.
    /// </summary>
    [DataContract]
    public class DisputeOutcome
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public DisputeOutcome() {}

        /// <summary>
        /// The currency and amount for a financial value-related field. For example, balance or payment due.
        /// </summary>
        [DataMember(Name="amount_refunded", EmitDefaultValue = false)]
        public Money AmountRefunded;

        /// <summary>
        /// The outcome of a resolved dispute. Value is:<ul><li><code>RESOLVED_BUYER_FAVOUR</code>. The dispute was resolved in the customer's favor.</li><li><code>RESOLVED_SELLER_FAVOUR</code>. The dispute was resolved in the merchant's favor.</li><li><code>RESOLVED_WITH_PAYOUT</code>. PayPal provided the merchant or customer with protection and the case is resolved.</li><li><code>CANCELED_BY_BUYER</code>. The customer canceled the dispute.</li><li><code>ACCEPTED</code>. The dispute was accepted.</li><li><code>DENIED</code>. The dispute was denied.</li><li>Empty. The dispute was not resolved.</li></ul>
        /// </summary>
        [DataMember(Name="outcome_code", EmitDefaultValue = false)]
        public string OutcomeCode;
    }
}

