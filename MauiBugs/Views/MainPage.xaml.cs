using MauiBugs.ViewModels;

namespace MauiBugs.Views;

public partial class MainPage : ContentPage
{
	private readonly MainPageViewModel _vm;

	public MainPage(MainPageViewModel vm)
	{
		InitializeComponent();

		_vm = vm;
		BindingContext = _vm;
	}

	private void Button_Clicked(object sender, EventArgs e)
	{
		if (!_vm.ShowCollectionView)
		{
			_vm.Items = ["Item 1", "Item 2", "Item 3"];
		}

		_vm.ShowCollectionView = !_vm.ShowCollectionView;
	}
}