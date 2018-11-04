using System.Collections.Generic;

namespace GodSharp.Encryption
{
    /// <summary>
    /// CRC16
    /// </summary>
    public sealed class CRC16 : CrcHashAlgorithm<ushort>
    {
        /// <summary>
        /// Initializes the <see cref="CRC16"/> class.
        /// </summary>
        static CRC16()
        {
            Tables = new Dictionary<string, ushort[]>();
            Paramters = new Dictionary<string, CrcParamter<ushort>>() {

                { "CRC-10",new CrcParamter<ushort>("CRC-10", 0x233, 0x000,0x000,10, false, false)},
                { "CRC-10/CDMA2000",new CrcParamter<ushort>("CRC-10/CDMA2000", 0x3D9, 0x3FF,0x000,10, false, false)},

                { "CRC-11",new CrcParamter<ushort>("CRC-11", 0x385, 0x01A,0x000,11, false, false) },
                
                { "CRC-12/3GPP",new CrcParamter<ushort>("CRC-12/3GPP", 0x80F, 0x000, 0x000, 12, false, true) },
                { "CRC-12/CDMA2000",new CrcParamter<ushort>("CRC-12/CDMA2000", 0xF13, 0xFFF, 0x0000,12, false, false)},
                { "CRC-12/DECT",new CrcParamter<ushort>("CRC-12/DECT", 0x80F, 0x000, 0x0000, 12, false, false)},

                { "CRC-13/BBC",new CrcParamter<ushort>("CRC-13/BBC", 0x1CF5, 0x0000,0x0000,13, false, false)},

                { "CRC-14/DARC",new CrcParamter<ushort>("CRC-14/DARC", 0x0805, 0x0000,0x0000,14, true, true)},

                { "CRC-15",new CrcParamter<ushort>("CRC-15", 0x4599, 0x0000,0x0000,15, false, false)},
                { "CRC-15/MPT1327",new CrcParamter<ushort>("CRC-15/MPT1327", 0x6815, 0x0000,0x0001,15, false, false)},

                { "CRC-16/DECT-R",new CrcParamter<ushort>("CRC-16/DECT-R", 0x0589, 0x0000,0x0001,16, false, false)},
                { "CRC-16/DECT-X",new CrcParamter<ushort>("CRC-16/DECT-X", 0x0589, 0x0000,0x0000,16, false, false)},

                { "CRC-16/KERMIT",new CrcParamter<ushort>("CRC-16/KERMIT", 0x1021, 0x0000, 0x0000, 16, true, true)},
                { "CRC-16/XMODEM",new CrcParamter<ushort>("CRC-16/XMODEM", 0x1021, 0x0000, 0x0000, 16, false, false)},
                { "CRC-16/TMS37157",new CrcParamter<ushort>("CRC-16/TMS37157", 0x1021, 0x89EC,0x0000,16, true, true)},
                { "CRC-16/AUG-CCITT",new CrcParamter<ushort>("CRC-16/AUG-CCITT", 0x1021, 0x1D0F,0x0000,16, false, false)},
                { "CRC-16/RIELLO",new CrcParamter<ushort>("CRC-16/RIELLO", 0x1021, 0xB2AA, 0x0000,16,true, true)},
                { "CRC-16/A",new CrcParamter<ushort>("CRC-16/A", 0x1021, 0xC6C6,0x0000,16, true, true)},
                { "CRC-16/MCRF4XX",new CrcParamter<ushort>("CRC-16/MCRF4XX", 0x1021, 0xFFFF,0x0000,16, true, true)},
                { "CRC-16/CCITT-FALSE",new CrcParamter<ushort>("CRC-16/CCITT-FALSE", 0x1021, 0xFFFF, 0x0000,16, false, false)},
                { "CRC-16/X-25",new CrcParamter<ushort>("CRC-16/X-25", 0x1021, 0xFFFF, 0xFFFF,16,true, true)},
                { "CRC-16/GENIBUS",new CrcParamter<ushort>("CRC-16/GENIBUS", 0x1021, 0xFFFF, 0xFFFF,16,false, false)},

                { "CRC-16/DNP",new CrcParamter<ushort>("CRC-16/DNP", 0x3D65, 0x0000,0xFFFF,16, true, true)},

                { "CRC-16/EN-13757",new CrcParamter<ushort>("CRC-16/EN-13757", 0x3D65, 0x0000, 0xFFFF,16,false, false)},

                { "CRC-16/ARC",new CrcParamter<ushort>("CRC-16/ARC", 0x8005, 0x0000, 0x0000, 16,true, true)},
                { "CRC-16/BUYPASS",new CrcParamter<ushort>("CRC-16/BUYPASS", 0x8005, 0x0000,0x0000,16, false, false) },
                { "CRC-16/MAXIM",new CrcParamter<ushort>("CRC-16/MAXIM", 0x8005, 0x0000, 0xFFFF,16,true, true)},
                { "CRC-16/DDS-110",new CrcParamter<ushort>("CRC-16/DDS-110", 0x8005, 0x800D,0x0000,16, false, false)},
                { "CRC-16/MODBUS",new CrcParamter<ushort>("CRC-16/MODBUS", 0x8005, 0xFFFF,0x0000,16, true, true)},
                { "CRC-16/USB",new CrcParamter<ushort>("CRC-16/USB", 0x8005, 0xFFFF, 0xFFFF,16, true, true)},

                { "CRC-16/T10-DIF",new CrcParamter<ushort>("CRC-16/T10-DIF", 0x8BB7, 0x0000,0x0000,16, false, false)},

                { "CRC-16/TELEDISK",new CrcParamter<ushort>("CRC-16/TELEDISK", 0xA097, 0x0000,0x0000,16, false, false)},

                { "CRC-16/CDMA2000",new CrcParamter<ushort>("CRC-16/CDMA2000", 0xC867, 0xFFFF,0x0000,16, false, false) }
            };
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CRC16"/> class.
        /// </summary>
        /// <param name="type">The type.</param>
        public CRC16(CRCTypes type) : base(type)
        {
            Mask = (ushort)(ushort.MaxValue >> (byte)(16 - Paramter.Width));
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

            FinalValue = (ushort)crc;
        }

        /// <summary>
        /// When overridden in a derived class, finalizes the hash computation after the last data is processed by the cryptographic stream object.
        /// </summary>
        /// <returns>
        /// The computed hash code.
        /// </returns>
        protected override byte[] HashFinal() => CrcHashAlgorithmHelper.ToBigEndianBytes((ushort)(FinalValue ^ Paramter.XorResultValue));

        /// <summary>
        /// Generates the specified paramter.
        /// </summary>
        /// <param name="paramter">The paramter.</param>
        /// <returns></returns>
        internal override ushort[] Generate(CrcParamter<ushort> paramter) => CrcHashAlgorithmHelper.GenerateTable(paramter.Polynomial, paramter.Width, paramter.RefInput, Mask);
    }
}
