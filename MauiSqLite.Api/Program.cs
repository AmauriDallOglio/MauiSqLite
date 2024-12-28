using MauiSqLite.Dominio.Entidade;
using MauiSqLite.Dominio.Interface;
using MauiSqLite.Infra.Contexto;
using MauiSqLite.Infra.Repositorio;
using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace MauiSqLite.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);




            // string databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Usuarios.db");
            //string databasePath = "C:\\Users\\amaur\\AppData\\Local\\Usuarios.db";
            string databasePath = @"C:\Amauri\GitHub\MauiSqLite\MauiSqLite.Api\Usuarios.db";
            //string databasePath = "/data/user/0/com.companyname.mauisqlite.app/files/app.db";

            builder.Services.AddDbContext<MeuContexto>(options =>
            {
                options.UseSqlite($"Filename={databasePath}");
            });

 
            try
            {
                if (!File.Exists(databasePath))
                {
                    Console.WriteLine("O banco de dados não foi encontrado.");
                }
                else
                {
                    using var connection = new SqliteConnection($"Data Source={databasePath}");
                    connection.Open();

                
                    string countQuery = "SELECT COUNT(*) FROM Usuarios;";
                    using var countCommand = new SqliteCommand(countQuery, connection);
                    var count = (long)countCommand.ExecuteScalar(); 
                    Console.WriteLine($"Número de registros na tabela 'Usuario': {count}");

                    if (count == 0)
                    {
                 
                        string createTableQuery = @"
                            CREATE TABLE IF NOT EXISTS Usuario (
                                Id INTEGER PRIMARY KEY AUTOINCREMENT,
                                Nome TEXT NOT NULL,
                                Email TEXT NOT NULL,
                                Telefone TEXT,
                                DataNascimento TEXT,
                                DataCadastro TEXT,
                                Ativo INTEGER
                            );";
                        using var createTableCommand = new SqliteCommand(createTableQuery, connection);
                        createTableCommand.ExecuteNonQuery();
                        Console.WriteLine("Tabela 'Usuario' criada ou já existia.");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Erro: {ex.Message}");
            }



            // Registra o repositório
            builder.Services.AddScoped<IUsuarioRepositorio, UsuarioRepositorio>();




            builder.Services.AddControllers();
           
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();


            // Resolve a injeção de dependência e realiza operações no banco
            var serviceProvider = app.Services.CreateScope().ServiceProvider;
            var meuContexto = serviceProvider.GetRequiredService<MeuContexto>();
            var usuarioRepositorio = serviceProvider.GetRequiredService<IUsuarioRepositorio>();



            app.MapControllers();

            app.Run();
        }
    }
}
