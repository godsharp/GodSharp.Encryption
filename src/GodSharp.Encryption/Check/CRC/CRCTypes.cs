using System.ComponentModel;

namespace GodSharp.Encryption
{
    /// <summary>
    /// CRC check type.
    /// </summary>
    [DefaultValue(CRC16_ARC)]
    public enum CRCTypes
    {
        /// <summary>
        /// CRC8
        /// </summary>
        [Description("CRC-8")]
        CRC8,
        /// <summary>
        /// CRC8/CDMA2000
        /// </summary>
        [Description("CRC-8/CDMA2000")]
        CRC8_CDMA2000,
        /// <summary>
        /// CRC8/DARC
        /// </summary>
        [Description("CRC-8/DARC")]
        CRC8_DARC,
        /// <summary>
        /// CRC8/DVB-S2
        /// </summary>
        [Description("CRC-8/DVB-S2")]
        CRC8_DVB_S2,
        /// <summary>
        /// CRC8/EBU
        /// </summary>
        [Description("CRC-8/EBU")]
        CRC8_EBU,
        /// <summary>
        /// CRC8/I-CODE
        /// </summary>
        [Description("CRC-8/I-CODE")]
        CRC8_I_CODE,
        /// <summary>
        /// CRC8/ITU
        /// </summary>
        [Description("CRC-8/ITU")]
        CRC8_ITU,
        /// <summary>
        /// CRC8/MAXIM
        /// </summary>
        [Description("CRC-8/MAXIM")]
        CRC8_MAXIM,
        /// <summary>
        /// CRC8/ROHC
        /// </summary>
        [Description("CRC-8/ROHC")]
        CRC8_ROHC,
        /// <summary>
        /// CRC8/WCDMA
        /// </summary>
        [Description("CRC-8/WCDMA")]
        CRC8_WCDMA,

        /// <summary>
        /// CRC10
        /// </summary>
        [Description("CRC-10")]
        CRC10,
        /// <summary>
        /// CRC10/CDMA2000
        /// </summary>
        [Description("CRC-10/CDMA2000")]
        CRC10_CDMA2000,

        /// <summary>
        /// CRC11
        /// </summary>
        [Description("CRC-11")]
        CRC11,

        /// <summary>
        /// CRC12/3GPP
        /// </summary>
        [Description("CRC-12/3GPP")]
        CRC12_3GPP,
        /// <summary>
        /// CRC12/CDMA2000
        /// </summary>
        [Description("CRC-12/CDMA2000")]
        CRC12_CDMA2000,
        /// <summary>
        /// CRC12/DECT
        /// </summary>
        [Description("CRC-12/DECT")]
        CRC12_DECT,

        /// <summary>
        /// CRC13
        /// </summary>
        [Description("CRC-13")]
        CRC13,

        /// <summary>
        /// CRC14/DARC
        /// </summary>
        [Description("CRC-14/DARC")]
        CRC14_DARC,

        /// <summary>
        /// CRC15
        /// </summary>
        [Description("CRC-15")]
        CRC15,
        /// <summary>
        /// CRC15/MPT1327
        /// </summary>
        [Description("CRC-15/MPT1327")]
        CRC15_MPT1327,

        /// <summary>
        /// CRC-16/DECT-R
        /// </summary>
        [Description("CRC-16/DECT-R")]
        CRC16_DECT_R,
        /// <summary>
        /// CRC-16/DECT-X
        /// </summary>
        [Description("CRC-16/DECT-X")]
        CRC16_DECT_X,
        /// <summary>
        /// CRC-16/DECT-R
        /// </summary>
        [Description("CRC-16/KERMIT")]
        CRC16_KERMIT,
        /// <summary>
        /// CRC-16/XMODEM
        /// </summary>
        [Description("CRC-16/XMODEM")]
        CRC16_XMODEM,
        /// <summary>
        /// CRC-16/TMS37157
        /// </summary>
        [Description("CRC-16/TMS37157")]
        CRC16_TMS37157,
        /// <summary>
        /// CRC-16/AUG-CCITT
        /// </summary>
        [Description("CRC-16/AUG-CCITT")]
        CRC16_AUG_CCITT,
        /// <summary>
        /// CRC-16/RIELLO
        /// </summary>
        [Description("CRC-16/RIELLO")]
        CRC16_RIELLO,
        /// <summary>
        /// CRC-16/A
        /// </summary>
        [Description("CRC-16/A")]
        CRC16_A,
        /// <summary>
        /// CRC-16/MCRF4XX
        /// </summary>
        [Description("CRC-16/MCRF4XX")]
        CRC16_MCRF4XX,
        /// <summary>
        /// CRC-16/CCITT-FALSE
        /// </summary>
        [Description("CRC-16/CCITT-FALSE")]
        CRC16_CCITT_FALSE,
        /// <summary>
        /// CRC-16/X-25
        /// </summary>
        [Description("CRC-16/X-25")]
        CRC16_X25,
        /// <summary>
        /// CRC-16/GENIBUS
        /// </summary>
        [Description("CRC-16/GENIBUS")]
        CRC16_GENIBUS,
        /// <summary>
        /// CRC-16/DNP
        /// </summary>
        [Description("CRC-16/DNP")]
        CRC16_DNP,
        /// <summary>
        /// CRC-16/EN-13757
        /// </summary>
        [Description("CRC-16/EN-13757")]
        CRC16_EN13757,
        /// <summary>
        /// CRC-16/ARC
        /// </summary>
        [Description("CRC-16/ARC")]
        CRC16_ARC,
        /// <summary>
        /// CRC-16/BUYPASS
        /// </summary>
        [Description("CRC-16/BUYPASS")]
        CRC16_BUYPASS,
        /// <summary>
        /// CRC-16/MAXIM
        /// </summary>
        [Description("CRC-16/MAXIM")]
        CRC16_MAXIM,
        /// <summary>
        /// CRC-16/DDS-110
        /// </summary>
        [Description("CRC-16/DDS-110")]
        CRC16_DDS110,
        /// <summary>
        /// CRC-16/MODBUS
        /// </summary>
        [Description("CRC-16/MODBUS")]
        CRC16_MODBUS,
        /// <summary>
        /// CRC-16/USB
        /// </summary>
        [Description("CRC-16/USB")]
        CRC16_USB,
        /// <summary>
        /// CRC-16/T10-DIF
        /// </summary>
        [Description("CRC-16/T10-DIF")]
        CRC16_T10_DIF,
        /// <summary>
        /// CRC-16/TELEDISK
        /// </summary>
        [Description("CRC-16/TELEDISK")]
        CRC16_TELEDISK,
        /// <summary>
        /// CRC-16/CDMA2000
        /// </summary>
        [Description("CRC-16/CDMA2000")]
        CRC16_CDMA2000,

        /// <summary>
        /// CRC-24
        /// </summary>
        [Description("CRC-24")]
        CRC24,
        /// <summary>
        /// CRC-24/FLEXRAY-A
        /// </summary>
        [Description("CRC-24/FLEXRAY-A")]
        CRC24_FLEXRAY_A,
        /// <summary>
        /// CRC-24/FLEXRAY-B
        /// </summary>
        [Description("CRC-24/FLEXRAY-B")]
        CRC24_FLEXRAY_B,

        /// <summary>
        /// CRC-31/PHILIPS
        /// </summary>
        [Description("CRC-31/PHILIPS")]
        CRC31_PHILIPS,

        /// <summary>
        /// CRC-32
        /// </summary>
        [Description("CRC-32")]
        CRC32,
        /// <summary>
        /// CRC-32/PHILIPS
        /// </summary>
        [Description("CRC-32/PHILIPS")]
        CRC32_PHILIPS,
        /// <summary>
        /// CRC-32/XFER
        /// </summary>
        [Description("CRC-32/XFER")]
        CRC32_XFER,
        /// <summary>
        /// CRC-32/POSIX
        /// </summary>
        [Description("CRC-32/POSIX")]
        CRC32_POSIX,
        /// <summary>
        /// CRC-32/JAMCRC
        /// </summary>
        [Description("CRC-32/JAMCRC")]
        CRC32_JAMCRC,
        /// <summary>
        /// CRC-32/MPEG-2
        /// </summary>
        [Description("CRC-32/MPEG-2")]
        CRC32_MPEG2,
        /// <summary>
        /// CRC-32/BZIP2
        /// </summary>
        [Description("CRC-32/BZIP2")]
        CRC32_BZIP2,
        /// <summary>
        /// CRC-32/Q
        /// </summary>
        [Description("CRC-32/Q")]
        CRC32_Q,
        /// <summary>
        /// CRC-32/D
        /// </summary>
        [Description("CRC-32/D")]
        CRC32_D,

        /// <summary>
        /// CRC-40/GSM
        /// </summary>
        [Description("CRC-40/GSM")]
        CRC40_GSM,

        /// <summary>
        /// CRC-64
        /// </summary>
        [Description("CRC-64")]
        CRC64,
        /// <summary>
        /// CRC-64/XZ
        /// </summary>
        [Description("CRC-64/XZ")]
        CRC64_XZ,
        /// <summary>
        /// CRC-64/WE
        /// </summary>
        [Description("CRC-64/WE")]
        CRC64_WE,
    }
}
