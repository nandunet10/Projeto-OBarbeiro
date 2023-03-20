namespace OBarbeiro.Modelo.Modelos;
public partial class Agendamento
{
    public int AgendamentoId { get; set; }
    public DateTime DataAgendamento { get; set; }

    public string ClienteEmail { get; set; }
    public Cliente? Cliente { get; set; }

    public string ProfissionalCpf { get; set; }
    public Profissional? Profissional { get; set; }

    public int AgendamentoStatusId { get; set; }
    public AgendamentoStatus? AgendamentoStatus { get; set; }
}