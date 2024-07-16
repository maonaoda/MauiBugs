using System.Collections.Generic;
using System.ComponentModel;
using System.Threading.Tasks;
using R3;

namespace MauiBugs.ViewModels;

public class BorderRenderDto : INotifyPropertyChanged
{
    public string Name { get; set; }

    private bool _isFinished;
    public bool IsFinished
    {
        get => _isFinished;
        set
        {
            _isFinished = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsFinished)));
        }
    }

    public event PropertyChangedEventHandler PropertyChanged;
}

public class BorderRenderViewModel : ViewModelBase
{
    public BindableReactiveProperty<List<BorderRenderDto>> BorderRenderList { get; }
    public BorderRenderViewModel() : base()
    {
        BorderRenderList = new BindableReactiveProperty<List<BorderRenderDto>>([]);
    }

    public override Task InitializeAsync(INavigationParameters parameters)
    {
        var list = new List<BorderRenderDto>();
        for (int i = 1; i <= 20; i++)
        {
            list.Add(new BorderRenderDto
            {
                Name = $"{i}",
            });
        }

        BorderRenderList.Value = list;

        return base.InitializeAsync(parameters);
    }

    public override void OnNavigatedTo(INavigationParameters parameters)
    {
        BorderRenderList.Value.ForEach(borderRender => borderRender.IsFinished = Convert.ToInt32(borderRender.Name) % 2 == 0);
        base.OnNavigatedTo(parameters);
    }
}