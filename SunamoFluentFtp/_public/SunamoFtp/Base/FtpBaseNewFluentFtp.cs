namespace SunamoFluentFtp._public.SunamoFtp.Base;

/// <summary>
/// Base class for FluentFTP operations.
/// IDisposable cannot be here - since it is in _sunamo, it must be internal
/// </summary>
public abstract class FtpBaseNewFluentFtp : FtpAbstractFluentFtp
{
    /// <summary>
    /// Debugs all directory entries
    /// </summary>
    public abstract void DebugAllEntries();

    /// <summary>
    /// Debugs directory permissions
    /// </summary>
    /// <param name="directory">Directory path</param>
    public abstract void DebugDirChmod(string directory);

    /// <summary>
    /// Disposes resources used by the FTP client
    /// </summary>
    public abstract void Dispose();

    /// <summary>
    /// Uploads a file to the server
    /// </summary>
    /// <param name="path">Local file path to upload</param>
    public abstract
#if ASYNC
    Task
#else
    void
#endif
    UploadFile(string path);
}
