namespace SunamoFluentFtp._sunamo.SunamoExceptions;

/// <summary>
/// Exception throwing utilities
/// </summary>
internal partial class ThrowEx
{
    /// <summary>
    /// Throws exception for not implemented method
    /// </summary>
    /// <returns>True if exception was thrown</returns>
    internal static bool NotImplementedMethod()
    {
        return ThrowIsNotNull(Exceptions.NotImplementedMethod);
    }

    #region Other

    /// <summary>
    /// Gets the full name of the executed code (type.method)
    /// </summary>
    /// <returns>Full name in format Type.Method</returns>
    internal static string FullNameOfExecutedCode()
    {
        Tuple<string, string, string> placeOfException = Exceptions.PlaceOfException();
        string fullName = FullNameOfExecutedCode(placeOfException.Item1, placeOfException.Item2, true);
        return fullName;
    }

    /// <summary>
    /// Gets the full name of executed code from type and method name
    /// </summary>
    /// <param name="type">Type information (can be Type, MethodBase, or string)</param>
    /// <param name="methodName">Method name</param>
    /// <param name="isFromThrowEx">Whether called from ThrowEx (adjusts stack depth)</param>
    /// <returns>Full name in format Type.Method</returns>
    static string FullNameOfExecutedCode(object type, string methodName, bool isFromThrowEx = false)
    {
        if (methodName == null)
        {
            int depth = 2;
            if (isFromThrowEx)
            {
                depth++;
            }

            methodName = Exceptions.CallingMethod(depth);
        }

        string typeFullName;
        if (type is Type castedType)
        {
            typeFullName = castedType.FullName ?? "Type cannot be get via type is Type";
        }
        else if (type is MethodBase method)
        {
            typeFullName = method.ReflectedType?.FullName ?? "Type cannot be get via type is MethodBase";
            methodName = method.Name;
        }
        else if (type is string)
        {
            typeFullName = type.ToString() ?? "Type cannot be get via type is string";
        }
        else
        {
            Type reflectedType = type.GetType();
            typeFullName = reflectedType.FullName ?? "Type cannot be get via type.GetType()";
        }

        return string.Concat(typeFullName, ".", methodName);
    }

    /// <summary>
    /// Throws exception if the exception string is not null
    /// </summary>
    /// <param name="exception">Exception message</param>
    /// <param name="isReallyThrow">Whether to actually throw the exception or just return true</param>
    /// <returns>True if exception is not null</returns>
    internal static bool ThrowIsNotNull(string? exception, bool isReallyThrow = true)
    {
        if (exception != null)
        {
            Debugger.Break();
            if (isReallyThrow)
            {
                throw new Exception(exception);
            }
            return true;
        }
        return false;
    }

    #region For avoid FullNameOfExecutedCode

    /// <summary>
    /// Throws exception using a function that generates the exception message
    /// </summary>
    /// <param name="exceptionFunc">Function that generates exception message</param>
    /// <returns>True if exception was thrown</returns>
    internal static bool ThrowIsNotNull(Func<string, string?> exceptionFunc)
    {
        string? exception = exceptionFunc(FullNameOfExecutedCode());
        return ThrowIsNotNull(exception);
    }

    #endregion
    #endregion
}