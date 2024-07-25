using System.Globalization;

namespace MauiControlDemo;

public partial class MauiControl : CustomContentView, IValueConverter
{
    public static BindableProperty BackgroundColorProperty = BindableProperty.Create(nameof(BackgroundColor), typeof(Color), typeof(MauiControl), Colors.Transparent);
    public Color BackgroundColor
    {
        get => (Color)GetValue(BackgroundColorProperty);
        set => SetValue(BackgroundColorProperty, value);
    }

    public static BindableProperty HorizontalTextAlignmentProperty = BindableProperty.Create(nameof(HorizontalTextAlignment), typeof(TextAlignment), typeof(MauiControl), TextAlignment.Start);
    public TextAlignment HorizontalTextAlignment
    {
        get => (TextAlignment)GetValue(HorizontalTextAlignmentProperty);
        set => SetValue(HorizontalTextAlignmentProperty, value);
    }

    public static BindableProperty FontFamilyProperty = BindableProperty.Create(nameof(FontFamily), typeof(string), typeof(MauiControl), String.Empty);
    public string FontFamily
    {
        get => (string)GetValue(FontFamilyProperty);
        set => SetValue(FontFamilyProperty, value);
    }

    public static BindableProperty FontSizeProperty = BindableProperty.Create(nameof(FontSize), typeof(double), typeof(MauiControl), 12.0);
    public double FontSize
    {
        get => (double)GetValue(FontSizeProperty);
        set => SetValue(FontSizeProperty, value);
    }

    public static BindableProperty TextProperty = BindableProperty.Create(nameof(Text), typeof(string), typeof(MauiControl), String.Empty, BindingMode.TwoWay);
    public string Text
    {
        get => (string)GetValue(TextProperty);
        set => SetValue(TextProperty, value);
    }

    public static BindableProperty TextColorProperty = BindableProperty.Create(nameof(TextColor), typeof(Color), typeof(MauiControl), Colors.Black);
    public Color TextColor
    {
        get => (Color)GetValue(TextColorProperty);
        set => SetValue(TextColorProperty, value);
    }

    public static BindableProperty TextValueProperty = BindableProperty.Create(nameof(TextValue), typeof(double), typeof(MauiControl), 0.0);
    public double TextValue
    {
        get => (double)GetValue(TextValueProperty);
        set => SetValue(TextValueProperty, value);
    }

    public event EventHandler Clicked;

    public Command InternalClickedCommand { get; }

    public MauiControl()
    {
        InternalClickedCommand = new Command(() => Clicked?.Invoke(this, EventArgs.Empty));

        InitializeComponent();

        PropertyChanged += MauiControl_PropertyChanged;
    }

    private async void MauiControl_PropertyChanged(object? sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        switch (e.PropertyName)
        {
            case nameof(TextValue):
                await Task.Delay(50);
                Text = TextValue.ToString();
                break;

            case nameof(Text):
                if (double.TryParse(Text, out double value))
                {
                    await Task.Delay(50);
                    TextValue = value;
                }
                break;
        }
    }
}