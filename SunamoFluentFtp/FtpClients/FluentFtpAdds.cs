// EN: Variable names have been checked and replaced with self-descriptive names
// CZ: Názvy proměnných byly zkontrolovány a nahrazeny samopopisnými názvy
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
