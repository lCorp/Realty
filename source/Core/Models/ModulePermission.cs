using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Models
{
    public class ModulePermission : BaseEntity
    {
        public Guid AccountRoleId { get; set; }
        public Guid ModuleId { get; set; }
        public string PermissionType { get; set; }
    }
}
