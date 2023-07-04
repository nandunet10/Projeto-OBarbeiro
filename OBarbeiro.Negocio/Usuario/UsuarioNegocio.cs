using OBarbeiro.Infra.Contexts;
using OBarbeiro.Negocio.NegocioBase;

namespace OBarbeiro.Negocio.Usuario;
public class UsuarioNegocio : NegocioBase<Modelo.Modelos.Usuario>, IUsuarioNegocio
{
    public UsuarioNegocio(OBarbeiroDbContext context, bool SaveChanges = true) : base(context, SaveChanges) { }

}
