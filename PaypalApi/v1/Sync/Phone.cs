// This class was generated on Tue, 30 Jan 2018 11:02:44 PST by version 0.1.0-dev+6beb51-dirty of Braintree SDK Generator
// Phone.cs
// @version 0.1.0-dev+6beb51-dirty
// @type object
// @data H4sIAAAAAAAC/9xTwWrbQBC99yuGPdmgWA20PehWlJwKbkhNLyGEkTS2Blaz6u4srij597KW6hDLpS2FUnLT7szb9+a90TezGXoyhblpnZDJzGf0jJWlNXbp2mTmAw1PhysKtede2YkpzKYl6BMQJHYV+QxYgDVAjeKEa7TAouQFEwAt3F2vLt+9mbpZdtBbFNg636HeL1rVPhR5vt/vV6xxxaK5pzrfXNxelxcHaE6yXJnMvPceh1H668zcEjYfxQ6m2KINlC6+RPbUHC9uvOvJK1Mwxd1x6KBJxHzq2kVRPzzUrqFnDpwU5m5MDVCjtWm+1AiLslz+I2tgFNFVLNSAJdlpC24L2hKUJaA0h88j60gHXQwK4hQqgp0nVPKgLQpcvoWGd6xhfPkUVzsJHDQkCnyqNhSUx9PkwPqqXB7YQ6ySZwk8vbH4tP6zSNXHk0QlWvuY/TJW+qokgZ08jNTPoj1TnMd7bJrE/+0q/qbwH8ae0z2vzWWfxPYf7OJP/5MXvaL3j6++AwAA//8=
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.Sync
{
    /// <summary>
    /// The phone number, in its canonical international [E.164 numbering plan format](https://www.itu.int/rec/T-REC-E.164/en).
    /// </summary>
    [DataContract]
    public class Phone
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public Phone() {}

        /// <summary>
        /// REQUIRED
        /// The country calling code (CC), in its canonical international [E.164 numbering plan format](https://www.itu.int/rec/T-REC-E.164/en). The combined length of the CC and the national number must not be greater than 15 digits. The national number consists of a national destination code (NDC) and subscriber number (SN).
        /// </summary>
        [DataMember(Name="country_code", EmitDefaultValue = false)]
        public string CountryCode;

        /// <summary>
        /// The extension number.
        /// </summary>
        [DataMember(Name="extension_number", EmitDefaultValue = false)]
        public string ExtensionNumber;

        /// <summary>
        /// REQUIRED
        /// The national number, in its canonical international [E.164 numbering plan format](https://www.itu.int/rec/T-REC-E.164/en). The combined length of the country calling code (CC) and the national number must not be greater than 15 digits. The national number consists of a national destination code (NDC) and subscriber number (SN).
        /// </summary>
        [DataMember(Name="national_number", EmitDefaultValue = false)]
        public string NationalNumber;
    }
}

