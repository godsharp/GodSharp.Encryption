using System.Security.Cryptography;
using System.Text;

namespace GodSharp.Encryption
{
    /// <summary>
    /// Hash/HMAC encryption.
    /// </summary>
    public abstract class HMACBase<TKeyedHashAlgorithm> where TKeyedHashAlgorithm : KeyedHashAlgorithm, new()
    {
        /// <summary>
        /// HMAC encryption with <typeparamref name="TKeyedHashAlgorithm"/>.
        /// </summary>
        /// <param name="data">The string to be encrypted,not null.</param>
        /// <param name="key">Encryption key,not null.</param>
        /// <param name="encoding">The <see cref="T:System.Text.Encoding"/>,default is <see cref="Encoding.UTF8"/>.</param>
        /// <returns>The encrypted string.</returns>
        public static HashResult Encrypt(string data, string key, Encoding encoding = null)
        {
            return HMAC.EncryptResultInternal<TKeyedHashAlgorithm>(data, key, encoding);
        }
    }
}
