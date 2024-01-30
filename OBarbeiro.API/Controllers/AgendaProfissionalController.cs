using Microsoft.AspNetCore.Mvc;
using OBarbeiro.Modelo.Modelos;
using OBarbeiro.Negocio.AgendaProfissional;

namespace OBarbeiro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class AgendaProfissionalController : ControllerBase
    {
        private readonly IAgendaProfissionalNegocio _agendaProfissionalNegocio;
        public AgendaProfissionalController(IAgendaProfissionalNegocio agendaProfissionalNegocio)
        {
            _agendaProfissionalNegocio = agendaProfissionalNegocio;
        }

        /// <summary>
        /// Obter todas as agendas
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        public async Task<List<AgendaProfissional>> ObterTodos()
        {
            return await _agendaProfissionalNegocio.ObterTodos();
        }

        /// <summary>
        /// Obter toda a agenda por cpf
        /// </summary>
        /// <param name="cpf"></param>
        /// <returns></returns>
        [HttpGet("{cpf}")]
        public async Task<List<AgendaProfissional>> ObterAgendaPorId([FromRoute] string cpf)
        {
            return await _agendaProfissionalNegocio.ObterTodosPorParametro(o => o.ProfissionalCpf.Equals(cpf));
        }

        /// <summary>
        /// Incluir um registro
        /// </summary>
        /// <param name="objeto"></param>
        [HttpPost()]
        public async Task IncluirAgenda([FromBody] AgendaProfissional objeto)
        {
            await _agendaProfissionalNegocio.Incluir(objeto);
        }

        /// <summary>
        /// Alterar registro
        /// </summary>
        /// <param name="objeto"></param>
        /// <returns></returns>
        [HttpPut("{objeto}")]
        public async Task AlterarAgenda([FromBody] AgendaProfissional objeto)
        {
            await _agendaProfissionalNegocio.Alterar(objeto);
        }

        /// <summary>
        /// Exclui um registro
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete("{id:int}")]
        public void DeletarAgenda([FromQuery] int id)
        {
            _agendaProfissionalNegocio.Excluir(id);
        }
    }
}
