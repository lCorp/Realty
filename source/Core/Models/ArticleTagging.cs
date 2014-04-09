using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Models
{
    public class ArticleTagging : BaseEntity
    {
        public int ArticleId { get; set; }
        public int TaggingId { get; set; }
    }
}
