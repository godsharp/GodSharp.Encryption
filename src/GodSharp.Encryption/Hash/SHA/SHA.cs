using System;
using System.Security.Cryptography;
using System.Text;

namespace GodSharp.Encryption
{
    /// <summary>
    /// Hash/SHA encryption.
    /// </summary>
    public class SHA
    {
        /// <summary>
        /// SHA encryption by <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The type of encryption.</param>
        /// <param name="data">The string to be encrypted,not null.</param>
        /// <param name="encoding">The <see cref="T:System.Text.Encoding"/>,default is <see cref="Encoding.UTF8"/>.</param>
        /// <returns>The encrypted string.</returns>
        public static HashResult Encrypt(SHAAlgorithmTypes type, string data, Encoding encoding = null)
        {
            switch (type)
            {
                case SHAAlgorithmTypes.SHA1:
                    return EncryptResultInternal<SHA1CryptoServiceProvider>(data, encoding);
                case SHAAlgorithmTypes.SHA256:
                    return EncryptResultInternal<SHA256CryptoServiceProvider>(data, encoding);
                case SHAAlgorithmTypes.SHA384:
                    return EncryptResultInternal<SHA384CryptoServiceProvider>(data, encoding);
                case SHAAlgorithmTypes.SHA512:
                    return EncryptResultInternal<SHA512CryptoServiceProvider>(data, encoding);
                default:
                    throw new ArgumentException("Not allowed type.", nameof(type));
            }
        }

        /// <summary>
        /// SHA encryption.
        /// </summary>
        /// <typeparam name="T">The <see cref="T:System.Security.Cryptography.HashAlgorithm"/> sub-class.</typeparam>
        /// <param name="data">The string to be encrypted,not null.</param>
        /// <param name="encoding">The <see cref="T:System.Text.Encoding"/>,default is <see cref="Encoding.UTF8"/>.</param>
        /// <returns>The encrypted object.</returns>
        internal static HashResult EncryptResultInternal<T>(string data, Encoding encoding = null) where T : HashAlgorithm, new()
        {
            return new HashResult(EncryptBytesInternal<T>(data, encoding), encoding);
        }

        /// <summary>
        /// SHA encryption.
        /// </summary>
        /// <typeparam name="T">The <see cref="T:System.Security.Cryptography.HashAlgorithm"/> sub-class.</typeparam>
        /// <param name="data">The string to be encrypted,not null.</param>
        /// <param name="encoding">The <see cref="T:System.Text.Encoding"/>,default is <see cref="Encoding.UTF8"/>.</param>
        /// <returns>The encrypted byte array.</returns>
        internal static byte[] EncryptBytesInternal<T>(string data, Encoding encoding = null) where T : HashAlgorithm, new()
        {
            ArgumentValidator.Validate(data);

            if (encoding == null) encoding = Encoding.UTF8;

            byte[] bytes = encoding.GetBytes(data);

            using (HashAlgorithm hash = new T())
            {
                return hash.ComputeHash(bytes);
            }
        }
    }
}
