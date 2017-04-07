using System.Text;

namespace GodSharp.Encryption
{
    /// <summary>
    /// Hash/HMAC/HMACRIPEMD160 encryption.
    /// </summary>
    public class HMACRIPEMD160:HMAC
    {
        /// <summary>
        /// HMACRIPEMD160 encryption.
        /// </summary>
        /// <param name="data">The string to be encrypted,not null.</param>
        /// <param name="key">Encryption key,not null.</param>
        /// <param name="encoding">The <see cref="T:System.Text.Encoding"/>,default is Encoding.UTF8.</param>
        /// <returns>The encrypted string.</returns>
        public static string Encrypt(string data, string key, Encoding encoding = null)
        {
            return Encrypt<System.Security.Cryptography.HMACRIPEMD160>(data, key, encoding);
        }
    }
}
