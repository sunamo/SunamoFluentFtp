namespace SunamoFluentFtp._sunamo.SunamoFtp.Base;


internal abstract class FtpAbstract
{
    #region Variables

    /// <summary>
    /// Je internal jen kvůli třídě Ftp
    /// </summary>
    internal PathSelector ps = null;
    /// <summary>
    /// Vzdálený hostitel
    /// </summary>
    internal string remoteHost;
    /// <summary>
    /// Uživatel který se pokouší přihlásit - používá se s příkazem USER
    /// </summary>
    internal string remoteUser;
    /// <summary>
    /// Heslo uživatele který se pokouší autentizovat. Posílá se s příkazem PASS
    /// </summary>F
    internal string remotePass;
    /// <summary>
    /// 
    /// </summary>
    internal int remotePort;
    internal bool logined;
    /// <summary>
    /// Pokud bude nastaveno na false, nebude se uploadovat na hosting nic - používá se pouze v této třídě, proto všechno ostatní bude fungovat normálně
    /// </summary>
    internal bool reallyUpload = true;
    /// <summary>
    /// Počet výjimek u jedné operace. Ideální pro to aby napočítalo do 3 a pak celou operaci zrušilo
    /// </summary>
    protected int pocetExc = 0;
    protected int maxPocetExc = 3;
    protected bool startup = true;
    internal ulong folderSizeRec = 0;
    #endregion
    #region Set variables methods
    /// <summary>
    /// S PP remoteHost A1
    /// </summary>
    /// <param name="remoteHost"></param>
    internal void setRemoteHost(string remoteHost)
    {
        this.remoteHost = remoteHost;
    }
    /// <summary>
    /// G adresu vzdáleného hostitele
    /// </summary>
    internal string getRemoteHost()
    {
        return remoteHost;
    }
    /// <summary>
    /// S PP remotePort A1
    /// </summary>
    /// <param name="remotePort"></param>
    internal void setRemotePort(int remotePort)
    {
        this.remotePort = remotePort;
    }
    /// <summary>
    /// G port který se používá pro vzdálený přenos
    /// </summary>
    internal int getRemotePort()
    {
        return remotePort;
    }
    /// <summary>
    /// S PP remoteUser A1
    /// </summary>
    /// <param name="remoteUser"></param>
    internal void setRemoteUser(string remoteUser)
    {
        this.remoteUser = remoteUser;
    }
    /// <summary>
    /// S PP remotePass A1
    /// </summary>
    /// <param name="remotePass"></param>
    internal void setRemotePass(string remotePass)
    {
        this.remotePass = remotePass;
    }
    #endregion
    internal abstract void Connect();
    internal abstract void D(string what, string text, params object[] args);
    internal abstract void DebugActualFolder();
    #region Abstract methods
    internal abstract bool mkdir(string dirName);
    internal abstract bool download(string remFileName, string locFileName, bool deleteLocalIfExists);
    internal abstract bool deleteRemoteFile(string fileName);
    internal abstract void renameRemoteFile(string oldFileName, string newFileName);
    internal abstract bool rmdir(List<string> slozkyNeuploadovatAVS, string dirName);
    internal abstract void DeleteRecursively(List<string> slozkyNeuploadovatAVS, string dirName, int i, List<DirectoriesToDelete> td);
    internal abstract void CreateDirectoryIfNotExists(string dirName);
    internal abstract List<string> ListDirectoryDetails();
    internal abstract Dictionary<string, List<string>> getFSEntriesListRecursively(List<string> slozkyNeuploadovatAVS);
    internal abstract void chdirLite(string dirName);
    internal abstract void goToUpFolderForce();
    internal abstract void goToUpFolder();
    internal abstract void LoginIfIsNot(bool startup);
    internal abstract long getFileSize(string filename);
    internal abstract void goToPath(string slozkaNaHostingu);
    #endregion
}