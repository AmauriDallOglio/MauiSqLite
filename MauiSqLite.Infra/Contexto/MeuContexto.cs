using MauiSqLite.Dominio.Entidade;
using MauiSqLite.Infra.Mapeamento;
using Microsoft.EntityFrameworkCore;

namespace MauiSqLite.Infra.Contexto
{
    public class MeuContexto : DbContext
    {
        public DbSet<UsuarioModel> UsuarioModel { get; set; }

        public MeuContexto(DbContextOptions<MeuContexto> options) : base(options)
        {
        }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                //optionsBuilder.UseSqlite($"Data Source={App.AppDatabasePath}");
            }

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configura o mapeamento do modelo
            modelBuilder.ApplyConfiguration(new UsuarioMapeamento());
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<UsuarioModel>().ToTable("Usuario");


        }
    }
}
