using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace GodSharp.Encryption
{
    /// <summary>
    /// Asymmetric/RSA encryption.
    /// </summary>
    /// <remarks>
    /// Reference: https://www.cnblogs.com/dudu/p/csharp-openssl-encrypt-decrypt.html
    /// </remarks>
    public sealed class RSAOpenSsl
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="RSAOpenSsl"/> class.
        /// </summary>
        internal RSAOpenSsl()
        {
        }

        /// <summary>
        /// Imports the public key from file.
        /// </summary>
        /// <param name="file">The file for public key.</param>
        /// <param name="beginString">The begin string. Default is <c>-----BEGIN PUBLIC KEY-----</c>.</param>
        /// <param name="endString">The end string. Default is <c>-----END PUBLIC KEY-----</c>.</param>
        /// <param name="encoding">The encoding. Default is <see cref="Encoding.UTF8"/>.</param>
        /// <returns></returns>
        public static string ImportPublicKeyFromFile(string file, string beginString = null, string endString = null, Encoding encoding = null)
        {
            return GetKeyFromFile(file, beginString, endString, GetPublicKeyString, encoding);
        }

        /// <summary>
        /// Imports the private key from file.
        /// </summary>
        /// <param name="file">The file for private key.</param>
        /// <param name="beginString">The begin string. Default is <c>-----BEGIN RSA PRIVATE KEY-----</c>.</param>
        /// <param name="endString">The end string. Default is <c>-----END RSA PRIVATE KEY-----</c>.</param>
        /// <param name="encoding">The encoding. Default is <see cref="Encoding.UTF8"/>.</param>
        /// <returns></returns>
        public static string ImportPrivateKeyFromFile(string file, string beginString = null, string endString = null, Encoding encoding = null)
        {
            return GetKeyFromFile(file, beginString, endString, GetPrivateKeyString, encoding);
        }

        /// <summary>
        /// Imports the public key from string.
        /// </summary>
        /// <param name="text">The text for public key.</param>
        /// <param name="beginString">The begin string. Default is <c>-----BEGIN PUBLIC KEY-----</c>.</param>
        /// <param name="endString">The end string. Default is <c>-----END PUBLIC KEY-----</c>.</param>
        /// <returns></returns>
        public static string ImportPublicKeyFromString(string text, string beginString = null, string endString = null)
        {
            ArgumentValidator.Validate(text);

            return GetPublicKeyString(text, beginString, endString);
        }

        /// <summary>
        /// Imports the private key from string.
        /// </summary>
        /// <param name="text">The text for private key.</param>
        /// <param name="beginString">The begin string. Default is <c>-----BEGIN RSA PRIVATE KEY-----</c>.</param>
        /// <param name="endString">The end string. Default is <c>-----END RSA PRIVATE KEY-----</c>.</param>
        /// <returns></returns>
        public static string ImportPrivateKeyFromString(string text, string beginString = null, string endString = null)
        {
            ArgumentValidator.Validate(text);

            return GetPrivateKeyString(text, beginString, endString);
        }

        private static Func<string, string, string, string> GetPublicKeyString => (text, begin, end) => {
            if (begin == null) begin = "-----BEGIN PUBLIC KEY-----";
            if (end == null) end = "-----END PUBLIC KEY-----";
            return text.Replace(begin, "").Replace(end, ""); ;
        };

        private static Func<string, string, string, string> GetPrivateKeyString => (text, begin, end) => {
            if (begin == null) begin = "-----BEGIN RSA PRIVATE KEY-----";
            if (end == null) end = "-----END RSA PRIVATE KEY-----";
            return text.Replace(begin, "").Replace(end, "");
        };

        private static string GetKeyFromFile(string file, string beginString, string endString, Func<string, string, string, string> func, Encoding encoding = null)
        {
            ArgumentValidator.Validate(file);

            if (encoding == null) encoding = Encoding.UTF8;

            string text = File.ReadAllText(file, encoding);

            return func(text, beginString, endString);
        }

        /// <summary>
        /// Encrypts the specified data.
        /// </summary>
        /// <param name="data">The data.</param>
        /// <param name="publicKey">The public key.</param>
        /// <param name="encoding">The encoding.</param>
        /// <returns></returns>
        public string Encrypt(string data, string publicKey, Encoding encoding = null)
        {
            ArgumentValidator.Validate(data, publicKey);

            using (RSACryptoServiceProvider rsa = CreateRsaProviderFromPublicKey(publicKey))
            {
                return Convert.ToBase64String(rsa.Encrypt(encoding.GetBytes(data), false));
            }
        }

        /// <summary>
        /// Decrypts the specified cipher.
        /// </summary>
        /// <param name="cipher">The cipher.</param>
        /// <param name="privateKey">The private key.</param>
        /// <param name="encoding">The encoding.</param>
        /// <returns></returns>
        public string Decrypt(string cipher, string privateKey, Encoding encoding = null)
        {
            ArgumentValidator.Validate(cipher, privateKey);

            if (encoding == null) encoding = Encoding.UTF8;

            using (RSACryptoServiceProvider rsa = CreateRsaProviderFromPrivateKey(privateKey))
            {
                return encoding.GetString(rsa.Decrypt(System.Convert.FromBase64String(cipher), false));
            }
        }

        private RSACryptoServiceProvider CreateRsaProviderFromPrivateKey(string privateKey)
        {
            var privateKeyBits = System.Convert.FromBase64String(privateKey);

            var parameter = new RSAParameters();

            using (BinaryReader reader = new BinaryReader(new MemoryStream(privateKeyBits)))
            {
                byte bt = 0;
                ushort twobytes = 0;
                twobytes = reader.ReadUInt16();
                if (twobytes == 0x8130) reader.ReadByte();
                else if (twobytes == 0x8230) reader.ReadInt16();
                else throw new Exception("Unexpected value read binr.ReadUInt16()");

                twobytes = reader.ReadUInt16();
                if (twobytes != 0x0102) throw new Exception("Unexpected version");

                bt = reader.ReadByte();
                if (bt != 0x00) throw new Exception("Unexpected value read binr.ReadByte()");

                parameter.Modulus = reader.ReadBytes(GetIntegerSize(reader));
                parameter.Exponent = reader.ReadBytes(GetIntegerSize(reader));
                parameter.D = reader.ReadBytes(GetIntegerSize(reader));
                parameter.P = reader.ReadBytes(GetIntegerSize(reader));
                parameter.Q = reader.ReadBytes(GetIntegerSize(reader));
                parameter.DP = reader.ReadBytes(GetIntegerSize(reader));
                parameter.DQ = reader.ReadBytes(GetIntegerSize(reader));
                parameter.InverseQ = reader.ReadBytes(GetIntegerSize(reader));
            }

            using (RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.ImportParameters(parameter);
                return rsa;
            }
        }

        private int GetIntegerSize(BinaryReader binr)
        {
            byte bt = 0;
            byte lowbyte = 0x00;
            byte highbyte = 0x00;
            int count = 0;
            bt = binr.ReadByte();
            if (bt != 0x02) return 0;

            bt = binr.ReadByte();

            if (bt == 0x81)
            {
                count = binr.ReadByte();
            }
            else if (bt == 0x82)
            {
                highbyte = binr.ReadByte();
                lowbyte = binr.ReadByte();
                byte[] modint = { lowbyte, highbyte, 0x00, 0x00 };
                count = BitConverter.ToInt32(modint, 0);
            }
            else
            {
                count = bt;
            }

            while (binr.ReadByte() == 0x00)
            {
                count -= 1;
            }
            binr.BaseStream.Seek(-1, SeekOrigin.Current);
            return count;
        }

        private RSACryptoServiceProvider CreateRsaProviderFromPublicKey(string publicKeyString)
        {
            // encoded OID sequence for  PKCS #1 rsaEncryption szOID_RSA_RSA = "1.2.840.113549.1.1.1"
            byte[] SeqOID = { 0x30, 0x0D, 0x06, 0x09, 0x2A, 0x86, 0x48, 0x86, 0xF7, 0x0D, 0x01, 0x01, 0x01, 0x05, 0x00 };
            byte[] x509key;
            byte[] seq = new byte[15];
            int x509size;

            x509key = Convert.FromBase64String(publicKeyString);
            x509size = x509key.Length;

            // ---------  Set up stream to read the asn.1 encoded SubjectPublicKeyInfo blob  ------
            using (MemoryStream mem = new MemoryStream(x509key))
            {
                using (BinaryReader binr = new BinaryReader(mem))  //wrap Memory Stream with BinaryReader for easy reading
                {
                    byte bt = 0;
                    ushort twobytes = 0;

                    twobytes = binr.ReadUInt16();
                    if (twobytes == 0x8130) //data read as little endian order (actual data order for Sequence is 30 81)
                        binr.ReadByte();    //advance 1 byte
                    else if (twobytes == 0x8230)
                        binr.ReadInt16();   //advance 2 bytes
                    else
                        return null;

                    seq = binr.ReadBytes(15);       //read the Sequence OID
                    if (!CompareByteArrays(seq, SeqOID))    //make sure Sequence for OID is correct
                        return null;

                    twobytes = binr.ReadUInt16();
                    if (twobytes == 0x8103) //data read as little endian order (actual data order for Bit String is 03 81)
                        binr.ReadByte();    //advance 1 byte
                    else if (twobytes == 0x8203)
                        binr.ReadInt16();   //advance 2 bytes
                    else
                        return null;

                    bt = binr.ReadByte();
                    if (bt != 0x00)     //expect null byte next
                        return null;

                    twobytes = binr.ReadUInt16();
                    if (twobytes == 0x8130) //data read as little endian order (actual data order for Sequence is 30 81)
                        binr.ReadByte();    //advance 1 byte
                    else if (twobytes == 0x8230)
                        binr.ReadInt16();   //advance 2 bytes
                    else
                        return null;

                    twobytes = binr.ReadUInt16();
                    byte lowbyte = 0x00;
                    byte highbyte = 0x00;

                    if (twobytes == 0x8102) //data read as little endian order (actual data order for Integer is 02 81)
                        lowbyte = binr.ReadByte();  // read next bytes which is bytes in modulus
                    else if (twobytes == 0x8202)
                    {
                        highbyte = binr.ReadByte(); //advance 2 bytes
                        lowbyte = binr.ReadByte();
                    }
                    else
                        return null;
                    byte[] modint = { lowbyte, highbyte, 0x00, 0x00 };   //reverse byte order since asn.1 key uses big endian order
                    int modsize = BitConverter.ToInt32(modint, 0);

                    int firstbyte = binr.PeekChar();
                    if (firstbyte == 0x00)
                    {   //if first byte (highest order) of modulus is zero, don't include it
                        binr.ReadByte();    //skip this null byte
                        modsize -= 1;   //reduce modulus buffer size by 1
                    }

                    byte[] modulus = binr.ReadBytes(modsize);   //read the modulus bytes

                    if (binr.ReadByte() != 0x02)            //expect an Integer for the exponent data
                        return null;
                    int expbytes = (int)binr.ReadByte();        // should only need one byte for actual exponent data (for all useful values)
                    byte[] exponent = binr.ReadBytes(expbytes);

                    // ------- create RSACryptoServiceProvider instance and initialize with public key -----
                    using (RSACryptoServiceProvider RSA = new RSACryptoServiceProvider())
                    {
                        RSAParameters RSAKeyInfo = new RSAParameters();
                        RSAKeyInfo.Modulus = modulus;
                        RSAKeyInfo.Exponent = exponent;
                        RSA.ImportParameters(RSAKeyInfo);

                        return RSA;
                    }
                }
            }
        }

        private bool CompareByteArrays(byte[] a, byte[] b)
        {
            if (a.Length != b.Length) return false;

            int i = 0;
            foreach (byte c in a)
            {
                if (c != b[i]) return false;
                i++;
            }

            return true;
        }
    }

    internal static class RSAOpenSslSingletonContainer
    {
        internal static RSAOpenSsl Instance = new RSAOpenSsl();
    }
}
