using OBarbeiro.Comum.Modelos;

namespace OBarbeiro.Negocio.Pesquisa
{
    public interface IPesquisa
    {
        Task<List<RetornoPesquisaEmpresasViewModel>> PesquisarEmpresas(PesquisarEmpresasViewModel pesquisar);
        Task<List<RetornoPesquisaAgendamentoViewModel>> PesquisarHorariosAgendamento(PesquisarAgendamentoViewModel pesquisar);
    }
}
