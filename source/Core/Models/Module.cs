using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Models
{
    public class Module : BaseEntity
    {
        public string ModuleName { get; set; }
        public string ControllerName { get; set; }
        public string ActionName { get; set; }
        public string Version { get; set; }
        public string ProviderName { get; set; }
        public string PackageName { get; set; }
        public string PackageUrl { get; set; }
    }
}