using System.Windows.Input;

namespace Indiko.Maui.Controls.Chips.Models;

public class ChipItem : BindableObject
{
    // Text
    public static readonly BindableProperty TextProperty =
        BindableProperty.Create(nameof(Text), typeof(string), typeof(ChipItem));
    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    // TextColor
    public static readonly BindableProperty TextColorProperty =
        BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(ChipItem), defaultValue: Colors.White);
    public Color TextColor
    {
        get => (Color)GetValue(TextColorProperty);
        set => SetValue(TextColorProperty, value);
    }

    public static readonly BindableProperty SelectedTextColorProperty =
        BindableProperty.Create(nameof(SelectedTextColor), typeof(Color), typeof(ChipItem), defaultValue: Colors.Black);
    public Color SelectedTextColor
    {
        get => (Color)GetValue(SelectedTextColorProperty);
        set => SetValue(SelectedTextColorProperty, value);
    }

    public static readonly BindableProperty BackgroundColorProperty =
       BindableProperty.Create(nameof(BackgroundColor), typeof(Color), typeof(ChipItem), defaultValue: Colors.CornflowerBlue);
    public Color BackgroundColor
    {
        get => (Color)GetValue(BackgroundColorProperty);
        set => SetValue(BackgroundColorProperty, value);
    }

    public static readonly BindableProperty SelectedBackgroundColorProperty =
       BindableProperty.Create(nameof(SelectedBackgroundColor), typeof(Color), typeof(ChipItem), defaultValue: Colors.CornflowerBlue);
    public Color SelectedBackgroundColor
    {
        get => (Color)GetValue(SelectedBackgroundColorProperty);
        set => SetValue(SelectedBackgroundColorProperty, value);
    }

    public static readonly BindableProperty DisabledBackgroundColorProperty =
      BindableProperty.Create(nameof(DisabledBackgroundColor), typeof(Color), typeof(ChipItem), defaultValue: Colors.CornflowerBlue);
    public Color DisabledBackgroundColor
    {
        get => (Color)GetValue(DisabledBackgroundColorProperty);
        set => SetValue(DisabledBackgroundColorProperty, value);
    }

    // CornerRadius
    public static readonly BindableProperty CornerRadiusProperty =
        BindableProperty.Create(nameof(CornerRadius), typeof(float), typeof(ChipItem), defaultValue: 6f);
    public float CornerRadius
    {
        get => (float)GetValue(CornerRadiusProperty);
        set => SetValue(CornerRadiusProperty, value);
    }

    public static readonly BindableProperty BorderColorProperty =
      BindableProperty.Create(nameof(BorderColor), typeof(Color), typeof(ChipItem), defaultValue: Colors.DarkBlue);
    public Color BorderColor
    {
        get => (Color)GetValue(BorderColorProperty);
        set => SetValue(BorderColorProperty, value);
    }

    public static readonly BindableProperty BorderSizeProperty =
        BindableProperty.Create(nameof(BorderSize), typeof(float), typeof(ChipItem), defaultValue: 2f);
    public float BorderSize
    {
        get => (float)GetValue(BorderSizeProperty);
        set => SetValue(BorderSizeProperty, value);
    }

    // FontSize

    public static readonly BindableProperty FontSizeProperty =
        BindableProperty.Create(nameof(FontSize), typeof(double), typeof(ChipItem), defaultValue: 18d);

    [System.ComponentModel.TypeConverter(typeof(FontSizeConverter))]
    public double FontSize
    {
        get => (double)GetValue(FontSizeProperty);
        set => SetValue(FontSizeProperty, value);
    }

    // Icon
    public static readonly BindableProperty IconProperty =
        BindableProperty.Create(nameof(Icon), typeof(ImageSource), typeof(ChipItem));
    public ImageSource Icon
    {
        get => (ImageSource)GetValue(IconProperty);
        set => SetValue(IconProperty, value);
    }

    // Close Icon
    public static readonly BindableProperty CloseIconProperty =
        BindableProperty.Create(nameof(CloseIcon), typeof(ImageSource), typeof(ChipItem));
    public ImageSource CloseIcon
    {
        get => (ImageSource)GetValue(CloseIconProperty);
        set => SetValue(CloseIconProperty, value);
    }

    // IsDisabled
    public static readonly BindableProperty IsDisabledProperty =
        BindableProperty.Create(nameof(IsDisabled), typeof(bool), typeof(ChipItem), defaultValue: false);
    public bool IsDisabled
    {
        get => (bool)GetValue(IsDisabledProperty);
        set => SetValue(IsDisabledProperty, value);
    }

    // IsCloseable
    public static readonly BindableProperty IsCloseableProperty =
        BindableProperty.Create(nameof(IsCloseable), typeof(bool), typeof(ChipItem), defaultValue: true);
    public bool IsCloseable
    {
        get => (bool)GetValue(IsCloseableProperty);
        set => SetValue(IsCloseableProperty, value);
    }

    // IsSelectedableProperty
    public static readonly BindableProperty IsSelectedableProperty =
        BindableProperty.Create(nameof(IsSelectedable), typeof(bool), typeof(ChipItem), defaultValue: true);
    public bool IsSelectedable
    {
        get => (bool)GetValue(IsSelectedableProperty);
        set => SetValue(IsSelectedableProperty, value);
    }

    // IsSelected
    public static readonly BindableProperty IsSelectedProperty =
        BindableProperty.Create(nameof(IsSelected), typeof(bool), typeof(ChipItem), defaultValue: false);
    public bool IsSelected
    {
        get => (bool)GetValue(IsSelectedProperty);
        set => SetValue(IsSelectedProperty, value);
    }

    // TabCommand
    public static readonly BindableProperty TabCommandProperty =
        BindableProperty.Create(nameof(TabCommand), typeof(ICommand), typeof(ChipItem));
    public ICommand TabCommand
    {
        get => (ICommand)GetValue(TabCommandProperty);
        set => SetValue(TabCommandProperty, value);
    }

    public static readonly BindableProperty TabCommandParameterProperty =
        BindableProperty.Create(nameof(TabCommandParameter), typeof(object), typeof(ChipItem));
    public object TabCommandParameter
    {
        get => GetValue(TabCommandParameterProperty);
        set => SetValue(TabCommandParameterProperty, value);
    }

    // SelectCommand
    public static readonly BindableProperty SelectCommandProperty =
        BindableProperty.Create(nameof(SelectCommand), typeof(ICommand), typeof(ChipItem));
    public ICommand SelectCommand
    {
        get => (ICommand)GetValue(SelectCommandProperty);
        set => SetValue(SelectCommandProperty, value);
    }

    public static readonly BindableProperty SelectCommandParameterProperty =
       BindableProperty.Create(nameof(SelectCommandParameter), typeof(object), typeof(ChipItem));
    public object SelectCommandParameter
    {
        get => GetValue(SelectCommandParameterProperty);
        set => SetValue(SelectCommandParameterProperty, value);
    }


    public static readonly BindableProperty UnSelectCommandProperty =
       BindableProperty.Create(nameof(UnSelectCommand), typeof(ICommand), typeof(ChipItem));
    public ICommand UnSelectCommand
    {
        get => (ICommand)GetValue(UnSelectCommandProperty);
        set => SetValue(UnSelectCommandProperty, value);
    }

    public static readonly BindableProperty UnSelectCommandParameterProperty =
       BindableProperty.Create(nameof(UnSelectCommandParameter), typeof(object), typeof(ChipItem));
    public object UnSelectCommandParameter
    {
        get => GetValue(UnSelectCommandParameterProperty);
        set => SetValue(UnSelectCommandParameterProperty, value);
    }


    // CloseCommand
    public static readonly BindableProperty CloseCommandProperty =
        BindableProperty.Create(nameof(CloseCommand), typeof(ICommand), typeof(ChipItem));
    public ICommand CloseCommand
    {
        get => (ICommand)GetValue(CloseCommandProperty);
        set => SetValue(CloseCommandProperty, value);
    }

    public static readonly BindableProperty CloseCommandParameterProperty =
       BindableProperty.Create(nameof(CloseCommandParameter), typeof(object), typeof(ChipItem));
    public object CloseCommandParameter
    {
        get => GetValue(CloseCommandParameterProperty);
        set => SetValue(CloseCommandParameterProperty, value);
    }

}