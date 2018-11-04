using System.ComponentModel;

namespace GodSharp.Encryption
{
    /// <summary>
    /// The size only can be 128, 192 of <see cref="TripleDES"/>.
    /// </summary>
    [DefaultValue(L128)]
    public enum TripleDESKeySizeFlags
    {
        /// <summary>
        /// The L128
        /// </summary>
        L128 = 128,
        /// <summary>
        /// The L192
        /// </summary>
        L192 = 192
    }
}
