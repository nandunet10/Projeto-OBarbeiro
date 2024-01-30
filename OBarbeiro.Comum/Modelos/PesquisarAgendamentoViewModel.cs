namespace OBarbeiro.Comum.Modelos
{
    public class PesquisarAgendamentoViewModel
    {
        public DateTime DataAgendamento { get; set; }
        public string? Email { get; set; }
        public int ServidoId { get; set; }
        public string? ProfissionalCpf { get; set; }
    }
}
