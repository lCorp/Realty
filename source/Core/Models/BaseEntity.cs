using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;

namespace Core.Models
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            CreatedDateTime = DateTime.Now;
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public Guid Id { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int? LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedDateTime { get; set; }
    }
}