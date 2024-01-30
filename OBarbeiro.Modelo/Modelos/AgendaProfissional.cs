namespace OBarbeiro.Modelo.Modelos;
public class AgendaProfissional
{
    public int AgendaProfissionalId { get; set; }
    public int DiaSemana { get; set; }
    public TimeSpan HoraInicioExpediente { get; set; }
    public TimeSpan HoraInicioAlmoco { get; set; }
    public TimeSpan HoraFimAlmoco { get; set; }
    public TimeSpan HoraFimExpediente { get; set; }

    public string ProfissionalCpf { get; set; }
    public Profissional? Profissional { get; set; }
}
