// This class was generated on Tue, 30 Jan 2018 11:14:21 PST by version 0.1.0-dev+6beb51-dirty of Braintree SDK Generator
// Terms.cs
// @version 0.1.0-dev+6beb51-dirty
// @type object
// @data H4sIAAAAAAAC/+xW72vcOBD9fn/F4E8X8Np3x8HBfjsuHGxLk9CEQglhGUuzK7Wy5GpG2ZrS/73I+6uuE9KSUCjko5+k0bz3Rg9/Kq76jop5cUWx5aIs3mC02Dg6wzbDRVm8pP74cUqsou3EBp8PGQLJB2EVIogh6Bz6qiiLf2PEflv6j7J4TajPveuL+QodUwY+JBtJH4CLGDqKYomL+fWhqf9SjORVP+0L25C8LCP6NY16/GZh2m+DTBCad6Rk6Bqdg5X16JVFB7foEs0iORTSsLLkNJfASRlAhgYdekUldNi35AV0ohLQa+AA4ceIS0z38maJ1q+nrNVOj6UKekxbHZWaUr4WE4lmymBEJRRhcXk++/uvP/+B/THIBW9+NyIdz+ta0y253FjVYd+hq1Roax0U19YLrSPm4rW2kZTUkVjqfaFZLsT1yWNnwCfnPpcPCjLYNRJij0xVOHAdtlTwyq6NQEOAHgZaFIeB2O2zxODse4IXF29BDApgJPBBQPrOKnSuh1XW0waPDvIkgSZlW3QH/M56V2enx3qcGm1vrSadewggJiRGr8VwBf/vHlXcKQU+tQ1FCKvDTZ1DRdvnh2M3S2AiuF5cnkO2+mjuZrOpLIcqxHVtOdQmtFSzoNcYNdejGePKSHvyyLkevLz5Djeb1FNckraSwZGtk6WxvwuvrUIhho0hMbTVTSWW0FIEhR7y2QHdJgRYD2IsD/n1FAQfpmf1iNLwOR3TxWn2V/bJ+sQP6f5EbfHjsrHOWb9ebiUadXvn8nO6Pqfrc7r+Iuka1O5y4pGnY3zq7FEWsS3xVt02eOqHXG0IuuQcadApX/yzU1Xy8td8dsDdf6p5vOhpFP/tCwAAAP//
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.BillingPlans
{
    /// <summary>
    /// The terms for the plan.
    /// </summary>
    [DataContract]
    public class Terms
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public Terms() {}

        /// <summary>
        /// REQUIRED
        /// The base object for all financial value-related fields, such as balance, payment due, and so on.
        /// </summary>
        [DataMember(Name="amount_range", EmitDefaultValue = false)]
        public Currency AmountRange;

        /// <summary>
        /// REQUIRED
        /// Indicates whether the customer can edit the amount in this term.
        /// </summary>
        [DataMember(Name="buyer_editable", EmitDefaultValue = false)]
        public string BuyerEditable;

        /// <summary>
        /// The ID of the terms.
        /// </summary>
        [DataMember(Name="id", EmitDefaultValue = false)]
        public string Id;

        /// <summary>
        /// REQUIRED
        /// The base object for all financial value-related fields, such as balance, payment due, and so on.
        /// </summary>
        [DataMember(Name="max_billing_amount", EmitDefaultValue = false)]
        public Currency MaxBillingAmount;

        /// <summary>
        /// REQUIRED
        /// The number of times that money can be pulled during this term.
        /// </summary>
        [DataMember(Name="occurrences", EmitDefaultValue = false)]
        public string Occurrences;

        /// <summary>
        /// REQUIRED
        /// The term type.
        /// </summary>
        [DataMember(Name="type", EmitDefaultValue = false)]
        public string Type;
    }
}

