using System;
using System.Text;
using Xunit;

namespace GodSharp.Encryption
{
    public class CRCTest
    {
        [Fact]
        public void CRC16Test()
        {
            string str = "1234";
            Encoding encoding = Encoding.UTF8;
            byte[] input = encoding.GetBytes(str);

            using (CRC16 crc = new CRC16( CRCTypes.CRC16_ARC))
            {
                byte[] values = crc.ComputeHash(input);

                Console.WriteLine(BitConverter.ToString(values));//14BA
            }

            using (CRC16 crc = new CRC16( CRCTypes.CRC16_MAXIM))
            {
                byte[] values = crc.ComputeHash(input);

                Console.WriteLine(BitConverter.ToString(values));//8832
            }

            using (CRC16 crc = new CRC16(CRCTypes.CRC16_AUG_CCITT))
            {
                byte[] values = crc.ComputeHash(input);

                Console.WriteLine(BitConverter.ToString(values));//8832
            }
        }
    }
}
