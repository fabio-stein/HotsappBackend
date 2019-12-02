// This class was generated on Tue, 30 Jan 2018 11:14:21 PST by version 0.1.0-dev+6beb51-dirty of Braintree SDK Generator
// PlanWithId.cs
// @version 0.1.0-dev+6beb51-dirty
// @type object
// @data H4sIAAAAAAAC/6TPMUvFMBAH8N1PcdwcxDmb8BYRVOThIvK411ybgzSJl5QSpN9dWqEdHBwc//+Du9994bllRos5ULzMUv1FHBp8IxW6Bn6icZ2iwUduRzhx6VRylRTR4tkzPJwg9VA9w7oJUoTZS+eheilAgzKPHCtIgSsVdrdo8F6V2s/5O4OvTO45hoa2p1B4LT4nUXZ78aIps1bhgvZ9h5eqEoff5O2NA73Fv9j/VcUphOVjufkGAAD//w==
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.BillingAgreements
{
    /// <summary>
    /// The ID of the plan on which this agreement is based.
    /// </summary>
    [DataContract]
    public class PlanWithId
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public PlanWithId() {}

        /// <summary>
        /// The ID of the plan.
        /// </summary>
        [DataMember(Name="id", EmitDefaultValue = false)]
        public string Id;
    }
}

