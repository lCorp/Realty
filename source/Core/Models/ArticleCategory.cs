using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Models
{
    public class ArticleCategory : BaseEntity
    {
        public Guid ParentId { get; set; }
        public string CategoryName { get; set; }
        public string CategoryType { get; set; }
        public int? MaxNumberOfAttachment { get; set; }
        public int Level { get; set; }
        public int Index { get; set; }
    }
}