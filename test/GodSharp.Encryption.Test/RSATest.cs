using GodSharp.Encryption;
using System;
using Xunit;

namespace GodSharp.Encryption.Tests
{
    public class RSATest
    {
        [Fact]
        public void CreateKeyTest()
        {
            //bool flag = RSA.CreateKey(1024, out string prik, out string pubk);
            //Console.WriteLine(flag);
            //Console.WriteLine(prik);
            //Console.WriteLine(pubk);

            string str = null;
            var s = str ?? "0";
            Console.WriteLine(s);
            str = "1";
            s = str ?? "0";
            Console.WriteLine(s);
        }
    }
}