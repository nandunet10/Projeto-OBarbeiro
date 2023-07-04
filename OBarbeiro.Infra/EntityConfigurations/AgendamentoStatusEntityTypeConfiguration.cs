using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using OBarbeiro.Modelo.Modelos;

namespace OBarbeiro.Infra.EntityConfigurations
{
    public class AgendamentoStatusEntityTypeConfiguration : IEntityTypeConfiguration<AgendamentoStatus>
    {
        public void Configure(EntityTypeBuilder<AgendamentoStatus> builder)
        {
            builder.ToTable("AgendamentoStatus", "dbo");

            builder.HasKey(p => p.AgendamentoStatusId);

            builder.Property(p => p.AgendamentoStatusId).HasColumnName("agendamentoStatusId").ValueGeneratedOnAdd();
            builder.Property(p => p.Descricao).HasColumnName("descricao").HasMaxLength(150);

            builder.HasData(
                new AgendamentoStatus
                {
                    AgendamentoStatusId = 1,
                    Descricao = "Agendado"
                },
                new AgendamentoStatus
                {
                    AgendamentoStatusId = 2,
                    Descricao = "Cancelado"
                },
                new AgendamentoStatus
                {
                    AgendamentoStatusId = 3,
                    Descricao = "Concluído"
                }

           );
        }
    }
}
