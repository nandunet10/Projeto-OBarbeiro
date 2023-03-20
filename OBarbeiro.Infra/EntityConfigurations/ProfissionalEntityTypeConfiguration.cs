using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OBarbeiro.Modelo.Modelos;

namespace OBarbeiro.Infra.EntityConfigurations
{
    public class ProfissionalEntityTypeConfiguration : IEntityTypeConfiguration<Profissional>
    {
        public void Configure(EntityTypeBuilder<Profissional> builder)
        {
            builder.ToTable("Profissional", "dbo");

            builder.HasKey(p => p.Cpf);

            builder.Property(p => p.Cpf).HasColumnName("cpf").HasMaxLength(14).ValueGeneratedOnAdd();
            builder.Property(p => p.Nome).HasColumnName("nome").HasMaxLength(100);
            builder.Property(p => p.Email).HasColumnName("email").HasMaxLength(150);
            builder.Property(p => p.DataNascimento).HasColumnName("dataNascimento").HasColumnType("DATE");
            builder.Property(p => p.Celular).HasColumnName("celular").HasMaxLength(15);
            builder.Property(p => p.Ativo).HasColumnName("ativo");
        }
    }
}
