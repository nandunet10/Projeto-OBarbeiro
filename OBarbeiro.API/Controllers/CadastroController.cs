using Microsoft.AspNetCore.Mvc;
using OBarbeiro.Comum.Modelos;
using OBarbeiro.Negocio.Cadastro;

namespace OBarbeiro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CadastroController : ControllerBase
    {
        private readonly ICadastroNegocio _cadastroNegocio;
        public CadastroController(ICadastroNegocio cadastroNegocio)
        {
            _cadastroNegocio = cadastroNegocio;
        }

        /// <summary>
        /// Incluir um registro
        /// </summary>
        /// <param name="objeto"></param>
        [HttpPost("Cliente")]
        public async Task CadastrarCliente([FromBody] CadastroClienteViewModel objeto)
        {
            await _cadastroNegocio.IncluirCliente(objeto);
        }

        /// <summary>
        /// Incluir um registro
        /// </summary>
        /// <param name="objeto"></param>
        [HttpPost("Empresa")]
        public async Task CadastrarEmpresa([FromBody] CadastroEmpresaViewModel objeto)
        {
            await _cadastroNegocio.IncluirEmpresa(objeto);
        }
    }
}
