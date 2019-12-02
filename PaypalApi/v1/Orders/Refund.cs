// This class was generated on Tue, 30 Jan 2018 11:02:41 PST by version 0.1.0-dev+6beb51-dirty of Braintree SDK Generator
// Refund.cs
// @version 0.1.0-dev+6beb51-dirty
// @type object
// @data H4sIAAAAAAAC/+yY32/bthPA379/xUH9PjSBLKVbf81vAbqhwbolSNy9ZEV8ls4SF4pUyVMcYdj/PlCUZMty2xTNjD74yeDxSN/d53g88e9gVpcUTINLWlYqDcLgDzQCF5J+x8LJgzD4ler14A3ZxIiShVbBNDgF06wDNqgsJk4cBWFwagzWfueTMLgkTM+VrIPpEqUlJ/hYCUNpL7gwuiTDgmwwve5tOi10pXhsE3bytWW9aGjfLCcosS5IMXiVEFaCc0iJUUj7eLZaNkJlY1uTyhhSST2wdkM4tveac0M0SXI0mDAZOLs6nzz/4dkr6JZBolP68DROdWJjoZgyg26DOBWGEo4NWY475YlTtvFRBBdYX6CEVJMFpRlsVZbaMKCU3daCvi4kbKqtiKhKyn/CPiwXbfA9Snjjwz4OU9pPrKO0lo2DhGkq3ND549UAF7pi4BHx/55xJpZ8szJYDszflI4dcLPgZmFJFMFveC+KqgBJKuMchIVnJ9CngA1hlYskB6ESWaVkp39WJyc/JpVsfsmPpPCjK7ojBanIBFtY0FIbasKSUiIKlFBqoTjya+Ju0XCL2Veqr3T3f7h0KfvAv4s7B74R0VbSfYpTjiqVQmU3S6IBqq2JMa1O4QDLmezrBqWw1H51W1m6c1cQ5zoFrWQd7YesULYyqJIh1k3pmGk/e4A6gOqwfZ7snqDaXJSln1kz3RCOkXaTB6J7q6ldyG9SYZNRW7Zr9vPYoNM8nMjvr8zaasGaUQ4Zr4U70LaTbS/WuyKYChvB2bIZGfpYkeUeJUihWp0QOBcWSm9s7bLg+Ni0vhwfH075XsAz3g+Y+/EYN+P9gcgjEPnwECajk/jpYzg4gw5FRimw7r6WiGBR9wMTwS/atF/2NgRDpSFLim2j0u7COfLG+la721QbkQnli5Xb8JAT3/pN/ZCUSLDkytCNSIfPDZvicXKcvQHt67BFSZtPOY6mB7uvPn5o+BcN3vH6tCvVXm2k2iN78k6oW9gwEc4Xf1Gy49FKCnU7fN/oJFtPagrQmedcbO/FiSGJrhG4fns6+/n89Aqapd0LEJYi1ndk7gSt4ic5Mmm0k0blaMvbl4//+JEbWg4/pr1gjC3RRSmJ3S1hMmJ4f/kugpmGAm+ppendTFDK0KkvXBvgZtpWp3m6a/oB510IQsH1+8szYCpKt9S1FwXyh6c5c2mnccxaSxsJ4mWkTRbnXMjYLJOXL16dHEVw5qtN8w/z/89DmD+dh4AqhfnRfCNlmq6lNDQpjU7IWqGyCJxHc+fr3KWY2+KWaugAOV+1oq5ONjAA+xB4H70/6Jok60i72oxS7ums+ZgO0PWiMby3s9lFh6Frv1x52AlvTx4YGt5/frzjRdWF3xvYFLW6pC+myIufXr9+YqmpKZPnR90FZcnckQW0gMrVIZcZ2OD1oCuFxUJkla6srCFtTFmQzw9LBSoWie2ql1sWwRURXDdl5LK10K6tW61WkUCFjW1orciU6/1t7NZOOpe2h9G9c+Mo2lcr4u6N7UtnLfuubxzLyNWwLveiHZ8zzdTw9nmkKP/vXwAAAP//
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.Orders
{
    /// <summary>
    /// A refund transaction.
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
        /// The ID of the sale transaction to refund.
        /// </summary>
        [DataMember(Name="capture_id", EmitDefaultValue = false)]
        public string CaptureId;

        /// <summary>
        /// The ID of the refund transaction. Maximum length is 17 characters.
        /// </summary>
        [DataMember(Name="id", EmitDefaultValue = false)]
        public string Id;

        /// <summary>
        /// An array of request-related [HATEOAS links](/docs/api/overview/#hateoas-links).
        /// </summary>
        [DataMember(Name="links", EmitDefaultValue = false)]
        public List<LinkDescriptionObject> Links;

        /// <summary>
        /// The ID of the sale transaction to refund.
        /// </summary>
        [DataMember(Name="sale_id", EmitDefaultValue = false)]
        public string SaleId;

        /// <summary>
        /// The status of the refund.
        /// </summary>
        [DataMember(Name="status", EmitDefaultValue = false)]
        public string Status;
    }
}

