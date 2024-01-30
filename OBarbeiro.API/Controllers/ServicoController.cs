using Microsoft.AspNetCore.Mvc;
using OBarbeiro.Modelo.Modelos;
using OBarbeiro.Negocio.Servico;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace OBarbeiro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ServicoController : ControllerBase
    {

        private readonly IServicoNegocio _servicoNegocio;
        public ServicoController(IServicoNegocio servicoNegocio)
        {
            _servicoNegocio = servicoNegocio;
        }

        /// <summary>
        ///  Obtém a lista de cliente
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        public async Task<List<Servico>> GetAll()
        {
            return await _servicoNegocio.ObterTodos();
        }
        /// <summary>
        /// Obter registro por identificador da tabela
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("Obter")]
        public async Task<Servico> Get([FromQuery] int id)
        {
            return await _servicoNegocio.Obter(id);
        }

        /// <summary>
        /// Obter registro por identificador da tabela
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpGet("{email}")]
        public async Task<List<Servico>> GetAllForParameters([FromRoute] string email)
        {
            return await _servicoNegocio.ObterTodosPorParametro(p => p.EmpresaEmail.Equals(email));
        }

        /// <summary>
        /// Incluir um registro
        /// </summary>
        /// <param name="objeto"></param>
        [HttpPost()]
        public async Task Post([FromBody] Servico objeto)
        {
            await _servicoNegocio.Incluir(objeto);
        }

        /// <summary>
        /// Alterar registro
        /// </summary>
        /// <param name="objeto"></param>
        /// <returns></returns>
        [HttpPut()]
        public async Task Put([FromBody] Servico objeto)
        {
            await _servicoNegocio.Alterar(objeto);
        }

        /// <summary>
        /// Exclui um registro
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete()]
        public void Delete([FromQuery] int id)
        {
            _servicoNegocio.Excluir(id);
        }
    }
}
