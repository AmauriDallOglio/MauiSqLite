using MauiSqLite.App.Mapeamento;
using MauiSqLite.App.Model;
using Microsoft.EntityFrameworkCore;

namespace MauiSqLite.App.Contexto
{
    public class MeuContexto : DbContext
    {
        public DbSet<UsuarioModel> UsuarioModel { get; set; }

        // Construtor que aceita DbContextOptions
        public MeuContexto(DbContextOptions<MeuContexto> options) : base(options)
        {
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured) // Verifica se o optionsBuilder já foi configurado
            {
                string databasePath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Usuarios.db");
                optionsBuilder.UseSqlite($"Filename={databasePath}");
            }


            //optionsBuilder.UseSqlite($"Filename={Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Usuarios.db")}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.Entity<UsuarioModel>().ToTable("Nomes");

            // Configura o mapeamento do modelo
            modelBuilder.ApplyConfiguration(new UsuarioMapeamento());

        }
    }
}
