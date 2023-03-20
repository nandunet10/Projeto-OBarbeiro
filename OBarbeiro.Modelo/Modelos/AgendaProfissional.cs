namespace OBarbeiro.Modelo.Modelos;
public class AgendaProfissional
{
    //[Key][Required(ErrorMessage = "Campo obrigatório!")][DisplayName("Cep")][StringLength(9)] public DateTime Dia { get; set; }
    //[Required(ErrorMessage = "Campo obrigatório!")][DisplayName("Horario inicio de expediente")][StringLength(5)] public string HoraInicioExpediente { get; set; }
    //[Required(ErrorMessage = "Campo obrigatório!")][DisplayName("Horario inicio de almoço")][StringLength(5)] public string HoraInicioAlmoco { get; set; }
    //[Required(ErrorMessage = "Campo obrigatório!")][DisplayName("Hoaraio fim de almoço")][StringLength(5)] public string HoraFimAlmoco { get; set; }
    //[Required(ErrorMessage = "Campo obrigatório!")][DisplayName("Horario fim de expediente")][StringLength(5)] public string HoraFimExpediente { get; set; }


    public int AgendaProfissionalId { get; set; }
    public DateTime DiaSemana { get; set; }
    public DateTime HoraInicioExpediente { get; set; }
    public DateTime HoraInicioAlmoco { get; set; }
    public DateTime HoraFimAlmoco { get; set; }
    public DateTime HoraFimExpediente { get; set; }

    public string ProfissionalCpf { get; set; }
    public Profissional? Profissional { get; set; }
}
