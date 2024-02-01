
namespace SunamoFluentFtp.FtpClients;
using SunamoFluentFtp.Enums;


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
