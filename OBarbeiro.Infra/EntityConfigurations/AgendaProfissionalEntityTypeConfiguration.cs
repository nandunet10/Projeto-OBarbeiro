using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OBarbeiro.Modelo.Modelos;

namespace OBarbeiro.Infra.EntityConfigurations
{
    public class AgendaProfissionalEntityTypeConfiguration : IEntityTypeConfiguration<AgendaProfissional>
    {
        public void Configure(EntityTypeBuilder<AgendaProfissional> builder)
        {
            builder.ToTable("AgendaProfissional", "dbo");

            builder.HasKey(p => p.AgendaProfissionalId);

            builder.Property(p => p.AgendaProfissionalId).HasColumnName("agendaProfissionalId").ValueGeneratedOnAdd();
            builder.Property(p => p.DiaSemana).HasColumnName("diaSemana").HasColumnType("DATE");
            builder.Property(p => p.HoraInicioAlmoco).HasColumnName("horaInicioAlmoco");
            builder.Property(p => p.HoraFimAlmoco).HasColumnName("horaFimAlmoco");
            builder.Property(p => p.HoraInicioExpediente).HasColumnName("horaInicioExpediente");
            builder.Property(p => p.HoraFimExpediente).HasColumnName("horaFimExpediente");

            builder.HasOne(p => p.Profissional)
                   .WithMany(p => p.AgendaProfissional)
                   .HasForeignKey(p => p.ProfissionalCpf);
        }
    }
}
