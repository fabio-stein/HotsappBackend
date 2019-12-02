// This class was generated on Tue, 30 Jan 2018 11:14:21 PST by version 0.1.0-dev+6beb51-dirty of Braintree SDK Generator
// OverrideChargeModel.cs
// @version 0.1.0-dev+6beb51-dirty
// @type object
// @data H4sIAAAAAAAC/6yUYWsTTxDG3/8/xbCv/sLlTkUQ8q5YhCptii2ClNJOdudyg3u719ndxEP87rJ3yTUxiop9mcns7Dy/57n9qq77jtRcLdYkwobgTYOyIjj3hqwq1EcUxqWlC2xzmyrUe+off5xS0MJdZO/UXJ2AHk+3+TTEBiP47eAAhmpMNu562NVeWsxHwSRhtwJcCVFLLoIWGv4pVaFORLAf13xeqA+EZuFsr+Y12kC58JBYyEyFS/EdSWQKan4zCTz3jnqIfUew4diATiLkdA/aG4KHhJZrJgNrtImOhWPrk4sH8qfSjxCGS2ovgNZCzQ6dZrTj5JmQxUgGaiZrQglvvQB9wbazVMASLTpNBXTYDxxMogLQGQge/pJGlPRLGCFm3scqd1AOdO4VD5VeNwQ3sRGiWfYUdSSBs6vF7NXLF68PAd/+38TYhXlVGVqTzTuVHfYd2lL7tjJeh4pdpJUMtleGhXSshEKsdoNmeVConv0jBZes/Vb8FsUuB48cdpVjCJPUoaWEc141EZYE6GBQRTLkYdvHFMDyZ4L7d5ef7sfPBIXA+Zizwxqt7aHOQNk7tJCjBCPozqImMKS5RTv1/Hz69cXp3vSQlobXbMjknTzExqeAzsRmm8LYEMgWHLjULknA19Ndw81hzPWhuQUEIrg5u1pAdn70el5Vm82m5OBLL6uKg68a31IVIjqDYsLk693ga9nE9kmsvf0Dc8cn6I7NYdD3qscmn51mGhnS/iP3NBv/9x0AAP//
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.BillingAgreements
{
    /// <summary>
    /// A charge model that overrides default charge information during agreement creation.
    /// </summary>
    [DataContract]
    public class OverrideChargeModel
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public OverrideChargeModel() {}

        /// <summary>
        /// REQUIRED
        /// A type for all financial value-related fields. For example, balance, payment due, and so on.
        /// </summary>
        [DataMember(Name="amount", EmitDefaultValue = false)]
        public MoneyTypeWithCurrencyCodeQualifiedValue Amount;

        /// <summary>
        /// REQUIRED
        /// The ID of the charge model.
        /// </summary>
        [DataMember(Name="charge_id", EmitDefaultValue = false)]
        public string ChargeId;
    }
}

