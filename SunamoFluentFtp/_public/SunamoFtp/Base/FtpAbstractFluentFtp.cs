namespace SunamoFluentFtp._public.SunamoFtp.Base;

/// <summary>
/// Abstract base class for FTP operations
/// </summary>
public abstract class FtpAbstractFluentFtp
{
    #region Variables

    /// <summary>
    /// Path selector for managing directory paths.
    /// Public only because of the Ftp class
    /// </summary>
    public PathSelectorFluentFtp? PathSelector { get; set; }

    /// <summary>
    /// Remote host address
    /// </summary>
    public string? RemoteHost { get; set; }

    /// <summary>
    /// User attempting to login - used with USER command
    /// </summary>
    public string? RemoteUser { get; set; }

    /// <summary>
    /// Password for user authentication - sent with PASS command
    /// </summary>
    public string? RemotePass { get; set; }

    /// <summary>
    /// Remote port number
    /// </summary>
    public int RemotePort { get; set; }

    /// <summary>
    /// Indicates whether the user is logged in
    /// </summary>
    public bool IsLoggedIn { get; set; }

    /// <summary>
    /// If set to false, nothing will be uploaded to hosting - only used in this class, everything else will work normally
    /// </summary>
    public bool ReallyUpload { get; set; } = true;

    /// <summary>
    /// Number of exceptions for one operation - ideal for counting up to 3 and then canceling the entire operation
    /// </summary>
    protected int ExceptionCount { get; set; } = 0;

    /// <summary>
    /// Maximum number of exceptions allowed before operation is canceled
    /// </summary>
    protected int MaxExceptionCount { get; set; } = 3;

    /// <summary>
    /// Indicates whether this is a startup operation
    /// </summary>
    protected bool Startup { get; set; } = true;

    /// <summary>
    /// Total folder size (recursive)
    /// </summary>
    public ulong FolderSizeRec { get; set; } = 0;

    #endregion

    #region Set variables methods

    /// <summary>
    /// Sets the remote host address
    /// </summary>
    /// <param name="remoteHost">Remote host address</param>
    public void setRemoteHost(string remoteHost)
    {
        RemoteHost = remoteHost;
    }

    /// <summary>
    /// Gets the remote host address
    /// </summary>
    /// <returns>Remote host address</returns>
    public string? getRemoteHost()
    {
        return RemoteHost;
    }

    /// <summary>
    /// Sets the remote port number
    /// </summary>
    /// <param name="remotePort">Remote port number</param>
    public void setRemotePort(int remotePort)
    {
        RemotePort = remotePort;
    }

    /// <summary>
    /// Gets the port used for remote transfer
    /// </summary>
    /// <returns>Remote port number</returns>
    public int getRemotePort()
    {
        return RemotePort;
    }

    /// <summary>
    /// Sets the remote user name
    /// </summary>
    /// <param name="remoteUser">Remote user name</param>
    public void setRemoteUser(string remoteUser)
    {
        RemoteUser = remoteUser;
    }

    /// <summary>
    /// Sets the remote user password
    /// </summary>
    /// <param name="remotePass">Remote user password</param>
    public void setRemotePass(string remotePass)
    {
        RemotePass = remotePass;
    }

    #endregion

    /// <summary>
    /// Connects to the FTP server
    /// </summary>
    public abstract void Connect();

    /// <summary>
    /// Debug method with custom message
    /// </summary>
    /// <param name="what">Type of debug information</param>
    /// <param name="text">Debug message text</param>
    /// <param name="args">Optional format arguments</param>
    public abstract void D(string what, string text, params object[] args);

    /// <summary>
    /// Debugs the current folder
    /// </summary>
    public abstract void DebugActualFolder();

    #region Abstract methods

    /// <summary>
    /// Creates a directory
    /// </summary>
    /// <param name="directoryName">Name of the directory to create</param>
    /// <returns>True if successful</returns>
    public abstract bool mkdir(string directoryName);

    /// <summary>
    /// Downloads a file from remote to local
    /// </summary>
    /// <param name="remoteFileName">Remote file name</param>
    /// <param name="localFileName">Local file name</param>
    /// <param name="isDeleteLocalIfExists">Whether to delete local file if it exists</param>
    /// <returns>True if successful</returns>
    public abstract bool download(string remoteFileName, string localFileName, bool isDeleteLocalIfExists);

    /// <summary>
    /// Deletes a remote file
    /// </summary>
    /// <param name="fileName">Name of the file to delete</param>
    /// <returns>True if successful</returns>
    public abstract bool deleteRemoteFile(string fileName);

    /// <summary>
    /// Renames a remote file
    /// </summary>
    /// <param name="oldFileName">Current file name</param>
    /// <param name="newFileName">New file name</param>
    public abstract void renameRemoteFile(string oldFileName, string newFileName);

    /// <summary>
    /// Removes a directory
    /// </summary>
    /// <param name="excludedDirectories">Directories to exclude from operation</param>
    /// <param name="directoryName">Name of the directory to remove</param>
    /// <returns>True if successful</returns>
    public abstract bool rmdir(List<string> excludedDirectories, string directoryName);

    /// <summary>
    /// Deletes directory recursively
    /// </summary>
    /// <param name="excludedDirectories">Directories to exclude from deletion</param>
    /// <param name="directoryName">Name of the directory to delete</param>
    /// <param name="depth">Recursion depth</param>
    /// <param name="directoriesToDelete">List of directories to delete</param>
    public abstract void DeleteRecursively(List<string> excludedDirectories, string directoryName, int depth, List<DirectoriesToDeleteFluentFtp> directoriesToDelete);

    /// <summary>
    /// Creates a directory if it doesn't exist
    /// </summary>
    /// <param name="directoryName">Name of the directory to create</param>
    public abstract void CreateDirectoryIfNotExists(string directoryName);

    /// <summary>
    /// Lists directory details
    /// </summary>
    /// <returns>List of directory entries</returns>
    public abstract List<string>? ListDirectoryDetails();

    /// <summary>
    /// Gets filesystem entries list recursively
    /// </summary>
    /// <param name="excludedDirectories">Directories to exclude from listing</param>
    /// <returns>Dictionary of directories and their contents</returns>
    public abstract Dictionary<string, List<string>>? getFSEntriesListRecursively(List<string> excludedDirectories);

    /// <summary>
    /// Changes directory (lite version)
    /// </summary>
    /// <param name="directoryName">Directory name</param>
    public abstract void chdirLite(string directoryName);

    /// <summary>
    /// Forces navigation to parent folder
    /// </summary>
    public abstract void goToUpFolderForce();

    /// <summary>
    /// Navigates to parent folder
    /// </summary>
    public abstract void goToUpFolder();

    /// <summary>
    /// Logs in if not already logged in
    /// </summary>
    /// <param name="isStartup">Whether this is a startup login</param>
    public abstract void LoginIfIsNot(bool isStartup);

    /// <summary>
    /// Gets the size of a file
    /// </summary>
    /// <param name="fileName">Name of the file</param>
    /// <returns>File size in bytes</returns>
    public abstract long getFileSize(string fileName);

    /// <summary>
    /// Navigates to specified path
    /// </summary>
    /// <param name="remotePath">Path on the hosting server</param>
    public abstract void goToPath(string remotePath);

    #endregion
}
