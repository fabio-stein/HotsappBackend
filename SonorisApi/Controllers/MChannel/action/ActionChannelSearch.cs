using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SonorisApi.Controllers.MChannel.action
{
    public class ActionChannelSearch
    {
        public String Name { get; set; }
        public bool? Mine { get; set; }

        public int page { get; set; }
    }
}
