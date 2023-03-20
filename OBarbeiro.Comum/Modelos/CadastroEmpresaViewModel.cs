using OBarbeiro.Modelo.Modelos;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OBarbeiro.Comum.Modelos;
public class CadastroEmpresaViewModel
{
    [DataType(DataType.EmailAddress)]
    [Required(ErrorMessage = "Campo é obrigatório")]
    [StringLength(100, ErrorMessage = "{0} deve ter pelo menos {2} caracteres de comprimento.", MinimumLength = 10)]
    [DisplayName("E-mail")]
    public string Email { get; set; }

    [DataType(DataType.Password)]
    [Required(ErrorMessage = "Campo é obrigatório")]
    [StringLength(15, ErrorMessage = "{0} deve ter pelo menos {2} caracteres de comprimento.", MinimumLength = 6)]
    [DisplayName("Senha")]
    public string Senha { get; set; }
    [Required(ErrorMessage = "Campo é obrigatório")] public int PerfilUsuarioId { get; set; }
    public PerfilUsuario? PerfilUsuario { get; set; }

    [Required][DisplayName("Nome")][StringLength(150)] public string Nome { get; set; }
    [Required][DisplayName("Celular")][StringLength(15)] public string Celular { get; set; }
    [DisplayName("Celular")][StringLength(14)] public string? Telefone { get; set; }
    [DisplayName("Data de inclusão")] public DateTime DataInclusao { get; set; }
    [DisplayName("Data de nascimento")] public DateTime? DataAlteracao { get; set; }
    [Required][DisplayName("Nome barbearia")][StringLength(150)] public string NomeBarbearia { get; set; }
    [Required(ErrorMessage = "Campo obrigatório!")][DisplayName("Cep")][StringLength(9)] public string Cep { get; set; }
    [Required(ErrorMessage = "Campo obrigatório!")][DisplayName("Endereco")][StringLength(50)] public string Logradouro { get; set; }
    [Required(ErrorMessage = "Campo obrigatório!")][DisplayName("Numero")][StringLength(20)] public string Numero { get; set; }
    [DisplayName("Complemento")][StringLength(50, ErrorMessage = "Maxímo de 50 caracteres.")] public string? Complemento { get; set; }
    [Required(ErrorMessage = "Campo obrigatório!")][DisplayName("Cidade")][StringLength(50)] public string Cidade { get; set; }
    [Required(ErrorMessage = "Campo obrigatório!")][DisplayName("Estado")][StringLength(2)] public string UF { get; set; }
    public bool Ativo { get; set; }

}
