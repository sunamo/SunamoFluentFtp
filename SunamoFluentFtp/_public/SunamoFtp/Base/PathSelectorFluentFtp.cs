namespace SunamoFluentFtp._public.SunamoFtp.Base;

/// <summary>
/// Manages path navigation and token manipulation for FTP operations
/// </summary>
public class PathSelectorFluentFtp
{
    private string firstToken = "";

    /// <summary>
    /// List of path tokens
    /// </summary>
    public List<string> Tokens { get; set; } = new List<string>();

    private bool firstTokenMustExists = false;
    private string delimiter = "";

    /// <summary>
    /// Gets the delimiter used for path separation
    /// </summary>
    public string Delimiter
    {
        get
        {
            return delimiter;
        }
    }

    /// <summary>
    /// Index of the first token (0 or 1 depending on whether first token must exist)
    /// </summary>
    public int IndexZero { get; set; } = 0;

    /// <summary>
    /// Gets the first token in the path
    /// </summary>
    public string FirstToken
    {
        get
        {
            return firstToken;
        }
    }

    /// <summary>
    /// Divides a path string into tokens
    /// </summary>
    /// <param name="path">Path to divide</param>
    /// <returns>List of path tokens</returns>
    public List<string> DivideToTokens(string path)
    {
        return path.Split(new string[] { delimiter }, StringSplitOptions.RemoveEmptyEntries).ToList();
    }

    /// <summary>
    /// Initializes a new instance of PathSelectorFluentFtp.
    /// The first parameter is the highest folder, can be set to C:\, www, SE, or anything else.
    /// Works with either \ or / - depending on what is found in the parameter. Other delimiters can be added freely.
    /// </summary>
    /// <param name="initialDirectory">Initial directory path</param>
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
    private int Count
    {
        get
        {
            return Tokens.Count;
        }
    }

    /// <summary>
    /// Removes the last token without checking if it's possible
    /// </summary>
    public void RemoveLastTokenForce()
    {
        Tokens.RemoveAt(Count - 1);
    }

    /// <summary>
    /// Removes the last token if possible
    /// </summary>
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
    public string GetLastToken()
    {
        return Tokens[Count - 1];
    }

    /// <summary>
    /// Adds a token to the path
    /// </summary>
    /// <param name="token">Token to add</param>
    public void AddToken(string token)
    {
        Tokens.Add(token);
    }

    /// <summary>
    /// Gets whether navigation to parent folder is possible
    /// </summary>
    public bool CanGoToUpFolder
    {
        get
        {
            return Count > IndexZero;
        }
    }

    /// <summary>
    /// Gets or sets the current path
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