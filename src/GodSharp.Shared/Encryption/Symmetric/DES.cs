using System;
using System.Text;
using System.Security.Cryptography;

namespace GodSharp.Encryption
{
    /// <summary>
    /// Symmetric/DES encryption.
    /// </summary>
    public class DES:XES
    {
        /// <summary>
        /// DES encryption.
        /// </summary>
        /// <param name="data">The string to be encrypted,not null.</param>
        /// <param name="password">The password to derive the key for.</param>
        /// <param name="encoding">The <see cref="T:System.Text.Encoding"/>,default is Encoding.UTF8.</param>
        /// <param name="salt">The key salt to use to derive the key.</param>
        /// <param name="vector">The initialization vector (IV) to use to derive the key.</param>
        /// <param name="model">The mode for operation of the symmetric algorithm.</param>
        /// <returns>The encrypted string.</returns>
        public static string Encrypt(string data, string password = null, int keySize = 64, Encoding encoding = null, string salt = null, string vector = null, CipherMode mode = CipherMode.ECB)
        {
            return Encrypt<DESCryptoServiceProvider>(data, password, encoding, mode, "SHA1", 64, 64, salt, vector);
        }

        /// <summary>
        /// DES decryption.
        /// </summary>
        /// <param name="data">The string to be decrypted,not null.</param>
        /// <param name="password">The password to derive the key for.</param>
        /// <param name="encoding">The <see cref="T:System.Text.Encoding"/>,default is Encoding.UTF8.</param>
        /// <param name="salt">The key salt to use to derive the key.</param>
        /// <param name="vector">The initialization vector (IV) to use to derive the key.</param>
        /// <param name="model">The mode for operation of the symmetric algorithm.</param>
        /// <returns>The decryption string.</returns>
        public static string Decrypt(string data, string password = null, Encoding encoding = null, string salt = null, string vector = null, CipherMode mode = CipherMode.ECB)
        {
            return Decrypt<DESCryptoServiceProvider>(data, password, encoding, mode, "SHA1", 64, 64, salt, vector);
        }
    }
}
