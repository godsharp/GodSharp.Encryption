using System;

namespace GodSharp.Encryption
{
    internal class CrcHashAlgorithmHelper
    {
        public static ulong[] GenerateTable(ulong poly, int width, bool input, ulong mask)
        {
            ulong[] array = new ulong[256];

            for (ulong i = 0; i < 256; i++)
            {
                array[i] = GenerateTableItem(i, poly, width, input, mask);
            }

            return array;
        }
        public static uint[] GenerateTable(uint poly, int width, bool input, uint mask)
        {
            uint[] array = new uint[256];

            for (uint i = 0; i < 256; i++)
            {
                array[i] = GenerateTableItem(i, poly, width, input, mask);
            }

            return array;
        }
        public static ushort[] GenerateTable(ushort poly, int width, bool input, ushort mask)
        {
            ushort[] array = new ushort[256];

            for (ushort i = 0; i < 256; i++)
            {
                array[i] = GenerateTableItem(i, poly, width, input, mask);
            }

            return array;
        }
        public static byte[] GenerateTable(byte poly, int width, bool input, byte mask)
        {
            byte[] array = new byte[256];

            for (byte i = 0; i <= 255; i++)
            {
                array[i] = GenerateTableItem(i, poly, width, input, mask);
            }

            return array;
        }
        
        public static ulong GenerateTableItem(ulong index, ulong poly, int width, bool input, ulong mask)
        {
            ulong r = index;

            if (input) r = ReverseBits(r, width);
            else if (width > 8) r <<= (width - 8);

            ulong lastBit = (ulong)(1 << (byte)(width - 1));

            for (int i = 0; i < 8; i++)
            {
                if ((r & lastBit) != 0) r = (ulong)((r << 1) ^ poly);
                else r <<= 1;
            }

            if (input) r = ReverseBits(r, width);

            return (ulong)(r & mask);
        }

        public static uint GenerateTableItem(uint index, uint poly, int width, bool input, uint mask)
        {
            uint r = index;

            if (input) r = ReverseBits(r, width);
            else if (width > 8) r <<= (width - 8);

            uint lastBit = (uint)(1 << (byte)(width - 1));

            for (int i = 0; i < 8; i++)
            {
                if ((r & lastBit) != 0) r = (uint)((r << 1) ^ poly);
                else r <<= 1;
            }

            if (input) r = ReverseBits(r, width);

            return (uint)(r & mask);
        }

        public static ushort GenerateTableItem(ushort index, ushort poly, int width, bool input, ushort mask)
        {
            ushort r = index;

            if (input) r = ReverseBits(r, width);
            else if (width > 8) r <<= (width - 8);

            ushort lastBit = (ushort)(1 << (byte)(width - 1));

            for (int i = 0; i < 8; i++)
            {
                if ((r & lastBit) != 0) r = (ushort)((r << 1) ^ poly);
                else r <<= 1;
            }

            if (input) r = ReverseBits(r, width);

            return (ushort)(r & mask);
        }

        public static byte GenerateTableItem(byte index, byte poly, int width, bool input, byte mask)
        {
            byte r = index;

            if (input) r = ReverseBits(r, width);
            else if (width > 8) r <<= (width - 8);

            byte lastBit = (byte)(1 << (byte)(width - 1));

            for (int i = 0; i < 8; i++)
            {
                if ((r & lastBit) != 0) r = (byte)((r << 1) ^ poly);
                else r <<= 1;
            }

            if (input) r = ReverseBits(r, width);

            return (byte)(r & mask);
        }
        
        internal static byte ReverseBits(byte value, int length)
        {
            byte output = 0;

            for (int i = length - 1; i >= 0; i--)
            {
                output |= (byte)((value & 1) << i);
                value >>= 1;
            }

            return output;
        }
        internal static ushort ReverseBits(ushort value, int length)
        {
            ushort output = 0;

            for (int i = length - 1; i >= 0; i--)
            {
                output |= (ushort)((value & 1) << i);
                value >>= 1;
            }

            return output;
        }
        internal static uint ReverseBits(uint value, int length)
        {
            uint output = 0;

            for (int i = length - 1; i >= 0; i--)
            {
                output |= (value & 1) << i;
                value >>= 1;
            }

            return output;
        }
        internal static ulong ReverseBits(ulong value, int length)
        {
            ulong output = 0;

            for (int i = length - 1; i >= 0; i--)
            {
                output |= (value & 1) << i;
                value >>= 1;
            }

            return output;
        }

        internal static byte[] ToBigEndianBytes(byte value) => ToBigEndianBytesFunc(BitConverter.GetBytes(value));
        internal static byte[] ToBigEndianBytes(ushort value) => ToBigEndianBytesFunc(BitConverter.GetBytes(value));
        internal static byte[] ToBigEndianBytes(uint value) => ToBigEndianBytesFunc(BitConverter.GetBytes(value));
        internal static byte[] ToBigEndianBytes(ulong value) => ToBigEndianBytesFunc(BitConverter.GetBytes(value));

        private static byte[] ToBigEndianBytesFunc(byte[] result)
        {
            if (BitConverter.IsLittleEndian) Array.Reverse(result);

            return result;
        }
    }
}
