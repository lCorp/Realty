using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using Core.Persistence;

namespace Core.Models
{
    public abstract class BaseEntity
    {
        public BaseEntity()
        {
            Id = Guid.NewGuid();
            CreatedDateTime = DateTime.Now;
            LastUpdatedDateTime = DateTime.Now;
        }

        [Key]
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Type { get; set; }
        public string Status { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int? LastUpdatedBy { get; set; }
        public DateTime LastUpdatedDateTime { get; set; }

        #region Methods

        public static string GetLocalizedValue(Guid recordId, string languageCulture)
        {
            using (Context context = new Context())
            {
                string result = string.Empty;
                Localization localization = context.LocalizationList.FirstOrDefault(m => m.RecordId == recordId && m.LanguageCulture == languageCulture);
                if (localization != null)
                {
                    result = localization.Value;
                }
                return result;
            }
        }

        public static string GetLocalizedValue(Guid recordId, string languageCulture, string defaultValue)
        {
            string result = BaseEntity.GetLocalizedValue(recordId, languageCulture);
            if (string.IsNullOrEmpty(result))
            {
                result = defaultValue;
            }
            return result;
        }

        #endregion
    }
}