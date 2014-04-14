using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Models
{
    public class ArticleAttachment : BaseEntity
    {
        public Guid ArticleId { get; set; }
        public string AttachmentName { get; set; }
        public string AttachmentUrl { get; set; }
    }
}