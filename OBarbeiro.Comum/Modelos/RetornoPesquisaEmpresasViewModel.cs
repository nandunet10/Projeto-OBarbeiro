using OBarbeiro.Modelo.Modelos;

namespace OBarbeiro.Comum.Modelos
{
    public class RetornoPesquisaEmpresasViewModel : EnderecoModel
    {
        public string? Email { get; set; }
        public string NomeBarbearia { get; set; }
        public string Celular { get; set; }
        public string Telefone { get; set; }
        public List<Teste> Teste { get; set; }


    }


    public class Teste
    {
        public string Nome { get; set; }
        public string Endereco { get; set; }
        public string Url { get; set; }
    }
}
