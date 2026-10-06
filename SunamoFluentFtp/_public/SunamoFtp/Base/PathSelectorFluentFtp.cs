namespace SunamoFluentFtp._public.SunamoFtp.Base;

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

    public int IndexZero { get; set; } = 0;

    /// <summary>
    /// Gets the first token in the path
    /// </summary>
    public string FirstToken => firstToken;

    public List<string> DivideToTokens(string path)
    {
        return path.Split(new string[] { delimiter }, StringSplitOptions.RemoveEmptyEntries).ToList();
    }

    // The first parameter is the highest folder, can be set to C:\, www, SE, or anything else.
    // Works with either \ or / - depending on what is found in the parameter. Other delimiters can be added freely.
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

    public void RemoveLastTokenForce()
    {
        Tokens.RemoveAt(Count - 1);
    }

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

    public void AddToken(string token)
    {
        Tokens.Add(token);
    }

    /// <summary>
    /// Gets whether navigation to parent folder is possible
    /// </summary>
    public bool CanGoToUpFolder => Count > IndexZero;

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
