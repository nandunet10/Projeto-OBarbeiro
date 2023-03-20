using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OBarbeiro.Modelo.Modelos;

namespace OBarbeiro.Infra.EntityConfigurations
{
    public class ClienteEntityTypeConfiguration : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {
            builder.ToTable("Clientes", "dbo");

            builder.HasKey(p => p.Email);

            // Dados base
            builder.Property(p => p.Email).HasColumnName("email").ValueGeneratedOnAdd();
            builder.Property(p => p.Nome).HasColumnName("nome");
            builder.Property(p => p.Celular).HasColumnName("celular").HasMaxLength(15);
            builder.Property(p => p.DataNascimento).HasColumnName("dataNascimento").HasColumnType("DATE");
            builder.Property(p => p.DataInclusao).HasColumnName("dataInclusao");
            builder.Property(p => p.DataAlteracao).HasColumnName("dataAlteracao").IsRequired(false);
            builder.Property(p => p.Ativo).HasColumnName("ativo");
        }
    }
}
