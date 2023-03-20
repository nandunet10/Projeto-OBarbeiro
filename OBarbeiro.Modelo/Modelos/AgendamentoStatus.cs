namespace OBarbeiro.Modelo.Modelos;
public class AgendamentoStatus
{
    //[Key][DatabaseGenerated(DatabaseGeneratedOption.Identity)][Required(ErrorMessage = "O Id é obrigatório.")] public int AgendamentoStatusId { get; set; }
    //[Required][DisplayName("Descrição do status")][StringLength(150)] public string Descricao { get; set; }

    public int AgendamentoStatusId { get; set; }
    public string Descricao { get; set; }

    public Agendamento? Agendamento { get; set; }
}
