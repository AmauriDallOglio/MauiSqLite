using MauiSqLite.App.Contexto;
using MauiSqLite.App.Repositorio;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;

namespace MauiSqLite.App
{
    public partial class App : Application
    {

        // Propriedade para o repositório de usuários
        public static IUsuarioRepositorio _iUsuarioRepositorio { get; private set; }

        // Propriedade para o contexto de banco de dados
        public static MeuContexto _meuContexto { get; private set; }


        public static IUsuarioRepositorio UsuarioRepositorio { get; private set; }
        public static MeuContexto DbContext { get; private set; }

        public App()
        {
            try
            {
                InitializeComponent();

                // Configuração dos serviços
                var serviceProvider = new ServiceCollection()
                    .AddDbContext<MeuContexto>(options =>
                    {
                        string databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Usuarios.db");
                        options.UseSqlite($"Filename={databasePath}");
                    })
                    .AddScoped<IUsuarioRepositorio, UsuarioRepositorio>() // Certifique-se de registrar seu repositório
                    .BuildServiceProvider();

                // Inicializa o contexto do banco de dados
                DbContext = serviceProvider.GetService<MeuContexto>();
                UsuarioRepositorio = serviceProvider.GetService<IUsuarioRepositorio>();



                // Define o caminho para o arquivo SQLite no diretório de dados local da aplicação
                string databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Usuarios.db");
                ////// Exclui o arquivo do banco de dados se existir
                //if (File.Exists(databasePath))
                //{
                //    File.Delete(databasePath); // Apaga o banco de dados existente
                //}
                if (!File.Exists(databasePath))
                {
                    // Cria e configura o contexto do banco de dados
                    _meuContexto = serviceProvider.GetService<MeuContexto>();

                    // Cria o banco de dados
                    _meuContexto.Database.EnsureCreated();
                }
                // Inicializa o repositório de usuários
                _iUsuarioRepositorio = new UsuarioRepositorio(_meuContexto);

 



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
