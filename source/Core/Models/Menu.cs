using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Models
{
    public class Menu: BaseEntity
    {
        public int Level { get; set; }
        public int Index { get; set; }
        public int ParentId { get; set; }
        public int ModuleId { get; set; }
    }
}
