using OBarbeiro.Modelo.Modelos;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OBarbeiro.Comum.Modelos;

public class CadastroClienteViewModel
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

    [Required]
    [DisplayName("Data de nascimento")]
    [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")] public DateTime DataNascimento { get; set; }

}
