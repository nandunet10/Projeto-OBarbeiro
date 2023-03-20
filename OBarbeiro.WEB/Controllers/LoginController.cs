using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using Newtonsoft.Json;
using OBarbeiro.Comum.Modelos;
using OBarbeiro.Comum.Servico;
using OBarbeiro.Modelo.Modelos;
using System.Net;
using System.Net.Http.Headers;
using System.Security.Claims;

namespace OBarbeiro.Front.Controllers;
public class LoginController : Controller
{
    private readonly IOptions<DadosBase> _dadosBase;
    private readonly IOptions<LoginResposta> _loginRespostaModel;
    private readonly HttpClient _httpClient;
    private readonly IApiToken _apiToken;

    public LoginController(IOptions<DadosBase> dadosBase, IOptions<LoginResposta> loginRespostaModel, IHttpClientFactory httpClient, IApiToken apiToken)
    {
        _dadosBase = dadosBase;
        _loginRespostaModel = loginRespostaModel;
        _apiToken = apiToken;
        _httpClient = httpClient.CreateClient();
        _httpClient.DefaultRequestHeaders.Accept.Clear();
        _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
    }

    public IActionResult Index()
    {
        return View();
    }

    public async Task<JsonResult> Entrar(string usuario, string senha)
    {
        try
        {
            //Obtendo o usuário se cadastrado.
            _httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", await _apiToken.Obter());
            HttpResponseMessage response = _httpClient.GetAsync($"{_dadosBase.Value.API_URL_BASE}Usuario/Obter?Email={usuario}").Result;

            var usuarioCadastrado = new Usuario();
            if (response.StatusCode == HttpStatusCode.OK)
                usuarioCadastrado = JsonConvert.DeserializeObject<Usuario>(await response.Content.ReadAsStringAsync());
            else
                throw new Exception("Usuário não encontrador! por favor informe o e-mail correto.");

            //Obtendo o perfil
            response = await _httpClient.GetAsync($"{_dadosBase.Value.API_URL_BASE}PerfilUsuario/Obter?id={usuarioCadastrado.PerfilUsuarioId}");

            var perfil = new PerfilUsuario();
            if (response.IsSuccessStatusCode)
                perfil = JsonConvert.DeserializeObject<PerfilUsuario>(await response.Content.ReadAsStringAsync());
            else
                throw new Exception("Problemas ao tentar acessar o perfil!");


            if (usuario == usuarioCadastrado.Email && senha == usuarioCadastrado.Senha)
            {
                var identity = new ClaimsIdentity(new[]
                {
                        new Claim(ClaimTypes.NameIdentifier, usuario),
                        new Claim(ClaimTypes.Role, perfil.Perfil.ToLower() == "admin" ? "admin" : perfil.Perfil.ToLower()),
                    }, CookieAuthenticationDefaults.AuthenticationScheme);

                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return Json("OK");
            }
            else
            {
                TempData["erroLogin"] = "Usuário ou Senha inválido!";
                return Json("Usuário ou Senha inválido!");
            }


        }
        catch (Exception ex)
        {
            TempData["erroLogin"] = ex.Message;
            return Json(ex.Message);
        }
    }

}

