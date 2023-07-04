using OBarbeiro.Infra.Contexts;
using OBarbeiro.Negocio.NegocioBase;

namespace OBarbeiro.Negocio.PerfilUsuario;
public class PerfilUsuariosNegocio : NegocioBase<Modelo.Modelos.PerfilUsuario>, IPerfilUsuariosNegocio
{
    public PerfilUsuariosNegocio(OBarbeiroDbContext context, bool SaveChanges = true) : base(context, SaveChanges) { }
}
