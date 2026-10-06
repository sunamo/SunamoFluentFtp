namespace SunamoFluentFtp._sunamo.SunamoExceptions;

internal partial class ThrowEx
{
    internal static bool NotImplementedMethod()
    {
        return ThrowIsNotNull(Exceptions.NotImplementedMethod);
    }

    #region Other

    internal static string FullNameOfExecutedCode()
    {
        Tuple<string, string, string> placeOfException = Exceptions.PlaceOfException();
        string fullName = FullNameOfExecutedCode(placeOfException.Item1, placeOfException.Item2, true);
        return fullName;
    }

    static string FullNameOfExecutedCode(object type, string methodName, bool isFromThrowEx = false)
    {
        if (methodName is null)
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

    internal static bool ThrowIsNotNull(string? exception, bool isReallyThrow = true)
    {
        if (exception is not null)
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

    internal static bool ThrowIsNotNull(Func<string, string?> exceptionFunc)
    {
        string? exception = exceptionFunc(FullNameOfExecutedCode());
        return ThrowIsNotNull(exception);
    }

    #endregion
    #endregion
}
