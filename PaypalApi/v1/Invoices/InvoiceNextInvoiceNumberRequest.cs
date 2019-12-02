// This class was generated on Tue, 30 Jan 2018 11:02:40 PST by version 0.1.0-dev+6beb51-dirty of Braintree SDK Generator
// InvoiceNextInvoiceNumberRequest.cs
// @version 0.1.0-dev+6beb51-dirty
// @type request
// @data H4sIAAAAAAAC/6SST2/UMBDF73wKa87ZP3DMDZU/RQi60BUXVFXT5LUxSsZmPFk1qva7I+OwVYO40FMyTzOen9/zA33mAVSTl0PwDdaCe7uei2sZhxsoVfQGqVEfzQehmt5DoGxIzjq4POHmCVcmnHVszifHB/Y93/RwFn43D9CmY7E1VfRlhE47Vh5g0ET196uKzsEtdKm+CzostR1bt9S+4ueIZPspgmoZ+z5LKQZJKNoDlS99eAJMFX1j9Zl09oMq+ojpsXjqAFX0WpWnctg2b+H2QvqJ6lvuEwqJV7QnYachQs0jo54wkqmXu7/Xn7AeIf4Rxv6/I3D7zqc/7blztLDy0igGiKF1txqGMhKSOUUDWa5ZP9OJnNHx6ljRWRCDzMkRx9j7hvMVNz9SEKro3Cx+gnWhpZp2F5d7Kk+AatocXm4Klpe7+Q9pk11ZzdXq5N7b+4jG0F4a25jOQguqX223xxe/AAAA//8=
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
    /// Generates the next invoice number that is available to the merchant.
    /// </summary>
    public class InvoiceNextInvoiceNumberRequest : HttpRequest
    {
        public InvoiceNextInvoiceNumberRequest() : base("/v1/invoicing/invoices/next-invoice-number?", HttpMethod.Post, typeof(InvoiceNumber))
        {
            
            this.ContentType =  "application/json";
        }
        
    }
}
