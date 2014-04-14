using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Models
{
    public class ArticleInTag : BaseEntity
    {
        public Guid ArticleId { get; set; }
        public Guid TaggingId { get; set; }
    }
}
