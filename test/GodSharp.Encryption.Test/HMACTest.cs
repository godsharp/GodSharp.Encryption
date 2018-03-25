using System;
using Xunit;

namespace GodSharp.Encryption.Tests
{
    public class HMACTest
    {
        [Fact]
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
#if NFX
            encrypt = HMACRIPEMD160.Encrypt(str, "");
            Console.WriteLine(encrypt);
#endif
        }
    }
}
