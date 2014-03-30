using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Models
{
    public class Account : BaseEntity
    {
        public Account()
            : base()
        {

        }

        public string FullName { get; set; }
        public string NickName { get; set; }
        public bool IsConfirmed { get; set; }
        public string ConfirmationToken { get; set; }
        public DateTime? ConfirmationTokenExpiration { get; set; }
        public string Password { get; set; }
        public int PasswordFailuresSinceLastSuccess { get; set; }
        public DateTime? LastPasswordFailureDateTime { get; set; }
        public string PasswordVerificationToken { get; set; }
        public DateTime? PasswordVerificationTokenExpiration { get; set; }
        public DateTime? LastPasswordChangedDateTime { get; set; }
    }
}
