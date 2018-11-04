using System.ComponentModel;

namespace GodSharp.Encryption
{
    /// <summary>
    /// The bit number of <see cref="MD5"/>.
    /// </summary>
    [DefaultValue(L32)]
    public enum MD5Types
    {
        /// <summary>
        /// return 16 bit data.
        /// </summary>
        L16,
        /// <summary>
        /// return 32 bit data.
        /// </summary>
        L32,
        /// <summary>
        /// return 64 bit data.
        /// </summary>
        L64
    }
}
