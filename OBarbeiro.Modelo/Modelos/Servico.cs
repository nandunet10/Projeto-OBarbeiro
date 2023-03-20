namespace OBarbeiro.Modelo.Modelos;
public class Servico
{
    public int ServicoId { get; set; }
    public string Descricao { get; set; }
    public decimal Preco { get; set; }
    public bool Ativo { get; set; }

    public string EmpresaEmail { get; set; }
    public Empresa? Empresa { get; set; }

}
