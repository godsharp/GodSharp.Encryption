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
    public class RSA
    {
        /// <summary>
        /// The string format of public key.
        /// </summary>
        private static string publicKeyFormat = @"<RSAKeyValue><Modulus>{0}</Modulus><Exponent>{1}</Exponent></RSAKeyValue>";

        /// <summary>
        /// The string format of private key.
        /// </summary>
        private static string privateKeyFormat = @"<RSAKeyValue><Modulus>{0}</Modulus><Exponent>{1}</Exponent><P>{2}</P><Q>{3}</Q><DP>{4}</DP><DQ>{5}</DQ><InverseQ>{6}</InverseQ><D>{7}</D></RSAKeyValue>";

        #region Get public and private key of xml format.
        /// <summary>
        /// Get public and private key of xml format.
        /// </summary>
        /// <param name="xmlPrivateKey">The private key of xml format.</param>
        /// <param name="xmlPublicKey">The public key of xml format.</param>
        /// <param name="dwKeySize">The size of the key to use in bits</param>
        public static void CreateKey(out string xmlPrivateKey, out string xmlPublicKey, int dwKeySize = 1024)
        {
            try
            {
                xmlPrivateKey = null;
                xmlPublicKey = null;
                RSACryptoServiceProvider rsa = new RSACryptoServiceProvider(dwKeySize);
                xmlPrivateKey = rsa.ToXmlString(true);
                xmlPublicKey = rsa.ToXmlString(false);
            }
            catch ( Exception ex)
            {
                throw ex;
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
            if (!File.Exists(certFile))
            {
                throw new FileNotFoundException(nameof(certFile));
            }

            X509Certificate2 cert = new X509Certificate2(certFile, password, X509KeyStorageFlags.Exportable);
            string privateKey = cert.PrivateKey.ToXmlString(true);
            return privateKey;
        }

        /// <summary>
        /// Get public key of xml format from certificate file.
        /// </summary>
        /// <param name="certFile">The string path of certificate file.</param>
        /// <returns>String public key of xml format.</returns>
        public static string GetPublicKey(string certFile)
        {
            if (!File.Exists(certFile))
            {
                throw new FileNotFoundException(nameof(certFile));
            }

            X509Certificate2 cert = new X509Certificate2(certFile);
            string publicKey = cert.PublicKey.Key.ToXmlString(false);
            return publicKey;
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
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(xmlPublicKey);
                byte[] bytes = rsa.Encrypt(encoding.GetBytes(data), false);
                return Convert.ToBase64String(bytes);
            }
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
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                byte[] dataBytes = Convert.FromBase64String(data);
                rsa.FromXmlString(xmlPrivateKey);
                byte[] bytes = rsa.Decrypt(dataBytes, false);
                return encoding.GetString(bytes);
            }
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
            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.FromXmlString(xmlPrivateKey);
                byte[] bytes = rsa.Decrypt(dataBytes, false);
                return encoding.GetString(bytes);
            }
        }
        #endregion

        #region Get hash sign
        /// <summary>
        /// Get hash sign.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="hash"></param>
        /// <param name="encoding">The <see cref="T:System.Text.Encoding"/>,default is Encoding.UTF8.</param>
        /// <returns></returns>
        public bool GetHash(string data, ref byte[] hash,Encoding encoding=null)
        {
            try
            {
                if (encoding==null)
                {
                    encoding = Encoding.UTF8;
                }
                HashAlgorithm MD5 = HashAlgorithm.Create("MD5");
                hash = MD5.ComputeHash(encoding.GetBytes(data));
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get hash sign.
        /// </summary>
        /// <param name="data"></param>
        /// <param name="hash"></param>
        /// <param name="encoding">The <see cref="T:System.Text.Encoding"/>,default is Encoding.UTF8.</param>
        /// <returns></returns>
        public bool GetHash(string data, ref string hash, Encoding encoding = null)
        {
            try
            {
                if (encoding == null)
                {
                    encoding = Encoding.UTF8;
                }

                HashAlgorithm MD5 = HashAlgorithm.Create("MD5");
                byte[] buffer = MD5.ComputeHash(encoding.GetBytes(data));
                hash = Convert.ToBase64String(buffer);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get hash sign.
        /// </summary>
        /// <param name="fs"></param>
        /// <param name="hash"></param>
        /// <returns></returns>
        public bool GetHash(FileStream fs, ref byte[] hash)
        {
            try
            {
                HashAlgorithm MD5 = HashAlgorithm.Create("MD5");
                hash = MD5.ComputeHash(fs);
                fs.Close();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        /// <summary>
        /// Get hash sign.
        /// </summary>
        /// <param name="fs"></param>
        /// <param name="hash"></param>
        /// <returns></returns>
        public bool GetHash(FileStream fs, ref string hash)
        {
            try
            {
                HashAlgorithm MD5 = HashAlgorithm.Create("MD5");
                byte[] buffer = MD5.ComputeHash(fs);
                fs.Close();
                hash = Convert.ToBase64String(buffer);
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        #endregion
    }
}
