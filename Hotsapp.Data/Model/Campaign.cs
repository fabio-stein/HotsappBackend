using System;
using System.Collections.Generic;

namespace Hotsapp.Data.Model
{
    public partial class Campaign
    {
        public Campaign()
        {
            CampaignContact = new HashSet<CampaignContact>();
        }

        public Guid Id { get; set; }
        public int OwnerId { get; set; }
        public DateTime CreateDateUtc { get; set; }
        public bool IsPaused { get; set; }
        public bool IsComplete { get; set; }
        public string Title { get; set; }
        public string MessageToSend { get; set; }
        public bool IsCanceled { get; set; }

        public virtual User Owner { get; set; }
        public virtual ICollection<CampaignContact> CampaignContact { get; set; }
    }
}
