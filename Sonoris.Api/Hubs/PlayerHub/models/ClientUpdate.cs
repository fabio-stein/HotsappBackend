using System;

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
