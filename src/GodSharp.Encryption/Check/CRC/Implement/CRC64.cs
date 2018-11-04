using System.Collections.Generic;

namespace GodSharp.Encryption
{
    /// <summary>
    /// CRC64
    /// </summary>
    public sealed class CRC64 : CrcHashAlgorithm<ulong>
    {
        /// <summary>
        /// Initializes the <see cref="CRC64"/> class.
        /// </summary>
        static CRC64()
        {
            Tables = new Dictionary<string, ulong[]>();

            Paramters = new Dictionary<string, CrcParamter<ulong>>() {
                {"CRC-40/GSM",new CrcParamter<ulong>("CRC-40/GSM",0x4820009,0x0000000000,0xFFFFFFFFFF,40,false,false) },

                {"CRC-64",new CrcParamter<ulong>("CRC-64",0x42F0E1EBA9EA3693,0x0000000000000000,0x00000000000000,64,false,false) },
                {"CRC-64/XZ",new CrcParamter<ulong>("CRC-64/XZ",0x42F0E1EBA9EA3693,0xFFFFFFFFFFFFFFFF,0xFFFFFFFFFFFFFFFF,64,true,true) },
                {"CRC-64/WE",new CrcParamter<ulong>("CRC-64/WE",0x42F0E1EBA9EA3693,0xFFFFFFFFFFFFFFFF,0xFFFFFFFFFFFFFFFF,64,false,false) },
            };
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CRC64"/> class.
        /// </summary>
        /// <param name="type">The type.</param>
        public CRC64(CRCTypes type) : base(type)
        {
            Mask = ulong.MaxValue >> (byte)(16 - Paramter.Width);
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
            ulong crc = Paramter.RefOutput ? CrcHashAlgorithmHelper.ReverseBits(Paramter.RemainderInitialValue, Paramter.Width) : Paramter.RemainderInitialValue;

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
        internal override ulong[] Generate(CrcParamter<ulong> paramter)=> CrcHashAlgorithmHelper.GenerateTable(paramter.Polynomial, paramter.Width, paramter.RefInput, Mask);
    }
}
