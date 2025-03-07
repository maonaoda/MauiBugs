using CommunityToolkit.Mvvm.ComponentModel;

namespace MauiBugs.ViewModels;

public partial class MainPageViewModel : ObservableObject
{
	[ObservableProperty]
	private List<string>? _items;

	[ObservableProperty]
	public bool _showCollectionView;
}