namespace SunamoFluentFtp._public;

/// <summary>
/// Represents directories to be deleted with their depth level
/// </summary>
public class DirectoriesToDeleteFluentFtp
{
    /// <summary>
    /// Depth level of the directory in the hierarchy
    /// </summary>
    public int Depth { get; set; }

    /// <summary>
    /// List of directories with their contents
    /// </summary>
    public List<Dictionary<string, List<string>>> Directories { get; set; } = new List<Dictionary<string, List<string>>>();
}
