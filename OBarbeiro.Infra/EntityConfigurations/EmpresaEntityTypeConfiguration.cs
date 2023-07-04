using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OBarbeiro.Modelo.Modelos;

namespace OBarbeiro.Infra.EntityConfigurations
{
    public class EmpresaEntityTypeConfiguration : IEntityTypeConfiguration<Empresa>
    {
        public void Configure(EntityTypeBuilder<Empresa> builder)
        {
            builder.ToTable("Empresas", "dbo");

            builder.HasKey(p => p.Email);

            // Dados base
            builder.Property(p => p.Email).HasColumnName("email").ValueGeneratedOnAdd();
            builder.Property(p => p.Nome).HasColumnName("nome").HasMaxLength(100);
            builder.Property(p => p.NomeBarbearia).HasColumnName("nomeBarbearia").HasMaxLength(100);
            builder.Property(p => p.Celular).HasColumnName("celular").HasMaxLength(15);
            builder.Property(p => p.Telefone).HasColumnName("telefone").HasMaxLength(14).IsRequired(false);
            builder.Property(p => p.DataInclusao).HasColumnName("dataInclusao");
            builder.Property(p => p.DataAlteracao).HasColumnName("dataAlteracao").IsRequired(false);
            builder.Property(p => p.Ativo).HasColumnName("ativo");

            // Endereço
            builder.Property(p => p.Cep).HasColumnName("cep").HasMaxLength(9);
            builder.Property(p => p.Logradouro).HasColumnName("logradouro").HasMaxLength(50);
            builder.Property(p => p.Numero).HasColumnName("numero").HasMaxLength(20);
            builder.Property(p => p.Complemento).HasColumnName("complemento").HasMaxLength(50).IsRequired(false);
            builder.Property(p => p.Cidade).HasColumnName("cidade").HasMaxLength(50);
            builder.Property(p => p.UF).HasColumnName("uf").HasMaxLength(2);

            builder.HasMany(p => p.Servicos)
                   .WithOne(p => p.Empresa)
                   .HasForeignKey(p => p.EmpresaEmail).OnDelete(DeleteBehavior.ClientNoAction);

            builder.HasMany(p => p.Profissionais)
                   .WithOne(p => p.Empresa)
                   .HasForeignKey(p => p.EmpresaEmail).OnDelete(DeleteBehavior.ClientNoAction);


        }
    }
}
