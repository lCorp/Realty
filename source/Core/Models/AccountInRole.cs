using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Models
{
    public class AccountInRole : BaseEntity
    {
        public int AccountId { get; set; }
        public int AccountRoleId { get; set; }
        public string RoleType { get; set; }
    }
}
