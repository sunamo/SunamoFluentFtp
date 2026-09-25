namespace SunamoFluentFtp._public.SunamoFtp.Base;

public abstract class FtpAbstractFluentFtp
{
    #region Variables

    // Public only because of the Ftp class
    public PathSelectorFluentFtp? PathSelector { get; set; }

    public string? RemoteHost { get; set; }

    // User attempting to login - used with USER command
    public string? RemoteUser { get; set; }

    // Password for user authentication - sent with PASS command
    public string? RemotePass { get; set; }

    public int RemotePort { get; set; }

    public bool IsLoggedIn { get; set; }

    // If set to false, nothing will be uploaded to hosting - only used in this class, everything else will work normally
    public bool ReallyUpload { get; set; } = true;

    // Number of exceptions for one operation - ideal for counting up to 3 and then canceling the entire operation
    protected int ExceptionCount { get; set; } = 0;

    protected int MaxExceptionCount { get; set; } = 3;

    protected bool Startup { get; set; } = true;

    // Total folder size (recursive)
    public ulong FolderSizeRec { get; set; } = 0;

    #endregion

    #region Set variables methods

    public void SetRemoteHost(string remoteHost)
    {
        RemoteHost = remoteHost;
    }

    public string? GetRemoteHost() => RemoteHost;

    public void SetRemotePort(int remotePort)
    {
        RemotePort = remotePort;
    }

    public int GetRemotePort() => RemotePort;

    public void SetRemoteUser(string remoteUser)
    {
        RemoteUser = remoteUser;
    }

    public void SetRemotePass(string remotePass)
    {
        RemotePass = remotePass;
    }

    #endregion

    public abstract void Connect();

    public abstract void Debug(string what, string text, params object[] args);

    public abstract void DebugActualFolder();

    #region Abstract methods

    public abstract bool Mkdir(string directoryName);

    public abstract bool Download(string remoteFileName, string localFileName, bool isDeleteLocalIfExists);

    public abstract bool DeleteRemoteFile(string fileName);

    public abstract void RenameRemoteFile(string oldFileName, string newFileName);

    public abstract bool Rmdir(List<string> excludedDirectories, string directoryName);

    public abstract void DeleteRecursively(List<string> excludedDirectories, string directoryName, int depth, List<DirectoriesToDeleteFluentFtp> directoriesToDelete);

    public abstract void CreateDirectoryIfNotExists(string directoryName);

    public abstract List<string>? ListDirectoryDetails();

    public abstract Dictionary<string, List<string>>? GetFSEntriesListRecursively(List<string> excludedDirectories);

    public abstract void ChdirLite(string directoryName);

    public abstract void GoToUpFolderForce();

    public abstract void GoToUpFolder();

    public abstract void LoginIfIsNot(bool isStartup);

    public abstract long GetFileSize(string fileName);

    public abstract void GoToPath(string remotePath);

    #endregion
}
