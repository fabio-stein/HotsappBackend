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
        public object clientInfo { get; set; }
        public object counter { get; set; }
    }
}
