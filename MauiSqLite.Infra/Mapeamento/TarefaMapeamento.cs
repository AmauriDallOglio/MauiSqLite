using MauiSqLite.Dominio.Entidade;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MauiSqLite.Infra.Mapeamento
{
    public class TarefaMapeamento : IEntityTypeConfiguration<Tarefa>
    {
        public void Configure(EntityTypeBuilder<Tarefa> builder)
        {
            builder.ToTable("Tarefa");

            builder.HasKey(t => t.Id);

            builder.Property(t => t.Id)
                   .ValueGeneratedOnAdd();

            builder.Property(t => t.Titulo)
                   .IsRequired()
                   .HasMaxLength(200);

            builder.Property(t => t.Descricao)
                   .HasMaxLength(1000);

            builder.Property(t => t.DataCriacao).IsRequired(true);

            builder.Property(t => t.DataAtualizacao).IsRequired(false);

            builder.Property(t => t.Id_Usuario).IsRequired(false);

            builder.Property(t => t.Status)
                   .HasConversion<int>(); 

            // Exemplo de relacionamento se existir a entidade Usuario
            builder.HasOne<Usuario>() 
                   .WithMany()
                   .HasForeignKey(t => t.Id_Usuario)
                   .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
