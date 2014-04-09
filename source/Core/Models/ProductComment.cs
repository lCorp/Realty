using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Models
{
    public class ProductComment : BaseEntity
    {
        public int ProductId { get; set; }
        public int ReplyForId { get; set; }
        public string Content { get; set; }
    }
}