using R3;

namespace MauiBugs.ViewModels;

public class BugPage
{
    public string Name { get; set; }

    public string BugId { get; set; }
}

public class MainPageViewModel : ViewModelBase
{
    public BindableReactiveProperty<List<BugPage>> BugPages { get; }
    public ReactiveCommand<string> TapCommand { get; }

    public MainPageViewModel(INavigationService navigationService) : base()
    {
        BugPages = new BindableReactiveProperty<List<BugPage>>([]);

        TapCommand = new ReactiveCommand<string>();
        TapCommand.SubscribeAwait(async (x, ct) =>
        {
            await navigationService.NavigateAsync(x);
        }, AwaitOperation.Drop);
    }

    public override Task InitializeAsync(INavigationParameters parameters)
    {
        BugPages.Value =
        [
            new()
            {
                Name = nameof(BorderRender),
                BugId = "22897",
            }
        ];

        return base.InitializeAsync(parameters);
    }
}