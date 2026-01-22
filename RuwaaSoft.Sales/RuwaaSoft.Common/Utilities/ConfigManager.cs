using System;
using System.Configuration;

namespace RuwaaSoft.Common.Utilities
{
    public static class ConfigManager
    {
        public static string GetConnectionString(string name = "SalesConnection")
        {
            try
            {
                return ConfigurationManager.ConnectionStrings[name]?.ConnectionString;
            }
            catch
            {
                return null;
            }
        }

        public static string GetAppSetting(string key, string defaultValue = "")
        {
            try
            {
                return ConfigurationManager.AppSettings[key] ?? defaultValue;
            }
            catch
            {
                return defaultValue;
            }
        }

        public static int GetAppSettingInt(string key, int defaultValue = 0)
        {
            var value = GetAppSetting(key);
            if (int.TryParse(value, out int result))
            {
                return result;
            }
            return defaultValue;
        }

        public static bool GetAppSettingBool(string key, bool defaultValue = false)
        {
            var value = GetAppSetting(key);
            if (bool.TryParse(value, out bool result))
            {
                return result;
            }
            return defaultValue;
        }
    }
}
