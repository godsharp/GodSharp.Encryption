using System;
using System.Text;
using System.Security.Cryptography;

namespace GodSharp.Encryption
{
    /// <summary>
    /// MD5 encryption.
    /// </summary>
    public class MD5
    {
        /// <summary>
        /// MD5 encrypt mehtod.
        /// </summary>
        /// <param name="data">The string of encrypt.</param>
        /// <param name="encoding">The <see cref="T:System.Text.Encoding"/>,default is <see cref="Encoding.UTF8"/>.</param>
        /// <param name="bit">Encrypt string bits number,only 16,32,64.</param>
        /// <returns>Encrypt string.</returns>
        public static string Encrypt(string data, Encoding encoding = null, MD5Types bit = MD5Types.L32)
        {
            return EncryptInternal(bit, data, encoding);
        }

        /// <summary>
        /// MD5 encrypt mehtod.
        /// </summary>
        /// <param name="data">The string of encrypt.</param>
        /// <param name="encoding">The <see cref="T:System.Text.Encoding"/>,default is <see cref="Encoding.UTF8"/>.</param>
        /// <returns>Encrypt byte array.</returns>
        public static byte[] EncryptBytes(string data, Encoding encoding = null)
        {
            return EncryptBytesInternal(data, encoding);
        }

        /// <summary>
        /// MD5 encrypt.
        /// </summary>
        /// <param name="bit">Encrypt string bits number,only 16,32,64.</param>
        /// <param name="data">The string of encrypt.</param>
        /// <param name="encoding">The <see cref="T:System.Text.Encoding"/>,default is <see cref="Encoding.UTF8"/>.</param>
        /// <returns>Encrypt string.</returns>
        private static string EncryptInternal(MD5Types bit, string data, Encoding encoding)
        {
            byte[] output = EncryptBytesInternal(data, encoding);

            switch (bit)
            {
                case MD5Types.L16:
                    return BitConverter.ToString(output, 4, 8).Replace("-", "");
                case MD5Types.L32:
                    {
                        StringBuilder builder = new StringBuilder(32);

                        foreach (var item in output)
                        {
                            builder.Append(item.ToString("X2"));
                        }

                        return builder.ToString();
                    }
                case MD5Types.L64:
                    return Convert.ToBase64String(output);
                default:
                    throw new ArgumentOutOfRangeException(nameof(bit), "Not allowed value");
            }
        }

        /// <summary>
        /// MD5 encrypt.
        /// </summary>
        /// <param name="data">The string of encrypt.</param>
        /// <param name="encoding">The <see cref="T:System.Text.Encoding"/>,default is <see cref="Encoding.UTF8"/>.</param>
        /// <returns>Encrypt byte array.</returns>
        private static byte[] EncryptBytesInternal(string data, Encoding encoding)
        {
            ArgumentValidator.Validate(data);

            if (encoding == null)
            {
                encoding = Encoding.UTF8;
            }

            using (MD5CryptoServiceProvider provider = new MD5CryptoServiceProvider())
            {
                return provider.ComputeHash(encoding.GetBytes(data));
            }
        }
    }
}