using OBarbeiro.Infra.Contexts;
using OBarbeiro.Negocio.NegocioBase;

namespace OBarbeiro.Negocio.AgendaProfissional;
public class AgendaProfissionalNegocio : NegocioBase<Modelo.Modelos.AgendaProfissional>, IAgendaProfissionalNegocio
{
    public AgendaProfissionalNegocio(OBarbeiroDbContext context, bool SaveChanges = true) : base(context, SaveChanges) { }

}
