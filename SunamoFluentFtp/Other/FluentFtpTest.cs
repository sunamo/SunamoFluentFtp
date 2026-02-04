namespace SunamoFluentFtp.Other;

/// <summary>
/// Test class for FluentFTP functionality
/// </summary>
public class FluentFtpTest
{
    /// <summary>
    /// Tests FluentFTP basic operations
    /// </summary>
    public static void FluentFtp()
    {
        FluentFtpWrapper fluentFtpWrapper = new FluentFtpWrapper();
        fluentFtpWrapper.TestBasicFunctionality();
    }
}