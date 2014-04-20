using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Core.Persistence;
using System.ComponentModel.DataAnnotations;
using Core.Resources.Models.CodeMaster;

namespace Core.Models
{
    public class CodeMaster : BaseEntity
    {
        private readonly Context _context = new Context();

        public Guid? ParentId { get; set; }
        public string CodeMasterType { get; set; }
        public string CodeMasterCode { get; set; }
        [Required(ErrorMessageResourceName = "Required", ErrorMessageResourceType = typeof(CodeMasterModelResource))]
        public string CodeMasterValue { get; set; }
        public string LocalizedValue { get; set; }
        public int Level { get; set; }
        public int Ordinal { get; set; }

        #region Methods

        public static bool IsEditableCodeType(string codeTypeToCheck)
        {
            bool result = false;
            using (Context context = new Context())
            {
                CodeMaster codeMaster = context.CodeMasterList.FirstOrDefault(m => m.CodeMasterType == "EditableCode" && m.CodeMasterCode == codeTypeToCheck);
                result = codeMaster != null;
            }
            return result;
        }

        public static string GetParentCodeType(string codeType)
        {
            string result = string.Empty;
            using (Context context = new Context())
            {
                CodeMaster codeMaster = context.CodeMasterList.FirstOrDefault(m => m.CodeMasterType == "EditableCode" && m.CodeMasterCode == codeType);
                if (codeMaster != null)
                {
                    CodeMaster parentCodeMaster = context.CodeMasterList.FirstOrDefault(m => m.Id == codeMaster.ParentId);
                    if (parentCodeMaster != null)
                    {
                        result = parentCodeMaster.CodeMasterValue;
                    }
                }
            }
            return result;
        }

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
                result = context.CodeMasterList.Where(m => m.CodeMasterType == codeType).OrderBy(m => m.Ordinal).ThenBy(m => m.CodeMasterValue).ToList();
            }
            return result;
        }

        public static List<CodeMaster> GetListByTypeWithLocalization(string codeType, string languageCulture)
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

        public static List<CodeMaster> GetAvailableListByType(string codeType)
        {
            List<CodeMaster> result = GetListByType(codeType);
            result = result.Where(m => string.Compare(m.Status, "DELETED", StringComparison.OrdinalIgnoreCase) != 0).ToList();
            return result;
        }

        public static List<CodeMaster> GetAvailableListByTypeWithLocalization(string codeType, string languageCulture)
        {
            List<CodeMaster> result = GetListByTypeWithLocalization(codeType, languageCulture);
            result = result.Where(m => string.Compare(m.Status, "DELETED", StringComparison.OrdinalIgnoreCase) != 0).ToList();
            return result;
        }

        public static List<CodeMaster> GetAvailableListByType(string codeType, string parentValue)
        {
            List<CodeMaster> result = new List<CodeMaster>();
            using (Context context = new Context())
            {
                result = (from m1 in context.CodeMasterList
                          from m2 in context.CodeMasterList
                          where m1.CodeMasterType == codeType
                          where m1.ParentId == m2.Id
                          where string.Compare(m2.CodeMasterValue, parentValue, StringComparison.OrdinalIgnoreCase) == 0
                          where string.Compare(m1.Status, "DELETED", StringComparison.OrdinalIgnoreCase) != 0
                          select m1).ToList();
            }
            return result;
        }

        public static List<CodeMaster> GetAvailableListByTypeWithLocalization(string codeType, string languageCulture, string parentValue)
        {
            List<CodeMaster> result = new List<CodeMaster>();
            using (Context context = new Context())
            {
                result = (from m1 in context.CodeMasterList
                          from m2 in context.CodeMasterList
                          where m1.CodeMasterType == codeType
                          where m1.ParentId == m2.Id
                          where string.Compare(m2.CodeMasterValue, parentValue, StringComparison.OrdinalIgnoreCase) == 0
                          where string.Compare(m1.Status, "DELETED", StringComparison.OrdinalIgnoreCase) != 0
                          select m1).ToList();
            }
            foreach (CodeMaster item in result)
            {
                item.LocalizedValue = BaseEntity.GetLocalizedValue(item.Id, languageCulture, item.LocalizedValue);
            }
            return result;
        }

        #endregion
    }
}