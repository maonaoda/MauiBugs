using CommunityToolkit.Mvvm.ComponentModel;

namespace MauiBugs;

public partial class MainPage : ContentPage
{
	private MainPageViewModel _vm;

	public MainPage()
	{
		InitializeComponent();

        _vm = new MainPageViewModel
        {
            ShowCollectionView = false
        };
        BindingContext = _vm;
	}

	private void Button_Clicked(object sender, EventArgs e)
	{
		if (!_vm.ShowCollectionView)
		{
			_vm.Items = new List<string> { "Item 1", "Item 2", "Item 3" };
		}

		_vm.ShowCollectionView = !_vm.ShowCollectionView;
	}
}

public partial class MainPageViewModel : ObservableObject
{
	[ObservableProperty]
	private List<string>? _items;

	[ObservableProperty]
	public bool _showCollectionView;
}