namespace SunamoFluentFtp.FtpClients;



public class FluentFtpAdds
{
    public FtpClient client = null;

    public SunamoFtpParser FtpParser
    {
        set
        {
            //client.ListingParser = (FtpParser)Enum.Parse(typeof(FtpParser), value.ToString());
        }
    }
}
