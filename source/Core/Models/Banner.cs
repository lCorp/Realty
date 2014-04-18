using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Models
{
    public class Banner: BaseEntity
    {
        public Guid CampaignId { get; set; }
        public string BannerName { get; set; }
        public string TargetUrl { get; set; }
        public DateTime StartDateTime { get; set; }
        public DateTime EndDateTime { get; set; }
        public int Ordinal { get; set; }
    }
}
