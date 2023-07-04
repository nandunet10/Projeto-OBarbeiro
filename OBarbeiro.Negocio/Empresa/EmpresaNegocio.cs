using OBarbeiro.Infra.Contexts;
using OBarbeiro.Negocio.NegocioBase;

namespace OBarbeiro.Negocio.Empresa;
public class EmpresaNegocio : NegocioBase<Modelo.Modelos.Empresa>, IEmpresaNegocio
{
    public EmpresaNegocio(OBarbeiroDbContext context, bool SaveChanges = true) : base(context, SaveChanges) { }
}
