using OBarbeiro.Infra.Contexts;
using OBarbeiro.Negocio.NegocioBase;

namespace OBarbeiro.Negocio.Cliente;
public class ClienteNegocio : NegocioBase<Modelo.Modelos.Cliente>, IClienteNegocio
{
    public ClienteNegocio(OBarbeiroDbContext context, bool SaveChanges = true) : base(context, SaveChanges) { }
}
