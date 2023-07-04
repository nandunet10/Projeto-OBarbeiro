namespace OBarbeiro.Modelo.Modelos;
public partial class Empresa : EnderecoModel
{
    public string Email { get; set; }
    public string Nome { get; set; }
    public string NomeBarbearia { get; set; }
    public string Celular { get; set; }
    public string Telefone { get; set; }
    public DateTime DataInclusao { get; set; }
    public DateTime? DataAlteracao { get; set; }
    public bool Ativo { get; set; }

    public string UsuarioEmail { get; set; }
    public Usuario? Usuario { get; set; }

    public ICollection<Servico>? Servicos { get; set; }
    public ICollection<Profissional>? Profissionais { get; set; }
}