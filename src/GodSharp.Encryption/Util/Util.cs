using System;
using System.Runtime.CompilerServices;
using System.Text;

[assembly: InternalsVisibleTo("GodSharp.Encryption.Test")]

namespace GodSharp.Encryption
{
    internal class Util
    {
        /// <summary>
        /// Get 8 bytes random string.
        /// </summary>
        /// <param name="bits"></param>
        /// <returns></returns>
        public static string GetRandomString(int bits=8)
        {
            string str = "0123456789abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ!\"#$%&'()*+,-./:;<=>?@[\\]^_`{|}~";
            int length = str.Length;

            StringBuilder builder = new StringBuilder();

            //Random random = new Random();

            byte[] b = new byte[4];
            new System.Security.Cryptography.RNGCryptoServiceProvider().GetBytes(b);
            Random random = new Random(BitConverter.ToInt32(b, 0));

            //Random random = new Random(new Guid().GetHashCode());

            //int tmp = (int)DateTime.Now.Ticks;
            //Random random = new Random(tmp);

            for (int i = 0; i < bits; i++)
            {
                builder.Append(str.Substring(random.Next(0, length), 1));
            }

            return builder.ToString();
        }
    }
}
