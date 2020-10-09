using Refit;
using System;
using System.Collections.Generic;
using System.Text;

namespace WaClient.Connector
{
    public class WaConnector
    {
        IWaConnector client;

        public WaConnector()
        {
            client = RestService.For<IWaConnector>("http://localhost:3000");
        }

        public IWaConnector GetClient()
        {
            return client;
        }
    }
}
