using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OBarbeiro.Modelo.Modelos;

namespace OBarbeiro.Infra.EntityConfigurations
{
    public class ProdutoEntityTypeConfiguration : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("Produtos", "dbo");

            builder.HasKey(p => p.ProdutoId);

            // Dados base
            builder.Property(p => p.ProdutoId).HasColumnName("produtoId").ValueGeneratedOnAdd();
            builder.Property(p => p.Descricao).HasColumnName("descricao").HasMaxLength(150);
            builder.Property(p => p.ValorUnitario).HasColumnName("ValorUnitario").HasPrecision(18, 2);
            builder.Property(p => p.Ativo).HasColumnName("ativo");
        }
    }
}
