using OBarbeiro.Negocio.NegocioBase;

namespace OBarbeiro.Negocio.Cliente;
public class ClienteNegocio : NegocioBase<Modelo.Modelos.Cliente>, IClienteNegocio
{
    public ClienteNegocio(bool SaveChanges = true) : base(SaveChanges) { }
}
