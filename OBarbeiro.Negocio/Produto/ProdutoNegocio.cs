using OBarbeiro.Modelo.Modelos;
using OBarbeiro.Negocio.NegocioBase;

namespace OBarbeiro.Negocio.Produto;
public class ProdutoNegocio : NegocioBase<Modelo.Modelos.Produto>, IProdutoNegocio
{
    public ProdutoNegocio(bool SaveChanges = true) : base(SaveChanges) { }
}
