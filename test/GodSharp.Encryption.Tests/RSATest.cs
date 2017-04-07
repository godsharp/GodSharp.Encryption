using Microsoft.VisualStudio.TestTools.UnitTesting;
using GodSharp.Encryption;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GodSharp.Encryption.Tests
{
    [TestClass]
    public class RSATest
    {
        [TestMethod]
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