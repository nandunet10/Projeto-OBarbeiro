using Microsoft.AspNetCore.Mvc;

namespace OBarbeiro.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BuscaCepController : ControllerBase
    {

        [HttpGet("BuscarCEP")]
        public async Task<string> BuscaCep([FromQuery] string cep)
        {
            HttpClient client = new();
            HttpResponseMessage resposta = await client.GetAsync($"https://viacep.com.br/ws/{cep}/json/");
            resposta.EnsureSuccessStatusCode();

            return await resposta.Content.ReadAsStringAsync();
        }
    }
}
