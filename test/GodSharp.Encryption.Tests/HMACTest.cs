using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GodSharp.Encryption.Tests
{
    [TestClass]
    public class HMACTest
    {
        [TestMethod]
        public void HMACSHA1Test()
        {
            string str = "Hello world!";
            string encrypt = HMACSHA1.Encrypt(str,"123456");
            Console.WriteLine(encrypt);
            encrypt = HMACSHA256.Encrypt(str, "123456");
            Console.WriteLine(encrypt);
            encrypt = HMACSHA384.Encrypt(str, "123456");
            Console.WriteLine(encrypt);
            encrypt = HMACSHA512.Encrypt(str, "123456");
            Console.WriteLine(encrypt);
            encrypt = HMACMD5.Encrypt(str, "123456");
            Console.WriteLine(encrypt);
            encrypt = HMACRIPEMD160.Encrypt(str, "");
            Console.WriteLine(encrypt);
        }
    }
}
