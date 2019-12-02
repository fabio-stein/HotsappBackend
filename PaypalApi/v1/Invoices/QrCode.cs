// This class was generated on Tue, 30 Jan 2018 11:02:40 PST by version 0.1.0-dev+6beb51-dirty of Braintree SDK Generator
// QrCode.cs
// @version 0.1.0-dev+6beb51-dirty
// @type object
// @data H4sIAAAAAAAC/6TOP6vCMBQF8P19inDnwHvDwyGb6Cb4p4iLONw2tyWQJvEmHYL0u0tbrNTV8ZwL9/wecM6BQMGpEBuvCSRckA2WlvbYDgeQsKP8DluKFZuQjHegoMRIq39BrvKatDAtNiR8LVIONKXf4BqQsGbGPG39SSgI9cHZDKpGG2ko7p1h0nNxZB+Ik6EI6jorY2IzvvtAjksL6atZcr+EuM7a/tb/PAEAAP//
// DO NOT EDIT
using System.Runtime.Serialization;
using System.Collections.Generic;


namespace PayPal.v1.Invoices
{
    /// <summary>
    /// base64 encoded image of type image/png
    /// </summary>
    [DataContract]
    public class QrCode
    {
        /// <summary>
	    /// Required default constructor
		/// </summary>
        public QrCode() {}

        /// <summary>
        /// </summary>
        [DataMember(Name="image", EmitDefaultValue = false)]
        public string Image;
    }
}

