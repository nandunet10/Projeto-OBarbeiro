using OBarbeiro.Negocio.NegocioBase;

namespace OBarbeiro.Negocio.Profissional;
public class ProfissionalNegocio : NegocioBase<Modelo.Modelos.Profissional>, IProfissionalNegocio
{
    public ProfissionalNegocio(bool SaveChanges = true) : base(SaveChanges) { }

}
