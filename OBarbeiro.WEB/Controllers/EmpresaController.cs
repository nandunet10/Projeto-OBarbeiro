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
public class EmpresaController : Controller
{
    private string mensagem = String.Empty;

    private readonly IOptions<DadosBase> _dadosBase;
    private readonly IOptions<LoginResposta> _loginRespostaModel;
    private readonly HttpClient _httpClient;
    private readonly IApiToken _apiToken;

    public EmpresaController(IOptions<DadosBase> dadosBase, IOptions<LoginResposta> loginRespostaModel, IHttpClientFactory httpClient, IApiToken apiToken)
    {
        _dadosBase = dadosBase;
        _loginRespostaModel = loginRespostaModel;
        _apiToken = apiToken;
        _httpClient = httpClient.CreateClient();
        _httpClient.DefaultRequestHeaders.Accept.Clear();
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    // GET: EmpresaController
    public async Task<IActionResult> Index(string? mensagem = null, bool sucesso = true)
    {
        if (sucesso)
            TempData["sucesso"] = mensagem;
        else
            TempData["erro"] = mensagem;

        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _apiToken.Obter());
        HttpResponseMessage response = await _httpClient.GetAsync($"{_dadosBase.Value.API_URL_BASE}Empresa");

        if (response.IsSuccessStatusCode)
            return View(JsonConvert.DeserializeObject<List<Empresa>>(await response.Content.ReadAsStringAsync()));
        else
            throw new Exception("Não foi possível carregar as informações!");
    }

    // GET: EmpresaController/Details/5
    public async Task<IActionResult> Details(string email)
    {
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _apiToken.Obter());
        HttpResponseMessage response = _httpClient.GetAsync($"{_dadosBase.Value.API_URL_BASE}Empresa/Obter?Email={email}").Result;

        if (response.IsSuccessStatusCode)
            return View(JsonConvert.DeserializeObject<Empresa>(await response.Content.ReadAsStringAsync()));
        else
            throw new Exception("Algo não deu certo.");
    }


    // GET: EmpresaController/Edit/5
    public async Task<IActionResult> Edit(string Cnpj)
    {
        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _apiToken.Obter());
        HttpResponseMessage response = _httpClient.GetAsync($"{_dadosBase.Value.API_URL_BASE}Empresa/Obter?Cnpj={Cnpj}").Result;

        if (response.IsSuccessStatusCode)
            return View(JsonConvert.DeserializeObject<Empresa>(await response.Content.ReadAsStringAsync()));
        else
            throw new Exception("Não foi possível carregar as informações!");

    }

    // POST: EmpresaController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> Edit([FromForm] Empresa model)
    {
        try
        {
            if (model != null)
                model.DataAlteracao = DateTime.Now;

            if (ModelState.IsValid)
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _apiToken.Obter());
                HttpResponseMessage response = await _httpClient.PutAsJsonAsync($"{_dadosBase.Value.API_URL_BASE}Empresa", model);

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

    // GET: EmpresaController/Delete/5
    [Authorize(Roles = "admin")]
    public async Task<IActionResult> Delete(string email)
    {
        try
        {
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _apiToken.Obter());
            HttpResponseMessage response = _httpClient.DeleteAsync($"{_dadosBase.Value.API_URL_BASE}Empresa?Email={email}").Result;

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

    // POST: EmpresaController/Delete/5
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
