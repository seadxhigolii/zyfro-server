using System;
using System.Security.Cryptography;

namespace Zyfro.Pro.Server.Common.Helpers
{
    public class PasswordHasher
    {
        /// <summary>
        /// This method generates a salt for each user
        /// </summary>
        /// <returns>String salt</returns>
        public static string GenerateSalt()
        {
            byte[] saltBytes = new byte[16];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(saltBytes);
            }
            return Convert.ToBase64String(saltBytes);
        }
    }
}
