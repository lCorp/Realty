using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Models
{
    public class Permission : BaseEntity
    {
        public int AccountRoleId { get; set; }
        public int ModuleId { get; set; }
        public string PermissionType { get; set; }
    }
}
