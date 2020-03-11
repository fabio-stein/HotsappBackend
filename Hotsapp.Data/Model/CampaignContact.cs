using System;
using System.Collections.Generic;

namespace Hotsapp.Data.Model
{
    public partial class CampaignContact
    {
        public int Id { get; set; }
        public Guid CampaignId { get; set; }
        public string PhoneNumber { get; set; }
        public bool Processed { get; set; }
        public bool IsSuccess { get; set; }

        public virtual Campaign Campaign { get; set; }
    }
}
