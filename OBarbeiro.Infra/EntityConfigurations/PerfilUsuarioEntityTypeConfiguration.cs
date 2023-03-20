using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OBarbeiro.Modelo.Modelos;

namespace OBarbeiro.Infra.EntityConfigurations
{
    public class PerfilUsuarioEntityTypeConfiguration : IEntityTypeConfiguration<PerfilUsuario>
    {
        public void Configure(EntityTypeBuilder<PerfilUsuario> builder)
        {
            builder.ToTable("PerfilUsuario", "dbo");

            builder.HasKey(p => p.PerfilUsuarioId);
  
            builder.Property(p => p.PerfilUsuarioId).HasColumnName("perfilUsuarioId").ValueGeneratedOnAdd();
            builder.Property(p => p.Perfil).HasColumnName("perfil").HasMaxLength(50);
            builder.Property(p => p.Descricao).HasColumnName("descricao").HasMaxLength(150);


            builder.HasOne(p => p.Usuario)
                   .WithOne(p => p.PerfilUsuario)
                   .HasForeignKey<Usuario>(p => p.PerfilUsuarioId);
        }
    }
}
