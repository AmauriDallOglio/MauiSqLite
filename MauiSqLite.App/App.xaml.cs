using MauiSqLite.App.Contexto;
using MauiSqLite.App.Repositorio;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace MauiSqLite.App
{
    public partial class App : Application
    {

        public static IUsuarioRepositorio AppIUsuarioRepositorio { get; private set; }
        public static MeuContexto AppMeuContexto { get; private set; }
        public static string AppDatabasePath = string.Empty;

        public App()
        {
            try
            {
                InitializeComponent();


                var serviceProvider = new ServiceCollection()
                    .AddDbContext<MeuContexto>(options =>
                    {
                        AppDatabasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Usuarios.db");
                        options.UseSqlite($"Filename={AppDatabasePath}");
                    })
                    .AddScoped<IUsuarioRepositorio, UsuarioRepositorio>() // Certifique-se de registrar seu repositório
                    .BuildServiceProvider();

                //// Exclui o arquivo do banco de dados se existir
                if (File.Exists(AppDatabasePath) && 1 == 2)
                {
                    File.Delete(AppDatabasePath); // Apaga o banco de dados existente
                }

                // Inicializa o contexto do banco de dados
                AppMeuContexto = serviceProvider.GetService<MeuContexto>();
                AppIUsuarioRepositorio = serviceProvider.GetService<IUsuarioRepositorio>();

                if (!File.Exists(AppDatabasePath))
                {
                    // Cria o banco de dados
                    AppMeuContexto.Database.EnsureCreated();
                }
                // Inicializa o repositório de usuários
                AppIUsuarioRepositorio = new UsuarioRepositorio(AppMeuContexto);

 



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
