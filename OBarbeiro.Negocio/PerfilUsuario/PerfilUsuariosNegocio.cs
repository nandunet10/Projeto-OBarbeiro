using OBarbeiro.Modelo.Modelos;
using OBarbeiro.Negocio.NegocioBase;

namespace OBarbeiro.Negocio.PerfilUsuario;
public class PerfilUsuariosNegocio : NegocioBase<Modelo.Modelos.PerfilUsuario>, IPerfilUsuariosNegocio
{
    public PerfilUsuariosNegocio(bool SaveChanges = true) : base(SaveChanges) { }
}
