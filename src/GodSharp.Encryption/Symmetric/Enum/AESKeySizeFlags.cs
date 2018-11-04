using System.ComponentModel;

namespace GodSharp.Encryption
{
    /// <summary>
    /// The size only can be 128, 192, or 256 of <see cref="AES"/>.
    /// </summary>
    [DefaultValue(L256)]
    public enum AESKeySizeFlags
    {
        /// <summary>
        /// The L128
        /// </summary>
        L128 = 128,
        /// <summary>
        /// The L192
        /// </summary>
        L192 = 192,
        /// <summary>
        /// The L256
        /// </summary>
        L256 = 256
    }
}
