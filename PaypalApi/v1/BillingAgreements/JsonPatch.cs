// This class was generated on Tue, 30 Jan 2018 11:14:21 PST by version 0.1.0-dev+6beb51-dirty of Braintree SDK Generator
// JsonPatch.cs
// @version 0.1.0-dev+6beb51-dirty
// @type object
// @data H4sIAAAAAAAC/7STT2vjQAzF7/spxJxN2LNvgT3tQhJ2w15KIcpYiaeMR1ONnGJKvnuZyT/cFEL/HfUkDb/nJz+b5RDJ1Ob3v/kMFqi2NZX5j+Jw7WmGXe6Zyvyh4VL8omTFRXUcTG2mUHZj3gVeP5BVUAaM0Q8QUdShhz42qJRyQyhxL5bSxFRmKoLDAeFnZf4SNvPgB1Nv0CfKwmPvhJqzsBCOJOoomfruDJ9UXNheg2+EuxH8UXjbALugJBlRWwLPFvMAuFBqRdmSQsO27ygo5KfgqXW2zRsd76iM7dD3NIETOGxYir7KEyvI9OXZz5oPvff76uYX4DjyX8qx+2VLF6psxXIXPSm9i1Cl/xhgRG1HiEfhVkR4MyDUSzwnT2XwuzI43P61xXISI48n5TqJ0jn/PhPI2kro1fFAw5QgsIIc+ACPh/cVju73P14AAAD//w==
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.BillingAgreements
{
    /// <summary>
    /// A JSON patch object to apply partial updates to resources.
    /// </summary>
    [DataContract]
    public class JsonPatch<T>
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public JsonPatch() {}

        /// <summary>
        /// A JSON pointer to the location in the target document from which to move the value. Required for the `move` operation.
        /// </summary>
        [DataMember(Name="from", EmitDefaultValue = false)]
        public string From;

        /// <summary>
        /// REQUIRED
        /// The operation to complete.
        /// </summary>
        [DataMember(Name="op", EmitDefaultValue = false)]
        public string Op;

        /// <summary>
        /// A JSON pointer to a location in the target document at which to complete the operation.
        /// </summary>
        [DataMember(Name="path", EmitDefaultValue = false)]
        public string Path;

        /// <summary>
        /// The value to apply. The `remove` operation does not require a value.
        /// </summary>
        [DataMember(Name="value", EmitDefaultValue = false)]
        public T Value;
    }
}

