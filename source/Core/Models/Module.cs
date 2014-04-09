using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Models
{
    public class Module : BaseEntity
    {
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
    }
}
