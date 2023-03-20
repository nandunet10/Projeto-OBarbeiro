using OBarbeiro.Modelo.Modelos;
using OBarbeiro.Negocio.NegocioBase;

namespace OBarbeiro.Negocio.Usuario;
public class UsuarioNegocio : NegocioBase<Modelo.Modelos.Usuario>, IUsuarioNegocio
{
    public UsuarioNegocio(bool SaveChanges = true) : base(SaveChanges) { }

}
