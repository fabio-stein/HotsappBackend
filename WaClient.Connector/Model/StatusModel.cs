using System;
using System.Collections.Generic;
using System.Text;

namespace WaClient.Connector.Model
{
    public class StatusModel
    {
        public bool initialized { get; set; }
        public string qr { get; set; }
        public object session { get; set; }
        public bool ready { get; set; }
        public ClientInfo clientInfo { get; set; }
        public object counter { get; set; }
    }

    public class ClientInfo
    {
        public MeInfo me { get; set; }
    }

    public class MeInfo
    {
        public string server { get; set; }
        public string user { get; set; }
    }
}
