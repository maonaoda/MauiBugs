using MauiBugs.ViewModels;
using Microsoft.Extensions.Logging;
using Prism.Controls;
using DotNet.Meteor.HotReload.Plugin;

namespace MauiBugs;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.UsePrism(DryIocContainerExtension.DefaultRules.WithUseInterpretation(), prism =>
			{
				prism.RegisterTypes(containerRegistry =>
				{
					containerRegistry
						.Register<PrismNavigationPage>(() => new PrismNavigationPage())
						.RegisterInstance(new ViewRegistration
						{
							Name = nameof(PrismNavigationPage),
							View = typeof(PrismNavigationPage),
							Type = ViewType.Page
						});
					containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
					containerRegistry.RegisterForNavigation<BorderRender, BorderRenderViewModel>();
				})
				.CreateWindow(async (container, navigationService) =>
				{
					await navigationService.NavigateAsync($"/{nameof(PrismNavigationPage)}/{nameof(MainPage)}");
				});
			})
#if DEBUG
            .EnableHotReload()
#endif
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

#if DEBUG
		builder.Logging.AddDebug();
#endif

		return builder.Build();
	}
}
