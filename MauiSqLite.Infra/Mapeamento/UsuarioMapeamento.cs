using MauiSqLite.Dominio.Entidade;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MauiSqLite.Infra.Mapeamento
{
    public class UsuarioMapeamento : IEntityTypeConfiguration<UsuarioModel>
    {
        public void Configure(EntityTypeBuilder<UsuarioModel> builder)
        {
            builder.ToTable("Usuario");
            builder.HasKey(u => u.Id);
            builder.Property(u => u.Nome).HasMaxLength(100).IsRequired(true);
            builder.Property(u => u.Email).HasMaxLength(100).IsRequired(true);
            builder.Property(u => u.Telefone).HasMaxLength(20).IsRequired(true);
            builder.Property(u => u.DataNascimento).IsRequired(true);
            builder.Property(u => u.DataCadastro).IsRequired(true);
            builder.Property(u => u.Ativo).IsRequired(true);
        }
    }
}