using System;
using System.Text;

namespace GodSharp.Encryption
{
    /// <summary>
    /// The result of hash.
    /// </summary>
    public class HashResult
    {
        /// <summary>
        /// Gets the hash bytes.
        /// </summary>
        /// <value>
        /// The hash bytes.
        /// </value>
        public byte[] HashBytes { get; private set; }

        /// <summary>
        /// Gets the hash base64 string.
        /// </summary>
        /// <value>
        /// The hash base64 string.
        /// </value>
        public string HashBase64String { get; private set; }

        /// <summary>
        /// Gets the hexadecimal upper string.
        /// </summary>
        /// <value>
        /// The hexadecimal upper string.
        /// </value>
        public string HexUpperString { get; private set; }

        /// <summary>
        /// Gets the hexadecimal upper bytes.
        /// </summary>
        /// <value>
        /// The hexadecimal upper bytes.
        /// </value>
        public byte[] HexUpperBytes { get; private set; }

        /// <summary>
        /// Gets the hexadecimal upper base64 string.
        /// </summary>
        /// <value>
        /// The hexadecimal upper base64 string.
        /// </value>
        public string HexUpperBase64String { get;private set; }

        /// <summary>
        /// Gets the hexadecimal lower string.
        /// </summary>
        /// <value>
        /// The hexadecimal lower string.
        /// </value>
        public string HexLowerString { get; private set; }

        /// <summary>
        /// Gets the hexadecimal lower bytes.
        /// </summary>
        /// <value>
        /// The hexadecimal lower bytes.
        /// </value>
        public byte[] HexLowerBytes { get; private set; }

        /// <summary>
        /// Gets the hexadecimal lower base64 string.
        /// </summary>
        /// <value>
        /// The hexadecimal lower base64 string.
        /// </value>
        public string HexLowerBase64String { get; private set; }

        /// <summary>
        /// Initializes a new instance of the <see cref="HashResult"/> class.
        /// </summary>
        /// <param name="bytes">The bytes.</param>
        /// <param name="encoding">The <see cref="T:System.Text.Encoding"/>,default is <see cref="Encoding.UTF8"/>.</param>
        public HashResult(byte[] bytes, Encoding encoding=null)
        {
            if (bytes == null) return;

            if (encoding == null) encoding = Encoding.UTF8;

            HashBytes = bytes;

            HashBase64String = Convert.ToBase64String(bytes);

            string hex = BitConverter.ToString(bytes);

            HexUpperString = hex.Replace("-", "");

            HexUpperBytes = encoding.GetBytes(HexUpperString);

            HexUpperBase64String = Convert.ToBase64String(HexUpperBytes);

            HexLowerString = HexUpperString?.ToLower();

            HexLowerBytes = encoding.GetBytes(HexLowerString);

            HexLowerBase64String = Convert.ToBase64String(HexLowerBytes);
        }
    }
}
