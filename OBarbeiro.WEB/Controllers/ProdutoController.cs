using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using OBarbeiro.Comum.Modelos;
using OBarbeiro.Comum.Servico;
using OBarbeiro.Modelo.Modelos;
using System.Net.Http.Headers;
using System.Reflection;

namespace OBarbeiro.Front.Controllers;

//[Authorize]
public class ProdutoController : Controller
{
    private string mensagem = String.Empty;

    private readonly IOptions<DadosBase> _dadosBase;
    private readonly IOptions<LoginResposta> _loginRespostaModel;
    private readonly HttpClient _httpClient;
    private readonly IApiToken _apiToken;

    public ProdutoController(IOptions<DadosBase> dadosBase, IOptions<LoginResposta> loginRespostaModel, IHttpClientFactory httpClient, IApiToken apiToken)
    {
        _dadosBase = dadosBase;
        _loginRespostaModel = loginRespostaModel;
        _apiToken = apiToken;
        _httpClient = httpClient.CreateClient();
        _httpClient.DefaultRequestHeaders.Accept.Clear();
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    // GET: ProdutoController
    public async Task<IActionResult> Index(string? mensagem = null, bool sucesso = true)
    {
        if (sucesso)
            TempData["sucesso"] = mensagem;
        else
            TempData["erro"] = mensagem;

        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _apiToken.Obter());
        HttpResponseMessage response = await _httpClient.GetAsync($"{_dadosBase.Value.API_URL_BASE}Produto");

        if (response.IsSuccessStatusCode)
            return View(JsonConvert.DeserializeObject<List<Produto>>(await response.Content.ReadAsStringAsync()));
        else
            throw new Exception("Não foi possível carregar as informações!");
    }

    // GET: ProdutoController/Details/5
    public async Task<IActionResult> Details(int id)
    {
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _apiToken.Obter());
        HttpResponseMessage response = _httpClient.GetAsync($"{_dadosBase.Value.API_URL_BASE}Produto/Obter?Id={id}").Result;

        if (response.IsSuccessStatusCode)
            return View(JsonConvert.DeserializeObject<Produto>(await response.Content.ReadAsStringAsync()));
        else
            throw new Exception("Algo não deu certo.");
    }

    // GET: ProdutoController/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: ProdutoController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([FromForm] Produto model)
    {
        try
        {
            if (ModelState.IsValid)
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _apiToken.Obter());
                HttpResponseMessage response = await _httpClient.PostAsJsonAsync($"{_dadosBase.Value.API_URL_BASE}Produto", model);

                if (response.IsSuccessStatusCode)
                    return RedirectToAction(nameof(Index), new { mensagem = "Registro criado!", sucesso = true });
                else
                    throw new Exception("Não foi possível carregar as informações!");
            }
            else
            {
                TempData["erro"] = "Algum campo deve estar faltando o seu preenchimento!";
                return View();
            }
        }
        catch (Exception ex)
        {
            TempData["erro"] = "Algum erro aconteceu " + ex.Message;
            return View();
        }
    }

    // GET: ProdutoController/Edit/5
    public async Task<IActionResult> Edit(int id)
    {
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _apiToken.Obter());
        HttpResponseMessage response = _httpClient.GetAsync($"{_dadosBase.Value.API_URL_BASE}Produto/Obter?Id={id}").Result;

        if (response.IsSuccessStatusCode)
            return View(JsonConvert.DeserializeObject<Produto>(await response.Content.ReadAsStringAsync()));
        else
            throw new Exception("Não foi possível carregar as informações!");

    }

    // POST: ProdutoController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit([FromForm] Produto model)
    {
        try
        {
            if (ModelState.IsValid)
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _apiToken.Obter());
                HttpResponseMessage response = await _httpClient.PutAsJsonAsync($"{_dadosBase.Value.API_URL_BASE}Produto", model);

                if (response.IsSuccessStatusCode)
                    return RedirectToAction(nameof(Index), new { mensagem = "Registro editado!", sucesso = true });
                else
                    throw new Exception("Não foi possível carregar as informações!");
            }
            else
            {
                TempData["erro"] = "Algum campo deve estar faltando o seu preenchimento!";
                return View();
            }
        }
        catch (Exception ex)
        {
            TempData["erro"] = "Algum erro aconteceu " + ex.Message;

            return View();
        }
    }

    // GET: ProdutoController/Delete/5
    public async Task<IActionResult> Delete(int id)
    {
        try
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _apiToken.Obter());
            HttpResponseMessage response = _httpClient.DeleteAsync($"{_dadosBase.Value.API_URL_BASE}Produto?Id={id}").Result;

            if (response.IsSuccessStatusCode)
                return RedirectToAction(nameof(Index), new { mensagem = "Registro deletado!", sucesso = true });
            else
                throw new Exception("Não foi possível carregar as informações!");

        }
        catch (Exception ex)
        {
            TempData["erro"] = $"Não foi possivel excluir " + ex.Message;

            return View();
        }
    }

    // POST: ProdutoController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, IFormCollection collection)
    {
        try
        {
            return RedirectToAction(nameof(Index));
        }
        catch
        {
            return View();
        }
    }
}
