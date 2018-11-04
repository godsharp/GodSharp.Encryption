using System.ComponentModel;

namespace GodSharp.Encryption
{
    /// <summary>
    /// The Algorithm types for <see cref="HMAC"/>.
    /// </summary>
    [DefaultValue(MD5)]
    public enum HMACAlgorithmTypes
    {
        /// <summary>
        /// The Algorithm by <see cref="System.Security.Cryptography.HMACMD5"/>
        /// </summary>
        MD5,
        /// <summary>
        /// The Algorithm by <see cref="System.Security.Cryptography.HMACSHA1"/>
        /// </summary>
        SHA1,
        /// <summary>
        /// The Algorithm by <see cref="System.Security.Cryptography.HMACSHA256"/>
        /// </summary>
        SHA256,
        /// <summary>
        /// The Algorithm by <see cref="System.Security.Cryptography.HMACSHA384"/>
        /// </summary>
        SHA384,
        /// <summary>
        /// The Algorithm by <see cref="System.Security.Cryptography.HMACSHA512"/>
        /// </summary>
        SHA512,
#if NFX
        /// <summary>
        /// The Algorithm by <see cref="System.Security.Cryptography.RIPEMD160"/>, not implement in .NET Standard  
        /// </summary>
#else
        /// <summary>
        /// Not implement in .NET Standard  
        /// </summary>
#endif
        RIPEMD160
    }
}
