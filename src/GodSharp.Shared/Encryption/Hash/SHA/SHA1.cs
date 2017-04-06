using System.Text;
using System.Security.Cryptography;

namespace GodSharp.Encryption
{
    /// <summary>
    /// Hash/SHA1 encryption.
    /// </summary>
    public class SHA1:SHA
    {
        /// <param name="data">The string to be encrypted,not null.</param>
        /// <param name="encoding">The <see cref="T:System.Text.Encoding"/>,default is Encoding.UTF8.</param>
        /// <returns>The encrypted string.</returns>
        public static string Encrypt(string data, Encoding encoding = null)
        {
            return Encrypt<SHA1CryptoServiceProvider>(data, encoding);
        }
    }
}