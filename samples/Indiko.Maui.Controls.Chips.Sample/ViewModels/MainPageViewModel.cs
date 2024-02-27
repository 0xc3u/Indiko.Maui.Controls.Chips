using CommunityToolkit.Mvvm.ComponentModel;
using Indiko.Maui.Controls.Chips.Models;
using Indiko.Maui.Controls.Chips.Sample.Services;
using System.Collections.ObjectModel;

namespace Indiko.Maui.Controls.Chips.Sample.ViewModels;
public partial class MainPageViewModel : BaseViewModel
{
    public MainPageViewModel(INavigationService navigationService) : base(navigationService)
	{
	}

    [ObservableProperty]
    ObservableCollection<ChipItem> chips;


    public override async void OnAppearing(object param)
	{
        Chips =
        [
            new ChipItem{ Text ="Custom Icons", IsSelectedable = true,
                            IsCloseable = true, Icon = "house.svg", CloseIcon = "close.svg", BackgroundColor=Colors.LightGray,
                            SelectedBackgroundColor=Colors.DarkGray, TextColor=Colors.Black},
            new ChipItem{ Text ="Custom Icon, No Close", IsSelectedable = true, IsCloseable = false, Icon ="user.svg", BackgroundColor=Colors.LightGray, SelectedBackgroundColor=Colors.DarkGray, TextColor=Colors.Black},
            new ChipItem{ Text ="Default Close", IsSelectedable = true, IsCloseable = true, BackgroundColor=Colors.DarkViolet, SelectedBackgroundColor=Colors.DarkViolet, TextColor=Colors.White},
            new ChipItem{ Text ="Disabled", IsDisabled = true, IsCloseable = false, BackgroundColor=Colors.LightGrey, SelectedBackgroundColor=Colors.Grey, DisabledBackgroundColor=Colors.LightGrey,  TextColor=Colors.Grey},
            new ChipItem{ Text ="#MAUI", IsDisabled = true, IsCloseable = false, BackgroundColor=Colors.DarkSlateBlue, TextColor=Colors.White},
            new ChipItem{ Text ="#DOTNET", IsDisabled = true, IsCloseable = false, BackgroundColor=Colors.DarkSlateBlue, TextColor=Colors.White},
            new ChipItem{ Text ="#AWESOME", IsDisabled = true, IsCloseable = false, BackgroundColor=Colors.DarkSlateBlue, TextColor=Colors.White},
        ];
    }
}
