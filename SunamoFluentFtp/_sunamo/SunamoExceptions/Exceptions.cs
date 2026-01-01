namespace SunamoFluentFtp._sunamo.SunamoExceptions;

/// <summary>
/// Exception handling utilities
/// © www.sunamo.cz. All Rights Reserved.
/// </summary>
internal sealed partial class Exceptions
{
    #region Other

    /// <summary>
    /// Checks and formats a prefix for exception messages
    /// </summary>
    /// <param name="before">Prefix text</param>
    /// <returns>Formatted prefix with colon or empty string</returns>
    internal static string CheckBefore(string before)
    {
        return string.IsNullOrWhiteSpace(before) ? string.Empty : before + ": ";
    }

    /// <summary>
    /// Gets the place where exception occurred including type, method name and stack trace
    /// </summary>
    /// <param name="isFillAlsoFirstTwo">Whether to fill type and method name from first non-ThrowEx entry</param>
    /// <returns>Tuple containing type name, method name, and stack trace</returns>
    internal static Tuple<string, string, string> PlaceOfException(bool isFillAlsoFirstTwo = true)
    {
        StackTrace stackTrace = new();
        var value = stackTrace.ToString();
        var lines = value.Split(new string[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries).ToList();
        lines.RemoveAt(0);

        var currentIndex = 0;
        string type = string.Empty;
        string methodName = string.Empty;

        for (; currentIndex < lines.Count; currentIndex++)
        {
            var item = lines[currentIndex];
            if (isFillAlsoFirstTwo)
            {
                if (!item.StartsWith("   at ThrowEx"))
                {
                    TypeAndMethodName(item, out type, out methodName);
                    isFillAlsoFirstTwo = false;
                }
            }

            if (item.StartsWith("at System."))
            {
                lines.Add(string.Empty);
                lines.Add(string.Empty);
                break;
            }
        }

        return new Tuple<string, string, string>(type, methodName, string.Join(Environment.NewLine, lines));
    }

    /// <summary>
    /// Extracts type and method name from a stack trace line
    /// </summary>
    /// <param name="lines">Stack trace line</param>
    /// <param name="type">Output: Type name</param>
    /// <param name="methodName">Output: Method name</param>
    internal static void TypeAndMethodName(string lines, out string type, out string methodName)
    {
        var trimmedLine = lines.Split("at ")[1].Trim();
        var methodPath = trimmedLine.Split("(")[0];
        var parts = methodPath.Split(new char[] { '.' }, StringSplitOptions.RemoveEmptyEntries).ToList();
        methodName = parts[^1];
        parts.RemoveAt(parts.Count - 1);
        type = string.Join(".", parts);
    }

    /// <summary>
    /// Gets the name of the calling method
    /// </summary>
    /// <param name="value">Frame depth (1 = immediate caller)</param>
    /// <returns>Method name</returns>
    internal static string CallingMethod(int value = 1)
    {
        StackTrace stackTrace = new();
        var methodBase = stackTrace.GetFrame(value)?.GetMethod();
        if (methodBase == null)
        {
            return "Method name cannot be get";
        }
        var methodName = methodBase.Name;
        return methodName;
    }

    #endregion

    #region IsNullOrWhitespace

    /// <summary>
    /// StringBuilder for inner additional info
    /// </summary>
    internal readonly static StringBuilder AdditionalInfoInnerStringBuilder = new();

    /// <summary>
    /// StringBuilder for additional info
    /// </summary>
    internal readonly static StringBuilder AdditionalInfoStringBuilder = new();

    #endregion

    #region OnlyReturnString

    /// <summary>
    /// Creates exception message for not implemented method
    /// </summary>
    /// <param name="before">Prefix for the message</param>
    /// <returns>Exception message</returns>
    internal static string? NotImplementedMethod(string before)
    {
        return CheckBefore(before) + "Not implemented method.";
    }

    #endregion
}
