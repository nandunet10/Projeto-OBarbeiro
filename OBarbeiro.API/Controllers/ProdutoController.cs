using Microsoft.AspNetCore.Mvc;
using OBarbeiro.Modelo.Modelos;
using OBarbeiro.Negocio.Produto;

namespace OBarbeiro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoNegocio _produtoNegocio;
        public ProdutoController(IProdutoNegocio produtoNegocio)
        {
            _produtoNegocio = produtoNegocio;
        }

        /// <summary>
        ///  Obtém a lista de produtos
        /// </summary>
        /// <returns></returns>
        [HttpGet()]
        public async Task<List<Produto>> GetAll()
        {
            return await _produtoNegocio.ObterTodos();
        }

        /// <summary>
        /// Obter registro por identificador da tabela
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("Obter")]
        public async Task<Produto> Get([FromQuery] int id)
        {
            return await _produtoNegocio.Obter(id);
        }

        /// <summary>
        /// Incluir registro(s)
        /// </summary>
        /// <param name="objeto"></param>
        /// <returns></returns>
        [HttpPost()]
        public async Task Post([FromBody] Produto objeto)
        {
            await _produtoNegocio.Incluir(objeto);
        }

        /// <summary>
        /// Alterar registro
        /// </summary>
        /// <param name="objeto"></param>
        /// <returns></returns>
        [HttpPut()]
        public async Task Put([FromBody] Produto objeto)
        {
            await _produtoNegocio.Alterar(objeto);
        }

        /// <summary>
        /// Exclui um registro
        /// </summary>
        /// <param name="id"></param>
        [HttpDelete()]
        public void Delete([FromQuery] int id)
        {
            _produtoNegocio.Excluir(id);
        }
    }
}
