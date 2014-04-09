using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Models
{
    public class AccountProfile : BaseEntity
    {
        public string FullName { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public DateTime Birthday { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Ward { get; set; }
        public string Street { get; set; }
        public string Skype { get; set; }
        public string Facebook { get; set; }
        public string GooglePlus { get; set; }
        public string Yahoo { get; set; }
    }
}