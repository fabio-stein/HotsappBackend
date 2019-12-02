// This class was generated on Tue, 30 Jan 2018 11:02:41 PST by version 0.1.0-dev+6beb51-dirty of Braintree SDK Generator
// Metadata.cs
// @version 0.1.0-dev+6beb51-dirty
// @type object
// @data H4sIAAAAAAAC/+ySQavUMBCA7/6KIee8hycPvT3wJmqRZUFkkdl2ug2bJnEmEYPsf5e0ddduFxXXk3gpdCaZ+b7JfFWbHEhVaqCILUZUWm2RDe4tvcGhZJRWryhffl6SNGxCNN6pSr2e7z0qrZ6YMU/1nmv1jrB962xWVYdWqAQ+JcPUngM1+0AcDYmqPpxJSidA18IWbSKo0fAaKniJe2yOH2fmC+F1Zon75AALJfgOHA70gK59+Dw2CmhYIPYYofEuonFAXyKxQwullgZJTQ8okIRYj1/oiNrSTYM0nkmP4OLBu6uBvPjzgUhk4w7rGRT+hfocWBpveoIjZeg8Q+zplvUjvPcJhiTFnJksRhrPTkeKUrkFMQeSex/aJWtP+pdyY+uF3ffIWm/C/Jng32De/UD9WzsqKQRLA7mInNeLejN9z7aWEsCzB+wz1JhrtNNgGJ1gU+pCYN+QiHGH/zv6z+3o7vTsGwAAAP//
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.Orders
{
    /// <summary>
    /// Metadata.
    /// </summary>
    [DataContract]
    public class Metadata
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public Metadata() {}

        /// <summary>
        /// An array of name-and-value pairs that contain external data, such as user, user feedback, score, and so on.
        /// </summary>
        [DataMember(Name="postback_data", EmitDefaultValue = false)]
        public List<NameAndValuePair> PostbackData;

        /// <summary>
        /// An array of name-and-value pairs that contain data required by PayPal for transaction processing.
        /// </summary>
        [DataMember(Name="supplementary_data", EmitDefaultValue = false)]
        public List<NameAndValuePair> SupplementaryData;
    }
}

