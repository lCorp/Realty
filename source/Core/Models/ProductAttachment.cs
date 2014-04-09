using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Models
{
    public class ProductAttachment : BaseEntity
    {
        public int ProductId { get; set; }
        public string Source { get; set; }
    }
}
