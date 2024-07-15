using SunamoFluentFtp._public;
using SunamoFluentFtp._public.SunamoFtp.Base;

namespace SunamoFluentFtp.FtpClients;

/// <summary>
/// Prvky této třídy jsem udělal public protože její nadřazené prvky musí být max internal. A tím pádem nemůžou být public zde
/// </summary>
public class FluentFtpWrapper : FtpBaseNewFluentFtp
{
    static Type type = typeof(FluentFtpWrapper);
    public FtpClient client = null;
    public FluentFtpAdds adds = new FluentFtpAdds();



    public override void DebugActualFolder()
    {
#if DEBUG
        var v = client.GetWorkingDirectory();
        //DebugLogger.Instance.WriteLine(v);
#endif
    }

    public override void D(string what, string text, params object[] args)
    {
        ThrowEx.NotImplementedMethod();
    }

    public override void DebugAllEntries()
    {
        ThrowEx.NotImplementedMethod();
    }


    public void TestBasicFunctionality()
    {
        Connect();

        Console.WriteLine(client.GetChmod(AllStrings.slash));

        // get a list of files and directories in the "/" + "htdocs" folder
        foreach (FtpListItem item in client.GetListing(AllStrings.slash))
        {

            // if this is a file
            if (item.Type == FtpObjectType.File)
            {
                // get the file size
                long size = client.GetFileSize(item.FullName);
            }

            Console.WriteLine(item.Chmod);
            Console.WriteLine(item.Name);


            // get modified date/time of the file or folder
            DateTime time = client.GetModifiedTime(item.FullName);

            // calculate a hash for the file on the server side (default algorithm)
            FtpHash hash = client.GetChecksum(item.FullName);
        }

        //var d = client.GetWorkingDirectory();

        //client.CreateDirectory("htdocs2");
        //CreateDirectoryIfNotExists("/" + "htdocs");

        //// upload a file
        //client.UploadFile(@"D:\a.txt", "/htdocs/big.txt");

        //// rename the uploaded file
        //client.Rename("/htdocs/big.txt", "/htdocs/big2.txt");

        //// download the file again
        //client.DownloadFile(@"D:\b.txt", "/htdocs/big2.txt");

        //// delete the file
        //client.DeleteFile("/htdocs/big2.txt");

        //// delete a folder recursively
        //client.DeleteDirectory("/" + "htdocs/extras" + "/");

        //// check if a file exists
        //if (client.FileExists("/htdocs/big2.txt")) { }

        //client.CreateDirectory("/" + "htdocs/extras" + "/");

        //// upload a file and retry 3 times before giving up
        //client.RetryAttempts = 3;
        //client.UploadFile(@"C:\MyVideo.mp4", "/htdocs/big.txt", FtpRemoteExists.Overwrite, false, FtpVerify.Retry);

        //// disconnect! good bye!
        //client.Disconnect();

    }

    public override void Connect()
    {

        #region https://github.com/robinrodricks/FluentFTP/wiki/Quick-Start-Example.
        // Dont forget call Dispose() in calling class
        client = new FtpClient(remoteHost, remotePort, new FtpConfig() { });// remoteUser, remotePass);
        //client.EncryptionMode = FtpEncryptionMode.Auto;
        //client.ValidateAnyCertificate = true;
        client.Connect();

        adds.client = client;
        #endregion

        #region Toto jsem zkoušel nejdřív sám
        //// if you don't specify login credentials, we use the "anonymous" user account
        //client.Credentials = new NetworkCredential(remoteUser, remotePass);

        //// begin connecting to the server
        //client.EncryptionMode = FtpEncryptionMode.Auto;
        //client.ValidateAnyCertificate = true;

        //client.Connect();
        #endregion
    }

    #region Other


    public override void CreateDirectoryIfNotExists(string dirName)
    {
        // check if a folder exists
        if (!client.DirectoryExists(dirName))
        {
            client.CreateDirectory(dirName);
        }
    }



    public override bool deleteRemoteFile(string fileName)
    {
        ThrowEx.NotImplementedMethod();
        return false;
    }

    public override bool download(string remFileName, string locFileName, bool deleteLocalIfExists)
    {
        ThrowEx.NotImplementedMethod();
        return false;
    }

    public override long getFileSize(string filename)
    {
        ThrowEx.NotImplementedMethod();
        return 0;
    }

    public override Dictionary<string, List<string>> getFSEntriesListRecursively(List<string> slozkyNeuploadovatAVS)
    {
        ThrowEx.NotImplementedMethod();
        return null;
    }

    string wd = null;

    /// <summary>
    /// Ve FluentFTP toto není třeba.
    /// </summary>
    /// <param name="slozkaNaHostingu"></param>
    public override void goToPath(string slozkaNaHostingu)
    {
        if (!slozkaNaHostingu.StartsWith(AllStrings.slash))
        {
            slozkaNaHostingu = AllStrings.slash + slozkaNaHostingu;
        }

        wd = slozkaNaHostingu;
        client.SetWorkingDirectory(slozkaNaHostingu);
        //ThrowEx.NotImplementedMethod();
    }

    public override void goToUpFolder()
    {
        ThrowEx.NotImplementedMethod();
    }

    public override void goToUpFolderForce()
    {
        ThrowEx.NotImplementedMethod();
    }

    public override List<string> ListDirectoryDetails()
    {
        return null;

        //string listCmd = null;
        //bool machineList = false;
        //client.CalculateGetListingCommand(wd, FtpListOption.AllFiles, out listCmd, out machineList);
        //var ftpListItem = client.GetListingInternal(listCmd, FtpListOption.AllFiles, true);
        //return ftpListItem;




        // TS return always the same regardless to FtpListing
        //var ts = ftpListItem[0].ToString();

        //Return dirs and files - but only names. It cant be changed.
        //var result = client.GetNameListing(wd);
        //return result.ToList();
    }

    public override void LoginIfIsNot(bool startup)
    {
        ThrowEx.NotImplementedMethod();
    }

    public override bool mkdir(string dirName)
    {
        ThrowEx.NotImplementedMethod();
        return false;
    }

    public override void renameRemoteFile(string oldFileName, string newFileName)
    {
        ThrowEx.NotImplementedMethod();
    }

    public override bool rmdir(List<string> slozkyNeuploadovatAVS, string dirName)
    {
        ThrowEx.NotImplementedMethod();
        return false;
    }
    #endregion

    public override void DebugDirChmod(string dir)
    {
        //ConsoleLogger.Instance.WriteLine(client.GetChmod(dir).ToString());
        //client.Chmod(dir, 777)
    }

    #region Other
    public override void DeleteRecursively(List<string> slozkyNeuploadovatAVS, string dirName, int i, List<DirectoriesToDeleteFluentFtp> td)
    {
        ThrowEx.NotImplementedMethod();
    }


    /// <summary>
    /// Must be here due to interface
    /// </summary>
    /// <param name="dirName"></param>
    public override void chdirLite(string dirName)
    {
        ThrowEx.NotImplementedMethod();
    }

    public override
#if ASYNC
async Task
#else
void
#endif
UploadFile(string path)
    {
        client.UploadBytes(
#if ASYNC
await
#endif
TFSE.ReadAllBytesArray(path), Path.GetFileName(path), FtpRemoteExists.Overwrite);
    }


    // IDisposable tu být nemůže - jelikož je v _sunamo, musí být internal
    // proto je zde internal
    public override void Dispose()
    {
        client.Dispose();
    }


    #endregion
}
