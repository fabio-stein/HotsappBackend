// This class was generated on Tue, 30 Jan 2018 11:02:40 PST by version 0.1.0-dev+6beb51-dirty of Braintree SDK Generator
// InvoiceDeleteExternalRefundRequest.cs
// @version 0.1.0-dev+6beb51-dirty
// @type request
// @data H4sIAAAAAAAC/6yST2/TQBDF73yK1ZyXOnD0DTVBrfgXIOKCqmjqfakXObtmdlxqRfnuaLOGJs0BIfVm/fQ8fr8Z7+gjb0E1+XAffYMLhw6KNR4UErhbCzZDcGRpjtSI79XHQDXND7FkOJg/UVOi1tyOZppmrueGgzMqHBI3+V1zPb8gS58HyLhk4S0Ukqj+fmPpCuwgT+nbKNunbMnanrAdrcY+eyQVH+7I0jcWz7cdTv3WPru8wzjhM7FVe2gdN0Zb/PXYSNyaX61vWqPRlB0dAsX5WDDbvRHhsRSaWfoCdp9CN1K94S4hg5+DFziqVQZYWkrsIeqRqA5D1+3tP3WOPvifSueNH5Weo/tNySBpGZJhRqmPIeGYXcagCFOMuO8733AuVP1IMZClK9X+A7SNLv9xi/eL1YLK7amm6v5VVc7jw930hFTtHg+9r4rrS0ETxaVqd7q1PVlaPPRoFO6rsg7pMjpQ/Xo227/4DQAA//8=
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
    /// Deletes an external refund, by invoice ID and transaction ID.
    /// </summary>
    public class InvoiceDeleteExternalRefundRequest : HttpRequest
    {
        public InvoiceDeleteExternalRefundRequest(string InvoiceId, string TransactionId) : base("/v1/invoicing/invoices/{invoice_id}/refund-records/{transaction_id}?", HttpMethod.Delete, typeof(void))
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
