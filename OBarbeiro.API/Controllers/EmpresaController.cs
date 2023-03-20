using Microsoft.AspNetCore.Mvc;
using OBarbeiro.Modelo.Modelos;
using OBarbeiro.Negocio.Empresa;

namespace OBarbeiro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class EmpresaController : ControllerBase
    {
        private readonly IEmpresaNegocio _empresaNegocio;
        public EmpresaController(IEmpresaNegocio empresaNegocio)
        {
            _empresaNegocio = empresaNegocio;
        }

        /// <summary>
        ///  Obtém a lista de empresas
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        public async Task<List<Empresa>> GetAll()
        {
            return await _empresaNegocio.ObterTodos();
        }

        /// <summary>
        /// Obter registro por identificador da tabela
        /// </summary>
        /// <param name="email"></param>
        /// <returns></returns>
        [HttpGet("Obter")]
        public async Task<Empresa> Get([FromQuery] string email)
        {
            return await _empresaNegocio.Obter(email);
        }

        /// <summary>
        /// Incluir um registro
        /// </summary>
        /// <param name="objeto"></param>
        [HttpPost()]
        public async Task Post([FromBody] Empresa objeto)
        {
            await _empresaNegocio.Incluir(objeto);
        }

        /// <summary>
        /// Alterar registro
        /// </summary>
        /// <param name="objeto"></param>
        /// <returns></returns>
        [HttpPut()]
        public async Task Put([FromBody] Empresa objeto)
        {
            await _empresaNegocio.Alterar(objeto);
        }

        /// <summary>
        /// Exclui um registro
        /// </summary>
        /// <param name="email"></param>
        [HttpDelete()]
        public void Delete([FromQuery] string email)
        {
            _empresaNegocio.Excluir(email);
        }
    }
}
