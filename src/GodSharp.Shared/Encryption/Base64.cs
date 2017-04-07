using System;
using System.Text;

namespace GodSharp.Encryption
{
    /// <summary>
    /// Hash/Base64 encryption.
    /// </summary>
    public class Base64
    {
        /// <summary>
        /// Base64 encryption.
        /// </summary>
        /// <param name="data">The string to be encrypted,not null.</param>
        /// <param name="encoding">The <see cref="T:System.Text.Encoding"/>,default is Encoding.UTF8.</param>
        /// <returns>The encrypted string.</returns>
        public static string Encrypt(string data, Encoding encoding = null)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }
            if (encoding == null)
            {
                encoding = Encoding.UTF8;
            }

            return Convert.ToBase64String(encoding.GetBytes(data));
        }

        /// <summary>
        /// Base64 decryption.
        /// </summary>
        /// <param name="data">The string to be decrypted,not null.</param>
        /// <param name="encoding">The <see cref="T:System.Text.Encoding"/>,default is Encoding.UTF8.</param>
        /// <returns>The decrypted string.</returns>
        public static string Decrypt(string data, Encoding encoding = null)
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }
            if (encoding == null)
            {
                encoding = Encoding.UTF8;
            }

            return encoding.GetString(Convert.FromBase64String(data));
        }
    }
}
