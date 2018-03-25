using System;
using Xunit;

namespace GodSharp.Encryption.Tests
{
    public class SHATest
    {
        [Fact]
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
