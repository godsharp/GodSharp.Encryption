using System;
using System.Security.Cryptography;
using System.Text;

namespace GodSharp.Encryption
{
    /// <summary>
    /// Symmetric/XES encryption.
    /// </summary>
    public abstract class XES
    {
        /// <summary>
        /// XES encryption.
        /// </summary>
        /// <typeparam name="T">The <see cref="T:System.Security.Cryptography.SymmetricAlgorithm"/> sub-class.</typeparam>
        /// <param name="data">The string to be encrypted,not null.</param>
        /// <param name="password">The password to derive the key for.</param>
        /// <param name="encoding">The <see cref="T:System.Text.Encoding"/>,default is Encoding.UTF8.</param>
        /// <param name="model">The mode for operation of the symmetric algorithm.</param>
        /// <param name="hashName">The hash algorithm to use to derive the key.</param>
        /// <param name="keySize">The size, in bits, of the secret key used by the symmetric algorithm.</param>
        /// <param name="blockSize">The block size, in bits, of the cryptographic operation.</param>
        /// <param name="salt">The key salt to use to derive the key.</param>
        /// <param name="vector">The initialization vector (IV) to use to derive the key.</param>
        /// <returns>The encrypted string.</returns>
        internal static string Encrypt<T>(string data, string password, Encoding encoding =null, CipherMode model= CipherMode.ECB, string hashName= "SHA1",int keySize=128,int blockSize=128, string salt=null,string vector=null,int iterations=1000)
                where T : SymmetricAlgorithm, new()
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }
            if (encoding == null)
            {
                encoding = Encoding.UTF8;
            }

            byte[] valueBytes = encoding.GetBytes(data);

            byte[] encrypted;
            using (T cipher = new T())
            {
                cipher.KeySize = keySize;
                cipher.BlockSize = blockSize;
                cipher.Mode = model;
                //cipher.Padding = PaddingMode.Zeros;

                int keyLength = keySize / 8;

                byte[] saltBytes = salt == null ? encoding.GetBytes(password) : encoding.GetBytes(salt);
                PasswordDeriveBytes pdb = new PasswordDeriveBytes(password, saltBytes, hashName, iterations);
                byte[] keyBytes = pdb.GetBytes(keyLength);

                cipher.Key = keyBytes;

                if (vector != null)
                {
                    int vectorLength = blockSize / 8;
                    byte[] bVector = new byte[vectorLength];
                    Array.Copy(encoding.GetBytes(vector.PadRight(vectorLength)), bVector, vectorLength);
                    cipher.IV = bVector;
                }

                using (ICryptoTransform encryptor = cipher.CreateEncryptor())
                {
                    encrypted = encryptor.TransformFinalBlock(valueBytes, 0, valueBytes.Length);
                }

                cipher.Clear();
            }

            return Convert.ToBase64String(encrypted);
        }

        /// <summary>
        /// XES decryption.
        /// </summary>
        /// <typeparam name="T">The <see cref="T:System.Security.Cryptography.SymmetricAlgorithm"/> sub-class.</typeparam>
        /// <param name="data">The string to be decrypted,not null.</param>
        /// <param name="password">The password to derive the key for.</param>
        /// <param name="encoding">The <see cref="T:System.Text.Encoding"/>,default is Encoding.UTF8.</param>
        /// <param name="model">The mode for operation of the symmetric algorithm.</param>
        /// <param name="hashName">The hash algorithm to use to derive the key.</param>
        /// <param name="keySize">The size, in bits, of the secret key used by the symmetric algorithm.</param>
        /// <param name="blockSize">The block size, in bits, of the cryptographic operation.</param>
        /// <param name="salt">The key salt to use to derive the key.</param>
        /// <param name="vector">The initialization vector (IV) to use to derive the key.</param>
        /// <returns>The decryption string.</returns>
        internal static string Decrypt<T>(string data, string password, Encoding encoding = null, CipherMode model = CipherMode.ECB, string hashName = "SHA1", int keySize = 128, int blockSize = 128, string salt = null, string vector = null, int iterations = 1000) where T : SymmetricAlgorithm, new()
        {
            if (data == null)
            {
                throw new ArgumentNullException(nameof(data));
            }
            if (encoding == null)
            {
                encoding = Encoding.UTF8;
            }

            byte[] valueBytes = Convert.FromBase64String(data);

            byte[] decrypted;

            using (T cipher = new T())
            {
                cipher.KeySize = keySize;
                cipher.BlockSize = blockSize;
                cipher.Mode = model;
                //cipher.Padding = PaddingMode.Zeros;

                int keyLength = keySize / 8;

                byte[] saltBytes = salt == null ? encoding.GetBytes(password) : encoding.GetBytes(salt);
                PasswordDeriveBytes pdb = new PasswordDeriveBytes(password, saltBytes, hashName, iterations);
                byte[] keyBytes = pdb.GetBytes(keyLength);

                cipher.Key = keyBytes;

                if (vector != null)
                {
                    int vectorLength = blockSize / 8;
                    byte[] bVector = new byte[vectorLength];
                    Array.Copy(encoding.GetBytes(vector.PadRight(vectorLength)), bVector, vectorLength);
                    cipher.IV = bVector;
                }

                using (ICryptoTransform decryptor = cipher.CreateDecryptor())
                {
                    decrypted = decryptor.TransformFinalBlock(valueBytes, 0, valueBytes.Length);
                }

                cipher.Clear();
            }

            return encoding.GetString(decrypted);
        }
    }
}
