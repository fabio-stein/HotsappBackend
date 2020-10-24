using Refit;
using System;
using System.Collections.Generic;
using System.Text;

namespace WaClient.Connector
{
    public class WaConnector
    {
        IWaConnector client;

        public WaConnector(string endpoint)
        {
            client = RestService.For<IWaConnector>(endpoint);
        }

        public IWaConnector GetClient()
        {
            return client;
        }
    }
}
