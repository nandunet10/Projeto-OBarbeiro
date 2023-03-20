using Microsoft.AspNetCore.Mvc;
using OBarbeiro.Modelo.Modelos;
using OBarbeiro.Negocio.Usuario;

namespace OBarbeiro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioNegocio _usuarioNegocio;
        public UsuarioController(IUsuarioNegocio usuarioNegocio)
        {
            _usuarioNegocio = usuarioNegocio;
        }

        /// <summary>
        ///  Obtém a lista de usuários
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        public async Task<List<Usuario>> GetAll()
        {
            return await _usuarioNegocio.ObterTodos();
        }

        /// <summary>
        /// Obter registro por identificador da tabela
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpGet("Obter")]
        public async Task<Usuario> Get([FromQuery] string email)
        {
            return await _usuarioNegocio.Obter(email);
        }

        /// <summary>
        /// Incluir um registro
        /// </summary>
        /// <param name="objeto"></param>
        [HttpPost()]
        public async Task Post([FromBody] Usuario objeto)
        {
            await _usuarioNegocio.Incluir(objeto);
        }

        /// <summary>
        /// Alterar registro
        /// </summary>
        /// <param name="objeto"></param>
        /// <returns></returns>
        [HttpPut()]
        public async Task Put([FromBody] Usuario objeto)
        {
            await _usuarioNegocio.Alterar(objeto);
        }

        /// <summary>
        /// Exclui um registro
        /// </summary>
        /// <param name="email"></param>
        [HttpDelete()]
        public void Delete([FromQuery] string email)
        {
            _usuarioNegocio.Excluir(email);
        }
    }
}
