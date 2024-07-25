using System.Globalization;

namespace MauiControlDemo;

public partial class MauiControl : ContentView, IValueConverter
{
	public static BindableProperty AppearanceProperty = BindableProperty.Create(nameof(Appearance), typeof(string), typeof(MauiControl), "label");
	public string Appearance
	{
        get => (string)GetValue(AppearanceProperty);
        set => SetValue(AppearanceProperty, value);
    }

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

    public event EventHandler Clicked;

    public Command InternalClickedCommand { get; }

	public MauiControl()
	{
        InternalClickedCommand = new Command(() => Clicked?.Invoke(this, EventArgs.Empty));

		InitializeComponent();

		SetBinding(ControlTemplateProperty, new Binding(nameof(Appearance), converter: this, source: this));
	}

    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value == null)
        {
            return null;
        }

        if (value is string appearance)
        {
            if (Resources.TryGetValue(appearance, out object resource))
            {
                if (resource is ControlTemplate controlTemplate)
                {
                    return controlTemplate;
                }
            }
        }

        return null;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }
}