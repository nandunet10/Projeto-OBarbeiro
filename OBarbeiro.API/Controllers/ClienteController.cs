using Microsoft.AspNetCore.Mvc;
using OBarbeiro.Modelo.Modelos;
using OBarbeiro.Negocio.Cliente;

namespace OBarbeiro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ClienteController : ControllerBase
    {
        private readonly IClienteNegocio _clienteNegocio;
        public ClienteController(IClienteNegocio clienteNegocio)
        {
            _clienteNegocio = clienteNegocio;
        }

        /// <summary>
        ///  Obtém a lista de cliente
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        public async Task<List<Cliente>> GetAll()
        {
            return await _clienteNegocio.ObterTodos();
        }
        /// <summary>
        /// Obter registro por identificador da tabela
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpGet("Obter")]
        public async Task<Cliente> Get([FromQuery] string email)
        {
            return await _clienteNegocio.Obter(email);
        }

        /// <summary>
        /// Incluir um registro
        /// </summary>
        /// <param name="objeto"></param>
        [HttpPost()]
        public async Task Post([FromBody] Cliente objeto)
        {
            await _clienteNegocio.Incluir(objeto);
        }

        /// <summary>
        /// Alterar registro
        /// </summary>
        /// <param name="objeto"></param>
        /// <returns></returns>
        [HttpPut()]
        public async Task Put([FromBody] Cliente objeto)
        {
            await _clienteNegocio.Alterar(objeto);
        }

        /// <summary>
        /// Exclui um registro
        /// </summary>
        /// <param name="email"></param>
        [HttpDelete()]
        public void Delete([FromQuery] string email)
        {
            _clienteNegocio.Excluir(email);
        }
    }
}
