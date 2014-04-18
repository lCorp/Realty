using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Models
{
    public class BannerCampaign : BaseEntity
    {
        public string CampaignName { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public int Ordinal { get; set; }
        public Guid OwnerId { get; set; }
        public Guid AgentId { get; set; }
    }
}