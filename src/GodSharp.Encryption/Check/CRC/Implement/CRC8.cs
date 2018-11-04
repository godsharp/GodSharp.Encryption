using System.Collections.Generic;

namespace GodSharp.Encryption
{
    /// <summary>
    /// CRC8
    /// </summary>
    public sealed class CRC8 : CrcHashAlgorithm<byte>
    {
        /// <summary>
        /// Initializes the <see cref="CRC8"/> class.
        /// </summary>
        static CRC8()
        {
            Tables = new Dictionary<string, byte[]>();
            Paramters = new Dictionary<string, CrcParamter<byte>>() {
                {"CRC-8",new CrcParamter<byte>("CRC-8",0x7,0x0,0x0,8,false,false) },
                {"CRC-8/ITU",new CrcParamter<byte>("CRC-8/ITU",0x7,0x0,0x55,8,false,false) },
                {"CRC-8/ROHC",new CrcParamter<byte>("CRC-8/ROHC",0x7,0xFF,0x0,8,true,true) },
                {"CRC-8/I-CODE",new CrcParamter<byte>("CRC-8/I-CODE",0x1D,0xFD,0x0,8,false,false) },
                {"CRC-8/EBU",new CrcParamter<byte>("CRC-8/EBU",0x1D,0xFF,0x0,8,true,true) },
                {"CRC-8/MAXIM",new CrcParamter<byte>("CRC-8/MAXIM",0x31,0x0,0x0,8,true,true) },
                {"CRC-8/DARC",new CrcParamter<byte>("CRC-8/DARC",0x39,0x0,0x0,8,true,true) },
                {"CRC-8/WCDMA",new CrcParamter<byte>("CRC-8/WCDMA",0x9B,0x0,0x0,8,true,true) },
                {"CRC-8/CDMA2000",new CrcParamter<byte>("CRC-8/CDMA2000",0x9B,0xFF,0x0,8,false,false) },
                {"CRC-8/DVB-S2",new CrcParamter<byte>("CRC-8/DVB-S2",0xD5,0x0,0x0,8,false,false) }
            };
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CRC8"/> class.
        /// </summary>
        /// <param name="type">The type.</param>
        public CRC8(CRCTypes type) : base(type)
        {
            Mask = (byte)(byte.MaxValue >> (byte)(16 - Paramter.Width));
            Initialize();
        }

        /// <summary>
        /// When overridden in a derived class, routes data written to the object into the hash algorithm for computing the hash.
        /// </summary>
        /// <param name="array">The input to compute the hash code for.</param>
        /// <param name="offset">The offset into the byte array from which to begin using data.</param>
        /// <param name="length">The number of bytes in the byte array to use as data.</param>
        internal override void HashCoreImplement(byte[] array, int offset, int length)
        {
            int crc = Paramter.RefOutput ? CrcHashAlgorithmHelper.ReverseBits(Paramter.RemainderInitialValue, Paramter.Width) : Paramter.RemainderInitialValue;

            if (Paramter.RefOutput)
            {
                for (int i = offset; i < offset + length; i++)
                {
                    crc = (Table[(crc ^ array[i]) & 0xFF] ^ (crc >> 8));
                    crc &= Mask;
                }
            }
            else
            {
                int toRight = (HashSize - 8);
                toRight = toRight < 0 ? 0 : toRight;
                for (int i = offset; i < offset + length; i++)
                {
                    crc = (Table[((crc >> toRight) ^ array[i]) & 0xFF] ^ (crc << 8));
                    crc &= Mask;
                }
            }

            FinalValue = (byte)crc;
        }

        /// <summary>
        /// When overridden in a derived class, finalizes the hash computation after the last data is processed by the cryptographic stream object.
        /// </summary>
        /// <returns>
        /// The computed hash code.
        /// </returns>
        protected override byte[] HashFinal() => CrcHashAlgorithmHelper.ToBigEndianBytes((byte)(FinalValue ^ Paramter.XorResultValue));

        /// <summary>
        /// Generates the specified paramter.
        /// </summary>
        /// <param name="paramter">The paramter.</param>
        /// <returns></returns>
        internal override byte[] Generate(CrcParamter<byte> paramter)=> CrcHashAlgorithmHelper.GenerateTable(paramter.Polynomial, paramter.Width, paramter.RefInput, Mask);
    }
}
