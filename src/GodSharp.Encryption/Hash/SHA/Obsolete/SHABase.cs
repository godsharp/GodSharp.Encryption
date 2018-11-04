using System.Security.Cryptography;
using System.Text;

namespace GodSharp.Encryption
{
    /// <summary>
    /// Hash/SHA encryption base class.
    /// </summary>
    public abstract class SHABase<THashAlgorithm> where THashAlgorithm : HashAlgorithm, new()
    {
        /// <summary>
        /// SHA encryption by <typeparamref name="THashAlgorithm"/>.
        /// </summary>
        /// <param name="data">The string to be encrypted,not null.</param>
        /// <param name="encoding">The <see cref="T:System.Text.Encoding"/>,default is <see cref="Encoding.UTF8"/>.</param>
        /// <returns>The encrypted object.</returns>
        public static HashResult Encrypt(string data, Encoding encoding = null)
        {
            return SHA.EncryptResultInternal<THashAlgorithm>(data, encoding);
        }
    }
}
