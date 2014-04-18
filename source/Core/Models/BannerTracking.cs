using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Models
{
    public class BannerTracking : BaseEntity
    {
        public Guid BannerId { get; set; }
        public DateTime RunningDateTime { get; set; }
        public int LoadTimes { get; set; }
        public int ClickTimes { get; set; }
        public int HoverTimes { get; set; }
    }
}