using OBarbeiro.Infra.Contexts;
using OBarbeiro.Negocio.NegocioBase;

namespace OBarbeiro.Negocio.Servico;
public class ServicoNegocio : NegocioBase<Modelo.Modelos.Servico>, IServicoNegocio
{
    public ServicoNegocio(OBarbeiroDbContext context, bool SaveChanges = true) : base(context, SaveChanges) { }
}
