using System.Globalization;

namespace MauiControlDemo;

public partial class CustomContentView : ContentView
{
    public static BindableProperty AppearanceProperty = BindableProperty.Create(nameof(Appearance), typeof(string), typeof(CustomContentView));
    public string Appearance
    {
        get => (string)GetValue(AppearanceProperty);
        set => SetValue(AppearanceProperty, value);
    }

    public CustomContentView()
	{
		InitializeComponent();
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