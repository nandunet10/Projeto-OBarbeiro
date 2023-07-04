using OBarbeiro.Modelo.Modelos;

namespace OBarbeiro.Comum.Modelos
{
    public class PesquisaViewModel : EnderecoModel
    {
        public string Email { get; set; }
        public string NomeBarbearia { get; set; }
        public string Celular { get; set; }
        public string Telefone { get; set; }
        //public ICollection<Modelo.Modelos.Servico>? Servicos { get; set; }
        //public ICollection<Profissional>? Profissionais { get; set; }

    }
}
