using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Models
{
    public class BannerZone : BaseEntity
    {
        public string ZoneName { get; set; }
        public decimal Width { get; set; }
        public decimal Height { get; set; }
        public decimal OffsetX { get; set; }
        public decimal OffsetY { get; set; }
        public decimal Duration { get; set; }
    }
}
