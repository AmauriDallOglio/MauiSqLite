using System.Diagnostics;

namespace MauiSqLite.App
{
    public partial class App : Application
    {

        public App()
        {
            try
            {
                InitializeComponent();
                MainPage = new AppShell();
            }
            catch (XamlParseException ex)
            {
                Debug.WriteLine($"XAML Parse Error: {ex.Message}");
                Debug.WriteLine($"Inner Exception: {ex.InnerException?.Message}");
            }
        }

    }
}
