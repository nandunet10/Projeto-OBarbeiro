namespace OBarbeiro.Modelo.Modelos;
public partial class Profissional
{
    public string Cpf { get; set; }
    public string Nome { get; set; }
    public DateTime DataNascimento { get; set; }
    public string Email { get; set; }
    public string Celular { get; set; }
    public bool Ativo { get; set; }

    public string EmpresaEmail { get; set; }
    public Empresa? Empresa { get; set; }

    public ICollection<Agendamento>? Agendamentos { get; set; }
    public ICollection<AgendaProfissional>? AgendaProfissional { get; set; }
}