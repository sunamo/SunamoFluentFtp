namespace SunamoFluentFtp._sunamo.SunamoFtp.Base;


internal abstract class FtpBaseNew : FtpAbstract, IDisposable
{
    internal abstract void DebugAllEntries();
    internal abstract void DebugDirChmod(string dir);
    public abstract void Dispose();
    internal abstract
#if ASYNC
 Task
#else
void  
#endif
UploadFile(string path);
}