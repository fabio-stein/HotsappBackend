// This class was generated on Sun, 08 Apr 2018 17:47:21 UTC by version 0.1.0-dev+291f3f of Braintree SDK Generator
// Document.cs
// @version 0.1.0-dev+291f3f
// @type object
// @data H4sIAAAAAAAC/7zPsWrDMBAG4L1PcdxsQmdvhiyh0Ibgdikdzta1VpEl9XQa3JJ3LyImiSmkQ0smcb9O4vu/sJ0iY43r0OeRvWKFTySWOsf3NJYbrPCOp9Ow5tSLjWqDxxobDzm6QIYNmPkP0IEUUo4xiCYgMDbFrLyCdmBothtIuRutJtCBT6+orHbWk0wQunfudYUVNiI0HZC3Fe6YzIN3E9av5BKX4CNbYXMMthIii1pOWD8f6yUV699+lvPlOC84B8uS7TmzbPwV5rNz++pXXbKfS90cXNCVjSvpsrgF7jBfsD3uNv9Ce9nffAMAAP//
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.CustomerDisputes
{
    /// <summary>
    /// An uploaded document that supports a dispute. The API submits the document as a binary object.
    /// </summary>
    [DataContract]
    public class Document
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public Document() {}

        /// <summary>
        /// The document name.
        /// </summary>
        [DataMember(Name="name", EmitDefaultValue = false)]
        public string Name;

        /// <summary>
        /// The document size.
        /// </summary>
        [DataMember(Name="size", EmitDefaultValue = false)]
        public string Size;

        /// <summary>
        /// The document URI.
        /// </summary>
        [DataMember(Name="url", EmitDefaultValue = false)]
        public string Url;
    }
}

