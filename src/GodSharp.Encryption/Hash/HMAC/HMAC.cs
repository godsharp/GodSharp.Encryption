using System;
using System.Security.Cryptography;
using System.Text;

namespace GodSharp.Encryption
{
    /// <summary>
    /// Hash/HMAC encryption.
    /// </summary>
    public class HMAC
    {
        /// <summary>
        /// HMAC encryption with <paramref name="type"/>.
        /// </summary>
        /// <param name="type">The type of encryption.</param>
        /// <param name="data">The string to be encrypted,not null.</param>
        /// <param name="key">Encryption key,not null.</param>
        /// <param name="encoding">The <see cref="T:System.Text.Encoding"/>,default is <see cref="Encoding.UTF8"/>.</param>
        /// <returns>The encrypted string.</returns>
        public static HashResult Encrypt(HMACAlgorithmTypes type, string data, string key, Encoding encoding = null)
        {
            switch (type)
            {
                case HMACAlgorithmTypes.MD5:
                    return EncryptResultInternal<System.Security.Cryptography.HMACMD5>(data, key, encoding);
#if NFX
                case HMACAlgorithmTypes.RIPEMD160:
                    return EncryptResultInternal<System.Security.Cryptography.HMACRIPEMD160>(data, key, encoding); 
#endif
                case HMACAlgorithmTypes.SHA1:
                    return EncryptResultInternal<System.Security.Cryptography.HMACSHA1>(data, key, encoding);
                case HMACAlgorithmTypes.SHA256:
                    return EncryptResultInternal<System.Security.Cryptography.HMACSHA256>(data, key, encoding);
                case HMACAlgorithmTypes.SHA384:
                    return EncryptResultInternal<System.Security.Cryptography.HMACSHA384>(data, key, encoding);
                case HMACAlgorithmTypes.SHA512:
                    return EncryptResultInternal<System.Security.Cryptography.HMACSHA512>(data, key, encoding);
                default:
                    throw new ArgumentException("Not allowed type.", nameof(type));
            }
        }

        /// <summary>
        /// HMAC encryption.
        /// </summary>
        /// <param name="data">The string to be encrypted,not null.</param>
        /// <param name="key">Encryption key,not null.</param>
        /// <param name="encoding">The <see cref="T:System.Text.Encoding"/>,default is <see cref="Encoding.UTF8"/>.</param>
        /// <returns>The encrypted string.</returns>
        internal static HashResult EncryptResultInternal<TKeyedHashAlgorithm>(string data, string key, Encoding encoding = null) where TKeyedHashAlgorithm : KeyedHashAlgorithm, new()
        {
            return new HashResult(EncryptBytesInternal<TKeyedHashAlgorithm>(data, key, encoding), encoding);
        }

        /// <summary>
        /// HMAC encryption.
        /// </summary>
        /// <param name="data">The string to be encrypted,not null.</param>
        /// <param name="key">Encryption key,not null.</param>
        /// <param name="encoding">The <see cref="T:System.Text.Encoding"/>,default is <see cref="Encoding.UTF8"/>.</param>
        /// <returns>The encrypted string.</returns>
        private static byte[] EncryptBytesInternal<TKeyedHashAlgorithm>(string data, string key, Encoding encoding = null) where TKeyedHashAlgorithm : KeyedHashAlgorithm, new()
        {
            ArgumentValidator.Validate(data, key);

            if (encoding == null) encoding = Encoding.UTF8;

            byte[] keys = encoding.GetBytes(key);
            byte[] datas = encoding.GetBytes(data);
            
            using (TKeyedHashAlgorithm hash = new TKeyedHashAlgorithm() { Key = keys })
            {
                return hash.ComputeHash(datas);
            }
        }
    }
}
