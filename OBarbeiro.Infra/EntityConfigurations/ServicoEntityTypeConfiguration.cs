using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OBarbeiro.Modelo.Modelos;

namespace OBarbeiro.Infra.EntityConfigurations
{
    public class ServicoEntityTypeConfiguration : IEntityTypeConfiguration<Servico>
    {
        public void Configure(EntityTypeBuilder<Servico> builder)
        {
            builder.ToTable("Servicos", "dbo");

            builder.HasKey(p => p.ServicoId);

            // Dados base
            builder.Property(p => p.ServicoId).HasColumnName("servicoId").ValueGeneratedOnAdd();
            builder.Property(p => p.Descricao).HasColumnName("descricao").HasMaxLength(150);
            builder.Property(p => p.Preco).HasColumnName("preco").HasPrecision(18, 2);
            builder.Property(p => p.Ativo).HasColumnName("ativo");
        }
    }
}
