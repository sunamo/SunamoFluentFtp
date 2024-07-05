namespace SunamoFluentFtp._sunamo.SunamoFtp.Base;


internal class PathSelector
{
    string firstToken = "";
    internal List<string> tokens = new List<string>();
    bool firstTokenMustExists = false;
    string delimiter = "";
    internal string Delimiter
    {
        get
        {
            return delimiter;
        }
    }
    internal int indexZero = 0;
    internal string FirstToken
    {
        get
        {
            return firstToken;
        }
    }
    internal List<string> DivideToTokens(string r)
    {
        return r.Split(new string[] { delimiter }, StringSplitOptions.RemoveEmptyEntries).ToList();
    }
    /// <summary>
    /// A1 je složka, která je nejvyšší. Může být nastavena na C:\, www, SE nebo cokoliv jiného
    /// Pracuje buď s \ nebo s / - podle toho co najde v A1. Libovolně lze přidat další oddělovače
    /// </summary>
    /// <param name="initialDirectory"></param>
    internal PathSelector(string initialDirectory)
    {
        if (initialDirectory.Contains(":\\") || initialDirectory != "")
        {
            firstTokenMustExists = true;
        }
        if (initialDirectory.Contains(AllStrings.bs))
        {
            delimiter = AllStrings.bs;
        }
        else
        {
            delimiter = AllStrings.slash;
            if (initialDirectory.Contains(delimiter))
            {
                if (initialDirectory.StartsWith(AllStrings.slash))
                {
                    throw new Exception("Počáteční složka nemůže začínat s lomítkem na začátku");
                    int druhy = initialDirectory.IndexOf(AllChars.slash, 1);
                    firstToken = initialDirectory.Substring(0, druhy);
                }
                else
                {
                    int prvni = initialDirectory.IndexOf(AllChars.slash);
                    firstToken = initialDirectory.Substring(0, prvni);
                }
            }
        }
        if (firstTokenMustExists)
        {
            indexZero = 1;
        }
        ActualPath = initialDirectory;
    }
    int Count
    {
        get
        {
            return tokens.Count;
        }
    }
    internal void RemoveLastTokenForce()
    {
        tokens.RemoveAt(Count - 1);
    }
    static Type type = typeof(PathSelector);
    internal void RemoveLastToken()
    {
        if (CanGoToUpFolder)
        {
            tokens.RemoveAt(Count - 1);
        }
        else
        {
            throw new Exception("Is not possible go to up folder");
        }
    }
    internal string GetLastToken()
    {
        return tokens[Count - 1];
    }
    internal void AddToken(string token)
    {
        tokens.Add(token);
    }
    internal bool CanGoToUpFolder
    {
        get
        {
            return Count > indexZero;
        }
    }
    internal string
        ActualPath
    {
        get
        {
            if (tokens.Count != 0)
            {
                return string.Join(delimiter, tokens.ToArray()) + delimiter;
            }
            else
            {
                return AllStrings.slash;
            }
        }
        set
        {
            tokens.Clear();
            tokens.AddRange(value.Split(new string[] { delimiter }, StringSplitOptions.RemoveEmptyEntries)); //SHSplit.Split(value, delimiter));
        }
    }
}