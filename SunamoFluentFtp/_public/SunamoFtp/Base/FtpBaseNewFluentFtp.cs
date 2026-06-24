namespace SunamoFluentFtp._public.SunamoFtp.Base;

// IDisposable cannot be here - since it is in _sunamo, it must be internal
public abstract class FtpBaseNewFluentFtp : FtpAbstractFluentFtp
{
    public abstract void DebugAllEntries();

    public abstract void DebugDirChmod(string directory);

    public abstract void Dispose();

    public abstract
    Task
    UploadFile(string path);
}
