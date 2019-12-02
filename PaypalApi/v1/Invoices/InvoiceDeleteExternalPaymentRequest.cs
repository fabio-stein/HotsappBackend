// This class was generated on Tue, 30 Jan 2018 11:02:40 PST by version 0.1.0-dev+6beb51-dirty of Braintree SDK Generator
// InvoiceDeleteExternalPaymentRequest.cs
// @version 0.1.0-dev+6beb51-dirty
// @type request
// @data H4sIAAAAAAAC/6yST2/TQBDF73yK1ZyXOnD0DTVBrfgXIOKCqmjqfakX2bvL7LjUivLd0dYuTQoSQuJm/fQ8fr8Z7+k996CafLiNvsGZQwfFFncKCdxtE489gpKlJXIjPqmPgWpa3uey4WAesmbOWnM9mnmeuVwaDs6ocMjclJfN5fKMLH0cIOOahXsoJFP99crSBdhBntLXUfqnbM3anrA9bcZUTLKKDzdk6QuL5+sOp4Zb78jSG4wz/s1s0963jjujLX557CT25kfrm9ZoNNOWDD8oH/sVuVciPE59FpY+gd2H0I1U77jLKOD74AWOapUBltYSE0Q9MtVh6LqD/avN0Qf/0egPlR+V/kf5qymDrNOQAgvKKYaMY3YegyLMMeKUOt9wKVR9yzGQpQvV9A7aRld+udXb1WZF0+2ppur2RTWdx4eb+Qm52j8e+lDNss8FTRSXq/3p3g5kaXWX0CjcZ2Ud8nl0oPrlYnF49hMAAP//
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
    /// Deletes an external payment, by invoice ID and transaction ID.
    /// </summary>
    public class InvoiceDeleteExternalPaymentRequest : HttpRequest
    {
        public InvoiceDeleteExternalPaymentRequest(string InvoiceId, string TransactionId) : base("/v1/invoicing/invoices/{invoice_id}/payment-records/{transaction_id}?", HttpMethod.Delete, typeof(void))
        {
            try {
                this.Path = this.Path.Replace("{invoice_id}", Uri.EscapeDataString(Convert.ToString(InvoiceId) ));
            } catch (IOException) {}
            try {
                this.Path = this.Path.Replace("{transaction_id}", Uri.EscapeDataString(Convert.ToString(TransactionId) ));
            } catch (IOException) {}
            
            this.ContentType =  "application/json";
        }
        
    }
}
