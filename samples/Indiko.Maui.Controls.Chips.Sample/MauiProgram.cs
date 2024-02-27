using CommunityToolkit.Maui;
using Indiko.Maui.Controls.Chips.Sample.Services;
using Indiko.Maui.Controls.Chips.Sample.ViewModels;

namespace Indiko.Maui.Controls.Chips.Sample;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
		builder.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			})
			.UseMauiCommunityToolkit()
			.UseChipsView();

        builder.Services.AddSingleton<INavigationService, NavigationService>();
        builder.Services.AddSingletonWithShellRoute<MainPage, MainPageViewModel>(nameof(MainPage));

		return builder.Build();
    }
}