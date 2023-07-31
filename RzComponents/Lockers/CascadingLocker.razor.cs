namespace RzComponents;

//=========================================
public interface ICascadingLocker
{
    void Lock();

    void Unlock();
}

//=========================================
public partial class CascadingLocker : ICascadingLocker
{
    public void Lock()
    {
        maskRef?.RefreshView(true);
    }

    public void Unlock()
    {
        maskRef?.RefreshView(false);
    }


}

