namespace SunamoFluentFtp.FtpClients;

public class FluentFtpWrapper : FtpBaseNewFluentFtp
{
    public FtpClient? Client { get; set; }

    public FluentFtpAdds Adds { get; set; } = new FluentFtpAdds();

    public override void DebugActualFolder()
    {
    }

    public override void Debug(string what, string text, params object[] args)
    {
        ThrowEx.NotImplementedMethod();
    }

    public override void DebugAllEntries()
    {
        ThrowEx.NotImplementedMethod();
    }

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

    public override void Connect()
    {
        Client = new FtpClient(RemoteHost, RemotePort, new FtpConfig() { });
        Client.Connect();
        Adds.Client = Client;
    }

    #region Other

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

    public override bool DeleteRemoteFile(string fileName)
    {
        ThrowEx.NotImplementedMethod();
        return false;
    }

    public override bool Download(string remoteFileName, string localFileName, bool isDeleteLocalIfExists)
    {
        ThrowEx.NotImplementedMethod();
        return false;
    }

    public override long GetFileSize(string fileName)
    {
        ThrowEx.NotImplementedMethod();
        return 0;
    }

    public override Dictionary<string, List<string>>? GetFSEntriesListRecursively(List<string> excludedDirectories)
    {
        ThrowEx.NotImplementedMethod();
        return null;
    }

    private string? workingDirectory;

    public override void GoToPath(string remotePath)
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

    public override void GoToUpFolder()
    {
        ThrowEx.NotImplementedMethod();
    }

    public override void GoToUpFolderForce()
    {
        ThrowEx.NotImplementedMethod();
    }

    public override List<string>? ListDirectoryDetails()
    {
        return null;
    }

    public override void LoginIfIsNot(bool isStartup)
    {
        ThrowEx.NotImplementedMethod();
    }

    public override bool Mkdir(string directoryName)
    {
        ThrowEx.NotImplementedMethod();
        return false;
    }

    public override void RenameRemoteFile(string oldFileName, string newFileName)
    {
        ThrowEx.NotImplementedMethod();
    }

    public override bool Rmdir(List<string> excludedDirectories, string directoryName)
    {
        ThrowEx.NotImplementedMethod();
        return false;
    }

    #endregion

    public override void DebugDirChmod(string directory)
    {
    }

    #region Other

    public override void DeleteRecursively(List<string> excludedDirectories, string directoryName, int depth, List<DirectoriesToDeleteFluentFtp> directoriesToDelete)
    {
        ThrowEx.NotImplementedMethod();
    }

    public override void ChdirLite(string directoryName)
    {
        ThrowEx.NotImplementedMethod();
    }

    public override
    async Task
    UploadFile(string path)
    {
        if (Client == null)
        {
            throw new InvalidOperationException("Client is not initialized");
        }

        Client.UploadBytes(
        await
        FileAsync.ReadAllBytesAsync(path), Path.GetFileName(path), FtpRemoteExists.Overwrite);
    }

    public override void Dispose()
    {
        Client?.Dispose();
    }

    #endregion
}
