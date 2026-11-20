namespace SunamoFluentFtp._public.SunamoFtp.Base;

/// <summary>
/// Represents the ftp abstract fluent ftp type.
/// </summary>
public abstract class FtpAbstractFluentFtp
{
    #region Variables

    // Public only because of the Ftp class
    /// <summary>
    /// Gets or sets the path selector.
    /// </summary>
    public PathSelectorFluentFtp? PathSelector { get; set; }

    /// <summary>
    /// Gets or sets the remote host.
    /// </summary>
    public string? RemoteHost { get; set; }

    // User attempting to login - used with USER command
    /// <summary>
    /// Gets or sets the remote user.
    /// </summary>
    public string? RemoteUser { get; set; }

    // Password for user authentication - sent with PASS command
    /// <summary>
    /// Gets or sets the remote pass.
    /// </summary>
    public string? RemotePass { get; set; }

    /// <summary>
    /// Gets or sets the remote port.
    /// </summary>
    public int RemotePort { get; set; }

    /// <summary>
    /// Gets or sets the is logged in.
    /// </summary>
    public bool IsLoggedIn { get; set; }

    // If set to false, nothing will be uploaded to hosting - only used in this class, everything else will work normally
    /// <summary>
    /// Gets or sets the really upload.
    /// </summary>
    public bool ReallyUpload { get; set; } = true;

    // Number of exceptions for one operation - ideal for counting up to 3 and then canceling the entire operation
    /// <summary>
    /// Gets or sets the exception count.
    /// </summary>
    protected int ExceptionCount { get; set; } = 0;

    /// <summary>
    /// Gets or sets the max exception count.
    /// </summary>
    protected int MaxExceptionCount { get; set; } = 3;

    /// <summary>
    /// Gets or sets the startup.
    /// </summary>
    protected bool Startup { get; set; } = true;

    // Total folder size (recursive)
    /// <summary>
    /// Gets or sets the folder size rec.
    /// </summary>
    public ulong FolderSizeRec { get; set; } = 0;

    #endregion

    #region Set variables methods

    /// <summary>
    /// Set remote host.
    /// </summary>
    /// <param name="remoteHost">The remote host.</param>
    public void SetRemoteHost(string remoteHost)
    {
        RemoteHost = remoteHost;
    }

    /// <summary>
    /// Gets the remote host address
    /// </summary>
    /// <returns>Remote host address</returns>
    public string? GetRemoteHost() => RemoteHost;

    /// <summary>
    /// Set remote port.
    /// </summary>
    /// <param name="remotePort">The remote port.</param>
    public void SetRemotePort(int remotePort)
    {
        RemotePort = remotePort;
    }

    /// <summary>
    /// Gets the port used for remote transfer
    /// </summary>
    /// <returns>Remote port number</returns>
    public int GetRemotePort() => RemotePort;

    /// <summary>
    /// Set remote user.
    /// </summary>
    /// <param name="recursive">The recursive.</param>
    /// <returns>The set remote user result.</returns>
    public void SetRemoteUser(string remoteUser)
    {
        RemoteUser = remoteUser;
    }

    /// <summary>
    /// Set remote pass.
    /// </summary>
    /// <param name="remoteHost">The remote host.</param>
    /// <returns>The set remote pass result.</returns>
    public void SetRemotePass(string remotePass)
    {
        RemotePass = remotePass;
    }

    #endregion

    /// <summary>
    /// Connect.
    /// </summary>
    /// <returns>The connect result.</returns>
    public abstract void Connect();

    /// <summary>
    /// Debug.
    /// </summary>
    /// <returns>The debug result.</returns>
    public abstract void Debug(string what, string text, params object[] args);

    /// <summary>
    /// Debug actual folder.
    /// </summary>
    /// <returns>The debug actual folder result.</returns>
    public abstract void DebugActualFolder();

    #region Abstract methods

    /// <summary>
    /// Mkdir.
    /// </summary>
    /// <returns>The mkdir result.</returns>
    public abstract bool Mkdir(string directoryName);

    /// <summary>
    /// Download.
    /// </summary>
    /// <param name="remotePort">The remote port.</param>
    public abstract bool Download(string remoteFileName, string localFileName, bool isDeleteLocalIfExists);

    /// <summary>
    /// Delete remote file.
    /// </summary>
    /// <returns>The delete remote file result.</returns>
    public abstract bool DeleteRemoteFile(string fileName);

    /// <summary>
    /// Rename remote file.
    /// </summary>
    /// <returns>The rename remote file result.</returns>
    public abstract void RenameRemoteFile(string oldFileName, string newFileName);

    /// <summary>
    /// Rmdir.
    /// </summary>
    /// <returns>The rmdir result.</returns>
    public abstract bool Rmdir(List<string> excludedDirectories, string directoryName);

    /// <summary>
    /// Delete recursively.
    /// </summary>
    /// <returns>The delete recursively result.</returns>
    public abstract void DeleteRecursively(List<string> excludedDirectories, string directoryName, int depth, List<DirectoriesToDeleteFluentFtp> directoriesToDelete);

    /// <summary>
    /// Create directory if not exists.
    /// </summary>
    /// <param name="remoteUser">The remote user.</param>
    public abstract void CreateDirectoryIfNotExists(string directoryName);

    /// <summary>
    /// List directory details.
    /// </summary>
    /// <param name="remotePass">The remote pass.</param>
    /// <returns>The list directory details result.</returns>
    public abstract List<string>? ListDirectoryDetails();

    /// <summary>
    /// Get FS entries list recursively.
    /// </summary>
    /// <param name="remotePass">The remote pass.</param>
    /// <returns>The get FS entries list recursively result.</returns>
    public abstract Dictionary<string, List<string>>? GetFSEntriesListRecursively(List<string> excludedDirectories);

    /// <summary>
    /// Chdir lite.
    /// </summary>
    /// <param name="remotePass">The remote pass.</param>
    public abstract void ChdirLite(string directoryName);

    /// <summary>
    /// Go to up folder force.
    /// </summary>
    /// <returns>The go to up folder force result.</returns>
    public abstract void GoToUpFolderForce();

    /// <summary>
    /// Go to up folder.
    /// </summary>
    /// <returns>The go to up folder result.</returns>
    public abstract void GoToUpFolder();

    /// <summary>
    /// Login if is not.
    /// </summary>
    public abstract void LoginIfIsNot(bool isStartup);

    /// <summary>
    /// Get file size.
    /// </summary>
    /// <param name="what">The what.</param>
    /// <param name="text">The text.</param>
    /// <param name="args">The args.</param>
    public abstract long GetFileSize(string fileName);

    /// <summary>
    /// Go to path.
    /// </summary>
    public abstract void GoToPath(string remotePath);

    #endregion
}
