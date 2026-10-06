namespace SunamoFluentFtp._public;

public class DirectoriesToDeleteFluentFtp
{
    public int Depth { get; set; }

    /// <summary>
    /// List of directories with their contents
    /// </summary>
    public List<Dictionary<string, List<string>>> Directories { get; set; } = new();
}