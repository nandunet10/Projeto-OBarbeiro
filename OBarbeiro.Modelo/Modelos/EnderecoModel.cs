namespace OBarbeiro.Modelo.Modelos;
public class EnderecoModel
{
    //[Required(ErrorMessage = "Campo obrigatório!")][DisplayName("Cep")][StringLength(9)] public string Cep { get; set; }
    //[Required(ErrorMessage = "Campo obrigatório!")][DisplayName("Endereco")][StringLength(50)] public string Logradouro { get; set; }
    //[Required(ErrorMessage = "Campo obrigatório!")][DisplayName("Numero")][StringLength(20)] public string Numero { get; set; }
    //[DisplayName("Complemento")][StringLength(50, ErrorMessage = "Maxímo de 50 caracteres.")] public string? Complemento { get; set; }
    //[Required(ErrorMessage = "Campo obrigatório!")][DisplayName("Cidade")][StringLength(50)] public string Cidade { get; set; }
    //[Required(ErrorMessage = "Campo obrigatório!")][DisplayName("Estado")][StringLength(2)] public string UF { get; set; }

    public string Cep { get; set; }
    public string Logradouro { get; set; }
    public string Numero { get; set; }
    public string? Complemento { get; set; }
    public string Cidade { get; set; }
    public string UF { get; set; }
}
