using System;
using System.Security.Cryptography;
using System.Text;

namespace RuwaaSoft.Common.Helpers
{
    public static class SecurityHelper
    {
        public static string GenerateSalt()
        {
            byte[] saltBytes = new byte[32];
            using (var provider = new RNGCryptoServiceProvider())
            {
                provider.GetBytes(saltBytes);
            }
            return Convert.ToBase64String(saltBytes);
        }

        public static string HashPassword(string password, string salt)
        {
            using (var sha256 = SHA256.Create())
            {
                var combinedBytes = Encoding.UTF8.GetBytes(password + salt);
                var hashBytes = sha256.ComputeHash(combinedBytes);
                return BitConverter.ToString(hashBytes).Replace("-", "");
            }
        }

        public static bool VerifyPassword(string password, string salt, string hash)
        {
            var computedHash = HashPassword(password, salt);
            return computedHash.Equals(hash, StringComparison.OrdinalIgnoreCase);
        }
    }
}
