using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using OBarbeiro.Comum.Modelos;
using OBarbeiro.Comum.Servico;
using System.Net.Http.Headers;

namespace OBarbeiro.Web.Controllers
{
    public class PesquisaController : Controller
    {
        private readonly IOptions<DadosBase> _dadosBase;
        private readonly HttpClient _httpClient;
        private readonly IApiToken _apiToken;

        public PesquisaController(IOptions<DadosBase> dadosBase, HttpClient httpClient, IApiToken apiToken)
        {
            _dadosBase = dadosBase;
            _httpClient = httpClient;
            _apiToken = apiToken;
        }

        // GET: PesquisaController
        public async Task<IActionResult> Index([FromForm] PesquisarEmpresasViewModel pesquisar)
        {
            try
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _apiToken.Obter());
                HttpResponseMessage response = await _httpClient.PostAsJsonAsync($"{_dadosBase.Value.API_URL_BASE}Pesquisa", pesquisar);

                if (response.IsSuccessStatusCode)
                    return View(JsonConvert.DeserializeObject<List<PesquisaViewModel>>(await response.Content.ReadAsStringAsync()));
                else
                    throw new Exception("Não foi possível carregar as informações!");
            }
            catch (Exception ex)
            {
                TempData["erro"] = "Algum erro aconteceu " + ex.Message;
                throw new Exception(ex.Message);
            }
        }

    }
}
