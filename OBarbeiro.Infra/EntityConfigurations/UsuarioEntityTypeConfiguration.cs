using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OBarbeiro.Modelo.Modelos;

namespace OBarbeiro.Infra.EntityConfigurations
{
    public class UsuarioEntityTypeConfiguration : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuarios", "dbo");

            builder.HasKey(p => p.Email);

            builder.Property(p => p.Email).HasColumnName("email").ValueGeneratedOnAdd();
            builder.Property(p => p.Senha).HasColumnName("senha");

            builder.HasOne(p => p.Cliente)
                   .WithOne(p => p.Usuario)
                   .HasForeignKey<Cliente>(p => p.UsuarioEmail).OnDelete(DeleteBehavior.Cascade);

            builder.HasOne(p => p.Empresa)
                   .WithOne(p => p.Usuario)
                   .HasForeignKey<Empresa>(p => p.UsuarioEmail).OnDelete(DeleteBehavior.Cascade);
        }
    }
}
