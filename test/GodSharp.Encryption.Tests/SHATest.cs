using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GodSharp.Encryption.Tests
{
    [TestClass]
    public class SHATest
    {
        [TestMethod]
        public void SHA1Test()
        {
            string str = "Hello world!";
            string encrypt = SHA1.Encrypt(str);
            Console.WriteLine(encrypt);
            encrypt = SHA256.Encrypt(str);
            Console.WriteLine(encrypt);
            encrypt = SHA384.Encrypt(str);
            Console.WriteLine(encrypt);
            encrypt = SHA512.Encrypt(str);
            Console.WriteLine(encrypt);
            encrypt = MD5.Encrypt(str);
            Console.WriteLine(encrypt);
        }
    }
}
