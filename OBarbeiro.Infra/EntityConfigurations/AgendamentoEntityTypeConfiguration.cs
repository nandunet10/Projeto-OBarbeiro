using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OBarbeiro.Modelo.Modelos;

namespace OBarbeiro.Infra.EntityConfigurations
{
    public class AgendamentoEntityTypeConfiguration : IEntityTypeConfiguration<Agendamento>
    {
        public void Configure(EntityTypeBuilder<Agendamento> builder)
        {
            builder.ToTable("Agendamentos", "dbo");

            builder.HasKey(p => p.AgendamentoId);

            builder.Property(p => p.AgendamentoId).HasColumnName("AgendamentoId").ValueGeneratedOnAdd();
            builder.Property(p => p.DataAgendamento).HasColumnName("dataAgendamento");

            builder.HasOne(p => p.Cliente)
                   .WithMany(p => p.Agendamentos)
                   .HasForeignKey(p => p.ClienteEmail).OnDelete(DeleteBehavior.ClientNoAction);

            builder.HasOne(p => p.Profissional)
                   .WithMany(p => p.Agendamentos)
                   .HasForeignKey(p => p.ProfissionalCpf).OnDelete(DeleteBehavior.ClientNoAction);

            builder.HasOne(p => p.AgendamentoStatus)
                   .WithOne(p => p.Agendamento)
                   .HasForeignKey<Agendamento>(p => p.AgendamentoStatusId);

        }
    }
}
