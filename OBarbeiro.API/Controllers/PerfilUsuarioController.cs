using Microsoft.AspNetCore.Mvc;
using OBarbeiro.Modelo.Modelos;
using OBarbeiro.Negocio.PerfilUsuario;

namespace OBarbeiro.API.Controllers;

[Route("api/[controller]")]
[ApiController]
public class PerfilUsuarioController : ControllerBase
{
    private readonly IPerfilUsuariosNegocio _perfilUsuariosNegocio;
    public PerfilUsuarioController(IPerfilUsuariosNegocio perfilUsuariosNegocio)
    {
        _perfilUsuariosNegocio = perfilUsuariosNegocio;
    }

    /// <summary>
    ///  Obtém a lista de perfils de usuários
    /// </summary>
    /// <returns></returns>
    [HttpGet()]
    public async Task<List<PerfilUsuario>> GetAll()
    {
        return await _perfilUsuariosNegocio.ObterTodos();
    }

    /// <summary>
    ///  Obtém a lista de perfils de usuários
    /// </summary>
    /// <returns></returns>
    [HttpGet("Obter")]
    public async Task<PerfilUsuario> Get([FromQuery] int id)
    {
        return await _perfilUsuariosNegocio.Obter(id);
    }

    /// <summary>
    /// Incluir um registro
    /// </summary>
    /// <param name="objeto"></param>
    [HttpPost()]
    public async Task Post([FromBody] PerfilUsuario objeto)
    {
        await _perfilUsuariosNegocio.Incluir(objeto);
    }

    /// <summary>
    /// Alterar registro
    /// </summary>
    /// <param name="objeto"></param>
    /// <returns></returns>
    [HttpPut()]
    public async Task Put([FromBody] PerfilUsuario objeto)
    {
        await _perfilUsuariosNegocio.Alterar(objeto);
    }

    /// <summary>
    /// Exclui um registro
    /// </summary>
    /// <param name="id"></param>
    [HttpDelete()]
    public void Delete([FromQuery] int id)
    {
        _perfilUsuariosNegocio.Excluir(id);
    }
}
