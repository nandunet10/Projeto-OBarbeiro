using OBarbeiro.Modelo.Modelos;
using OBarbeiro.Negocio.NegocioBase;

namespace OBarbeiro.Negocio.Agendamento;
public class AgendamentoNegocio : NegocioBase<Modelo.Modelos.Agendamento>, IAgendamentoNegocio
{
    public AgendamentoNegocio(bool SaveChanges = true) : base(SaveChanges) { }

}
