using System;
using System.Security.Cryptography;
using System.Text;

namespace GodSharp.Encryption
{
    /// <summary>
    /// Hash/SHA1 encryption.
    /// </summary>
    public abstract class SHA
    {
        /// <summary>
        /// SHA1 encryption.
        /// </summary>
        /// <typeparam name="T">The <see cref="T:System.Security.Cryptography.HashAlgorithm"/> sub-class.</typeparam>
        /// <param name="data">The string to be encrypted,not null.</param>
        /// <param name="encoding">The <see cref="T:System.Text.Encoding"/>,default is Encoding.UTF8.</param>
        /// <returns>The encrypted string.</returns>
        internal static string Encrypt<T>(string data, Encoding encoding = null) where T : HashAlgorithm, new()
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }
            if (encoding == null)
            {
                encoding = Encoding.UTF8;
            }

            byte[] bytes = encoding.GetBytes(data);

            using (HashAlgorithm hash = new T())
            {
                bytes = hash.ComputeHash(bytes);

                StringBuilder buidler = new StringBuilder();
                foreach (byte item in bytes)
                {
                    buidler.AppendFormat("{0:x2}", item);
                }

                return buidler.ToString();
            }
        }
    }
}
