using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Models
{
    public class AccountTransaction : BaseEntity
    {
        public Guid AccoutnId { get; set; }
        public string TransactionToken { get; set; }
        public string VerificationToken { get; set; }
        public DateTime VerificationTokenExpiration { get; set; }
    }
}