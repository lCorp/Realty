using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Models
{
    public class ArticleComment : BaseEntity
    {
        public Guid ArticleId { get; set; }
        public Guid? ReplyForId { get; set; }
        public string Content { get; set; }
    }
}