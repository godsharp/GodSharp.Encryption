using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Security.Cryptography;

namespace GodSharp.Encryption
{
    /// <summary>
    /// CrcHashAlgorithm
    /// </summary>
    /// <seealso cref="System.Security.Cryptography.HashAlgorithm" />
    public abstract class CrcHashAlgorithm<TTable> : HashAlgorithm where TTable:struct
    {
        /// <summary>
        /// The tables
        /// </summary>
        protected static Dictionary<string, TTable[]> Tables = null;

        /// <summary>
        /// The paramters
        /// </summary>
        internal static Dictionary<string, CrcParamter<TTable>> Paramters = null;

        /// <summary>
        /// The mask
        /// </summary>
        protected TTable Mask;

        /// <summary>
        /// The table
        /// </summary>
        protected TTable[] Table = null;

        /// <summary>
        /// The paramter
        /// </summary>
        internal CrcParamter<TTable> Paramter = null;

        /// <summary>
        /// The final value
        /// </summary>
        protected TTable FinalValue;

        /// <summary>
        /// Gets or sets the type of the CRC.
        /// </summary>
        /// <value>
        /// The type of the CRC.
        /// </value>
        public CRCTypes CrcType { get; set; }

        /// <summary>
        /// Gets or sets the name of the CRC.
        /// </summary>
        /// <value>
        /// The name of the CRC.
        /// </value>
        public string CrcName { get; private set; }

        /// <summary>
        /// Gets the size, in bits, of the computed hash code.
        /// </summary>
        public override int HashSize => Paramter.Width;

        private bool computed = false;

        /// <summary>
        /// Initializes a new instance of the <see cref="CrcHashAlgorithm{TTable}"/> class.
        /// </summary>
        /// <param name="type">The type.</param>
        public CrcHashAlgorithm(CRCTypes type)
        {
            FieldInfo fi = type.GetType().GetField(type.ToString());
            DescriptionAttribute m = fi.GetCustomAttributes(typeof(DescriptionAttribute),false).Single() as DescriptionAttribute;
            if (m == null) throw new ArgumentNullException("Not exist description attribute.");

            CrcName = m.Description;

            if (!Paramters.ContainsKey(CrcName)) throw new ArgumentException();

            Paramter = Paramters[CrcName];
            CrcType = type;
        }

        /// <summary>
        /// Initializes an implementation of the <see cref="T:System.Security.Cryptography.HashAlgorithm" /> class.
        /// </summary>
        public override void Initialize()
        {
            if (!Tables.ContainsKey(CrcName)) Tables.Add(CrcName, Generate(Paramter));

            Table = Tables[CrcName];
        }
        
        /// <summary>
        /// When overridden in a derived class, routes data written to the object into the hash algorithm for computing the hash.
        /// </summary>
        /// <param name="array">The input to compute the hash code for.</param>
        /// <param name="offset">The offset into the byte array from which to begin using data.</param>
        /// <param name="length">The number of bytes in the byte array to use as data.</param>
        protected override void HashCore(byte[] array, int offset, int length)
        {
            HashCoreImplement(array,offset,length);

            computed = true;
        }

        /// <summary>
        /// Computes the checksum.
        /// </summary>
        /// <returns></returns>
        /// <exception cref="InvalidOperationException">Not call ComputeHash method.</exception>
        public TTable ComputeChecksum()
        {
            if (!computed) throw new InvalidOperationException("Not call ComputeHash method.");

            return FinalValue;
        }

        /// <summary>
        /// Generates the specified paramter.
        /// </summary>
        /// <param name="paramter">The paramter.</param>
        /// <returns></returns>
        internal abstract TTable[] Generate(CrcParamter<TTable> paramter);

        /// <summary>
        /// Hashes the core implement.
        /// </summary>
        /// <param name="array">The array.</param>
        /// <param name="offset">The offset.</param>
        /// <param name="length">The length.</param>
        internal abstract void HashCoreImplement(byte[] array, int offset, int length);
    }
}
