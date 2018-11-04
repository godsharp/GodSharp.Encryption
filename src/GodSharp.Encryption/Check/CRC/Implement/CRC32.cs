using System.Collections.Generic;

namespace GodSharp.Encryption
{
    /// <summary>
    /// CRC32
    /// </summary>
    public sealed class CRC32 : CrcHashAlgorithm<uint>
    {
        /// <summary>
        /// Initializes the <see cref="CRC32"/> class.
        /// </summary>
        static CRC32()
        {
            Tables = new Dictionary<string, uint[]>();

            Paramters = new Dictionary<string, CrcParamter<uint>>() {
                {"CRC-24/FLEXRAY-B",new CrcParamter<uint>("CRC-24/FLEXRAY-B",0x5D6DCB,0xABCDEF,0x000000,24,false,false) },
                {"CRC-24/FLEXRAY-A",new CrcParamter<uint>("CRC-24/FLEXRAY-A",0x5D6DCB,0xFEDCBA,0x000000,24,false,false) },
                {"CRC-24",new CrcParamter<uint>("CRC-24",0x864CFB,0xB704CE,0x000000,24,false,false) },

                {"CRC-31/PHILIPS",new CrcParamter<uint>("CRC-31/PHILIPS",0x4C11DB7,0x7FFFFFFF,0x7FFFFFFF,31,false,false) },

                {"CRC-32/XFER",new CrcParamter<uint>("CRC-32/XFER",0x000000AF,0x00000000,0x00000000,32,false,false) },
                {"CRC-32/POSIX",new CrcParamter<uint>("CRC-32/POSIX",0x04C11DB7,0x00000000,0xFFFFFFFF,32,false,false) },
                {"CRC-32/JAMCRC",new CrcParamter<uint>("CRC-32/JAMCRC",0x04C11DB7,0xFFFFFFFF,0x00000000,32,true,true) },
                {"CRC-32/MPEG-2",new CrcParamter<uint>("CRC-32/MPEG-2",0x04C11DB7,0xFFFFFFFF,0x00000000,32,false,false) },
                {"CRC-32",new CrcParamter<uint>("CRC-32",0x04C11DB7,0xFFFFFFFF,0xFFFFFFFF,32,true,true) },
                {"CRC-32/BZIP2",new CrcParamter<uint>("CRC-32/BZIP2",0x04C11DB7,0xFFFFFFFF,0xFFFFFFFF,32,false,false) },
                {"CRC-32/C",new CrcParamter<uint>("CRC-32/C",0x1EDC6F41,0xFFFFFFFF,0xFFFFFFFF,32,true,true) },
                {"CRC-32/Q",new CrcParamter<uint>("CRC-32/Q",0x814141AB,0x00000000,0x00000000,32,false,false) },
                {"CRC-32/D",new CrcParamter<uint>("CRC-32/D",0xA833982B,0xFFFFFFFF,0xFFFFFFFF,32,true,true) },
            };
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CRC32"/> class.
        /// </summary>
        /// <param name="type">The type.</param>
        public CRC32(CRCTypes type) : base(type)
        {
            Mask = uint.MaxValue >> (byte)(16 - Paramter.Width);
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
            uint crc = Paramter.RefOutput ? CrcHashAlgorithmHelper.ReverseBits(Paramter.RemainderInitialValue, Paramter.Width) : Paramter.RemainderInitialValue;

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

            FinalValue = crc;
        }

        /// <summary>
        /// When overridden in a derived class, finalizes the hash computation after the last data is processed by the cryptographic stream object.
        /// </summary>
        /// <returns>
        /// The computed hash code.
        /// </returns>
        protected override byte[] HashFinal() => CrcHashAlgorithmHelper.ToBigEndianBytes(FinalValue ^ Paramter.XorResultValue);

        /// <summary>
        /// Generates the specified paramter.
        /// </summary>
        /// <param name="paramter">The paramter.</param>
        /// <returns></returns>
        internal override uint[] Generate(CrcParamter<uint> paramter)=> CrcHashAlgorithmHelper.GenerateTable(paramter.Polynomial, paramter.Width, paramter.RefInput, Mask);
    }
}
