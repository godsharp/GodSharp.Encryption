using System.ComponentModel;

namespace GodSharp.Encryption
{
    /// <summary>
    /// The Algorithm types for <see cref="SHA"/>.
    /// </summary>
    [DefaultValue(SHA1)]
    public enum SHAAlgorithmTypes
    {
        /// <summary>
        /// The Algorithm by <see cref="System.Security.Cryptography.SHA1CryptoServiceProvider"/>
        /// </summary>
        SHA1,
        /// <summary>
        /// The Algorithm by <see cref="System.Security.Cryptography.SHA256CryptoServiceProvider"/>
        /// </summary>
        SHA256,
        /// <summary>
        /// The Algorithm by <see cref="System.Security.Cryptography.SHA384CryptoServiceProvider"/>
        /// </summary>
        SHA384,
        /// <summary>
        /// The Algorithm by <see cref="System.Security.Cryptography.SHA512CryptoServiceProvider"/>
        /// </summary>
        SHA512
    }
}
