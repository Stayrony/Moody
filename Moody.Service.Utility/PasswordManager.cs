using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Moody.Service.Utility
{

    /// <summary>
    ///     The password manager.
    /// </summary>
    public class PasswordManager
    {
        /// <summary>
        ///     The key size.
        /// </summary>
        private readonly int keySize = 20;

        /// <summary>
        ///     The salt size.
        /// </summary>
        private readonly int saltSize = 20;

        /// <summary>
        /// Password-Based Key Derivation Function 2
        /// </summary>
        /// <param name="password">
        /// </param>
        /// <param name="salt">
        /// </param>
        /// <returns>
        /// Generated derived key
        /// </returns>
        public string GeneratePasswordHash(string password, out string salt)
        {
            byte[] key;

            using (var deriveBytes = new Rfc2898DeriveBytes(password, this.saltSize))
            {
                // salt = deriveBytes.Salt.ToString();
                salt = Convert.ToBase64String(deriveBytes.Salt);
                key = deriveBytes.GetBytes(this.keySize);
            }
            return Convert.ToBase64String(key);
        }

        /// <summary>
        /// Check input password
        /// </summary>
        /// <param name="password">
        /// </param>
        /// <param name="salt">
        /// </param>
        /// <param name="hashPassword">
        /// hashPassword from DB
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool IsPasswordMatch(string password, string salt, string hashPassword)
        {
            byte[] saltBytes = Convert.FromBase64String(salt);
            byte[] hashPasswordBytes = Convert.FromBase64String(hashPassword);

            using (var deriveBytes = new Rfc2898DeriveBytes(password, saltBytes))
            {
                byte[] newKey = deriveBytes.GetBytes(this.keySize);
                // return Convert.ToBase64String(newKey).SequenceEqual(hashPassword);
                return newKey.SequenceEqual(hashPasswordBytes);
            }
        }
    }

}
