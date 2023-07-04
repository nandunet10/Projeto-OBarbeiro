using OBarbeiro.Infra.Contexts;
using OBarbeiro.Negocio.NegocioBase;

namespace OBarbeiro.Negocio.Profissional;
public class ProfissionalNegocio : NegocioBase<Modelo.Modelos.Profissional>, IProfissionalNegocio
{
    public ProfissionalNegocio(OBarbeiroDbContext context, bool SaveChanges = true) : base(context, SaveChanges) { }

}
