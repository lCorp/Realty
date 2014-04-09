using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Models
{
    public class ProductTagging : BaseEntity
    {
        public int ProductId { get; set; }
        public int TaggingId { get; set; }
    }
}
