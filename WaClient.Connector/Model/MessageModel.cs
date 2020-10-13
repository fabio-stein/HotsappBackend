using System;
using System.Collections.Generic;
using System.Text;

namespace WaClient.Connector.Model
{
    public class Id
    {
        public bool fromMe { get; set; }
        public string remote { get; set; }
        public string id { get; set; }
        public string _serialized { get; set; }
    }

    public class MessageModel
    {
        public Id id { get; set; }
        public int ack { get; set; }
        public bool hasMedia { get; set; }
        public string body { get; set; }
        public string type { get; set; }
        public int timestamp { get; set; }
        public string from { get; set; }
        public string to { get; set; }
        public bool isForwarded { get; set; }
        public bool broadcast { get; set; }
        public bool fromMe { get; set; }
        public bool hasQuotedMsg { get; set; }
        public List<object> mentionedIds { get; set; }
    }
}
