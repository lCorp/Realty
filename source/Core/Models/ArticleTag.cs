using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Models
{
    public class ArticleTag : BaseEntity
    {
        public string Category { get; set; }
        public string TagName { get; set; }
    }
}
