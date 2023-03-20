namespace OBarbeiro.Modelo.Modelos;
public partial class Produto
{
    public int ProdutoId { get; set; }
    public string Descricao { get; set; }
    public decimal ValorUnitario { get; set; }
    public int Quantidade { get; set; }

    public bool Ativo { get; set; }


    public string EmpresaEmail { get; set; }
    public Empresa? Empresa { get; set; }

}