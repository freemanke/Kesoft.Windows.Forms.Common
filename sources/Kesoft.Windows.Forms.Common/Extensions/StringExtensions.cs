using System.Text.RegularExpressions;

namespace System
{
    /// <summary>
    ///   字符串扩展。
    /// </summary>
    public static class StringExtensions
    {
        /// <summary>
        /// 验证是否是IPV4地址。
        /// </summary>
        public static bool IsIpv4(this string t)
        {
            if (!string.IsNullOrEmpty(t))
            {
                const string pattern = @"^(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d"
                                       + @"|2[0-4]\d|25[0-5])\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])"
                                       + @"\.(\d{1,2}|1\d\d|2[0-4]\d|25[0-5])$";
                return Regex.IsMatch(t, pattern);
            }

            return false;
        }

        /// <summary>
        /// 验证是否是邮件地址。
        /// </summary>
        public static bool IsEmail(this string t)
        {
            if (!string.IsNullOrEmpty(t))
            {
                const string pattern = @"^[\w-]+(\.[\w-]+)*@[\w-]+(\.[\w-]+)+$";
                return Regex.IsMatch(t, pattern);
            }

            return false;
        }
    }
}