// This class was generated on Tue, 30 Jan 2018 11:02:40 PST by version 0.1.0-dev+6beb51-dirty of Braintree SDK Generator
// FileAttachment.cs
// @version 0.1.0-dev+6beb51-dirty
// @type object
// @data H4sIAAAAAAAC/6zPQUs0MQwG4Pv3K0LO5cPz3BbEi6KyrF7EQ3aasYFOOmYyLoPsf5e6sq6M4EFPJW/L2yevuJkHxgYvJDOs3KlNPatjwHsyoW3ma+rrAwx4yfPncM5jazK4FMUGN4mhqxX0XsERvAApiL4UaRmKgXM/ZHL+jwFXZjQffj4LuGaKN5pnbDrKI9fgeRLjeAxurQxsLjxi83A0j26iT0uq1uOU+xEsyfUCSgeeTuR1j98idcp5H36UTpa/QA/z0nm3vvqWGWCXpE3QksKWIZad5kKR45/4H/f/3gAAAP//
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.Invoices
{
    /// <summary>
    /// The file attached to an invoice or template.
    /// </summary>
    [DataContract]
    public class FileAttachment
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public FileAttachment() {}

        /// <summary>
        /// The name of the attached file.
        /// </summary>
        [DataMember(Name="name", EmitDefaultValue = false)]
        public string Name;

        /// <summary>
        /// The URL of the attached file, which can be downloaded.
        /// </summary>
        [DataMember(Name="url", EmitDefaultValue = false)]
        public string Url;
    }
}

