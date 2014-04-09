using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Models
{
    public class ArticleAttachment : BaseEntity
    {
        public int ArticleId { get; set; }
        public string Source { get; set; }
    }
}