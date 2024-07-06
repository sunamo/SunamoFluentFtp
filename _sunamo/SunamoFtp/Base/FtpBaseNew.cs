namespace SunamoFluentFtp._sunamo.SunamoFtp.Base;


/// <summary>
/// IDisposable tu být nemůže - jelikož je v _sunamo, musí být internal
/// </summary>
internal abstract class FtpBaseNew : FtpAbstract//, IDisposable
{
    internal abstract void DebugAllEntries();
    internal abstract void DebugDirChmod(string dir);
    internal abstract void Dispose();
    internal abstract
#if ASYNC
 Task
#else
void  
#endif
UploadFile(string path);
}