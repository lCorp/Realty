using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Persistence;

namespace Core.Models
{
    public class CodeMaster : BaseEntity
    {
        public Guid? ParentId { get; set; }
        public string CodeMasterType { get; set; }
        public string CodeMasterCode { get; set; }
        public string CodeMasterValue { get; set; }
        public string LocalizedValue { get; set; }
        public int Level { get; set; }
        public int Ordinal { get; set; }

        #region Methods

        public static string GetValue(string codeMasterType, string codeMasterCode)
        {
            using (Context context = new Context())
            {
                string result = string.Empty;
                CodeMaster codeMaster = context.CodeMasterList.FirstOrDefault(m => m.CodeMasterType == codeMasterType && m.CodeMasterCode == codeMasterCode);
                if (codeMaster != null)
                {
                    result = codeMaster.CodeMasterValue;
                }
                return result;
            }
        }

        public static string GetValue(string codeMasterType, string codeMasterCode, string languageCulture)
        {
            using (Context context = new Context())
            {
                string result = string.Empty;
                CodeMaster codeMaster = context.CodeMasterList.FirstOrDefault(m => m.CodeMasterType == codeMasterType && m.CodeMasterCode == codeMasterCode);
                if (codeMaster != null)
                {
                    result = BaseEntity.GetLocalizedValue(codeMaster.Id, languageCulture, codeMaster.LocalizedValue);
                }
                return result;
            }
        }

        public static List<CodeMaster> GetListByType(string codeType)
        {
            List<CodeMaster> result = new List<CodeMaster>();
            using (Context context = new Context())
            {
                result = context.CodeMasterList.Where(m => m.CodeMasterType == codeType).OrderBy(m => m.Ordinal).ToList();
            }
            return result;
        }

        public static List<CodeMaster> GetListByType(string codeType, string languageCulture)
        {
            List<CodeMaster> result = CodeMaster.GetListByType(codeType);
            using (Context context = new Context())
            {
                foreach (CodeMaster item in result)
                {
                    item.LocalizedValue = BaseEntity.GetLocalizedValue(item.Id, languageCulture, item.LocalizedValue);
                }
            }
            return result;
        }

        #endregion
    }
}