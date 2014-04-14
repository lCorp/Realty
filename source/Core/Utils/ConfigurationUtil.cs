using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;

namespace Core.Utils
{
    public class ConfigurationUtil
    {
        public static string GetAppSetting(string key)
        {
            string value = ConfigurationManager.AppSettings[key];
            return value;
        }

        public static string GetConnectionString(string key)
        {
            string value = ConfigurationManager.ConnectionStrings[key].ConnectionString;
            return value;
        }
    }
}