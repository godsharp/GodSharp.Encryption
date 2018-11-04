using System.Security.Cryptography;
using System.Text;

namespace GodSharp.Encryption
{
    /// <summary>
    /// Symmetric/Rijndael encryption with <see cref="System.Security.Cryptography.RijndaelManaged"/>.
    /// </summary>
    public class Rijndael : SymmetricBase<RijndaelManaged>
    {
        /// <summary>
        /// AES encryption with <see cref="System.Security.Cryptography.RijndaelManaged"/>.
        /// </summary>
        /// <param name="data">The string to be encrypted,not null.</param>
        /// <param name="password">The password used to derive the key.</param>
        /// <param name="vector">The initialization vector (IV) to use to derive the key.</param>
        /// <param name="salt">The key salt to use to derive the key.The default is <paramref name="password"/>.</param>
        /// <param name="keySize">The size, in bits, of the secret key used by the symmetric algorithm.</param>
        /// <param name="encoding">The <see cref="T:System.Text.Encoding"/>,default is <see cref="Encoding.UTF8"/>.</param>
        /// <param name="iterations">The number of iterations for the operation.</param>
        /// <param name="mode">The mode for operation of the symmetric algorithm.</param>
        /// <param name="padding">The padding mode used in the symmetric algorithm. The default is System.Security.Cryptography.PaddingMode.PKCS7.</param>
        /// <returns>The encrypted string.</returns>
        public static string Encrypt(string data, string password, string vector = null, string salt = null, AESKeySizeFlags keySize = AESKeySizeFlags.L256, Encoding encoding = null, int iterations = 1000, CipherMode mode = CipherMode.ECB, PaddingMode padding = PaddingMode.PKCS7)
        {
            return EncryptOrDecryptString(EncryptionTypes.Encrypt, data, password, salt, vector, (int)keySize, 128, encoding, iterations, mode, padding);
        }

        /// <summary>
        /// AES encryption with <see cref="System.Security.Cryptography.RijndaelManaged"/>.
        /// </summary>
        /// <param name="data">The string to be decrypted,not null.</param>
        /// <param name="password">The password used to derive the key.</param>
        /// <param name="vector">The initialization vector (IV) to use to derive the key.</param>
        /// <param name="salt">The key salt to use to derive the key.The default is <paramref name="password"/>.</param>
        /// <param name="keySize">The size, in bits, of the secret key used by the symmetric algorithm.</param>
        /// <param name="encoding">The <see cref="T:System.Text.Encoding"/>,default is <see cref="Encoding.UTF8"/>.</param>
        /// <param name="iterations">The number of iterations for the operation.</param>
        /// <param name="mode">The mode for operation of the symmetric algorithm.</param>
        /// <param name="padding">The padding mode used in the symmetric algorithm. The default is System.Security.Cryptography.PaddingMode.PKCS7.</param>
        /// <returns>The decryption string.</returns>
        public static string Decrypt(string data, string password, string vector = null, string salt = null, AESKeySizeFlags keySize = AESKeySizeFlags.L256, Encoding encoding = null, int iterations = 1000, CipherMode mode = CipherMode.ECB, PaddingMode padding = PaddingMode.PKCS7)
        {
            return EncryptOrDecryptString(EncryptionTypes.Decrypt, data, password, salt, vector, (int)keySize, 128, encoding, iterations, mode, padding);
        }

        /// <summary>
        /// AES encryption with <see cref="System.Security.Cryptography.RijndaelManaged"/>.
        /// </summary>
        /// <param name="data">The string to be encrypted,not null.</param>
        /// <param name="password">The password used to derive the key.</param>
        /// <param name="vector">The initialization vector (IV) to use to derive the key.</param>
        /// <param name="salt">The key salt to use to derive the key.The default is <paramref name="password"/>.</param>
        /// <param name="keySize">The size, in bits, of the secret key used by the symmetric algorithm.</param>
        /// <param name="encoding">The <see cref="T:System.Text.Encoding"/>,default is <see cref="Encoding.UTF8"/>.</param>
        /// <param name="iterations">The number of iterations for the operation.</param>
        /// <param name="mode">The mode for operation of the symmetric algorithm.</param>
        /// <param name="padding">The padding mode used in the symmetric algorithm. The default is System.Security.Cryptography.PaddingMode.PKCS7.</param>
        /// <returns>The encrypted byte array.</returns>
        public static byte[] EncryptBytes(string data, string password, string vector = null, string salt = null, AESKeySizeFlags keySize = AESKeySizeFlags.L256, Encoding encoding = null, int iterations = 1000, CipherMode mode = CipherMode.ECB, PaddingMode padding = PaddingMode.PKCS7)
        {
            return EncryptOrDecryptBytes(EncryptionTypes.Encrypt, data, password, salt, vector, (int)keySize, 128, encoding, iterations, mode, padding);
        }

        /// <summary>
        /// AES encryption with <see cref="System.Security.Cryptography.RijndaelManaged"/>.
        /// </summary>
        /// <param name="data">The string to be decrypted,not null.</param>
        /// <param name="password">The password used to derive the key.</param>
        /// <param name="vector">The initialization vector (IV) to use to derive the key.</param>
        /// <param name="salt">The key salt to use to derive the key.The default is <paramref name="password"/>.</param>
        /// <param name="keySize">The size, in bits, of the secret key used by the symmetric algorithm.</param>
        /// <param name="encoding">The <see cref="T:System.Text.Encoding"/>,default is <see cref="Encoding.UTF8"/>.</param>
        /// <param name="iterations">The number of iterations for the operation.</param>
        /// <param name="mode">The mode for operation of the symmetric algorithm.</param>
        /// <param name="padding">The padding mode used in the symmetric algorithm. The default is System.Security.Cryptography.PaddingMode.PKCS7.</param>
        /// <returns>The decryption byte array.</returns>
        public static byte[] DecryptBytes(string data, string password, string vector = null, string salt = null, AESKeySizeFlags keySize = AESKeySizeFlags.L256, Encoding encoding = null, int iterations = 1000, CipherMode mode = CipherMode.ECB, PaddingMode padding = PaddingMode.PKCS7)
        {
            return EncryptOrDecryptBytes(EncryptionTypes.Decrypt, data, password, salt, vector, (int)keySize, 128, encoding, iterations, mode, padding);
        }
    }
}
