using Microsoft.AspNetCore.Mvc;
using OBarbeiro.Modelo.Modelos;
using OBarbeiro.Negocio.AgendamentoStatus;

namespace OBarbeiro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class AgendamentoStatusController : ControllerBase
    {
        private readonly IAgendamentoStatusNegocio _agendamentoStatusNegocio;
        public AgendamentoStatusController(IAgendamentoStatusNegocio agendamentoStatusNegocio)
        {
            _agendamentoStatusNegocio = agendamentoStatusNegocio;
        }

        /// <summary>
        /// Método para obter todos agendamentos
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        public async Task<List<AgendamentoStatus>> GetAll()
        {
            return await _agendamentoStatusNegocio.ObterTodos();
        }

        /// <summary>
        /// Método para obter todos agendamentos
        /// </summary>
        /// <returns></returns>
        [HttpGet("PorNome")]
        public async Task<List<AgendamentoStatus>> ObterAgendamentosPorNome()
        {
            return await _agendamentoStatusNegocio.ObterTodos();
        }

        /// <summary>
        /// Obter registro por identificador da tabela
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("Obter")]
        public async Task<AgendamentoStatus> Get([FromQuery] int id)
        {
            return await _agendamentoStatusNegocio.Obter(id);
        }

        /// <summary>
        /// Incluir um registro
        /// </summary>
        /// <param name="objeto"></param>
        [HttpPost()]
        public async Task Post([FromBody] AgendamentoStatus objeto)
        {
            await _agendamentoStatusNegocio.Incluir(objeto);
        }

        /// <summary>
        /// Alterar registro
        /// </summary>
        /// <param name="objeto"></param>
        /// <returns></returns>
        [HttpPut()]
        public async Task Put([FromBody] AgendamentoStatus objeto)
        {
            await _agendamentoStatusNegocio.Alterar(objeto);
        }

        /// <summary>
        /// Exclui um registro
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete()]
        public void Delete([FromQuery] int id)
        {
            _agendamentoStatusNegocio.Excluir(id);
        }

    }
}
