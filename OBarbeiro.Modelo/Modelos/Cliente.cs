namespace OBarbeiro.Modelo.Modelos;
public partial class Cliente
{
    public string Email { get; set; }
    public string Nome { get; set; }
    public string Celular { get; set; }
    public DateTime DataNascimento { get; set; }
    public DateTime DataInclusao { get; set; }
    public DateTime? DataAlteracao { get; set; }
    public bool Ativo { get; set; }

    public string UsuarioEmail { get; set; }
    public Usuario? Usuario { get; set; }

    public ICollection<Agendamento>? Agendamentos { get; set; }

}