using MauiSqLite.App.Model;
using Microsoft.EntityFrameworkCore;

namespace MauiSqLite.App.Contexto
{
    public class MeuContexto : DbContext
    {
        public DbSet<UsuarioModel> UsuarioModel { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite($"Filename={Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "Usuarios.db")}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UsuarioModel>().ToTable("Nomes");
        }
    }
}
