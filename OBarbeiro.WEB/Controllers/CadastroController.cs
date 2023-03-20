using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using OBarbeiro.Comum.Enums;
using OBarbeiro.Comum.Modelos;
using OBarbeiro.Comum.Servico;
using OBarbeiro.Modelo.Modelos;
using System.Net.Http.Headers;

namespace OBarbeiro.Front.Controllers;
public class CadastroController : Controller
{
    private string mensagem = String.Empty;

    private readonly IOptions<DadosBase> _dadosBase;
    private readonly IOptions<LoginResposta> _loginRespostaModel;
    private readonly HttpClient _httpClient;
    private readonly IApiToken _apiToken;

    public CadastroController(IOptions<DadosBase> dadosBase, IOptions<LoginResposta> loginRespostaModel, IHttpClientFactory httpClient, IApiToken apiToken)
    {
        _dadosBase = dadosBase;
        _loginRespostaModel = loginRespostaModel;
        _apiToken = apiToken;
        _httpClient = httpClient.CreateClient();
        _httpClient.DefaultRequestHeaders.Accept.Clear();
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    //// GET: CadastroController
    //[Authorize(Roles = "admin")]
    //public async Task<IActionResult> Index(string? mensagem = null, bool sucesso = true)
    //{
    //    if (sucesso)
    //        TempData["sucesso"] = mensagem;
    //    else
    //        TempData["erro"] = mensagem;


    //    _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _apiToken.Obter());
    //    HttpResponseMessage response = await _httpClient.GetAsync($"{_dadosBase.Value.API_URL_BASE}Cadastro");

    //    if (response.IsSuccessStatusCode)
    //    {
    //        ViewBag.PerfilsUsuario = await CarregarPerfilUsuario(false);
    //        return View(JsonConvert.DeserializeObject<List<Usuario>>(await response.Content.ReadAsStringAsync()));
    //    }
    //    else
    //        throw new Exception("Não foi possível carregar as informações!");
    //}

    #region CadastroDeUsuario
    // GET: CadastroController/CreateUsuario
    public async Task<IActionResult> CreateUsuario()
    {
        ViewBag.PerfilsUsuario = await CarregarPerfilUsuario(true, (int)PerfilsUsuarioEnum.Usuario);
        return View();
    }

    // POST: CadastroController/CreateUsuario
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateUsuario([FromForm] CadastroClienteViewModel model)
    {
        try
        {
            if (ModelState.IsValid)
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _apiToken.Obter());
                HttpResponseMessage response = await _httpClient.PostAsJsonAsync($"{_dadosBase.Value.API_URL_BASE}Cadastro/Cliente", model);

                if (response.IsSuccessStatusCode)
                    return RedirectToAction("Index", "Home", new { mensagem = "Registro criado!", sucesso = true });
                else
                    throw new Exception($"Não foi possível cadastrar o e-mail {model.Nome}");
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
    #endregion

    #region CadastroDeEmpresa

    // GET: CadastroController/CreateUsuario
    public async Task<IActionResult> CreateEmpresa()
    {
        ViewBag.PerfilsUsuario = await CarregarPerfilUsuario(true, (int)PerfilsUsuarioEnum.Empresa);
        return View();
    }

    // POST: CadastroController/CreateUsuario
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> CreateEmpresa([FromForm] CadastroEmpresaViewModel model)
    {
        try
        {
            if (ModelState.IsValid)
            {
                _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _apiToken.Obter());
                HttpResponseMessage response = await _httpClient.PostAsJsonAsync($"{_dadosBase.Value.API_URL_BASE}Cadastro/Empresa", model);

                if (response.IsSuccessStatusCode)
                    return RedirectToAction("Index", "Home", new { mensagem = "Registro criado!", sucesso = true });
                else
                    throw new Exception($"Não foi possível cadastrar o e-mail {model.Nome}");
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


    #endregion

    #region Metodos
    private async Task<List<SelectListItem>> CarregarPerfilUsuario(bool cadastro, int perfilUsuarioId = 0)
    {
        List<SelectListItem> lista = new();

        _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _apiToken.Obter());
        HttpResponseMessage response = await _httpClient.GetAsync($"{_dadosBase.Value.API_URL_BASE}PerfilUsuario");

        if (response.IsSuccessStatusCode)
        {
            var perfils = JsonConvert.DeserializeObject<List<PerfilUsuario>>(await response.Content.ReadAsStringAsync());

            foreach (var linha in perfils)
            {
                if (cadastro)
                {
                    //if (linha.Perfil.ToLower() != "admin")
                    //{

                    if (linha.PerfilUsuarioId == perfilUsuarioId)
                    {
                        lista.Add(new SelectListItem()
                        {
                            Value = linha.PerfilUsuarioId.ToString(),
                            Text = $"{linha.Perfil}",
                            Selected = false,
                        });
                    }
                    //}
                }
                else
                {
                    lista.Add(new SelectListItem()
                    {
                        Value = linha.PerfilUsuarioId.ToString(),
                        Text = $"{linha.Perfil}",
                        Selected = false,
                    });
                }

            }

            return lista;
        }
        else
        {
            throw new Exception(response.ReasonPhrase);
        }
    }
    #endregion
}
