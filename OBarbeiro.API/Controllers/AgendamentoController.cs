using Microsoft.AspNetCore.Mvc;
using OBarbeiro.Modelo.Modelos;
using OBarbeiro.Negocio.Agendamento;

namespace OBarbeiro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class AgendamentoController : ControllerBase
    {
        private readonly IAgendamentoNegocio _agendamentoNegocio;
        public AgendamentoController(IAgendamentoNegocio agendamentoNegocio)
        {
            _agendamentoNegocio = agendamentoNegocio;
        }

        /// <summary>
        /// Método para obter todos agendamentos
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        public async Task<List<Agendamento>> GetAll()
        {
            return await _agendamentoNegocio.ObterTodos();
        }


        /// <summary>
        /// Método que obtem todos agendamentos do usuario logado!
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpGet("{email}")]
        public async Task<List<Agendamento>> ObterAgendamentosPorEmailLogado([FromRoute] string email)
        {
            return await _agendamentoNegocio.ObterTodosPorParametro(p => p.ClienteEmail.Equals(email));
        }

        /// <summary>
        /// Obter registro por identificador da tabela
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("Obter")]
        public async Task<Agendamento> Get([FromQuery] int id)
        {
            return await _agendamentoNegocio.Obter(id);
        }

        /// <summary>
        /// Incluir um registro
        /// </summary>
        /// <param name="objeto"></param>
        [HttpPost()]
        public async Task Post([FromBody] Agendamento objeto)
        {
            await _agendamentoNegocio.Incluir(objeto);
        }

        /// <summary>
        /// Alterar registro
        /// </summary>
        /// <param name="objeto"></param>
        /// <returns></returns>
        [HttpPut()]
        public async Task Put([FromBody] Agendamento objeto)
        {
            await _agendamentoNegocio.Alterar(objeto);
        }

        /// <summary>
        /// Exclui um registro
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete()]
        public void Delete([FromQuery] int id)
        {
            _agendamentoNegocio.Excluir(id);
        }

    }
}
