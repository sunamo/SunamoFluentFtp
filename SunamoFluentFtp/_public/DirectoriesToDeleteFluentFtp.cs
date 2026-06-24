namespace SunamoFluentFtp._public;

public class DirectoriesToDeleteFluentFtp
{
    public int Depth { get; set; }

    public List<Dictionary<string, List<string>>> Directories { get; set; } = new();
}
