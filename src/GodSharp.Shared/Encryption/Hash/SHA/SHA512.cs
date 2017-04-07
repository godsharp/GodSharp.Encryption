using System.Security.Cryptography;
using System.Text;

namespace GodSharp.Encryption
{
    /// <summary>
    /// Hash/SHA1/SHA512 encryption.
    /// </summary>
    public class SHA512 : SHA
    {
        /// <param name="data">The string to be encrypted,not null.</param>
        /// <param name="encoding">The <see cref="T:System.Text.Encoding"/>,default is Encoding.UTF8.</param>
        /// <returns>The encrypted string.</returns>
        public static string Encrypt(string data, Encoding encoding = null)
        {
            return Encrypt<SHA512CryptoServiceProvider>(data, encoding);
        }
    }
}
