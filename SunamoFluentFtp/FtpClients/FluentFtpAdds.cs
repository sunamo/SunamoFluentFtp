namespace SunamoFluentFtp.FtpClients;

/// <summary>
/// Represents the fluent ftp adds type.
/// </summary>
public class FluentFtpAdds
{
    /// <summary>
    /// Gets or sets the client.
    /// </summary>
    public FtpClient? Client { get; set; }

    /// <summary>
    /// Gets or sets the ftp parser.
    /// </summary>
    public SunamoFtpParser FtpParser { get; set; }
}
