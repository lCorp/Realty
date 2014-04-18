using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Persistence;

namespace Core.Models
{
    public class CodeMaster : BaseEntity
    {
        public string CodeMasterType { get; set; }
        public string CodeMasterCode { get; set; }
        public string CodeMasterValue { get; set; }
        public string LocalizedValue { get; set; }

        public int Ordinal { get; set; }

        #region Methods

        public static string GetCode(string codeMasterType, string codeMasterCode, string languageCulture)
        {
            using (Context context = new Context())
            {
                string result = string.Empty;
                CodeMaster codeMaster = context.CodeMasterList.FirstOrDefault(m => m.CodeMasterType == codeMasterType && m.CodeMasterCode == codeMasterCode);
                if (codeMaster != null)
                {
                    result = GetLocalizedValue(codeMaster.Id, languageCulture, codeMaster.CodeMasterValue);
                }
                return result;
            }
        }
        #endregion
    }
}