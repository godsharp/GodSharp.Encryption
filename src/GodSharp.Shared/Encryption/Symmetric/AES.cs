using System;
using System.Security.Cryptography;
using System.Text;

namespace GodSharp.Encryption
{
    /// <summary>
    /// Symmetric/AES encryption.
    /// </summary>
    public class AES:XES
    {
        /// <summary>
        /// AES encryption.
        /// </summary>
        /// <param name="data">The string to be encrypted,not null.</param>
        /// <param name="password">The password to derive the key for.</param>
        /// <param name="keySize">The size only can be 128, 192, or 256</param>
        /// <param name="encoding">The <see cref="T:System.Text.Encoding"/>,default is Encoding.UTF8.</param>
        /// <param name="salt">The key salt to use to derive the key.</param>
        /// <param name="vector">The initialization vector (IV) to use to derive the key.</param>
        /// <param name="model">The mode for operation of the symmetric algorithm.</param>
        /// <returns>The encrypted string.</returns>
        public static string Encrypt(string data,string password = null,int keySize = 256,Encoding encoding=null, string salt = null, string vector = null ,CipherMode mode= CipherMode.ECB)
        {
            if (!(keySize == 256 || keySize == 192 || keySize == 128))
            {
                throw new ArgumentOutOfRangeException(nameof(keySize), "keySize only can be 128, 192, or 256");
            }

            return Encrypt<RijndaelManaged>(data, password, encoding, mode, "SHA1", keySize, 128, salt, vector);
        }

        /// <summary>
        /// AES decryption.
        /// </summary>
        /// <param name="data">The string to be decrypted,not null.</param>
        /// <param name="password">The password to derive the key for.</param>
        /// <param name="keySize">The size only can be 128, 192, or 256</param>
        /// <param name="encoding">The <see cref="T:System.Text.Encoding"/>,default is Encoding.UTF8.</param>
        /// <param name="salt">The key salt to use to derive the key.</param>
        /// <param name="vector">The initialization vector (IV) to use to derive the key.</param>
        /// <param name="model">The mode for operation of the symmetric algorithm.</param>
        /// <returns>The decryption string.</returns>
        public static string Decrypt(string data, string password = null, int keySize = 256, Encoding encoding = null, string salt = null, string vector = null, CipherMode mode = CipherMode.ECB)
        {
            if (!(keySize == 256 || keySize == 192 || keySize == 128))
            {
                throw new ArgumentOutOfRangeException(nameof(keySize), "keySize only can be 128, 192, or 256");
            }

            return Decrypt<RijndaelManaged>(data, password, encoding, mode, "SHA1", keySize, 128, salt, vector);
        }
    }
}
