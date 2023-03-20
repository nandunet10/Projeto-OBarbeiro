using OBarbeiro.Negocio.NegocioBase;

namespace OBarbeiro.Negocio.Empresa;
public class EmpresaNegocio : NegocioBase<Modelo.Modelos.Empresa>, IEmpresaNegocio
{
    public EmpresaNegocio(bool SaveChanges = true) : base(SaveChanges) { }
}
