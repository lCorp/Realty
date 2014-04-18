using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Models
{
    public class BannerAgent : BaseEntity
    {
        public string AgentName { get; set; }
        public string AgentAddress { get; set; }
        public string AgentPhone { get; set; }
        public string AgentMobile { get; set; }
        public string ContactName { get; set; }
        public string ContactAddress { get; set; }
        public string ContactPhone { get; set; }
        public string ContactMobile { get; set; }
    }
}
