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
        /// MD5 encrypt mehtod,default encrypt string is 32 bits.
        /// </summary>
        /// <param name="data">The string of encrypt.</param>
        /// <param name="bit">Encrypt string bits number,only 16,32,64.</param>
        /// <returns>Encrypt string.</returns>
        public static string Encrypt(string data, int bit=32, Encoding encoding = null)
        {
            try
            {
                if (data == null)
                {
                    throw new ArgumentNullException(nameof(data));
                }
                if (encoding == null)
                {
                    encoding = Encoding.UTF8;
                }
                
                string result = null;
                switch (bit)
                {
                    case 16:
                        result = Encrypt16(data, encoding);
                        break;
                    case 32:
                        result = Encrypt32(data, encoding);
                        break;
                    case 64:
                        result = Encrypt64(data, encoding);
                        break;
                    default:
                        result = Encrypt32(data, encoding);
                        break;
                }
                return result;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// MD5 encrypt with 16 bits.
        /// </summary>
        /// <param name="str">The string of encrypt.</param>
        /// <returns>Encrypt string.</returns>
        private static string Encrypt16(string str, Encoding encoding = null)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

            string result = BitConverter.ToString(md5.ComputeHash(encoding.GetBytes(str)), 4, 8);
            result = result.Replace("-", "");
            return result;
        }

        /// <summary>
        /// MD5 encrypt with 32 bits.
        /// </summary>
        /// <param name="str">The string of encrypt.</param>
        /// <returns>Encrypt string.</returns>
        private static string Encrypt32(string str, Encoding encoding = null)
        {
            string result = null;

            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();

            byte[] s = md5.ComputeHash(encoding.GetBytes(str));

            for (int i = 0; i < s.Length; i++)
            {
                result = result + s[i].ToString("X2");
            }
            return result;
        }

        /// <summary>
        /// MD5 encrypt with 64 bits.
        /// </summary>
        /// <param name="str">The string of encrypt.</param>
        /// <returns>Encrypt string.</returns>
        private static string Encrypt64(string str, Encoding encoding = null)
        {
            string cl = str;
            
            System.Security.Cryptography.MD5 md5 = System.Security.Cryptography.MD5.Create();

            byte[] s = md5.ComputeHash(encoding.GetBytes(cl));

            return Convert.ToBase64String(s);
        }
    }
}