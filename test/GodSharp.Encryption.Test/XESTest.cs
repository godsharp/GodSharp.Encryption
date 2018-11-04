using System;
using Xunit;

namespace GodSharp.Encryption.Tests
{
    public class XESTest
    {
        [Fact]
        public void UtilTest()
        {
            string str = null;
            for (int i = 0; i < 100; i++)
            {
                str = RandomGenerator.GetString(8);
                Console.WriteLine(str);
                str = null;
            }
        }

        [Fact]
        public void AESTest()
        {
            string data = "hello world!";
            string password = "GodSharp";

            string encrypted = AES.Encrypt(data, password, keySize: AESKeySizeFlags.L128);
            Console.WriteLine(encrypted);
            string decrypted = AES.Decrypt(encrypted, password, keySize: AESKeySizeFlags.L128);
            Console.WriteLine(decrypted);

            encrypted = AES.Encrypt(data, password, keySize: AESKeySizeFlags.L192);
            Console.WriteLine(encrypted);
            decrypted = AES.Decrypt(encrypted, password, keySize: AESKeySizeFlags.L192);
            Console.WriteLine(decrypted);

            encrypted = AES.Encrypt(data, password, keySize: AESKeySizeFlags.L256);
            Console.WriteLine(encrypted);
            decrypted = AES.Decrypt(encrypted, password, keySize: AESKeySizeFlags.L256);
            Console.WriteLine(decrypted);
        }

        [Fact]
        public void DESTest()
        {
            string data = "hello world!";
            string password = "GodSharp";
            string encrypted = DES.Encrypt(data, password);
            Console.WriteLine(encrypted);
            string decrypted = DES.Decrypt(encrypted, password);
            Console.WriteLine(decrypted);
        }

        [Fact]
        public void TripleDESTest()
        {
            string data = "hello world!";
            string password = "GodSharp";
            string encrypted = TripleDES.Encrypt(data, password);
            Console.WriteLine(encrypted);
            string decrypted = TripleDES.Decrypt(encrypted, password);
            Console.WriteLine(decrypted);

            encrypted = TripleDES.Encrypt(data, password, keySize: TripleDESKeySizeFlags.L192);
            Console.WriteLine(encrypted);
            decrypted = TripleDES.Decrypt(encrypted, password, keySize: TripleDESKeySizeFlags.L192);
            Console.WriteLine(decrypted);
        }

        [Fact]
        public void TripleDESTestFromIssue2()
        {
            var unEncryptedString = "This is a test!";
            var result = TripleDES.Encrypt(unEncryptedString, string.Empty);
            Console.WriteLine("Encrypted String " + result);
            Console.WriteLine("Encrypted String " + TripleDES.Decrypt(result, string.Empty));
        }
    }
}
