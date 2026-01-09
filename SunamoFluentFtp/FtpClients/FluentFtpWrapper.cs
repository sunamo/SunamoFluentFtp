namespace SunamoFluentFtp.FtpClients;

/// <summary>
/// Wrapper for FluentFTP client providing high-level FTP operations.
/// Elements of this class are made public because their parent elements must be at most internal.
/// Therefore they cannot be public here.
/// </summary>
public class FluentFtpWrapper : FtpBaseNewFluentFtp
{
    /// <summary>
    /// The FluentFTP client instance
    /// </summary>
    public FtpClient? Client { get; set; }

    /// <summary>
    /// Additional functionality for the FTP client
    /// </summary>
    public FluentFtpAdds Adds { get; set; } = new FluentFtpAdds();

    /// <summary>
    /// Debugs the current working directory
    /// </summary>
    public override void DebugActualFolder()
    {
#if DEBUG
        var value = Client?.GetWorkingDirectory();
#endif
    }

    /// <summary>
    /// Debug method with custom message
    /// </summary>
    /// <param name="what">Type of debug information</param>
    /// <param name="text">Debug message text</param>
    /// <param name="args">Optional format arguments</param>
    public override void D(string what, string text, params object[] args)
    {
        ThrowEx.NotImplementedMethod();
    }

    /// <summary>
    /// Debugs all directory entries
    /// </summary>
    public override void DebugAllEntries()
    {
        ThrowEx.NotImplementedMethod();
    }

    /// <summary>
    /// Tests basic FTP functionality
    /// </summary>
    public void TestBasicFunctionality()
    {
        if (Client == null)
        {
            throw new InvalidOperationException("Client is not initialized. Call Connect() first.");
        }

        Connect();
        Console.WriteLine(Client.GetChmod("/"));

        foreach (FtpListItem item in Client.GetListing("/"))
        {
            if (item.Type == FtpObjectType.File)
            {
                Client.GetFileSize(item.FullName);
            }
            Console.WriteLine(item.Chmod);
            Console.WriteLine(item.Name);
            Client.GetModifiedTime(item.FullName);
            Client.GetChecksum(item.FullName);
        }
    }

    /// <summary>
    /// Connects to the FTP server
    /// </summary>
    public override void Connect()
    {
        Client = new FtpClient(RemoteHost, RemotePort, new FtpConfig() { });
        Client.Connect();
        Adds.Client = Client;
    }

    #region Other

    /// <summary>
    /// Creates a directory if it doesn't exist
    /// </summary>
    /// <param name="directoryName">Name of the directory to create</param>
    public override void CreateDirectoryIfNotExists(string directoryName)
    {
        if (Client == null)
        {
            throw new InvalidOperationException("Client is not initialized");
        }

        if (!Client.DirectoryExists(directoryName))
        {
            Client.CreateDirectory(directoryName);
        }
    }

    /// <summary>
    /// Deletes a remote file
    /// </summary>
    /// <param name="fileName">Name of the file to delete</param>
    /// <returns>True if successful</returns>
    public override bool deleteRemoteFile(string fileName)
    {
        ThrowEx.NotImplementedMethod();
        return false;
    }

    /// <summary>
    /// Downloads a file from remote to local
    /// </summary>
    /// <param name="remoteFileName">Remote file name</param>
    /// <param name="localFileName">Local file name</param>
    /// <param name="isDeleteLocalIfExists">Whether to delete local file if it exists</param>
    /// <returns>True if successful</returns>
    public override bool download(string remoteFileName, string localFileName, bool isDeleteLocalIfExists)
    {
        ThrowEx.NotImplementedMethod();
        return false;
    }

    /// <summary>
    /// Gets the size of a file
    /// </summary>
    /// <param name="fileName">Name of the file</param>
    /// <returns>File size in bytes</returns>
    public override long getFileSize(string fileName)
    {
        ThrowEx.NotImplementedMethod();
        return 0;
    }

    /// <summary>
    /// Gets filesystem entries list recursively
    /// </summary>
    /// <param name="excludedDirectories">Directories to exclude from listing</param>
    /// <returns>Dictionary of directories and their contents</returns>
    public override Dictionary<string, List<string>>? getFSEntriesListRecursively(List<string> excludedDirectories)
    {
        ThrowEx.NotImplementedMethod();
        return null;
    }

    private string? workingDirectory;

    /// <summary>
    /// Navigates to specified path.
    /// In FluentFTP this is not strictly necessary but maintained for interface compatibility.
    /// </summary>
    /// <param name="remotePath">Path on the hosting server</param>
    public override void goToPath(string remotePath)
    {
        if (Client == null)
        {
            throw new InvalidOperationException("Client is not initialized");
        }

        if (!remotePath.StartsWith("/"))
        {
            remotePath = "/" + remotePath;
        }
        workingDirectory = remotePath;
        Client.SetWorkingDirectory(remotePath);
    }

    /// <summary>
    /// Navigates to parent folder
    /// </summary>
    public override void goToUpFolder()
    {
        ThrowEx.NotImplementedMethod();
    }

    /// <summary>
    /// Forces navigation to parent folder
    /// </summary>
    public override void goToUpFolderForce()
    {
        ThrowEx.NotImplementedMethod();
    }

    /// <summary>
    /// Lists directory details
    /// </summary>
    /// <returns>List of directory entries</returns>
    public override List<string>? ListDirectoryDetails()
    {
        return null;
    }

    /// <summary>
    /// Logs in if not already logged in
    /// </summary>
    /// <param name="isStartup">Whether this is a startup login</param>
    public override void LoginIfIsNot(bool isStartup)
    {
        ThrowEx.NotImplementedMethod();
    }

    /// <summary>
    /// Creates a directory
    /// </summary>
    /// <param name="directoryName">Name of the directory</param>
    /// <returns>True if successful</returns>
    public override bool mkdir(string directoryName)
    {
        ThrowEx.NotImplementedMethod();
        return false;
    }

    /// <summary>
    /// Renames a remote file
    /// </summary>
    /// <param name="oldFileName">Current file name</param>
    /// <param name="newFileName">New file name</param>
    public override void renameRemoteFile(string oldFileName, string newFileName)
    {
        ThrowEx.NotImplementedMethod();
    }

    /// <summary>
    /// Removes a directory
    /// </summary>
    /// <param name="excludedDirectories">Directories to exclude from operation</param>
    /// <param name="directoryName">Name of the directory to remove</param>
    /// <returns>True if successful</returns>
    public override bool rmdir(List<string> excludedDirectories, string directoryName)
    {
        ThrowEx.NotImplementedMethod();
        return false;
    }

    #endregion

    /// <summary>
    /// Debugs directory permissions
    /// </summary>
    /// <param name="directory">Directory path</param>
    public override void DebugDirChmod(string directory)
    {
    }

    #region Other

    /// <summary>
    /// Deletes directory recursively
    /// </summary>
    /// <param name="excludedDirectories">Directories to exclude from deletion</param>
    /// <param name="directoryName">Name of the directory to delete</param>
    /// <param name="depth">Recursion depth</param>
    /// <param name="directoriesToDelete">List of directories to delete</param>
    public override void DeleteRecursively(List<string> excludedDirectories, string directoryName, int depth, List<DirectoriesToDeleteFluentFtp> directoriesToDelete)
    {
        ThrowEx.NotImplementedMethod();
    }

    /// <summary>
    /// Changes directory (lite version, must be here due to interface)
    /// </summary>
    /// <param name="directoryName">Directory name</param>
    public override void chdirLite(string directoryName)
    {
        ThrowEx.NotImplementedMethod();
    }

    /// <summary>
    /// Uploads a file to the server
    /// </summary>
    /// <param name="path">Local file path</param>
    public override
#if ASYNC
    async Task
#else
    void
#endif
    UploadFile(string path)
    {
        if (Client == null)
        {
            throw new InvalidOperationException("Client is not initialized");
        }

        Client.UploadBytes(
#if ASYNC
        await
#endif
        File.ReadAllBytesAsync(path), Path.GetFileName(path), FtpRemoteExists.Overwrite);
    }

    /// <summary>
    /// Disposes the FTP client.
    /// IDisposable cannot be here - since it is in _sunamo, it must be internal.
    /// Therefore it is here as internal override.
    /// </summary>
    public override void Dispose()
    {
        Client?.Dispose();
    }

    #endregion
}
