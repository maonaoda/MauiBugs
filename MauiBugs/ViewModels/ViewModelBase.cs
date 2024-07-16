
namespace MauiBugs.ViewModels;

#nullable disable
public class ViewModelBase : BindableBase, IInitializeAsync, INavigationAware, IDestructible, IActiveAware, IApplicationLifecycleAware
{
    public bool IsActive
    {
        get { return _isActive; }
        set { SetProperty(ref _isActive, value, RaiseIsActiveChanged); }
    }
    private bool _isActive;

    protected virtual void RaiseIsActiveChanged()
    {
        IsActiveChanged?.Invoke(this, EventArgs.Empty);
    }

    public event EventHandler IsActiveChanged;

    public virtual void Destroy()
    {

    }

    public virtual Task InitializeAsync(INavigationParameters parameters)
    {
        return Task.CompletedTask;
    }

    public virtual void OnNavigatedFrom(INavigationParameters parameters)
    {

    }

    public virtual void OnNavigatedTo(INavigationParameters parameters)
    {

    }

    public virtual void OnResume()
    {

    }

    public virtual void OnSleep()
    {

    }
}