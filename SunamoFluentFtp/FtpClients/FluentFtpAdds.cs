namespace SunamoFluentFtp.FtpClients;

/// <summary>
/// Additional functionality for FluentFTP client
/// </summary>
public class FluentFtpAdds
{
    /// <summary>
    /// The FTP client instance
    /// </summary>
    public FtpClient? Client { get; set; }

    /// <summary>
    /// Gets or sets the FTP parser type
    /// </summary>
    public SunamoFtpParser FtpParser
    {
        set
        {
            //client.ListingParser = (FtpParser)Enum.Parse(typeof(FtpParser), value.ToString());
        }
    }
}
