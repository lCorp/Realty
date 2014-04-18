using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Models
{
    public class Account : BaseEntity
    {
        public string AccountName { get; set; }
        public string Password { get; set; }
        public int PasswordFailures { get; set; }
        public DateTime? LastPasswordFailure { get; set; }
        public string LastLoginToken { get; set; }
        public string LanguageCulture { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string NickName { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public DateTime? Birthday { get; set; }
        public string Gender { get; set; }
        public string Address { get; set; }
        public string City { get; set; }
        public string District { get; set; }
        public string Ward { get; set; }
        public string Street { get; set; }
        public string HomeNumber { get; set; }
        public string SkypeId { get; set; }
        public string FacebookId { get; set; }
        public string GooglePlusId { get; set; }
        public string YahooId { get; set; }
    }
}