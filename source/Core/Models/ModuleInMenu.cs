using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Models
{
    public class ModuleInMenu: BaseEntity
    {
        public Guid ParentId { get; set; }
        public Guid ModuleId { get; set; }
        public string Parameter { get; set; }
        public int Level { get; set; }
        public int Index { get; set; }
    }
}