using System;
using Xunit;

namespace GodSharp.Encryption.Tests
{
    public class HMACTest
    {
        [Fact]
        public void HMACSHATest()
        {
            string str = "Hello world!";
            string key = "123456";

            string[] types = Enum.GetNames(typeof(HMACAlgorithmTypes));

            foreach (var item in types)
            {
#if !NFX
                if(item=="RIPEMD160") continue;
#endif
                Console.WriteLine($"HMACAlgorithmType: {item}");

                HashResult result = HMAC.Encrypt((HMACAlgorithmTypes)Enum.Parse(typeof(HMACAlgorithmTypes), item),str, key);

                Type type = result.GetType();

                var props = type.GetProperties();

                foreach (var prop in props)
                {
                    if(prop.PropertyType==typeof(string)) Console.WriteLine($"{prop.Name}:{prop.GetValue(result, null)}");
                }

                Console.WriteLine();
            }
        }
    }
}
