using OBarbeiro.Comum.Modelos;

namespace OBarbeiro.Negocio.Cadastro;
public interface ICadastroNegocio
{
    Task IncluirCliente(CadastroClienteViewModel objeto);
    Task IncluirEmpresa(CadastroEmpresaViewModel objeto);
}


