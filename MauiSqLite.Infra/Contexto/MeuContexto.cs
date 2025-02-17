using MauiSqLite.Dominio.Entidade;
using MauiSqLite.Infra.Mapeamento;
using Microsoft.EntityFrameworkCore;

namespace MauiSqLite.Infra.Contexto
{
    public class MeuContexto : DbContext
    {
        public DbSet<Usuario> Usuario { get; set; }
        public DbSet<Anexo> Anexo { get; set; }
        public DbSet<Comentario> Comentario { get; set; }
        public DbSet<Tarefa> Tarefa { get; set; }


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
            modelBuilder.ApplyConfiguration(new TarefaMapeamento());
            //base.OnModelCreating(modelBuilder);
            //modelBuilder.Entity<UsuarioModel>().ToTable("Usuario");


        }
    }
}
