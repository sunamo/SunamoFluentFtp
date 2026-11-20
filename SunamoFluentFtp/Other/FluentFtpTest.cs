namespace SunamoFluentFtp.Other;

/// <summary>
/// Represents the fluent ftp test type.
/// </summary>
public class FluentFtpTest
{
    /// <summary>
    /// Fluent ftp.
    /// </summary>
    public static void FluentFtp()
    {
        var fluentFtpWrapper = new FluentFtpWrapper();
        fluentFtpWrapper.TestBasicFunctionality();
    }
}
