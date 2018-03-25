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
                str = Util.GetRandomString(8);
                Console.WriteLine(str);
                str = null;
            }
        }

        [Fact]
        public void AESTest()
        {
            string data = "hello world!";
            string password = "123456";

            string encrypted = AES.Encrypt(data, password);
            Console.WriteLine(encrypted);
            string decrypted = AES.Decrypt(encrypted, password);
            Console.WriteLine(decrypted);

            encrypted = AES.Encrypt(data, password, 192);
            Console.WriteLine(encrypted);
            decrypted = AES.Decrypt(encrypted, password, 192);
            Console.WriteLine(decrypted);

            encrypted = AES.Encrypt(data, password, 128);
            Console.WriteLine(encrypted);
            decrypted = AES.Decrypt(encrypted, password, 128);
            Console.WriteLine(decrypted);
        }

        [Fact]
        public void DESTest()
        {
            string data = "hello world!";
            string password = "123456";
            string encrypted = DES.Encrypt(data, password);
            Console.WriteLine(encrypted);
            string decrypted = DES.Decrypt(encrypted, password);
            Console.WriteLine(decrypted);
        }

        [Fact]
        public void TripleDESTest()
        {
            string data = "hello world!";
            string password = "123456";
            string encrypted = TripleDES.Encrypt(data, password);
            Console.WriteLine(encrypted);
            string decrypted = TripleDES.Decrypt(encrypted, password);
            Console.WriteLine(decrypted);

            encrypted = TripleDES.Encrypt(data, password, 128);
            Console.WriteLine(encrypted);
            decrypted = TripleDES.Decrypt(encrypted, password, 128);
            Console.WriteLine(decrypted);
        }

    }
}
