using OBarbeiro.Comum.Enums;
using OBarbeiro.Comum.Modelos;
using OBarbeiro.Infra.Contexts;

namespace OBarbeiro.Negocio.Cadastro;
public class CadastroNegocio : ICadastroNegocio
{
    private readonly OBarbeiroDbContext _context;
    public CadastroNegocio(OBarbeiroDbContext context)
    {
        _context = context;
    }

    public async Task IncluirEmpresa(CadastroEmpresaViewModel objeto)
    {
        var usuario = new Modelo.Modelos.Usuario()
        {
            Email = objeto.Email,
            Senha = objeto.Senha,
            PerfilUsuarioId = (int)PerfilsUsuarioEnum.Empresa
        };

        var empresa = new Modelo.Modelos.Empresa
        {
            UsuarioEmail = objeto.Email,

            Email = objeto.Email,
            Nome = objeto.Nome,
            NomeBarbearia = objeto.NomeBarbearia,
            Celular = objeto.Celular,
            Telefone = objeto.Telefone,

            Cep = objeto.Cep,
            Logradouro = objeto.Logradouro,
            Numero = objeto.Numero,
            Complemento = objeto.Complemento,
            Cidade = objeto.Cidade,
            UF = objeto.UF,

            DataInclusao = DateTime.Now,
            Ativo = true,
        };

        VerificarSeECadastradado(usuario.Email, usuario.PerfilUsuarioId);

        await _context.Empresas.AddAsync(empresa);
        await _context.Usuarios.AddAsync(usuario);
        await _context.SaveChangesAsync();
    }

    public async Task IncluirCliente(CadastroClienteViewModel objeto)
    {
        try
        {
            var usuario = new Modelo.Modelos.Usuario()
            {
                Email = objeto.Email,
                Senha = objeto.Senha,
                PerfilUsuarioId = (int)PerfilsUsuarioEnum.Cliente
            };

            var cliente = new Modelo.Modelos.Cliente
            {
                UsuarioEmail = objeto.Email,

                Email = objeto.Email,
                Nome = objeto.Nome,
                Celular = objeto.Celular,
                DataNascimento = objeto.DataNascimento,
                DataInclusao = DateTime.Now,
                Ativo = true,
            };

            VerificarSeECadastradado(usuario.Email, usuario.PerfilUsuarioId);

            await _context.Clientes.AddAsync(cliente);
            await _context.Usuarios.AddAsync(usuario);

            await _context.SaveChangesAsync();


        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }


    }

    public bool VerificarSeECadastradado(string email, int perfilUsuarioId)
    {
        var response = _context.Usuarios.Where(c => c.Email.Equals(email) && c.PerfilUsuarioId.Equals(perfilUsuarioId));

        if (response.Count() > 0)
            throw new Exception("Usuário já possui cadastro!");

        return false;
    }
}
