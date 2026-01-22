using System;

namespace RuwaaSoft.Common.Extensions
{
    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        public static bool IsNullOrWhiteSpace(this string value)
        {
            return string.IsNullOrWhiteSpace(value);
        }

        public static string ToSafeString(this object value)
        {
            return value?.ToString() ?? string.Empty;
        }

        public static int ToInt(this string value, int defaultValue = 0)
        {
            if (int.TryParse(value, out int result))
            {
                return result;
            }
            return defaultValue;
        }

        public static decimal ToDecimal(this string value, decimal defaultValue = 0m)
        {
            if (decimal.TryParse(value, out decimal result))
            {
                return result;
            }
            return defaultValue;
        }

        public static DateTime? ToDateTime(this string value)
        {
            if (DateTime.TryParse(value, out DateTime result))
            {
                return result;
            }
            return null;
        }
    }
}
