using OBarbeiro.Modelo.Modelos;

namespace OBarbeiro.Comum.Modelos
{
    public class RetornoPesquisaAgendamentoViewModel
    {
        public RetornoPesquisaAgendamentoViewModel()
        {
            Profissionais = new List<Profissional>();
        }
        public string? Email { get; set; }
        public string? NomeBarbearia { get; set; }
        public ICollection<Profissional> Profissionais { get; set; }
    }
}
