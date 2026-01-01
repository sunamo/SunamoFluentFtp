// variables names: ok
namespace SunamoFluentFtp.Enums;

/// <summary>
/// Represents different FTP list parser types
/// </summary>
public enum SunamoFtpParser
{
    /// <summary>
    /// Custom parser type
    /// </summary>
    Custom = -1,

    /// <summary>
    /// Automatic parser detection
    /// </summary>
    Auto = 0,

    /// <summary>
    /// Machine-readable format parser
    /// </summary>
    Machine = 1,

    /// <summary>
    /// Windows FTP server parser
    /// </summary>
    Windows = 2,

    /// <summary>
    /// Unix FTP server parser
    /// </summary>
    Unix = 3,

    /// <summary>
    /// Alternative Unix FTP server parser
    /// </summary>
    UnixAlt = 4,

    /// <summary>
    /// VMS FTP server parser
    /// </summary>
    VMS = 5,

    /// <summary>
    /// IBM FTP server parser
    /// </summary>
    IBM = 6,

    /// <summary>
    /// NonStop FTP server parser
    /// </summary>
    NonStop = 7
}
