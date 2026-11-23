namespace SunamoFluentFtp._public.SunamoFtp.Base;

/// <summary>
/// Represents the path selector fluent ftp type.
/// </summary>
public class PathSelectorFluentFtp
{
    private string firstToken = "";

    /// <summary>
    /// List of path tokens
    /// </summary>
    public List<string> Tokens { get; set; } = new();

    private bool firstTokenMustExists = false;
    private string delimiter = "";

    /// <summary>
    /// Gets the delimiter used for path separation
    /// </summary>
    public string Delimiter => delimiter;

    /// <summary>
    /// Gets or sets the index zero.
    /// </summary>
    public int IndexZero { get; set; } = 0;

    /// <summary>
    /// Gets the first token in the path
    /// </summary>
    public string FirstToken => firstToken;

    /// <summary>
    /// Divide to tokens.
    /// </summary>
    /// <param name="path">The path.</param>
    /// <returns>The divide to tokens result.</returns>
    public List<string> DivideToTokens(string path)
    {
        return path.Split(new string[] { delimiter }, StringSplitOptions.RemoveEmptyEntries).ToList();
    }

    // The first parameter is the highest folder, can be set to C:\, www, SE, or anything else.
    // Works with either \ or / - depending on what is found in the parameter. Other delimiters can be added freely.
    /// <summary>
    /// Path selector fluent ftp.
    /// </summary>
    /// <param name="initialDirectory">The initial directory.</param>
    /// <returns>The path selector fluent ftp result.</returns>
    public PathSelectorFluentFtp(string initialDirectory)
    {
        if (initialDirectory.Contains(":\\") || initialDirectory != "")
        {
            firstTokenMustExists = true;
        }

        if (initialDirectory.Contains("\""))
        {
            delimiter = "\"";
        }
        else
        {
            delimiter = "/";
            if (initialDirectory.Contains(delimiter))
            {
                if (initialDirectory.StartsWith("/"))
                {
                    throw new Exception("Initial directory cannot start with a slash");
                }
                else
                {
                    int firstSlashIndex = initialDirectory.IndexOf('/');
                    firstToken = initialDirectory.Substring(0, firstSlashIndex);
                }
            }
        }

        if (firstTokenMustExists)
        {
            IndexZero = 1;
        }

        ActualPath = initialDirectory;
    }

    /// <summary>
    /// Gets the number of tokens
    /// </summary>
    private int Count => Tokens.Count;

    /// <summary>
    /// Remove last token force.
    /// </summary>
    /// <returns>The remove last token force result.</returns>
    public void RemoveLastTokenForce()
    {
        Tokens.RemoveAt(Count - 1);
    }

    /// <summary>
    /// Initializes a new instance of the remove last token class.
    /// </summary>
    /// <param name="1">The 1.</param>
    public void RemoveLastToken()
    {
        if (CanGoToUpFolder)
        {
            Tokens.RemoveAt(Count - 1);
        }
        else
        {
            throw new Exception("Cannot navigate to parent folder");
        }
    }

    /// <summary>
    /// Gets the last token in the path
    /// </summary>
    /// <returns>Last token</returns>
    public string GetLastToken() => Tokens[Count - 1];

    /// <summary>
    /// Add token.
    /// </summary>
    /// <returns>The add token result.</returns>
    public void AddToken(string token)
    {
        Tokens.Add(token);
    }

    /// <summary>
    /// Gets whether navigation to parent folder is possible
    /// </summary>
    public bool CanGoToUpFolder => Count > IndexZero;

    /// <summary>
    /// The actual path.
    /// </summary>
    public string ActualPath
    {
        get
        {
            if (Tokens.Count != 0)
            {
                return string.Join(delimiter, Tokens.ToArray()) + delimiter;
            }
            else
            {
                return "/";
            }
        }
        set
        {
            Tokens.Clear();
            Tokens.AddRange(value.Split(new string[] { delimiter }, StringSplitOptions.RemoveEmptyEntries));
        }
    }
}
