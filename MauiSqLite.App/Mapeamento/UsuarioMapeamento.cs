using MauiSqLite.App.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MauiSqLite.App.Mapeamento
{
    public class UsuarioMapeamento : IEntityTypeConfiguration<UsuarioModel>
    {
        public void Configure(EntityTypeBuilder<UsuarioModel> builder)
        {
            builder.ToTable("Usuario");


            builder.HasKey(u => u.Id);

            builder.Property(u => u.Nome)
                   .HasMaxLength(100)
                   .IsRequired();   

            builder.Property(u => u.Email)
                   .HasMaxLength(100)
                   .IsRequired();   

            builder.Property(u => u.Telefone)
                   .HasMaxLength(20);   

            builder.Property(u => u.DataNascimento)
                   .IsRequired();   

            builder.Property(u => u.DataCadastro)
                   .IsRequired();   

            builder.Property(u => u.Ativo)
                   .IsRequired();  
        }
    }
}
