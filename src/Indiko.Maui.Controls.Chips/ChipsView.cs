using Indiko.Maui.Controls.Chips.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Indiko.Maui.Controls.Chips;

public class ChipsView : FlexLayout
{
    public static readonly BindableProperty ItemSourceProperty =
       BindableProperty.Create(nameof(ItemSource), typeof(ObservableCollection<ChipItem>), typeof(ChipsView), propertyChanged: OnItemSourceChanged);

    public ObservableCollection<ChipItem> ItemSource
    {
        get => (ObservableCollection<ChipItem>)GetValue(ItemSourceProperty);
        set => SetValue(ItemSourceProperty, value);
    }

    public static readonly BindableProperty SelectedItemsProperty =
      BindableProperty.Create(nameof(SelectedItems), typeof(ObservableCollection<ChipItem>), typeof(ChipsView));

    public ObservableCollection<ChipItem> SelectedItems
    {
        get => (ObservableCollection<ChipItem>)GetValue(SelectedItemsProperty);
        set => SetValue(SelectedItemsProperty, value);
    }

    public static readonly BindableProperty SizeProperty =
     BindableProperty.Create(nameof(Size), typeof(double), typeof(ChipsView), defaultValue: 25d);

    public double Size
    {
        get => (double)GetValue(SizeProperty);
        set => SetValue(SizeProperty, value);
    }

    public static readonly BindableProperty SpacingProperty =
    BindableProperty.Create(nameof(Spacing), typeof(double), typeof(ChipsView), defaultValue: 2d);

    public double Spacing
    {
        get => (double)GetValue(SpacingProperty);
        set => SetValue(SpacingProperty, value);
    }


    public ChipsView()
    {
        SelectedItems = [];
    }

    private static void OnItemSourceChanged(BindableObject bindable, object oldValue, object newValue)
    {
        var control = (ChipsView)bindable;
        var oldCollection = (ObservableCollection<ChipItem>)oldValue;
        var newCollection = (ObservableCollection<ChipItem>)newValue;

        if (oldCollection != null)
        {
            oldCollection.CollectionChanged -= control.OnCollectionChanged;
        }

        if (newCollection != null)
        {
            newCollection.CollectionChanged += control.OnCollectionChanged;
            control.BuildChips();
        }
    }

    private void OnCollectionChanged(object sender, System.Collections.Specialized.NotifyCollectionChangedEventArgs e)
    {
        BuildChips();
    }

    private void BuildChips()
    {
        Children.Clear();

        foreach (var chip in ItemSource)
        {
            var grid = new Grid
            {
                RowDefinitions = {
                    new RowDefinition {Height = Size}
                },
                ColumnSpacing = 10,
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center
            };

            if (chip.Icon != null || chip.IsCloseable)
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Auto });
            }
            else
            {
                grid.ColumnDefinitions.Add(new ColumnDefinition { Width = GridLength.Star });
            }

            var selectedTapGestureRecognizer = new TapGestureRecognizer();
            selectedTapGestureRecognizer.Tapped += (sender, args) =>
            {
                OnChipTapped(chip);
            };

            if (chip.Icon != null)
            {
                var icon = new Image
                {
                    Source = chip.Icon,
                    WidthRequest = 16,
                    HeightRequest = 16,
                    HorizontalOptions = LayoutOptions.Center,
                    VerticalOptions = LayoutOptions.Center
                };
                icon.GestureRecognizers.Add(selectedTapGestureRecognizer);
                Grid.SetColumn(icon, 0);
                grid.Children.Add(icon);
            }
            // Add text
            var label = new Label
            {
                Text = chip.Text,
                TextColor = chip.IsSelected ? chip.SelectedTextColor : chip.TextColor,
                FontSize = chip.FontSize,
                HorizontalOptions = LayoutOptions.Center,
                VerticalOptions = LayoutOptions.Center,
                HorizontalTextAlignment = TextAlignment.Start,
                VerticalTextAlignment = TextAlignment.Center,
                FontAttributes = chip.IsSelected ? FontAttributes.Bold : FontAttributes.None
            };
            label.GestureRecognizers.Add(selectedTapGestureRecognizer);

            if (chip.Icon != null)
            {
                Grid.SetColumn(label, 1);
            }
            else
            {
                if (chip.IsCloseable)
                {
                    Grid.SetColumn(label, 0);
                    Grid.SetColumnSpan(label, 2);
                }
                else
                {
                    Grid.SetColumn(label, 0);
                    Grid.SetColumnSpan(label, 1);
                }
            }

            grid.Children.Add(label);

            if (chip.IsCloseable)
            {
                var closeTapGestureRecognizer = new TapGestureRecognizer();
                closeTapGestureRecognizer.Tapped += (sender, args) =>
                {
                    if (chip.IsDisabled)
                        return;

                    chip.CloseCommand?.Execute(chip.CloseCommandParameter);
                    ItemSource.Remove(chip);
                };

                if (chip.CloseIcon != null)
                {
                    var closeIcon = new Image
                    {
                        Source = chip.CloseIcon,
                        WidthRequest = Math.Abs(Size / 2),
                        HeightRequest = Math.Abs(Size / 2),
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.Center,
                        Aspect = Aspect.AspectFit
                    };
                    closeIcon.GestureRecognizers.Add(closeTapGestureRecognizer);
                    Grid.SetColumn(closeIcon, 2);
                    grid.Children.Add(closeIcon);
                }
                else
                {
                    var closeView = new XSymbolView
                    {
                        LineColor = chip.IsSelected ? chip.SelectedTextColor : chip.TextColor,
                        WidthRequest = chip.FontSize,
                        HeightRequest = chip.FontSize,
                        HorizontalOptions = LayoutOptions.Center,
                        VerticalOptions = LayoutOptions.Center
                    };
                    closeView.GestureRecognizers.Add(closeTapGestureRecognizer);
                    Grid.SetColumn(closeView, 2);
                    grid.Children.Add(closeView);
                }
            }

            var chipFrame = new Frame
            {
                Content = grid,
                CornerRadius = chip.CornerRadius,
                BorderColor = chip.BorderColor,
                BackgroundColor = chip.IsSelected ? chip.SelectedBackgroundColor : chip.BackgroundColor,
                Margin = new Thickness(Spacing),
                Padding = new Thickness(5),
                HeightRequest = Size,
                HorizontalOptions = LayoutOptions.Start,
                VerticalOptions = LayoutOptions.Center,
                HasShadow = false
            };

            if (chip.IsDisabled)
            {
                chipFrame.BackgroundColor = chip.DisabledBackgroundColor;
            }

            Children.Add(chipFrame);
        }
    }

    private void OnChipTapped(ChipItem chip)
    {
        if (chip.IsDisabled)
            return;

        ICommand command;
        object param;
        if (chip.IsSelectedable)
        {
            chip.IsSelected = !chip.IsSelected;
            command = chip.IsSelected ? chip.SelectCommand : chip.UnSelectCommand;
            param = chip.IsSelected ? chip.SelectCommandParameter : chip.UnSelectCommandParameter;

            if (chip.IsSelected)
            {
                SelectedItems.Add(chip);
            }
            else
            {
                SelectedItems.Remove(chip);
            }
        }
        else
        {
            command = chip.TabCommand;
            param = chip.TabCommandParameter;
        }

        if (command != null)
        {
            if (command.CanExecute(param))
            {
                command.Execute(param);
            }
        }

        if (chip.IsSelectedable)
        {
            BuildChips();
        }
    }
}