using System.ComponentModel;

namespace GodSharp.Encryption
{
    /// <summary>
    /// RSA size types
    /// </summary>
    [DefaultValue(L2048)]
    public enum RSASizeTypes
    {
        /// <summary>
        /// The L1024
        /// </summary>
        L1024 = 1024,
        /// <summary>
        /// The L2048
        /// </summary>
        L2048 = 2048,
        /// <summary>
        /// The L3072
        /// </summary>
        L3072 = 3072,
        /// <summary>
        /// The L4096
        /// </summary>
        L4096 = 4096
    }
}