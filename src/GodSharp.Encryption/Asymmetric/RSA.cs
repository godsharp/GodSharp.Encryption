using System;
using System.Text;
using System.Security.Cryptography;
using System.Security.Cryptography.X509Certificates;
using System.IO;

namespace GodSharp.Encryption
{
    /// <summary>
    /// Asymmetric/RSA encryption.
    /// </summary>
    public static class RSA
    {
        /// <summary>
        /// Gets or sets the open SSL.
        /// </summary>
        /// <value>
        /// The open SSL.
        /// </value>
        public static RSAOpenSsl OpenSsl => RSAOpenSslSingletonContainer.Instance;

        #region Get public and private key of xml format.
        /// <summary>
        /// Get public and private key of xml format.
        /// </summary>
        /// <param name="xmlPrivateKey">The private key of xml format.</param>
        /// <param name="xmlPublicKey">The public key of xml format.</param>
        /// <param name="size">The size of the key to use in bits</param>
        public static void CreateXmlKey(out string xmlPrivateKey, out string xmlPublicKey, RSASizeTypes size = RSASizeTypes.L2048)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider((int)size))
            {
                xmlPrivateKey = rsa.ToXmlString(true);
                xmlPublicKey = rsa.ToXmlString(false);
            }
        }
        #endregion

        #region Get public and private key of xml format from certificate file.
        /// <summary>
        /// Get private key of xml format from certificate file.
        /// </summary>
        /// <param name="certFile">The string path of certificate file.</param>
        /// <param name="password">The string password of certificate file.</param>
        /// <returns>String private key of xml format.</returns>
        public static string GetPrivateKey(string certFile, string password)
        {
            X509Certificate2 cert = GetX509Certificate2(certFile);

            return cert.PrivateKey.ToXmlString(true);
        }

        /// <summary>
        /// Get public key of xml format from certificate file.
        /// </summary>
        /// <param name="certFile">The string path of certificate file.</param>
        /// <returns>String public key of xml format.</returns>
        public static string GetPublicKey(string certFile)
        {
            X509Certificate2 cert = GetX509Certificate2(certFile);

            return cert.PublicKey.Key.ToXmlString(false);
        }

        /// <summary>
        /// Gets the X509 certificate2.
        /// </summary>
        /// <param name="certFile">The cert file.</param>
        /// <returns></returns>
        /// <exception cref="FileNotFoundException">certFile</exception>
        private static X509Certificate2 GetX509Certificate2(string certFile)
        {
            if (!File.Exists(certFile)) throw new FileNotFoundException(nameof(certFile));

            return new X509Certificate2(certFile);
        }
        #endregion

        #region encrypt/decrypt string or byte[] with xml format.
        /// <summary>
        /// Encrypt string data with xml format.
        /// </summary>
        /// <param name="data">The data to be encrypted.</param>
        /// <param name="xmlPublicKey">The public key of xml format.</param>
        /// <param name="encoding">The <see cref="T:System.Text.Encoding"/>,default is Encoding.UTF8.</param>
        /// <returns>The encrypted data.</returns>
        public static string Encrypt(string data, string xmlPublicKey, Encoding encoding = null)
        {
            if (encoding == null) encoding = Encoding.UTF8;

            return Encrypt(encoding.GetBytes(data), xmlPublicKey);
        }

        /// <summary>
        /// Encrypt byte[] data with xml format.
        /// </summary>
        /// <param name="dataBytes">The data to be encrypted.</param>
        /// <param name="xmlPublicKey">The public key of xml format.</param>
        /// <returns>The encrypted data.</returns>
        public static string Encrypt(byte[] dataBytes, string xmlPublicKey)
        {
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(xmlPublicKey);
                byte[] bytes = rsa.Encrypt(dataBytes, false);
                return Convert.ToBase64String(bytes);
            }
        }

        /// <summary>
        /// Decrypt string data with xml format.
        /// </summary>
        /// <param name="data">The data to be encrypted.</param>
        /// <param name="xmlPrivateKey">The private key of xml format.</param>
        /// <param name="encoding">The <see cref="T:System.Text.Encoding"/>,default is Encoding.UTF8.</param>
        /// <returns>The decrypted data.</returns>
        public static string Decrypt(string data, string xmlPrivateKey, Encoding encoding = null)
        {
            return Decrypt(Convert.FromBase64String(data), xmlPrivateKey, encoding);
        }

        /// <summary>
        /// Decrypt byte[] data with xml format.
        /// </summary>
        /// <param name="dataBytes">The data to be encrypted.</param>
        /// <param name="xmlPrivateKey">The private key of xml format.</param>
        /// <param name="encoding">The <see cref="T:System.Text.Encoding"/>,default is Encoding.UTF8.</param>
        /// <returns>The decrypted data.</returns>
        public static string Decrypt(byte[] dataBytes, string xmlPrivateKey, Encoding encoding = null)
        {
            if (encoding == null) encoding = Encoding.UTF8;

            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(xmlPrivateKey);
                byte[] bytes = rsa.Decrypt(dataBytes, false);
                return encoding.GetString(bytes);
            }
        }
        #endregion
    }
}
