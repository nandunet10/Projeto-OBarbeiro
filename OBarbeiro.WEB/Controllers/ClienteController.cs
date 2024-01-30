using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using OBarbeiro.Comum.Modelos;
using OBarbeiro.Comum.Servico;
using OBarbeiro.Modelo.Modelos;
using System.Net.Http.Headers;

namespace OBarbeiro.Front.Controllers;

[Authorize]
public class ClienteController : Controller
{
    private string mensagem = String.Empty;

    private readonly IOptions<DadosBase> _dadosBase;
    private readonly IOptions<LoginResposta> _loginRespostaModel;
    private readonly HttpClient _httpClient;
    private readonly IApiToken _apiToken;

    public ClienteController(IOptions<DadosBase> dadosBase, IOptions<LoginResposta> loginRespostaModel, IHttpClientFactory httpClient, IApiToken apiToken)
    {
        _dadosBase = dadosBase;
        _loginRespostaModel = loginRespostaModel;
        _apiToken = apiToken;
        _httpClient = httpClient.CreateClient();
        _httpClient.DefaultRequestHeaders.Accept.Clear();
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }
    public async Task<IActionResult> Index(string? mensagem = null, bool sucesso = true)
    {
        if (sucesso)
            TempData["sucesso"] = mensagem;
        else
            TempData["erro"] = mensagem;

        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _apiToken.Obter());
        HttpResponseMessage response = await _httpClient.GetAsync($"{_dadosBase.Value.API_URL_BASE}Cliente");

        if (response.IsSuccessStatusCode)
            return View(JsonConvert.DeserializeObject<List<Cliente>>(await response.Content.ReadAsStringAsync()));
        else
            throw new Exception("Não foi possível carregar as informações!");
    }

    // GET: ClienteController/Create
    public IActionResult Create()
    {
        return View();
    }

    // POST: ClienteController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Create([FromForm] Cliente model)
    {
        try
        {
            //if (model != null)
            //{
            //    model.DataInclusao = DateTime.Now;
            //    model.Ativo = true;
            //}

            if (ModelState.IsValid)
            {
                model.DataInclusao = DateTime.Now;
                model.Ativo = true;

                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _apiToken.Obter());
                HttpResponseMessage response = await _httpClient.PostAsJsonAsync($"{_dadosBase.Value.API_URL_BASE}Cliente", model);

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

    // GET: ClienteController/Edit/5
    public async Task<IActionResult> Edit(string Cpf)
    {
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _apiToken.Obter());
        HttpResponseMessage response = _httpClient.GetAsync($"{_dadosBase.Value.API_URL_BASE}Cliente/Obter?Cpf={Cpf}").Result;

        if (response.IsSuccessStatusCode)
            return View(JsonConvert.DeserializeObject<Cliente>(await response.Content.ReadAsStringAsync()));
        else
            throw new Exception("Não foi possível carregar as informações!");

    }

    // POST: ClienteController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit([FromForm] Cliente model)
    {
        try
        {
            if (ModelState.IsValid)
            {
                if (model != null)
                    model.DataAlteracao = DateTime.Now;

                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _apiToken.Obter());
                HttpResponseMessage response = await _httpClient.PutAsJsonAsync($"{_dadosBase.Value.API_URL_BASE}Cliente", model);

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


    // GET: ClienteController/Details/5
    public async Task<IActionResult> Details(string email)
    {
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _apiToken.Obter());
        HttpResponseMessage response = _httpClient.GetAsync($"{_dadosBase.Value.API_URL_BASE}Cliente/Obter?Email={email}").Result;

        if (response.IsSuccessStatusCode)
            return View(JsonConvert.DeserializeObject<Cliente>(await response.Content.ReadAsStringAsync()));
        else
            throw new Exception("Algo não deu certo.");

    }


    // GET: ClienteController/Delete/5
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> Delete(string email)
    {
        try
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _apiToken.Obter());
            HttpResponseMessage response = _httpClient.DeleteAsync($"{_dadosBase.Value.API_URL_BASE}Cliente?Email={email}").Result;

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

    // POST: ClienteController/Delete/5
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
