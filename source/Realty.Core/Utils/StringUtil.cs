using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace Realty.Core.Utils
{
    public class StringUtil
    {
        public static string RemoveMarks(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return "";
            }
            Regex v_reg_regex = new Regex("\\p{IsCombiningDiacriticalMarks}+");
            string v_str_FormD = value.Normalize(NormalizationForm.FormD);
            return v_reg_regex.Replace(v_str_FormD, String.Empty).Replace('\u0111', 'd').Replace('\u0110', 'D');
        }

        public static string RemoveHtmlTags(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return "";
            }
            return Regex.Replace(value, "<.*?>", string.Empty);
        }

        public static string TrimAll(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return "";
            }
            return Regex.Replace(value.Trim(), "[ ]+", " ");
        }
    }
}