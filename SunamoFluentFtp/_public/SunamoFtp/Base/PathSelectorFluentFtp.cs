namespace SunamoFluentFtp._public.SunamoFtp.Base;

public class PathSelectorFluentFtp
{
    private string firstToken = "";

    public List<string> Tokens { get; set; } = new();

    private bool firstTokenMustExists = false;
    private string delimiter = "";

    public string Delimiter => delimiter;

    public int IndexZero { get; set; } = 0;

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

    public string GetLastToken() => Tokens[Count - 1];

    public void AddToken(string token)
    {
        Tokens.Add(token);
    }

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
