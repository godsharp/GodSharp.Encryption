using System;
using System.Security.Cryptography;
using System.Text;

namespace GodSharp.Encryption
{
    /// <summary>
    /// Hash/HMAC encryption.
    /// </summary>
    public abstract class HMAC
    {
        /// <summary>
        /// HMAC encryption.
        /// </summary>
        /// <typeparam name="T">The <see cref="T:System.Security.Cryptography.HMAC"/> sub-class.</typeparam>
        /// <param name="data">The string to be encrypted,not null.</param>
        /// <param name="key">Encryption key,not null.</param>
        /// <param name="encoding">The <see cref="T:System.Text.Encoding"/>,default is Encoding.UTF8.</param>
        /// <returns>The encrypted string.</returns>
        internal static string Encrypt<T>(string data, string key,Encoding encoding=null) where T : KeyedHashAlgorithm, new()
        {
            if (data==null)
            {
                throw new ArgumentNullException(nameof(data));
            }
            if (key==null)
            {
                throw new ArgumentNullException(nameof(key));
            }
            if (encoding==null)
            {
                encoding = Encoding.UTF8;
            }

            byte[] keys = encoding.GetBytes(key);
            byte[] datas = encoding.GetBytes(data);

            using (T hash = new T())
            {
                hash.Key = keys;
                byte[] result = hash.ComputeHash(datas);
                return Convert.ToBase64String(result);
            }
        }
    }
}
