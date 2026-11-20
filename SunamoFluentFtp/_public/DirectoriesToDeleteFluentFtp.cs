namespace SunamoFluentFtp._public;

/// <summary>
/// Represents the directories to delete fluent ftp type.
/// </summary>
public class DirectoriesToDeleteFluentFtp
{
    /// <summary>
    /// Gets or sets the depth.
    /// </summary>
    public int Depth { get; set; }

    /// <summary>
    /// List of directories with their contents
    /// </summary>
    public List<Dictionary<string, List<string>>> Directories { get; set; } = new();
}