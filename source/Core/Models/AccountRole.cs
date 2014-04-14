using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Models
{
    public class AccountRole : BaseEntity
    {
        public string RoleName { get; set; }
        public int? MaxNumberOfMember { get; set; }
    }
}