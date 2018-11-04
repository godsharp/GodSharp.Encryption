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
            string encrypt = MD5.Encrypt(str);
            Console.WriteLine(encrypt);
        }

        [Fact]
        public void MyTestMethod()
        {
            string str = "Hello world!";

            string[] types = Enum.GetNames(typeof(SHAAlgorithmTypes));

            foreach (var item in types)
            {
                Console.WriteLine($"SHAAlgorithmType: {item}");

                HashResult result = SHA.Encrypt((SHAAlgorithmTypes)Enum.Parse(typeof(SHAAlgorithmTypes), item), str);

                Type type = result.GetType();

                var props = type.GetProperties();

                foreach (var prop in props)
                {
                    if (prop.PropertyType == typeof(string)) Console.WriteLine($"{prop.Name}:{prop.GetValue(result, null)}");
                }

                Console.WriteLine();
            }
        }
    }
}
