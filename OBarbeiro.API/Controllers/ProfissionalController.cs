using Microsoft.AspNetCore.Mvc;
using OBarbeiro.Modelo.Modelos;
using OBarbeiro.Negocio.Profissional;

namespace OBarbeiro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ProfissionalController : ControllerBase
    {
        private readonly IProfissionalNegocio _profissionalNegocio;
        public ProfissionalController(IProfissionalNegocio profissionalNegocio)
        {
            _profissionalNegocio = profissionalNegocio;
        }

        /// <summary>
        ///  Obtém a lista de Profissional
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        public async Task<List<Profissional>> GetAll()
        {
            return await _profissionalNegocio.ObterTodos();
        }


        /// <summary>
        /// Obter registro por identificador da tabela
        /// </summary>
        /// <param name="cpf"></param>
        /// <returns></returns>
        [HttpGet("Obter")]
        public async Task<Profissional> Get([FromQuery] string cpf)
        {
            return await _profissionalNegocio.Obter(cpf);
        }

        /// <summary>
        /// Incluir registro
        /// </summary>
        /// <param name="objeto"></param>
        /// <returns></returns>
        [HttpPost()]
        public async Task Post([FromBody] Profissional objeto)
        {
            await _profissionalNegocio.Incluir(objeto);
        }

        /// <summary>
        /// Alterar registro
        /// </summary>
        /// <param name="objeto"></param>
        /// <returns></returns>
        [HttpPut()]
        public async Task Put([FromBody] Profissional objeto)
        {
            await _profissionalNegocio.Alterar(objeto);
        }

        /// <summary>
        /// Exclui um registro
        /// </summary>
        /// <param name="cpf"></param>
        [HttpDelete()]
        public void Delete([FromQuery] string cpf)
        {
            _profissionalNegocio.Excluir(cpf);
        }
    }
}
