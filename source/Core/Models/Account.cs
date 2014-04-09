using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Models
{
    public class Account : BaseEntity
    {
        public bool IsConfirmed { get; set; }
        public string ConfirmationToken { get; set; }
        public DateTime? ConfirmationTokenExpiration { get; set; }
        public string Password { get; set; }
        public int PasswordFailuresSinceLastSuccess { get; set; }
        public DateTime? LastPasswordFailureDateTime { get; set; }
        public string PasswordVerificationToken { get; set; }
        public DateTime? PasswordVerificationTokenExpiration { get; set; }
        public DateTime? LastPasswordChangedDateTime { get; set; }
        public string SessionToken { get; set; }
    }
}
