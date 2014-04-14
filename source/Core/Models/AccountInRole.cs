using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Models
{
    public class AccountInRole : BaseEntity
    {
        public Guid AccountId { get; set; }
        public Guid AccountRoleId { get; set; }
    }
}
