using DbManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sonoris.Api.Hubs.PlayerHub.models
{
    public class ClientUpdate
    {
        public int Channel { get; set; }
        public DateTime StartTime { get; set; }
        public long DurationSeconds { get; set; }
        public int MedType { get; set; }
        public String Name { get; set; }
        public String Source { get; set; }
    }
}
