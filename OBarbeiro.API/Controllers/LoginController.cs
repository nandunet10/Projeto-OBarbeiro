using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using OBarbeiro.Comum.Modelos;
using OBarbeiro.Negocio;

namespace OBarbeiro.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        [HttpPost]
        [AllowAnonymous]
        public async Task<ActionResult<LoginResposta>> Login([FromBody] LoginRequisicao loginRequisicaoModel)
        {
            return Ok(await new LoginServico().Login(loginRequisicaoModel));
        }
    }
}
