using OBarbeiro.Negocio.NegocioBase;

namespace OBarbeiro.Negocio.Servico;
public class ServicoNegocio : NegocioBase<Modelo.Modelos.Servico>, IServicoNegocio
{
    public ServicoNegocio(bool SaveChanges = true) : base(SaveChanges) { }
}
