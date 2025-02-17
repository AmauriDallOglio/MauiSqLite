using MauiSqLite.App.Pagina.Tarefas;
using MauiSqLite.Dominio.Interface;
using MauiSqLite.Infra.Contexto;
using MauiSqLite.Infra.Repositorio;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MauiSqLite.App
{
    public static class MauiProgram
    {
        public static string databasePath = string.Empty;
        public static MauiApp CreateMauiApp()
        {

            var builder = MauiApp.CreateBuilder();

            builder
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                });

            #if DEBUG
                builder.Logging.AddDebug();
            #endif


            databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Usuarios.db");
            builder.Services.AddDbContext<MeuContexto>(options =>
            {
                options.UseSqlite($"Filename={databasePath}");
            });

 
            builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();
            builder.Services.AddScoped<ITarefaRepositorio, TarefaRepositorio>();


            builder.Services.AddTransient<MainPage>();


            var mauiApp = builder.Build();

            BancoDeDados(mauiApp.Services);
            Repostorio(mauiApp.Services);

            return mauiApp;

        }

        /// <summary>
        /// Garante que o banco de dados seja criado se não existir.
        /// </summary>
        private static void BancoDeDados(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var contexto = scope.ServiceProvider.GetRequiredService<MeuContexto>();

                ////// Exclui o arquivo do banco de dados se existir
                //if (File.Exists(databasePath))
                //{
                //    File.Delete(databasePath); // Apaga o banco de dados existente
                //}

                // Cria o banco de dados se ele não existir
                if (!File.Exists(databasePath))
                {
                    contexto.Database.EnsureCreated();
                }

            }
        }

        private static void Repostorio(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var contexto = scope.ServiceProvider.GetRequiredService<MeuContexto>();
                var usuarioRepositorio = scope.ServiceProvider.GetRequiredService<IUsuarioRepositorio>();

            }
        }

    }
}
