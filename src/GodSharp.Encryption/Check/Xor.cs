using System;
using System.Text;

namespace GodSharp.Encryption
{
    /// <summary>
    /// Xor check.
    /// </summary>
    public class Xor
    {
        /// <summary>
        /// Computes the specified <paramref name="val"/> xor value.
        /// </summary>
        /// <param name="val">The value.</param>
        /// <param name="encoding">The encoding.</param>
        /// <returns></returns>
        public static byte Compute(string val, Encoding encoding = null)
        {
            if (encoding == null) encoding = Encoding.UTF8;

            byte[] buffer = encoding.GetBytes(val);

            return Compute(buffer, 0, buffer.Length);
        }

        /// <summary>
        /// Computes the specified <paramref name="buffer"/> xor value.
        /// </summary>
        /// <param name="buffer">The buffer.</param>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">buffer</exception>
        /// <exception cref="ArgumentOutOfRangeException">length</exception>
        public static byte Compute(byte[] buffer, int index = 0) => Compute(buffer, index, buffer.Length);

        /// <summary>
        /// Computes the specified <paramref name="buffer"/> xor value.
        /// </summary>
        /// <param name="buffer">The buffer.</param>
        /// <param name="index">The index.</param>
        /// <param name="length">The length.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">buffer</exception>
        /// <exception cref="ArgumentOutOfRangeException">index</exception>
        /// <exception cref="ArgumentOutOfRangeException">length</exception>
        public static byte Compute(byte[] buffer,int index, int length)
        {
            if (buffer == null || buffer.Length == 0) throw new ArgumentNullException(nameof(buffer));

            int _length = buffer.Length;

            if (index > _length - 1 || index < 0) throw new ArgumentOutOfRangeException(nameof(index));

            if (length > _length || length < 1) throw new ArgumentOutOfRangeException(nameof(length));

            if (index + length > _length) throw new ArgumentOutOfRangeException($"{nameof(index)} & {nameof(length)}");

            byte output = 0;

            for (int i = index; i < length; i++) output ^= buffer[i];

            return output;
        }
    }
}
