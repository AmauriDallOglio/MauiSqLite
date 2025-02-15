using MauiSqLite.Dominio.Interface;
using MauiSqLite.Infra.Contexto;
using System.Diagnostics;

namespace MauiSqLite.App
{
    public partial class App : Application
    {

        //private readonly IServiceProvider _serviceProvider;
        //public static string AppDatabasePath = string.Empty;
        //public static IUsuarioRepositorio AppIUsuarioRepositorio => Current.Handler?.MauiContext?.Services.GetService<IUsuarioRepositorio>();
        //public static ITarefaRepositorio TarefaRepositorio => Current.Handler?.MauiContext?.Services.GetService<ITarefaRepositorio>();
        //public static MeuContexto AppMeuContexto => Current.Handler?.MauiContext?.Services.GetService<MeuContexto>();
        //public App(IServiceProvider serviceProvider)
        //{
        //    try
        //    {
        //        InitializeComponent();
        //        AppDatabasePath = Path.Combine(FileSystem.AppDataDirectory, "app.db");
        //        _serviceProvider = serviceProvider;

        //        MainPage = new AppShell();
        //    }
        //    catch (XamlParseException ex)
        //    {
        //        Debug.WriteLine($"XAML Parse Error: {ex.Message}");
        //        Debug.WriteLine($"Inner Exception: {ex.InnerException?.Message}");
        //    }
        //}



        public static IUsuarioRepositorio AppIUsuarioRepositorio { get; private set; }
        public static ITarefaRepositorio AppITarefaRepositorio { get; private set; }
        public static MeuContexto AppMeuContexto { get; private set; }
        public static string AppDatabasePath = string.Empty;

        public App(IServiceProvider serviceProvider)
        {
            try
            {
                InitializeComponent();

                AppDatabasePath = Path.Combine(FileSystem.AppDataDirectory, "app.db");

                AppMeuContexto = serviceProvider.GetRequiredService<MeuContexto>();
                AppIUsuarioRepositorio = serviceProvider.GetRequiredService<IUsuarioRepositorio>();
                AppITarefaRepositorio = serviceProvider.GetRequiredService<ITarefaRepositorio>();

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
