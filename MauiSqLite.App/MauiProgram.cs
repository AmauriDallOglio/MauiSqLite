using MauiSqLite.Dominio.Interface;
using MauiSqLite.Infra.Contexto;
using MauiSqLite.Infra.Repositorio;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;

namespace MauiSqLite.App
{
    public static class MauiProgram
    {
        public static string AppDatabasePath = string.Empty;
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


            AppDatabasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Usuarios.db");
            builder.Services.AddDbContext<MeuContexto>(options =>
            {
                options.UseSqlite($"Filename={AppDatabasePath}");
            });

            builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();

            var mauiApp = builder.Build();

            BancoDeDados(mauiApp.Services);
            Repostorio(mauiApp.Services);

            return mauiApp;

        }

        private static void BancoDeDados(IServiceProvider serviceProvider)
        {
            using (var scope = serviceProvider.CreateScope())
            {
                var contexto = scope.ServiceProvider.GetRequiredService<MeuContexto>();

                ////// Exclui o arquivo do banco de dados se existir
                //if (File.Exists(AppDatabasePath) && 1 == 2)
                //{
                //    File.Delete(AppDatabasePath); // Apaga o banco de dados existente
                //}

                // Cria o banco de dados se ele não existir
                if (!File.Exists(AppDatabasePath))
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
