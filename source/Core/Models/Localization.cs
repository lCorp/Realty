using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Core.Models
{
    public class Localization : BaseEntity
    {
        public Guid RecordId { get; set; }
        public string LanguageCulture { get; set; }
        public string Value { get; set; }
    }
}
