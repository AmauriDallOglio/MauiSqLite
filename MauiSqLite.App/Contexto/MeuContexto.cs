using MauiSqLite.App.Mapeamento;
using MauiSqLite.App.Model;
using Microsoft.EntityFrameworkCore;

namespace MauiSqLite.App.Contexto
{
    public class MeuContexto : DbContext
    {
        public DbSet<UsuarioModel> UsuarioModel { get; set; }

        public MeuContexto(DbContextOptions<MeuContexto> options) : base(options)
        {
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configura o mapeamento do modelo
            modelBuilder.ApplyConfiguration(new UsuarioMapeamento());

        }
    }
}
