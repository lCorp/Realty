using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Models
{
    public class BannerInZone : BaseEntity
    {
        public Guid BannerId { get; set; }
        public Guid ZoneId { get; set; }
        public int Ordinal { get; set; }
    }
}