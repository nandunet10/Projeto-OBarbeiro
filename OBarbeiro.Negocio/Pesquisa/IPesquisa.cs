using OBarbeiro.Comum.Modelos;

namespace OBarbeiro.Negocio.Pesquisa
{
    public interface IPesquisa
    {
        Task<List<PesquisaViewModel>> PesquisarEmpresas(PesquisarEmpresasViewModel pesquisar);
    }
}
