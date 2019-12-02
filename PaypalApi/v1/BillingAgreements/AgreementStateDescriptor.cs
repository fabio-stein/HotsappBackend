// This class was generated on Tue, 30 Jan 2018 11:14:21 PST by version 0.1.0-dev+6beb51-dirty of Braintree SDK Generator
// AgreementStateDescriptor.cs
// @version 0.1.0-dev+6beb51-dirty
// @type object
// @data H4sIAAAAAAAC/6SPMUvEQBCFe3/FMHUQ63QHdoKKHjZiMSYvycLebJydFIvcf5fV3B3B8sr38XjzzTfvywxueTcacIA6vbo46B65szB7Mm74TSzIZ8SjHGqXG35AuYRTNyStS9RfMqWBfAJ1i1kdz7/jK5TTzVtueGcm5U/mruEXSP+ksXA7SMyo4GsJhv4Mni3NMA/I3L6f38huQcf/ypocG+0VbNX3E8ggOSkNybaOq3o3iY64VliXGI8fx5sfAAAA//8=
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.BillingAgreements
{
    /// <summary>
    /// A description of the current state of the agreement.
    /// </summary>
    [DataContract]
    public class AgreementStateDescriptor
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public AgreementStateDescriptor() {}

        /// <summary>
        /// The reason for the agreement state change.
        /// </summary>
        [DataMember(Name="note", EmitDefaultValue = false)]
        public string Note;
    }
}

