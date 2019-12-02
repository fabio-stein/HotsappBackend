// This class was generated on Tue, 30 Jan 2018 11:02:40 PST by version 0.1.0-dev+6beb51-dirty of Braintree SDK Generator
// TemplateSettingsMetadata.cs
// @version 0.1.0-dev+6beb51-dirty
// @type object
// @data H4sIAAAAAAAC/6SOT0sDQQxH736KIedFPO9N8CLiH7R4EQ9p51cnkJ1dkxQZpN9dltqV4rHHPJKX902rNoF6WmGYlAPpBRFSPzzdIzhzMHX0yia8VjzwMO9SR3dof8MNfGMyhYx1NhWkONr8aBt+bZfU0bUZt8Pfq46ewfmxaqN+y+qYwedODHkBTzZOsBA49W9L8XocFVz/5xXJGfUkckGnqbc1y4YDnr4KosBSFPG0FWhO4ulwdm5y3anu3/cXPwAAAP//
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.Invoices
{
    /// <summary>
    /// The template settings metadata.
    /// </summary>
    [DataContract]
    public class TemplateSettingsMetadata
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public TemplateSettingsMetadata() {}

        /// <summary>
        /// Indicates whether this field is hidden.
        /// </summary>
        [DataMember(Name="hidden", EmitDefaultValue = false)]
        public bool? Hidden;
    }
}

