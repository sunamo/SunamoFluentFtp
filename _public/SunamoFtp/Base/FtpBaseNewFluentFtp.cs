namespace SunamoFluentFtp._public.SunamoFtp.Base;


/// <summary>
/// IDisposable tu být nemůže - jelikož je v _sunamo, musí být internal
/// </summary>
public abstract class FtpBaseNewFluentFtp : FtpAbstractFluentFtp//, IDisposable
{
    public abstract void DebugAllEntries();
    public abstract void DebugDirChmod(string dir);
    public abstract void Dispose();
    public abstract
#if ASYNC
 Task
#else
void  
#endif
UploadFile(string path);
}