using OBarbeiro.Infra.Contexts;
using OBarbeiro.Negocio.NegocioBase;

namespace OBarbeiro.Negocio.AgendamentoStatus;
public class AgendamentoStatusNegocio : NegocioBase<Modelo.Modelos.AgendamentoStatus>, IAgendamentoStatusNegocio
{
    public AgendamentoStatusNegocio(OBarbeiroDbContext context, bool SaveChanges = true) : base(context, SaveChanges) { }

}
