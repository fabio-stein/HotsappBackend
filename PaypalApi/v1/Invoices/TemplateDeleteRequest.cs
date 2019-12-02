// This class was generated on Tue, 30 Jan 2018 11:02:40 PST by version 0.1.0-dev+6beb51-dirty of Braintree SDK Generator
// TemplateDeleteRequest.cs
// @version 0.1.0-dev+6beb51-dirty
// @type request
// @data H4sIAAAAAAAC/2SQQW/iMBCF7/srrHe2CLtH31YkK9DutrRFvVSoMvFAXDm2a09QI8R/r9JARen109PM994BN7olKDC10WmmiSFHTJAoKdfJRrbBQ6H8wFlocU5KsenFopxA4q6j1C910i0xpQz1tJaYkzaUrumfkNprttTcfGEHrPo4WGVO1u8g8aiT1RtHV7bP1kDiL/Un/k171ZBYlCJsBTf0qS44iLHnYP87Jd2PD6cS96TNrXc91Fa7TAN47WwiA8WpI4llCpESW8pQvnPuuB4zlHk8MsAB5Rh8pks2C57Jn2LQMTpb68G0eMnBQ2LOHP8TN8EMk1f/qlWFcR8oFPufhfX7YGvrd8W5Sy4OF2scIVG9RaqZzANr7vIsGIL6NZ0ef7wDAAD//w==
// DO NOT EDIT
using System;
using System.IO;
using System.Net;
using System.Net.Http;
using System.Collections.Generic;
using BraintreeHttp;


namespace PayPal.v1.Invoices
{
    /// <summary>
    /// Deletes a template, by ID.
    /// </summary>
    public class TemplateDeleteRequest : HttpRequest
    {
        public TemplateDeleteRequest(string TemplateId) : base("/v1/invoicing/templates/{template_id}?", HttpMethod.Delete, typeof(void))
        {
            try {
                this.Path = this.Path.Replace("{template_id}", Uri.EscapeDataString(Convert.ToString(TemplateId) ));
            } catch (IOException) {}
            
            this.ContentType =  "application/json";
        }
        
    }
}
