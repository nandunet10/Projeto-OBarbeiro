using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace OBarbeiro.Modelo.Modelos;
public class Usuario
{
    [Key]
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

    public Cliente? Cliente { get; set; }
    public Empresa? Empresa { get; set; }
}
