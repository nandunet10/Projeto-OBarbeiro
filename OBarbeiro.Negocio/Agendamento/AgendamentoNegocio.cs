using OBarbeiro.Infra.Contexts;
using OBarbeiro.Negocio.NegocioBase;

namespace OBarbeiro.Negocio.Agendamento;
public class AgendamentoNegocio : NegocioBase<Modelo.Modelos.Agendamento>, IAgendamentoNegocio
{
    public AgendamentoNegocio(OBarbeiroDbContext context, bool SaveChanges = true) : base(context, SaveChanges) { }

}
