using System;
using System.Security.Cryptography;
using System.Text;

namespace GodSharp.Encryption
{
    /// <summary>
    /// Symmetric/XES encryption.
    /// </summary>
    public abstract class SymmetricBase<TSymmetricAlgorithm> where TSymmetricAlgorithm : SymmetricAlgorithm, new()
    {
        /// <summary>
        /// The method for encrypt or dncrypt the specified <paramref name="data"/> with <paramref name="password"/>, <paramref name="vector"/>, <paramref name="salt"/>.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="data">The string to be encrypted or decrypted,not null.</param>
        /// <param name="password">The password used to derive the key.</param>
        /// <param name="vector">The initialization vector (IV) to use to derive the key.</param>
        /// <param name="salt">The key salt to use to derive the key.The default is <paramref name="password"/>.</param>
        /// <param name="keySize">The size, in bits, of the secret key used by the symmetric algorithm.</param>
        /// <param name="blockSize">The block size, in bits, of the cryptographic operation.</param>
        /// <param name="encoding">The <see cref="T:System.Text.Encoding"/>,default is <see cref="Encoding.UTF8"/>.</param>
        /// <param name="iterations">The number of iterations for the operation.</param>
        /// <param name="mode">The mode for operation of the symmetric algorithm.</param>
        /// <param name="padding">The padding mode used in the symmetric algorithm. The default is System.Security.Cryptography.PaddingMode.PKCS7.</param>
        /// <returns>The string value by <paramref name="type"/>. </returns>
        internal static string EncryptOrDecryptString(EncryptionTypes type, string data, string password, string vector = null, string salt = null, int keySize = 128, int blockSize = 128, Encoding encoding = null, int iterations = 1000, CipherMode mode = CipherMode.ECB, PaddingMode padding = PaddingMode.PKCS7)
        {
            ArgumentValidator.Validate(data, password);

            if (encoding == null) encoding = Encoding.UTF8;

            byte[] output = EncryptOrDecrypt(type,
                type == EncryptionTypes.Encrypt ? encoding.GetBytes(data): Convert.FromBase64String(data),
                GetKeyBytes(password, salt, keySize, encoding, iterations),
                GetVectorBytes(vector, blockSize, encoding)
                , keySize, mode, padding);

            return type == EncryptionTypes.Encrypt ? Convert.ToBase64String(output) : encoding.GetString(output);
        }

        /// <summary>
        /// The method for encrypt or dncrypt the specified <paramref name="data"/> with <paramref name="password"/>, <paramref name="vector"/>, <paramref name="salt"/>.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="data">The string to be encrypted or decrypted,not null.</param>
        /// <param name="password">The password used to derive the key.</param>
        /// <param name="vector">The initialization vector (IV) to use to derive the key.</param>
        /// <param name="salt">The key salt to use to derive the key.The default is <paramref name="password"/>.</param>
        /// <param name="keySize">The size, in bits, of the secret key used by the symmetric algorithm.</param>
        /// <param name="blockSize">The block size, in bits, of the cryptographic operation.</param>
        /// <param name="encoding">The <see cref="T:System.Text.Encoding"/>,default is <see cref="Encoding.UTF8"/>.</param>
        /// <param name="iterations">The number of iterations for the operation.</param>
        /// <param name="mode">The mode for operation of the symmetric algorithm.</param>
        /// <param name="padding">The padding mode used in the symmetric algorithm. The default is System.Security.Cryptography.PaddingMode.PKCS7.</param>
        /// <returns>The array of <see cref="byte"/> value by <paramref name="type"/>. </returns>
        internal static byte[] EncryptOrDecryptBytes(EncryptionTypes type, string data, string password, string vector = null, string salt = null, int keySize = 128, int blockSize = 128, Encoding encoding = null, int iterations = 1000, CipherMode mode = CipherMode.ECB, PaddingMode padding = PaddingMode.PKCS7)
        {
            ArgumentValidator.Validate(data, password);

            if (encoding == null) encoding = Encoding.UTF8;

            return EncryptOrDecrypt(type,
                type == EncryptionTypes.Encrypt ? encoding.GetBytes(data) : Convert.FromBase64String(data),
                GetKeyBytes(password, salt, keySize, encoding, iterations),
                GetVectorBytes(vector, blockSize, encoding)
                , keySize, mode, padding);
        }

        /// <summary>
        /// Gets the key bytes.
        /// </summary>
        /// <param name="password">The password used to derive the key.</param>
        /// <param name="salt">The key salt used to derive the key.</param>
        /// <param name="size">The size, in bits, of the secret key used by the symmetric algorithm.</param>
        /// <param name="encoding">The <see cref="T:System.Text.Encoding"/>,default is <see cref="Encoding.UTF8"/>.</param>
        /// <param name="iterations">The number of iterations for the operation.</param>
        /// <returns></returns>
        internal static byte[] GetKeyBytes(string password, string salt = null, int size = 128, Encoding encoding = null, int iterations = 1000)
        {
            ArgumentValidator.Validate(password);

            if (encoding == null) encoding = Encoding.UTF8;

            int length = size / 8;

            byte[] buffer = salt == null ? encoding.GetBytes(password) : encoding.GetBytes(salt);

            Rfc2898DeriveBytes derive = new Rfc2898DeriveBytes(password, buffer, iterations);

            return derive.GetBytes(length);
        }

        /// <summary>
        /// Gets the vector bytes.
        /// </summary>
        /// <param name="vector">The initialization vector (IV) to use to derive the key.</param>
        /// <param name="size">The block size, in bits, of the cryptographic operation.</param>
        /// <param name="encoding">The <see cref="T:System.Text.Encoding"/>,default is <see cref="Encoding.UTF8"/>.</param>
        /// <returns></returns>
        public static byte[] GetVectorBytes(string vector, int size = 128, Encoding encoding = null)
        {
            if (vector == null) return null;

            if (encoding == null) encoding = Encoding.UTF8;

            int length = size / 8;

            byte[] buffer = new byte[length];

            Array.Copy(encoding.GetBytes(vector.PadRight(length)), buffer, length);

            return buffer;
        }

        /// <summary>
        /// The method for encrypt or dncrypt the specified data.
        /// </summary>
        /// <param name="type">The type.</param>
        /// <param name="source">The source data for <paramref name="type"/>.</param>
        /// <param name="key">Gets or sets the secret key for the symmetric algorithm.</param>
        /// <param name="iv">The initialization vector (IV) to use to derive the key.</param>
        /// <param name="keySize">Size of the key.</param>
        /// <param name="mode">The mode.</param>
        /// <param name="padding">The padding.</param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException">source</exception>
        internal static byte[] EncryptOrDecrypt(EncryptionTypes type, byte[] source, byte[] key, byte[] iv, int keySize = 128, CipherMode mode = CipherMode.ECB, PaddingMode padding = PaddingMode.PKCS7)
        {
            ArgumentValidator.Validate(source, key);

            byte[] output = null;

            using (TSymmetricAlgorithm provider = new TSymmetricAlgorithm() { KeySize = keySize, Mode = mode, Padding = padding, Key = key })
            {
                if (iv != null) provider.IV = iv;
                using (ICryptoTransform encryptor = type == EncryptionTypes.Encrypt ? provider.CreateEncryptor() : provider.CreateDecryptor())
                {
                    output = encryptor.TransformFinalBlock(source, 0, source.Length);
                }

                provider.Clear();
            }

            return output;
        }
    }
}
